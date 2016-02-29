namespace PlexByte.MoCap.Backend
{
    public interface IWebServiceAdapter
    {
        T2 Serialize<T, T2>(ref T pObjectToSerialize);
        T2 Deserialize<T, T2>(ref T pObjectToDeserialize);
        void SendResponse<T>(ref T pResponseObject);
        void SendRequest<T>(string pServiceName, string pServiceMethod, ref T pRequestObject);
    }
}
