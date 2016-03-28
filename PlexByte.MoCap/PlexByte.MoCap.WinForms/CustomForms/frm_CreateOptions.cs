using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlexByte.MoCap.WinForms.CustomForms
{
    public partial class frm_CreateOptions : Form
    {
        public List<string> SurveyOptions { get; set; }

        public frm_CreateOptions(List<string> pOptionItems)
        {
            InitializeComponent();
            SurveyOptions = new List<string>();
            if (pOptionItems.Count > 0)
            {
                foreach (var option in pOptionItems)
                {
                    lbx_Options.Items.Add(option);
                    SurveyOptions.Add(option);
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (tbx_Text.Text.Length > 0)
            {
                lbx_Options.Items.Add(tbx_Text.Text);
                SurveyOptions.Add(tbx_Text.Text);
            }
            else
            {
                errorProvider1.SetError(tbx_Text, "No text for option specified");
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (lbx_Options.SelectedIndex >= 0)
            {
                lbx_Options.Items.Remove(lbx_Options.Items[lbx_Options.SelectedIndex].ToString());
                if (SurveyOptions.Contains(lbx_Options.Items[lbx_Options.SelectedIndex].ToString()))
                    SurveyOptions.Remove(lbx_Options.Items[lbx_Options.SelectedIndex].ToString());
            }
            else
            {
                errorProvider1.SetError(tbx_Text, "No option to remove was selected in the options box");
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.OK;
            this.Close();
        }
    }
}
