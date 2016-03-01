using PlexByte.MoCap.Helpers;

namespace MoCap.PlexByte.MoCap.Backend
{
    public class InteractionService
    {
        private static string _DBServer = "198.38.83.33";
        private static string _Password = "MoCap";
        private static string _DBUser = CryptoHelper.Decrypt("BjjfgaK9bvsBcQCzh2cA7D0OQnwJ1lrU/36zDXs5bKfbK/mCnQChL74+/wtOu1+6", _Password);
        private static string _DBPWD = CryptoHelper.Decrypt("mFntrazoOtZJqDO+T8vCdtnm6aUjkfvf0Lh8kATxrZQkfNE0NiPDC7zXkb2h22MM", _Password);
        private string _connectionString = string.Format("Server={0}; Database=csax2277_MoCap_Prod;User Id={1};Password={2};", _DBServer, _DBUser, _DBPWD);

        //public List<ITask> GetTasksByUser(string pUserId, List<Interaction> ) 
    }
}
