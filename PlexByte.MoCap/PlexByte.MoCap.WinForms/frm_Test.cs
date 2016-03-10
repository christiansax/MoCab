using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlexByte.MoCap.WinForms
{
    public partial class frm_Test : Form
    {
        public frm_Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlexByte.MoCap.Backend.BackendService isvc = new PlexByte.MoCap.Backend.BackendService();
            //DataTable tbl = isvc.GetTasksByUser("1");
        }
    }
}
