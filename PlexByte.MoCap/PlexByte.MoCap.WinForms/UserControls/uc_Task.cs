//////////////////////////////////////////////////////////////
//                      Windows form uc_Task                              
//      Author: Christian B. Sax            Date:   2016/02/14
//      The task details form containing any task detail and is docked as document type in the main form

using System.Collections.Generic;
using PlexByte.MoCap.Interactions;
using WeifenLuo.WinFormsUI.Docking;

namespace PlexByte.MoCap.WinForms.UserControls
{
    public partial class uc_Task : DockContent
    {
        public string TaskId { get; set; }
        public string InteractionId { get; set; }
        public string MainTaskId { get; set; }

        private const string PanelTitle = "Task Details";

        public uc_Task()
        {
            InitializeComponent();
            this.TabText = PanelTitle;
        }

        public void RegisterEvents(UIManager pManagerInstance)
        {
            btn_New.Click += new System.EventHandler(pManagerInstance.TaskButtonClicked);
            btn_Update.Click += new System.EventHandler(pManagerInstance.TaskButtonClicked);
            btn_Edit.Click += new System.EventHandler(pManagerInstance.TaskButtonClicked);
        }

        public void SetProjectCollection(List<IProject> pProjects)
        {
            foreach (Project project in pProjects)
            {
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(project.Name, project.Id);
                cbx_ProjectName.Items.Add(kvp);
            }
        }
    }
}
