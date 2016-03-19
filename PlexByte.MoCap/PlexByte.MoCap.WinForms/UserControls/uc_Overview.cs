//////////////////////////////////////////////////////////////
//      Overview form listing all items in the main form, 
//      docked on the left side                              
//      Author: Christian B. Sax            Date:   2016/02/21

using System.Collections.Generic;
using PlexByte.MoCap.Interactions;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms.UserControls
{
    public partial class uc_Overview : DockContent
    {
        /// <summary>
        /// The text shown in the tab title
        /// </summary>
        private const string ControlTitle = "Interactions Overview";

        public uc_Overview()
        {
            InitializeComponent();
            this.TabText = ControlTitle;
        }

        public void AddRecentlyChangedInteraction(IInteraction pInteraction)
        {
            switch (pInteraction.Type)
            {
                case InteractionType.Project:
                    AddAssignedProjects((IProject)pInteraction);
                    break;
                case InteractionType.Task:
                    break;
                case InteractionType.Survey:
                    break;
                case InteractionType.Expense:
                    break;
                case InteractionType.Timeslice:
                    break;
                default:
                    return;
            }
        }

        public void AddAssignedProjects(IProject pProject)
        {
            Project tmp = (Project) pProject;
            dgw_Project.Rows.Add(tmp.Id.ToString(), tmp.Name, tmp.State.ToString(), tmp.ModifiedDateTime);
        }
    }
}
