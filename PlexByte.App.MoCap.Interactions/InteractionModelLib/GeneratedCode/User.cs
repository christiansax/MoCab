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

public class User : IUser
{
	public User(string pUserName, string pPassword)
	{
	}

	public virtual void LogOn(string pUser, string pPassword)
	{
		throw new System.NotImplementedException();
	}

	public virtual void LogOff(string pUser)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Register()
	{
		throw new System.NotImplementedException();
	}

	public virtual void Decline()
	{
		throw new System.NotImplementedException();
	}

	public virtual void AddInteraction(IInteraction pInteraction)
	{
		throw new System.NotImplementedException();
	}

	public virtual void RemoveInteraction(IInteraction pInteraction)
	{
		throw new System.NotImplementedException();
	}

	public virtual void SetLogonState(LogonState pState)
	{
		throw new System.NotImplementedException();
	}

	public virtual void OnLogOn(object pSender, EventArgs e)
	{
		throw new System.NotImplementedException();
	}

	public virtual void OnLogOff(object pSender, EventArgs e)
	{
		throw new System.NotImplementedException();
	}

	public virtual void OnStateChanged(object psender, EventArgs e)
	{
		throw new System.NotImplementedException();
	}

}

