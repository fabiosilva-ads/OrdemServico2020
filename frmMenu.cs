﻿using System;
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
            this.Dispose();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frmCli = new frmClientes();
            frmCli.MdiParent = this;
            frmCli.Show();
        }

        private void abrirOrdemDeServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdens frmOrd = new frmOrdens();
            frmOrd.MdiParent = this;
            frmOrd.Show();
        }
    }
}
