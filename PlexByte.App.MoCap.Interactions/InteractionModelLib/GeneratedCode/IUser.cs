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

public interface IUser  : IPerson
{
	string UserName { get; }

	string Password { get; }

	DateTime CreatedDate { get; }

	DateTime ModifiedDate { get; }

	List<IInteraction> InteractionList { get; }

	LogonState LogonState { get; }

	void LogOn(string pUser, string pPassword);

	void LogOff(string pUser);

	void AddInteraction(IInteraction pInteraction);

	void RemoveInteraction(IInteraction pInteraction);

	void SetLogonState(LogonState pState);

	void OnLogOn(object pSender, EventArgs e);

	void OnLogOff(object pSender, EventArgs e);

	void OnStateChanged(object psender, EventArgs e);

}

