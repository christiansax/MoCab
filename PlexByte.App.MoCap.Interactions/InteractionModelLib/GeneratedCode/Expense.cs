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

public class Expense : IExpense, IInteraction
{
	public virtual void AddReceipt(System.Drawing.Image pImage)
	{
		throw new System.NotImplementedException();
	}

	public virtual void OnComplete(InteractionEventArgs pEventArgs)
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

	public Expense()
	{
	}

	public virtual void DeleteReceipt(System.Drawing.Image pImage)
	{
		throw new System.NotImplementedException();
	}

	public virtual void EditReceipt(System.Drawing.Image pImage)
	{
		throw new System.NotImplementedException();
	}

	public virtual void OnModify(InteractionEventArgs pEventArgs)
	{
		throw new System.NotImplementedException();
	}

	public virtual void ChangeState(InteractionState pState)
	{
		throw new System.NotImplementedException();
	}

	public virtual void OnStateChanged(InteractionEventArgs pEventArgs)
	{
		throw new System.NotImplementedException();
	}

}

