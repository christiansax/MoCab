//////////////////////////////////////////////////////////////
//                      Class Account                              
//      Author: Fabian Ochsner            Date:   2016/02/19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Account : IAccount, IInteraction
{
    #region Properties
    public IEnumerable<ITimeslice> TimesliceList { get; set; }
    public IEnumerable<IExpense> ExpenseList { get; set; }
    public IEnumerable<ITask> TaskList { get; set; }
    public string Id { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime ModifiedDateTime { get; set; }
    public bool IsActive { get; set; }
    public string Text { get; set; }
    public InteractionType Type { get; set; }
    public IUser Creator { get; set; }
    public IUser Owner { get; set; }
    public InteractionState State { get; set; }
    #endregion

    #region Variables


    #endregion

    #region Events
    public event Complete Completed;
    public event Modify Modified;
    public event StateChange StateChanged;
    #endregion

    #region Ctor & Dtor

    #endregion

    #region Event raising methods
    public virtual void OnComplete(InteractionEventArgs pEventArgs)
	{
		throw new System.NotImplementedException();
	}
    public virtual void OnModify(InteractionEventArgs pEventArgs)
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnStateChanged(InteractionEventArgs pEventArgs)
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region Public methods
    public virtual void ChangeOwner(IUser pUser)
	{
		throw new System.NotImplementedException();
	}

	public virtual void ChangeIsActive(bool pActive)
	{
		throw new System.NotImplementedException();
	}

	public virtual void ProjectView(IProject pProject)
	{
		throw new System.NotImplementedException();
	}

	public virtual void UserView(IProject pProject, IUser pUser)
	{
		throw new System.NotImplementedException();
	}

	public virtual void ChangeState(InteractionState pState)
	{
		throw new System.NotImplementedException();
	}
    #endregion

    #region Private methods

    #endregion
}

