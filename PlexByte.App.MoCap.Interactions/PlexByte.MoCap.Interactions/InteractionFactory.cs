﻿//////////////////////////////////////////////////////////////
//                      Class Interaction Factory                              
//      Author: Christian B. Sax            Date:   2016/02/24
//      Implementation of IInteractionFactory creating any object 
//      that inherits of IInteraction
using System;
using System.Collections.Generic;

public class InteractionFactory : IInteractionFactory
{
	public virtual IInteraction CreateTask(string pId, string pText, IUser pCreator)
	{
	    if (string.IsNullOrEmpty(pId))
	        pId = Helper.GenerateId();
        return new Task(pId, pText, pCreator);
	}

	public virtual IInteraction CreateTask(string pId, string pText, IUser pCreator, DateTime pStartDT, DateTime pEndDT, DateTime pDueDT)
	{
        if (string.IsNullOrEmpty(pId))
            pId = Helper.GenerateId();
        return (new Task(pId, pText, pCreator, pStartDT, pEndDT, pDueDT));
    }

    public IInteraction CreateTask(string pId, string pText, IUser pCreator, DateTime pStartDT, DateTime pEndDT, DateTime pDueDT, 
        decimal pBudget, int pDuration, int pPriority, InteractionState pState, decimal pBudgetUsed, int pTimeUsed, 
        List<ITask> pSubTask, int pProgress)
    {
        if (string.IsNullOrEmpty(pId))
            pId = Helper.GenerateId();
        return (new Task(pId, pText, pCreator, pStartDT, pEndDT, pDueDT, pBudget, pDuration, pPriority, 
            pState, pBudgetUsed, pTimeUsed, pSubTask, pProgress));
    }

    public virtual IInteraction CreateSurvey(string pId, string pText, List<ISurveyOption> pOptions, IUser pCreator)
	{
        if (string.IsNullOrEmpty(pId))
            pId = Helper.GenerateId();
        return (new Survey(pId, pText, pOptions, pCreator));
	}

	public virtual IInteraction CreateSurvey(string pId, string pText, List<string> pOptions, IUser pCreator)
	{
        if (string.IsNullOrEmpty(pId))
            pId = Helper.GenerateId();
        return (new Survey(pId, pText, pOptions, pCreator));
    }

	public virtual IInteraction CreateAccount(string pId, object pCreator, object IUser)
	{
		throw new System.NotImplementedException();
	}

	public virtual IInteraction CreateProject(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, IUser pCreator)
	{
		throw new System.NotImplementedException();
	}

	public virtual IInteraction CreateProject(string pId, string pText, IUser pCreatur, IUser pOwner, List<string> MemberList, List<string> InvitationList, bool pEnableBalance, bool pEnableSurvey, List<ITask> TaskList, List<ISurvey> SurveyList)
	{
		throw new System.NotImplementedException();
	}

	public virtual IInteraction CreateChat(string pTextTitle, IUser pCreator, List<IUser> pUsers)
	{
		throw new System.NotImplementedException();
	}

	public virtual IInteraction CreateChat(string pTextTitle, IUser pCreator, List<IUser> pUsers, DateTime pStartDateTime, DateTime pEndDateTime, bool pAllowSelfdestructing)
	{
		throw new System.NotImplementedException();
	}
}

