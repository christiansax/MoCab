//////////////////////////////////////////////////////////////
//                      Class ObjectFactory                              
//      Author: Christian B. Sax            Date:   2016/02/24
//              Fabian Ochsner
//      Implements IObjectFactory, creating various objects that do not
//      inherit from the IInteraction interface
using System;

public class ObjectFactory : IObjectFactory
{
	public virtual IVote CreateVote(string pId, IUser pUser, ISurveyOption pOption)
	{
	    if (string.IsNullOrEmpty(pId))
	        pId = Helper.GenerateId();
	    return (new Vote(pId, pUser, pOption));
	}

	public virtual ITimeslice CreateTimeslice(string pId, IUser pUser, DateTime pStartDT, DateTime pEndDT, IInteraction pTarget)
    {
        if (string.IsNullOrEmpty(pId))
            pId = Helper.GenerateId();
        return (new Timeslice(pId, pUser, pStartDT, pEndDT, pTarget));
    }

	public virtual ITimeslice CreateTimeslice(string pId, IUser pUser, int pDuration, IInteraction pTarget)
    {
        if (string.IsNullOrEmpty(pId))
            pId = Helper.GenerateId();
        return (new Timeslice(pId, pUser, pDuration, pTarget));
    }

	public virtual ISurveyOption CreateSurveyOption(string pId, string pText)
	{
        if (string.IsNullOrEmpty(pId))
            pId = Helper.GenerateId();
        return (new SurveyOption(pId, pText));
    }

	public virtual IExpense CreateExpense(string pId, string pText, System.Drawing.Image pReceipt, decimal pValue, IUser pUser, IInteraction pTarget)
    {
        if (string.IsNullOrEmpty(pId))
            pId = Helper.GenerateId();
        return (new Expense(pId, pText, pReceipt, pValue, pUser, pTarget));
    }

	public virtual IExpense CreateExpense(string pId, string pText, IUser pUser, IInteraction pTarget)
    {
        if (string.IsNullOrEmpty(pId))
            pId = Helper.GenerateId();
        return (new Expense(pId, pText, pUser, pTarget));
    }

}

