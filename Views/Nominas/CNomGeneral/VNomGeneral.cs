using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Nominas.CNomGeneral
{
    public partial class VNomGeneral : Form
    {
        public VNomGeneral()
        {
            InitializeComponent();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            VUploadArchivos frm = new VUploadArchivos();
            frm.ShowDialog();
        }
    }
}
