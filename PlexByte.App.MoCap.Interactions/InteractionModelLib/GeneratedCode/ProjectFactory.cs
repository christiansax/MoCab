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

public class ProjectFactory : IProjectFactory
{
	public virtual void AddSurvey(ISurvey pPoll)
	{
		throw new System.NotImplementedException();
	}

	public virtual void AddTask(ITask pTask)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Create(string pId, string pText, IUser pCreator)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Create(string pId, string pText, IUser pCreatur, bool MemberList, bool InvitationList, List<IUser> pMemberList, List<IUser> pInvitationList)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Invite(IUser pUser)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Accept(IUser pUser)
	{
		throw new System.NotImplementedException();
	}

}

