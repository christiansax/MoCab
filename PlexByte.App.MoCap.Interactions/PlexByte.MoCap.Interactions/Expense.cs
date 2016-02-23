//////////////////////////////////////////////////////////////
//                      Class Expense                              
//      Author: Fabian Ochsner            Date:   2016/02/22
//      Implementation of IExpense interface, representing the expense of a Task or Project
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


public class Expense : IExpense, IInteraction
{

    #region Properties

    /// <summary>
    /// The unique id of the task
    /// </summary>
    public string Id { get { return _id; } }
    /// <summary>
    /// The date and time this task becomes active and can be worked on. As long as this date is not reached the 
    /// state will remain queued and no work can be performed on the task as longs as it is in state queued
    /// </summary>
    public DateTime StartDateTime { get; set; }
    /// <summary>
    /// The date and time this task should be finished. If this date is reached the state will change to expired
    /// </summary>
    public DateTime EndDateTime { get; set; }
    /// <summary>
    /// The date and time the task was created
    /// </summary>
    public DateTime CreatedDateTime { get { return _createdDateTime; } }
    /// <summary>
    /// The date and time the task was last modified
    /// </summary>
    public DateTime ModifiedDateTime { get { return _modifiedDateTime; } }
    /// <summary>
    /// Flag indicating whether or not the task can be worked on
    /// </summary>
    public bool IsActive { get { return _isActive; } }
    /// <summary>
    /// The text of this task (description)
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// The type of interaction (will be always task)
    /// </summary>
    public InteractionType Type { get; }
    /// <summary>
    /// The user that created the task
    /// </summary>
    public IUser Creator { get { return _creator; } }
    /// <summary>
    /// The user currently owning the task
    /// </summary>
    public IUser Owner { get { return _owner; } }
    /// <summary>
    /// The state of the task
    /// </summary>
    public InteractionState State { get { return _state; } }
    /// <summary>
    /// The target to which a expense is connected
    /// </summary>
    public IInteraction Target { get; set; }
    /// <summary>
    /// The image of a receipts that is attached to a task, project or survey
    /// </summary>
    public Image Receipt { get { return _receipt; } }
    /// <summary>
    /// The value of the expenses that is attached to a task, project or survey
    /// </summary>
    public decimal Value { get { return _value; } }

    #endregion

    #region Variables

    private IUser _owner;
    private IUser _creator;
    private DateTime _modifiedDateTime;
    private DateTime _createdDateTime;
    private System.Timers.Timer _stateTimer = new System.Timers.Timer(60 * 1000);
    private InteractionState _state;
    private bool _isActive;
    private string _id;
    private Image  _receipt;
    private decimal _value;

    #endregion

    #region Events

    public event Complete Completed;
    public event Modify Modified;
    public event StateChange StateChanged;

    #endregion

    #region Ctor & Dtor

    /// <summary>
    /// Constructor of the class
    /// </summary>
    /// <param name="pId"></param>
    /// <param name="pText"></param>
    /// <param name="pCreator"></param>
    public Expense(string pId, string pText, IUser pCreator)
    {
        Image pReceipt= null;
        decimal pValue= 0;

        InitializeProperties(pId, pText, pReceipt, pValue, pCreator);
    }

    /// <summary>
    /// Constructor of the class
    /// </summary>
    /// <param name="pId"></param>
    /// <param name="pText"></param>
    /// <param name="pImageList"></param>
    /// <param name="pCreator"></param>
    public Expense(string pId, string pText, Image pReceipt, decimal pValue, IUser pCreator)
    {
        InitializeProperties(pId, pText, pReceipt, pValue, pCreator);
    }

    #endregion

    #region Event raising methods

    /// <summary>
    /// This method raises the corresponding event in case subscribers are registered
    /// </summary>
    /// <param name="pEventArgs"></param>
    public virtual void OnComplete(InteractionEventArgs pEventArgs)
    {
        Completed?.Invoke(this, pEventArgs);
    }

    /// <summary>
    /// This method raises the corresponding event in case subscribers are registered
    /// </summary>
    /// <param name="pEventArgs"></param>
    public virtual void OnModify(InteractionEventArgs pEventArgs)
    {
        Modified?.Invoke(this, pEventArgs);
    }

    /// <summary>
    /// This method raises the corresponding event in case subscribers are registered
    /// </summary>
    /// <param name="pEventArgs"></param>
    public virtual void OnStateChanged(InteractionEventArgs pEventArgs)
    {
        StateChanged?.Invoke(this, pEventArgs);
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Method to add a Receipt to an expense
    /// </summary>
    /// <param name="pImage"></param>
    public void AddReceipt(Image pReceipt)
    {
        _receipt = pReceipt;
    }

    /// <summary>
    /// Method to remove a Receipt from an expense
    /// </summary>
    /// <param name="pImage"></param>
    public void DeleteReceipt()
    {
        _receipt = null;
    }

    /// <summary>
    /// Method to edit the value of an expense
    /// </summary>
    /// <param name="pNewValue"></param>
    public void EditValue(decimal pNewValue)
    {
        _value = pNewValue;
    }


    /// <summary>
    /// This method changes the owner of the expense and raises the modified event if the owner is different
    /// used to create a secound project-admin
    /// </summary>
    /// <param name="pUser"></param>
	public virtual void ChangeOwner(IUser pUser)
    {
        if (_owner != pUser)
        {
            _owner = pUser;
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.Owner);
            OnModify(new InteractionEventArgs($"Survey owner changed [Id={Id}]", DateTime.Now, InteractionType.Expense));
        }
    }

    /// <summary>
    /// This method changes the active flag of the object. This can occure if the item expired, finished or was 
    /// cancelled. It will raise the Modified event once changed
    /// </summary>
    /// <param name="pActive"></param>
	public virtual void ChangeIsActive(bool pActive)
    {
        if (_isActive != pActive)
        {
            _isActive = pActive;
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.IsActive);
            OnModify(new InteractionEventArgs($"Survey IsActive changed [Id={Id}]", DateTime.Now, InteractionType.Expense));
        }
    }

    /// <summary>
    /// Changes the state of this interaction and thus causes the stateCHanged event to be fired
    /// </summary>
    /// <param name="pState"></param>
	public virtual void ChangeState(InteractionState pState)
    {
        this._state = pState;
        if (_state == InteractionState.Finished ||
            _state == InteractionState.Cancelled ||
            _state == InteractionState.Expired)
            ChangeIsActive(false);
        List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
        changedAttributes.Add(InteractionAttributes.State);
        OnStateChanged(new InteractionEventArgs($"Survey state changed [Id={Id}]", DateTime.Now, InteractionType.Expense));
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Initializes all attributes and started the state timer, which validates the interaction's state every 60
    /// </summary>
    /// <param name="pId"></param>
    /// <param name="pText"></param>
    /// <param name="pImageList"></param>
    /// <param name="pCreator"></param>
    private void InitializeProperties(string pId, string pText, Image pImage, decimal pValue, IUser pCreator)
    {
        _id = pId;
        _creator = pCreator;
        Text = pText;
        _receipt = pImage;
        _value = pValue;
        _createdDateTime = DateTime.Now;
        _modifiedDateTime = DateTime.Now;
        StartDateTime = DateTime.Now;
        EndDateTime = default(DateTime);
        _isActive = true;
        _state = StartDateTime <= DateTime.Now ? InteractionState.Active : InteractionState.Queued;
        _stateTimer.Elapsed += OnTimerElapsed;
        _stateTimer.AutoReset = false;
        _stateTimer.Start();
    }

    /// <summary>
    /// This method validates the object state and chages if required. Once the interaction is either 
    /// cancelled, finished or expired the state check will suspend
    /// </summary>
    /// <param name="sender">The object calling this method (timer)</param>
    /// <param name="e">The event parameters passed</param>
    private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (_state == InteractionState.Active || _state == InteractionState.Queued)
        {
            // Behind schedule?
            if (EndDateTime <= DateTime.Now)
                ChangeState(InteractionState.Expired);
            // Turns active?
            if (StartDateTime <= DateTime.Now && _state == InteractionState.Queued)
                ChangeState(InteractionState.Active);
            // Finished if project is closed?
            if (IsActive == false)
                ChangeState(InteractionState.Finished);
        }

        // Still active?
        if (_state == InteractionState.Active || _state == InteractionState.Queued)
            _stateTimer.Start();
    }

    #endregion
}

