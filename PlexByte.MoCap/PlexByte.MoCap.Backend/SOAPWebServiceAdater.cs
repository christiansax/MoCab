using System;
using System.Net;
using System.Xml;
using PlexByte.MoCap.Interactions;

/*
https://msdn.microsoft.com/en-us/library/hh534080.aspx
https://msdn.microsoft.com/en-us/library/fa420a9y(v=vs.110).aspx
https://msdn.microsoft.com/en-us/library/d5wt2he6(v=vs.110).aspx
http://mocapws.plexbyte.com/ws_interactions.asmx?op=GetSurvey
*/

namespace PlexByte.MoCap.Backend
{
    public class SOAPWebServiceAdater:IWebServiceAdapter
    {
        private string _baseURL = string.Empty;

        #region Ctor & Dtor

        public SOAPWebServiceAdater(string pBaseURL)
        {
            if (!string.IsNullOrEmpty(pBaseURL))
                _baseURL = pBaseURL;
            else
                throw new ArgumentException("The argument pBaseURL was an empty string, which is not allowed. Specify the url to use excluding method name");
        }

        #endregion

        #region Implementation of IWebServiceAdapter

        public XmlSerializer Serialize<IInteraction, XmlSerializer>(ref IInteraction pObjectToSerialize) { throw new System.NotImplementedException(); }

        public IInteraction Deserialize<XmlDocument, IInteraction>(ref XmlDocument pObjectToDeserialize) { throw new System.NotImplementedException(); }

        public void SendResponse<XmlDocument>(ref XmlDocument pResponseObject) { throw new System.NotImplementedException(); }

        public void SendRequest<XmlSerializer>(string pServiceName, string pServiceMethod, ref XmlSerializer pRequestObject)
        {
            try
            {
                string requestURL = _baseURL + "/" + pServiceName + "?op=" + pServiceMethod;
                HttpWebRequest request = WebRequest.Create(requestURL) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                if (response != null)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(response.GetResponseStream());
                    IInteraction repsonseObject = Deserialize<XmlDocument, IInteraction>(ref xmlDoc);
                }

            }
            catch (Exception exp)
            {
                throw new Exception($"Exception while calling SendRequest. Exception: {exp.Message}");
            }
        }

        #endregion
    }
}
