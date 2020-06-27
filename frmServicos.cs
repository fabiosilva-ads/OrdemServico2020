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
    public partial class frmServicos : Form
    {
        public frmServicos()
        {
            InitializeComponent();
        }

        private void frmServicos_Load(object sender, EventArgs e)
        {
            Camadas.DAL.Ordens dalOrd = new Camadas.DAL.Ordens();
            dgvFiltro.DataSource = dalOrd.Select();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
