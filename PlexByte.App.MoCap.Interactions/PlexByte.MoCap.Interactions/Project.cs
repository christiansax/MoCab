//////////////////////////////////////////////////////////////
//                      Class Project                              
//      Author: Fabian Ochsner            Date:   2016/02/19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Project : IProject, IInteraction
{
    #region Properties
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
    public bool EnableBalance { get; set; }
    public bool EnableSurvey { get; set; }
    public List<IUser> MemberList { get; set; }
    public List<IUser> InvitationList { get; set; }
    public List<Task> TaskList { get; set; }
    public List<Survey> SurveyList { get; set; }

    #endregion

    #region Variables
    
    private IUser _creator;
    private DateTime _modifiedDateTime;
    private DateTime _createdDateTime;
    private System.Timers.Timer _stateTimer = new System.Timers.Timer(60 * 1000);
    private bool _isActive;
    private string _id;

    #endregion

    #region Events

    public event Complete Completed;
    public event Modify Modified;
    public event StateChange StateChanged;

    #endregion

    #region Ctor & Dtor
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pId"></param>
    /// <param name="pText"></param>
    /// <param name="pCreator"></param>
    public Project(string pId, string pText, IUser pCreator)
    {
        List<IUser> pMemberList = new List<IUser>();
        List<IUser> pInvitationList = new List<IUser>();
        EnableSurvey = true;
        EnableBalance = true;

        InitializeProperties(pId, pText, EnableBalance, EnableSurvey, pMemberList, pInvitationList, pCreator);

    }


    public Project(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, IUser pCreator, List<IUser> pMemberList, List<IUser> pInvitationList)
    {
        InitializeProperties(pId, pText, pEnableBalance, pEnableSurvey, pMemberList, pInvitationList, pCreator);

    }
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

	public virtual void AddTask(ITask pTask)
	{
		throw new System.NotImplementedException();
	}

	public virtual void AddSurvey(ISurvey pPoll)
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

	public virtual void Leave()
	{
		throw new System.NotImplementedException();
	}

	public virtual void KickUser(IUser pUser)
	{
		throw new System.NotImplementedException();
	}
    
	public virtual void ChangeState(InteractionState pState)
	{
		throw new System.NotImplementedException();
	}
    #endregion

    #region Private methods
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pId"></param>
    /// <param name="pText"></param>
    /// <param name="pMemberList"></param>
    /// <param name="pInvitationList"></param>
    /// <param name="pCreator"></param>
    private void InitializeProperties(string pId, string pText, bool pEnableBalance, bool pEnableSurvey, List<IUser> pMemberList, List<IUser> pInvitationList, IUser pCreator)
    {
        _id = pId;
        EnableBalance = pEnableBalance;
        EnableSurvey = pEnableSurvey;
        _creator = pCreator;
        Text = pText;
        MemberList = pMemberList;
        InvitationList = pInvitationList;
        _createdDateTime = DateTime.Now;
        _modifiedDateTime = DateTime.Now;
        StartDateTime = DateTime.Now;
        EndDateTime = default(DateTime);
        _isActive = true;
        Type = InteractionType.Project;

    }
    #endregion
}

