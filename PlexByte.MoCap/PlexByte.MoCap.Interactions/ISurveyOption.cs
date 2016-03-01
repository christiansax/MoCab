//////////////////////////////////////////////////////////////
//                      Interface ISurveyOption                              
//      Author: Christian B. Sax            Date:   2016/02/13
//      Implemented in class survey option
using System;

namespace PlexByte.MoCap.Interactions
{
    /// <summary>
    /// The survey option interface
    /// </summary>
    public interface ISurveyOption
    {
        string Text { get; }

        DateTime CreatedDateTime { get; }

        string Id { get; }
    }
}