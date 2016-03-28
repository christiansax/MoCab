//////////////////////////////////////////////////////////////
//      Overview form listing all items in the main form, 
//      docked on the left side                              
//      Author: Christian B. Sax            Date:   2016/02/21

using System;
using System.Collections.Generic;
using PlexByte.MoCap.Backend;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.WinForms.Managers;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms.UserControls
{
    public partial class uc_Overview : DockContent
    {
        /// <summary>
        /// The text shown in the tab title
        /// </summary>
        private const string ControlTitle = "Interactions Overview";

        private UIManager _UIManager = null;

        public uc_Overview(UIManager pManager)
        {
            InitializeComponent();
            this.TabText = ControlTitle;
            _UIManager = pManager;
        }

        /// <summary>
        /// This method adds an interaction to the users overview section
        /// </summary>
        /// <param name="pInteraction">The interaction to add</param>
        public void AddRecentlyChangedInteraction(IInteraction pInteraction)
        {
            switch (pInteraction.Type)
            {
                case InteractionType.Project:
                    Project project = (Project) pInteraction;
                    dgw_Recent.Rows.Add(project.Id,
                        project.Type.ToString(),
                        project.Name,
                        project.State.ToString(),
                        project.ModifiedDateTime.ToString("u"));
                    break;
                case InteractionType.Task:
                    Task task = (Task)pInteraction;
                    dgw_Recent.Rows.Add(task.Id,
                        task.Type.ToString(),
                        task.Title,
                        task.State.ToString(),
                        task.ModifiedDateTime.ToString("u"));
                    break;
                case InteractionType.Survey:
                    Survey survey = (Survey) pInteraction;
                    dgw_Recent.Rows.Add(survey.Id,
                        survey.Type.ToString(),
                        survey.Text,
                        survey.State.ToString(),
                        survey.ModifiedDateTime.ToString("u"));
                    break;
                case InteractionType.Expense:
                    Expense expense = (Expense)pInteraction;
                    dgw_Recent.Rows.Add(expense.Id,
                        expense.Type.ToString(),
                        expense.Text,
                        expense.State.ToString(),
                        expense.ModifiedDateTime.ToString("u"));
                    break;
                case InteractionType.Timeslice:
                    Timeslice timeslice = (Timeslice)pInteraction;
                    dgw_Recent.Rows.Add(timeslice.Id,
                        "Timeslice",
                        $"Time spent = {new TimeSpan(0,0,0,timeslice.Duration).TotalHours.ToString()}:{new TimeSpan(0, 0, 0, timeslice.Duration).TotalMinutes.ToString()}:{new TimeSpan(0, 0, 0, timeslice.Duration).TotalSeconds.ToString()}",
                        "Finished",
                        timeslice.Target.CreatedDateTime.ToString("u"));
                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// This method adds a project to the overview
        /// </summary>
        /// <param name="pProject">The project to add</param>
        public void AddAssignedProjects(IProject pProject)
        {
            Project tmp = (Project) pProject;
            dgw_Project.Rows.Add(tmp.Id.ToString(), tmp.Name, tmp.State.ToString(), tmp.ModifiedDateTime);
            dgw_Project.Refresh();
        }

        /// <summary>
        /// Clears all the gridviews and refreshes them
        /// </summary>
        public void ClearDataGridViews()
        {
            dgw_Project.Rows.Clear();
            dgw_Recent.Rows.Clear();
            dgw_Project.Refresh();
            dgw_Recent.Refresh();
        }

        /// <summary>
        /// Registers the forms event to UIManager
        /// </summary>
        public void RegisterEvents()
        {
            dgw_Project.CellDoubleClick += _UIManager.OverviewGridviewDoubleClicked;
        }
    }
}
