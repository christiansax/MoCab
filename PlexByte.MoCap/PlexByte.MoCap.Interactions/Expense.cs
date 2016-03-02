//////////////////////////////////////////////////////////////
//                      Class Expense                              
//      Author: Fabian Ochsner            Date:   2016/02/22
//      Implementation of IExpense interface, representing the expense of a Task or Project
using System;
using System.Collections.Generic;
using System.Drawing;
using PlexByte.MoCap.Security;


namespace PlexByte.MoCap.Interactions
{
    public class Expense : IExpense
    {

        #region Properties

        /// <summary>
        /// The unique id of the expense
        /// </summary>
        public string Id { get; private set; }
        /// <summary>
        /// The date and time the expense was created
        /// </summary>
        public DateTime CreatedDateTime { get; private set; }
        /// <summary>
        /// The date and time the expense was last modified
        /// </summary>
        public DateTime ModifiedDateTime { get; private set; }
        /// <summary>
        /// Flag indicating whether or not the expense can be worked on
        /// </summary>
        public bool IsActive { get; private set; }
        /// <summary>
        /// The text of this expense (description)
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// The type of interaction (will be always expense)
        /// </summary>
        public InteractionType Type { get; }
        /// <summary>
        /// The state of the expense
        /// </summary>
        public InteractionState State { get; private set; }
        /// <summary>
        /// The target to which a expense is connected
        /// </summary>
        public IInteraction Target { get; private set; }
        /// <summary>
        /// The image of a receipts from the expense
        /// </summary>
        public Image Receipt { get; private set; }
        /// <summary>
        /// The value of the expenses
        /// </summary>
        public decimal Value { get; private set; }
        /// <summary>
        /// The user that created the task
        /// </summary>
        public IUser Creator { get; private set; }
        /// <summary>
        /// The user the expenses belongs to
        /// </summary>
        public IUser User { get; private set; }

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
        public Expense(string pId, string pText, IUser pCreator, IInteraction pTarget)
        {
            Image pReceipt = null;
            decimal pValue = 0;

            InitializeProperties(pId, pText, pReceipt, pValue, pCreator, pTarget);
        }

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pText"></param>
        /// <param name="pImageList"></param>
        /// <param name="pCreator"></param>
        public Expense(string pId, string pText, Image pReceipt, decimal pValue, IUser pCreator, IInteraction pTarget)
        {
            InitializeProperties(pId, pText, pReceipt, pValue, pCreator, pTarget);
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
            if (Receipt == null)
            {
                Receipt = pReceipt;
                List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
                changedAttributes.Add(InteractionAttributes.Receipt);
                OnModify(new InteractionEventArgs($"Receipt added [Id={Id}]", DateTime.Now, InteractionType.Expense));
            }
        }

        /// <summary>
        /// Method to remove a Receipt from an expense
        /// </summary>
        /// <param name="pImage"></param>
        public void DeleteReceipt()
        {
            if (Receipt != null)
            {
                Receipt = null;
                List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
                changedAttributes.Add(InteractionAttributes.Receipt);
                OnModify(new InteractionEventArgs($"Receipt deleted [Id={Id}]", DateTime.Now, InteractionType.Expense));
            }
        }

        /// <summary>
        /// Method to edit the value of an expense
        /// </summary>
        /// <param name="pNewValue"></param>
        public void EditValue(decimal pNewValue)
        {
            Value = pNewValue;
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.Value);
            OnModify(new InteractionEventArgs($"Value edited [Id={Id}]", DateTime.Now, InteractionType.Expense));
        }

        /// <summary>
        /// This method changes the active flag of the object. This can occure if the item expired, finished or was 
        /// cancelled. It will raise the Modified event once changed
        /// </summary>
        /// <param name="pActive"></param>
        public virtual void ChangeIsActive(bool pActive)
        {
            if (IsActive != pActive)
            {
                IsActive = pActive;
                List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
                changedAttributes.Add(InteractionAttributes.IsActive);
                OnModify(new InteractionEventArgs($"Expense IsActive changed [Id={Id}]", DateTime.Now, InteractionType.Expense));
            }
        }

        /// <summary>
        /// Changes the state of this interaction and thus causes the stateCHanged event to be fired
        /// </summary>
        /// <param name="pState"></param>
        public virtual void ChangeState(InteractionState pState)
        {
            this.State = pState;
            if (State == InteractionState.Finished ||
                State == InteractionState.Cancelled)
                ChangeIsActive(false);
            List<InteractionAttributes> changedAttributes = new List<InteractionAttributes>();
            changedAttributes.Add(InteractionAttributes.State);
            OnStateChanged(new InteractionEventArgs($"Expense state changed [Id={Id}]", DateTime.Now, InteractionType.Expense));
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Initializes all attributes
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pText"></param>
        /// <param name="pImage"></param>
        /// <param name="pValue"></param>
        /// <param name="pCreator"></param>
        /// <param name="pTarget"></param>
        private void InitializeProperties(string pId, string pText, Image pImage, decimal pValue, IUser pCreator, IInteraction pTarget)
        {
            Id = pId;
            User = pCreator;
            Creator = pCreator;
            Text = pText;
            Receipt = pImage;
            Value = pValue;
            Target = pTarget;
            CreatedDateTime = DateTime.Now;
            ModifiedDateTime = DateTime.Now;
            IsActive = true;
        }

        #endregion
    }

}