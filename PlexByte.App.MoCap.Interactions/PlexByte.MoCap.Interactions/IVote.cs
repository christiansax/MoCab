//////////////////////////////////////////////////////////////
//                      Interface IVote                              
//      Author: Christian B. Sax            Date:   2016/02/13
//      Implemented in class vote
using System;

/// <summary>
/// The vote interface
/// </summary>
public interface IVote 
{
	IUser User { get; }

	ISurveyOption Option { get; }

	DateTime CreatedDateTime { get; }

	string Id { get; }
}