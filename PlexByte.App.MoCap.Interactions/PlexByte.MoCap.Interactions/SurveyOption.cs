//////////////////////////////////////////////////////////////
//                      Class SurveyOption                              
//      Author: Christian B. Sax            Date:   2016/02/13
using System;

/// <summary>
/// The survey option class, which hold the option text
/// </summary>
public class SurveyOption : ISurveyOption
{
	public SurveyOption(string pId, string pText)
	{
        CreatedDateTime=DateTime.Now;
	    Id = pId;
	    Text = pText;
	}

    public DateTime CreatedDateTime { get; }

    public string Id { get; }

    public string Text { get; }
}