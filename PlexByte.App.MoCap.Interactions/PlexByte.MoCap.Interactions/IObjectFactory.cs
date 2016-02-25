//////////////////////////////////////////////////////////////
//                      Interface IObjectFactory                              
//      Author: Christian B. Sax            Date:   2016/02/24
//              Fabian Ochsner
//      Defines methods to construct object contained in the interaction package
//      but do not inherit from IInteraction
using System;

public interface IObjectFactory 
{
	IVote CreateVote(string pId, IUser pUser, ISurveyOption pOption);

    ITimeslice CreateTimeslice(string pId, IUser pUser, DateTime pStartDT, DateTime pEndDT, IInteraction pTarget);

    ITimeslice CreateTimeslice(string pId, IUser pUser, int pDuration, IInteraction pTarget);

    ISurveyOption CreateSurveyOption(string pId, string pText);

    IExpense CreateExpense(string pId, string pText, System.Drawing.Image pReceipt, decimal pValue, IUser pUser, IInteraction pTarget);

    IExpense CreateExpense(string pId, string pText, IUser pUser, IInteraction pTarget);

}

