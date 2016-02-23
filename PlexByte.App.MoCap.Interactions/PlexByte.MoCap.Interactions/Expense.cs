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
    /// A List of all receipts that are attached to a task, project or survey
    /// </summary>
    public List<Image> ReceiptList { get { return _receiptList; } }
    /// <summary>
    /// A list of all expenes that are attached to a task, project or survey
    /// </summary>
    public List<decimal> ExpenditureList { get { return _expenditureList; } }
    /// <summary>
    /// The total expenses that are attached to a task, project or survey
    /// </summary>
    public decimal Expenditure { get { return _expenditure; } }

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
    private List<Image>  _receiptList;
    private List<decimal>  _expenditureList;
    private decimal _expenditure;

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
        List<Image> pImageList = new List<Image>();
        List<decimal> pValueList = new List<decimal>();
        InitializeProperties(pId, pText, pImageList, pValueList, pCreator);
    }

    /// <summary>
    /// Constructor of the class
    /// </summary>
    /// <param name="pId"></param>
    /// <param name="pText"></param>
    /// <param name="pImageList"></param>
    /// <param name="pCreator"></param>
    public Expense(string pId, string pText, List<Image> pImageList, List<decimal> pValueList, IUser pCreator)
    {
        InitializeProperties(pId, pText, pImageList, pValueList, pCreator);
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
    /// Adds a "Receipt" to the receiptlist, and a value is added to the valuelist
    /// the method "ExpenseValueCalculation" is executed at the end
    /// </summary>
    /// <param name="pImage"></param>
    public virtual void AddReceipt(Image pImage, decimal pValue)
    {
        ExpenditureList.Add(pValue);
        List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
        changedAttributes.Add(InteractionAttributes.ValueList);
        if (pImage != null)
        {
            ReceiptList.Add(pImage);
            changedAttributes.Add(InteractionAttributes.ImageList);
        }
        OnModify(new InteractionEventArgs($"Survey IsActive changed [Id={Id}]", DateTime.Now, InteractionType.Expense));
        ExpenseValueCalculation();
    }

    /// <summary>
    /// To edit the receipt, the old one is removed and a new is being created, the same goes for value 
    /// the method "ExpenseValueCalculation" is executed at the end
    /// </summary>
    /// <param name="pImage"></param>
    /// <param name="pNewImage"></param>
    public virtual void EditReceipt(Image pImage, Image pNewImage, decimal pValue, decimal pNewValue)
    {
        if (ReceiptList.Contains(pImage))
        {
            if (pImage != pNewImage && pValue != pNewValue)
            {
                List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
                if (pImage != pNewImage)
                {
                    ReceiptList.Remove(pImage);
                    ReceiptList.Add(pNewImage);
                    changedAttributes.Add(InteractionAttributes.ImageList);
                }
                if (pValue != pNewValue)
                {
                    ExpenditureList.Remove(pValue);
                    ExpenditureList.Add(pNewValue);
                    changedAttributes.Add(InteractionAttributes.ValueList);
                    ExpenseValueCalculation();
                }
                OnModify(new InteractionEventArgs($"Survey user list changed [Id={Id}]", DateTime.Now, InteractionType.Expense));
            }
        }
    }

    /// <summary>
    /// Deletes a "Receipt" object if it exists in the receiptlist, and a value is removed from the valuelist
    /// the method "ExpenseValueCalculation" is executed at the end
    /// </summary>
    /// <param name="pImage"></param>
	public virtual void DeleteReceipt(Image pImage, decimal pValue)
    {
        if (ReceiptList.Contains(pImage))
        {
            ReceiptList.Remove(pImage);
            ExpenditureList.Remove(pValue);
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.ImageList);
            changedAttributes.Add(InteractionAttributes.ValueList);
            OnModify(new InteractionEventArgs($"Survey user list changed [Id={Id}]", DateTime.Now, InteractionType.Expense));
            ExpenseValueCalculation();
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
    private void InitializeProperties(string pId, string pText, List<Image> pImageList, List<decimal> pValueList, IUser pCreator)
    {
        _id = pId;
        _creator = pCreator;
        Text = pText;
        _receiptList = pImageList;
        _expenditureList = pValueList;
        _createdDateTime = DateTime.Now;
        _modifiedDateTime = DateTime.Now;
        StartDateTime = DateTime.Now;
        EndDateTime = default(DateTime);
        _isActive = true;
        _state = StartDateTime <= DateTime.Now ? InteractionState.Active : InteractionState.Queued;
        _stateTimer.Elapsed += OnTimerElapsed;
        _stateTimer.AutoReset = false;
        _stateTimer.Start();
        ExpenseValueCalculation();
    }

    /// <summary>
    /// It calculates the value of the entire valuelist
    /// </summary>
    private void ExpenseValueCalculation()
    {
        foreach(decimal value in ExpenditureList)
        {
            _expenditure =+ value;
        }
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

