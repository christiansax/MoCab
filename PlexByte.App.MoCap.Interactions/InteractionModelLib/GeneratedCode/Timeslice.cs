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

public class Timeslice : ITimeslice, IInteraction
{
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

	public Timeslice(string pId, IUser pUser, int pDuration)
	{
	}

	public Timeslice(string pId, IUser pUser, DateTime pStartDT, DateTime pEndDT)
	{
	}

	public virtual int CalculateDuration(DateTime pStartDT, DateTime pEndDT)
	{
		throw new System.NotImplementedException();
	}

	public virtual void OnModify(InteractionEventArgs pEventArgs)
	{
		throw new System.NotImplementedException();
	}

}

