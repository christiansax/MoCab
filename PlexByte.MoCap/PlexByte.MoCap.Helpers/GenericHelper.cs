//////////////////////////////////////////////////////////////
//                      Class GenericHelper                              
//      Author: Christian B. Sax            Date:   2016/02/23
//      Implements helper methods to simplify coding
using System;
using System.Collections.Generic;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.Helpers
{
    public class GenericHelper
    {
        public static string GenerateId()
        {
            return DateTime.Now.ToString("yyyyMMDDHHmmssfff");
        }

        public static int DiffSeconds(DateTime pStartDateTime, DateTime pEndDateTime)
        {
            TimeSpan diff = pEndDateTime - pStartDateTime;
            return Convert.ToInt32(diff.TotalSeconds);
        }

        public static int DiffMinutes(DateTime pStartDateTime, DateTime pEndDateTime)
        {
            TimeSpan diff = pEndDateTime - pStartDateTime;
            return Convert.ToInt32(diff.TotalMinutes);
        }

        public static int DiffHours(DateTime pStartDateTime, DateTime pEndDateTime)
        {
            TimeSpan diff = pEndDateTime - pStartDateTime;
            return Convert.ToInt32(diff.TotalHours);
        }

        public static int DiffDays(DateTime pStartDateTime, DateTime pEndDateTime)
        {
            TimeSpan diff = pEndDateTime - pStartDateTime;
            return Convert.ToInt32(diff.TotalDays);
        }

        //TODO: Implement CalculateAvailableMinutes
        public static int CalculateAvailableMinutes(IUser pUser)
        {
            throw new System.NotImplementedException();
        }

        //TODO: Implement GetTasksByUser
        public static List<ITask> GetTasksByUser(IUser pUser)
        {
            throw new System.NotImplementedException();
        }

        //TODO: Implement GetPendingSurveysByUser
        public static List<ISurvey> GetPendingSurveysByUser(IUser pUser)
        {
            throw new System.NotImplementedException();
        }

        //TODO: Implement GetProjectsByUser
        public static List<IProject> GetProjectsByUser(IUser pUser)
        {
            throw new System.NotImplementedException();
        }
    }
}
