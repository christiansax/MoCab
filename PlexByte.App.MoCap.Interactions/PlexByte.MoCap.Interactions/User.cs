//////////////////////////////////////////////////////////////
//                      Class User                              
//      Author: Christian B. Sax            Date:   2016/02/24
//      Class implementing IUser and IPerson which is inherited from the IUser
using System;
using System.Collections.Generic;

public class User : IUser
{
    public delegate void LogingOn(object sender, EventArgs e);
    public delegate void LogingOff(object sender, EventArgs e);
    public delegate void StateChange(object sender, EventArgs e);

    public string UserName => _userName;
    public string Password => _password;
    public DateTime CreatedDate => _createdDateTime;
    public DateTime ModifiedDate => _modifiedDateTime;
    public List<IInteraction> InteractionList => _interactionList;
    public LogonState LogonState => _logonState;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string EmailAddress { get; set; }
    public DateTime Birthdate { get; set; }

    private string _userName;
    private string _password;
    private DateTime _createdDateTime;
    private DateTime _modifiedDateTime;
    private List<IInteraction> _interactionList;
    private LogonState _logonState;

    public event LogingOn LoggedOn;
    public event LogingOff LoggedOff;
    public event StateChange StateChanged;


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

    public void AddInteraction(IInteraction pInteraction)
    {
        throw new NotImplementedException();
    }

    public void RemoveInteraction(IInteraction pInteraction)
    {
        throw new NotImplementedException();
    }

    public void SetLogonState(LogonState pState)
    {
        throw new NotImplementedException();
    }
}

