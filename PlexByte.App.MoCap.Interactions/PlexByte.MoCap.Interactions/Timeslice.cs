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
    public int Duration
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public IUser User
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public string Id
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public DateTime StartDateTime
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public DateTime EndDateTime
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public DateTime CreatedDateTime
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public DateTime ModifiedDateTime
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public bool IsActive
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public string Text
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public InteractionType Type
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public IUser Creator
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public IUser Owner
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public InteractionState State
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public event Complete Completed;
    public event Modify Modified;
    public event StateChange StateChanged;

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

    public void OnStateChanged(InteractionEventArgs pEventArgs)
    {
        throw new NotImplementedException();
    }

    public void ChangeState(InteractionState pState)
    {
        throw new NotImplementedException();
    }
}
