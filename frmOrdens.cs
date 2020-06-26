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

            Camadas.DAL.Clientes dalCli = new Camadas.DAL.Clientes();
            cmbCliente.DisplayMember = "nome";
            cmbCliente.ValueMember = "idCli";
            cmbCliente.DataSource = dalCli.Select();

            limparControles();
        }

        private void limparControles()
        {
            dtpEntrada.Text = "";
            txtIdCli.Text = "";
            cmbCliente.Text = "";
            txtEquipamento.Text = "";
            txtDefeito.Text = "";
            txtValor.Text = "";
            txtSituacao.Text = "";
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            Camadas.MODEL.Ordens ordem = new Camadas.MODEL.Ordens();
            ordem.entrada = Convert.ToDateTime(dtpEntrada.Value);
            ordem.equipamento = txtEquipamento.Text;
            ordem.defeito = txtDefeito.Text;
            ordem.valor = Convert.ToSingle(txtValor.Text);
            ordem.situacao = txtSituacao.Text;
            ordem.clienteID = Convert.ToInt32(txtIdCli.Text);

            Camadas.DAL.Ordens dalCli = new Camadas.DAL.Ordens();
            dalCli.Insert(ordem);

            dgvOrdens.DataSource = "";
            dgvOrdens.DataSource = dalCli.Select();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparControles();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdCli.Text = cmbCliente.SelectedValue.ToString();
        }
    }
}
