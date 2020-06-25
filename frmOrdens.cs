using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdemServico2020
{
    public partial class frmOrdens : Form
    {
        public frmOrdens()
        {
            InitializeComponent();
        }

        private void frmOrdens_Load(object sender, EventArgs e)
        {
            Camadas.DAL.Ordens dalOrd = new Camadas.DAL.Ordens();
            dgvOrdens.DataSource = dalOrd.Select();
        }
    }
}
