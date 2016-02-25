//////////////////////////////////////////////////////////////
//                      Interface IUser                              
//      Author: Christian B. Sax            Date:   2016/02/24
//      Interface specifying the attributes and events for user base interaction
//      This interface also inherits from the IPerson interface wich is kind of a prospect
using System;
using System.Collections.Generic;

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

}

