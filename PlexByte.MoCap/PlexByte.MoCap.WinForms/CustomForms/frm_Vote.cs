using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlexByte.MoCap.Interactions;
using PlexByte.MoCap.Security;

namespace PlexByte.MoCap.WinForms.CustomForms
{
    public partial class frm_Vote : Form
    {
        public IUser VotingUser { get; set; }
        public IVote Vote { get; set; }

        private ObjectFactory factory = null;
        private List<ISurveyOption> options = null; 

        public frm_Vote(IUser pUserContext, ObjectFactory pFactory)
        {
            InitializeComponent();
            VotingUser = pUserContext;
            Vote = null;
            factory = pFactory;
        }

        public void SetSurveyOptions(List<ISurveyOption> pSurveyOptions)
        {
            options = pSurveyOptions;
            foreach (ISurveyOption option in pSurveyOptions)
            {
                KeyValuePair<string, string> tmp = new KeyValuePair<string, string>(option.Text, option.Id);
                cbx_Options.Items.Add(tmp);
            }
        }

        private void btn_Vote_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (cbx_Options.SelectedIndex >= 0)
            {
                Vote = factory.CreateVote(DateTime.Now.ToString("yyyyMMddhhmmssfff"),
                    VotingUser,
                    options[cbx_Options.SelectedIndex]);
                this.DialogResult= DialogResult.OK;
                this.Close();
            }
            else
                errorProvider1.SetError(cbx_Options, "You must select an option");
        }
    }
}
