﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Task : IInteraction, ITask
{
	public virtual void OnComplete(IInteraction pInteraction, InteractionEventArgs e)
	{
		throw new System.NotImplementedException();
	}

	public virtual void ChangeOwner(IUser pUser)
	{
		throw new System.NotImplementedException();
	}

	public virtual void ChangeIsActive(bool pActive)
	{
		throw new System.NotImplementedException();
	}

	public virtual void AddTimeslice(ITimeslice pTimeslice)
	{
		throw new System.NotImplementedException();
	}

	public virtual void AddExpense(IExpense pExpense)
	{
		throw new System.NotImplementedException();
	}

	public Task(string pId, string pText, IUser pCreator)
	{
	}

	public Task(string pId, string pText, IUser pCreator, DateTime pStartDT, DateTime pEndDT, DateTime pDueDT)
	{
	}

	public Task(string pId, string pText, IUser pCreator, DateTime pStartDT, DateTime pEndDT, DateTime pDueDT, decimal pBudget, int pDuration, int pPriority)
	{
	}

}
