//////////////////////////////////////////////////////////////
//                      Interface ISurvey                              
//      Author: Christian B. Sax            Date:   2016/02/13
//      Implemented in class Survey
using System;
using System.Collections.Generic;

public interface ISurvey 
{
    DateTime DueDateTime { get; set; }
    List<ISurveyOption> OptionList { get;set; }

	List<IVote> VoteList { get; }

	void AddVote(IVote pVote);

	void AddOption(ISurveyOption pOption);

}

