using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrdemServico2020.Relatorios;

namespace OrdemServico2020
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Deseja sair do sistema?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
          
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frmCli = new frmClientes();
            frmCli.MdiParent = this;
            frmCli.Show();
        }        

        private void ordemDeServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdens frmOrd = new frmOrdens();
            frmOrd.MdiParent = this;
            frmOrd.Show();
        }

        private void fecharOrdemDeSerciçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServicos frmSer = new frmServicos();
            frmSer.MdiParent = this;
            frmSer.Show();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre frmSb = new frmSobre();
            frmSb.ShowDialog();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Relatorios.RelClientes.relCliente();
        }

        private void ordemDeServiçoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Relatorios.RelOrdens.relOrdem();
        }
    }
}
