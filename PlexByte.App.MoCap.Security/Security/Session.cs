using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MoCap.Security
{
    #region Enumerations

    public enum Protocol
    {
        TCP,
        UDP
    };

    #endregion

    #region Delegates

    public delegate void ConnectionEstablishedEventHandler(object sender, SessionEventArgs e);
    public delegate void ConnectionClosedEventHandler(object sender, SessionEventArgs e);
    public delegate void ReceiveDataEventHandler(object sender, SessionEventArgs e);
    public delegate void SendDataEventHandler(object sender, SessionEventArgs e);

    #endregion

    public class Session : IDisposable
    {
        #region Properties

        public string HostName { get; set; }
        public List<IPEndPoint> HostEndpoint { get; set; }
        public IPAddress LocalExternalIP { get; set; }
        public int Port { get; set; }
        public int ReceiveTimeout { get; set; } = 5000;
        public int SendTimeout { get; set; } = 5000;
        public Protocol Protocol { get; set; }
        public TcpClient ConnectionTCP { get; set; }
        public UdpClient ConnectionUDP { get; set; }

        #endregion

        #region Variables

        private Thread listener = null;

        #endregion

        #region Events

        public event ConnectionEstablishedEventHandler ConnectionEstablished;
        public event ConnectionClosedEventHandler ConnectionClosed;
        public event ReceiveDataEventHandler ReceivedData;
        public event SendDataEventHandler SentData;

        #endregion

        #region Ctor & Dtor

        public Session(string pHostName, int pPort) : this(pHostName, null, "", pPort, Protocol.TCP)
        {
        }

        public Session(string pHostName, string[] pIPAddresses, string pLocalExternalIP,
            int pPort, Protocol pProtocol)
        {
            HostName = pHostName;
            Port = pPort;
            HostEndpoint = null;

            IPAddress ipAddress = null;
            foreach (string s in pIPAddresses)
            {
                ipAddress = null;
                IPAddress.TryParse(s, out ipAddress);
                if (HostEndpoint == null) { HostEndpoint = new List<IPEndPoint>(); }
                if (ipAddress != null)
                    HostEndpoint.Add(new IPEndPoint(ipAddress, pPort));
            }
            if (HostEndpoint == null)
            {
                foreach (IPAddress ip in GetIPAddressesFromName(pHostName))
                {
                    if (HostEndpoint == null) { HostEndpoint = new List<IPEndPoint>(); }
                    HostEndpoint.Add(new IPEndPoint(ip, pPort));
                }
            }
            // Still no endpoint?
            if (HostEndpoint == null)
                throw new ArgumentException("The endpoint could not be set");

            LocalExternalIP = null;
            ipAddress = null;
            IPAddress.TryParse(pLocalExternalIP, out ipAddress);
            if (ipAddress != null)
                LocalExternalIP = ipAddress;
            else
            {
                IPAddress.TryParse(new System.Net.WebClient().DownloadString("https://api.ipify.org"), out ipAddress);
                if (ipAddress != null) { LocalExternalIP = ipAddress; }
            }

            Protocol = pProtocol;

            if (Protocol == Protocol.TCP)
            {
                ConnectionTCP = new TcpClient(HostEndpoint[0]);
                ConnectionUDP = null;
            }
            else
            {
                ConnectionTCP = null;
                ConnectionUDP = new UdpClient(HostEndpoint[0]);
            }

            ipAddress = null;

            // Create listener thread
            listener = new Thread(ConnectionListener);
            listener.Name = "Listener";
            listener.Start();
        }

        public void Dispose()
        {
            Disconnect();
            if (Protocol == Protocol.TCP)
            {
                if (ConnectionTCP != null)
                    ConnectionTCP = null;
            }
            else
            {
                if (ConnectionUDP != null)
                    ConnectionUDP = null;
            }
            HostEndpoint.Clear();
            HostEndpoint = null;
            LocalExternalIP = null;
        }

        #endregion

        #region Methods

        public void Connect()
        {
            IPAddress[] ips = new IPAddress[HostEndpoint.Count];
            for (int i = 0; i < HostEndpoint.Count; i++)
                ips[i] = HostEndpoint[i].Address;

            if (Protocol == Protocol.TCP)
                ConnectionTCP.Connect(ips, HostEndpoint.First().Port);
            else
                ConnectionUDP.Connect(HostEndpoint.First());
            ConnectionTCP.ReceiveTimeout = ConnectionUDP.Client.ReceiveTimeout = ReceiveTimeout;
            ConnectionTCP.SendTimeout = ConnectionUDP.Client.SendTimeout = SendTimeout;

            OnConnectionEstablished(new SessionEventArgs(String.Format("Connection established [IP={0}] [Host={1}]", 
                HostEndpoint.First().Address.ToString(), HostName)));
        }

        public void Disconnect()
        {
            try
            {
                if (Protocol == Protocol.TCP)
                {
                    if (ConnectionTCP.Connected)
                    {
                        ConnectionTCP.Close();
                        OnConnectionClosed(new SessionEventArgs(String.Format(@"Connection closed successfully 
                            [Host={0}] [IP={1}]", HostName, HostEndpoint.First().Address.ToString())));
                    }
                }
                else
                {
                    if (ConnectionUDP.Client.Connected)
                        ConnectionUDP.Client.Close();
                }
            }
            catch (Exception exp) { }
        }

        public void SendString(string pData)
        {
            if (Protocol == Protocol.TCP)
            {
                if (!ConnectionTCP.Client.Connected)
                    Connect();
                NetworkStream stream = null;
                stream = ConnectionTCP.GetStream();
                stream.Write(Encoding.UTF8.GetBytes(pData), 0, pData.ToArray().Length);
            }
            else
            {
                if (!ConnectionUDP.Client.Connected)
                    Connect();
                ConnectionUDP.Send(Encoding.UTF8.GetBytes(pData), pData.ToArray().Length);
            }

            OnDataSent(new SessionEventArgs(pData));
        }

        public void SendStream(Stream pData)
        {
            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {
                pData.CopyTo(ms);
                buffer = ms.ToArray();
            }
            if (Protocol == Protocol.TCP)
            {
                if (!ConnectionTCP.Client.Connected)
                    Connect();
                NetworkStream stream = null;
                stream = ConnectionTCP.GetStream();
                stream.Write(buffer, 0, buffer.Length);
            }
            else
            {
                if (!ConnectionUDP.Client.Connected)
                    Connect();
                ConnectionUDP.Send(buffer, buffer.Length);
            }

            OnDataSent(new SessionEventArgs(pData));
        }

        private void ConnectionListener()
        {
            Stream stream = null;
            IPEndPoint host = new IPEndPoint(HostEndpoint.First().Address, HostEndpoint.First().Port);
            while (true)
            {
                stream = null;
                if (Protocol == Protocol.TCP)
                {
                    NetworkStream netStream = ConnectionTCP.GetStream();
                    if (netStream.DataAvailable)
                        netStream.CopyTo(stream);
                }
                else
                    foreach (byte b in ConnectionUDP.Receive(ref host))
                    { stream.WriteByte(b); }
                OnDataReceived(new SessionEventArgs(stream));
            }
        }

        private IPAddress[] GetIPAddressesFromName(string pHostName)
        {
            return (Dns.GetHostAddresses(pHostName));
        }

        #endregion

        #region Event handlers

        protected virtual void OnDataReceived(SessionEventArgs e)
        {
            if (ReceivedData != null)
                ReceivedData(this, e);
        }

        protected virtual void OnDataSent(SessionEventArgs e)
        {
            if (SentData != null)
                SentData(this, e);
        }

        protected virtual void OnConnectionEstablished(SessionEventArgs e)
        {
            if (ConnectionEstablished != null)
                ConnectionEstablished(this, e);
        }

        protected virtual void OnConnectionClosed(SessionEventArgs e)
        {
            if (ConnectionEstablished != null)
                ConnectionEstablished(this, e);
        }

        #endregion
    }
}
