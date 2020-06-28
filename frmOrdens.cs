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

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdCli.Text = cmbCliente.SelectedValue.ToString();
        }

        private void limparControles()
        {
            txtIdOrd.Text = "";
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
            try
            {
                Camadas.MODEL.Ordens ordem = new Camadas.MODEL.Ordens();
                ordem.entrada = Convert.ToDateTime(dtpEntrada.Value);
                ordem.equipamento = txtEquipamento.Text;
                ordem.defeito = txtDefeito.Text;
                ordem.valor = Convert.ToSingle(txtValor.Text);                              
                ordem.situacao = Convert.ToInt32(txtSituacao.Text);
                ordem.clienteID = Convert.ToInt32(txtIdCli.Text);

                Camadas.DAL.Ordens dalCli = new Camadas.DAL.Ordens();
                dalCli.Insert(ordem);

                limparControles();

                dgvOrdens.DataSource = "";
                dgvOrdens.DataSource = dalCli.Select();
            }
            catch
            {
                MessageBox.Show("Selecione o cliente e digite o equipamento, o defeito, o valor e a situação!");
            }            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                Camadas.MODEL.Ordens ordem = new Camadas.MODEL.Ordens();
                ordem.idOrd = Convert.ToInt32(txtIdOrd.Text);
                ordem.entrada = Convert.ToDateTime(dtpEntrada.Value);
                ordem.equipamento = txtEquipamento.Text;
                ordem.defeito = txtDefeito.Text;
                ordem.valor = Convert.ToSingle(txtValor.Text);
                ordem.situacao = Convert.ToInt32(txtSituacao.Text);
                ordem.clienteID = Convert.ToInt32(txtIdCli.Text);

                Camadas.DAL.Ordens dalCli = new Camadas.DAL.Ordens();
                dalCli.Update(ordem);

                limparControles();

                dgvOrdens.DataSource = "";
                dgvOrdens.DataSource = dalCli.Select();
            }
            catch
            {
                MessageBox.Show("Selecione o cliente e digite o equipamento, o defeito, o valor e a situação!");
            }
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparControles();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
        
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Camadas.DAL.Ordens dalCli = new Camadas.DAL.Ordens();

            if (txtIdOrd.Text != "")
            {
                DialogResult resp = MessageBox.Show("Deseja excluir o Cliente?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (resp == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(txtIdOrd.Text);
                    dalCli.Delete(id);
                }
            }
            else MessageBox.Show("Informe o número do ID!", "Remover", MessageBoxButtons.OK, MessageBoxIcon.Information);

            limparControles();

            dgvOrdens.DataSource = "";
            dgvOrdens.DataSource = dalCli.Select();
        }

        private void dgvOrdens_DoubleClick(object sender, EventArgs e)
        {
            txtIdOrd.Text = dgvOrdens.SelectedRows[0].Cells["idOrd"].Value.ToString();
            dtpEntrada.Text = dgvOrdens.SelectedRows[0].Cells["entrada"].Value.ToString();
            txtEquipamento.Text = dgvOrdens.SelectedRows[0].Cells["equipamento"].Value.ToString();
            txtDefeito.Text = dgvOrdens.SelectedRows[0].Cells["defeito"].Value.ToString();
            txtValor.Text = dgvOrdens.SelectedRows[0].Cells["valor"].Value.ToString();
            txtSituacao.Text = dgvOrdens.SelectedRows[0].Cells["situacao"].Value.ToString();
            txtIdCli.Text = dgvOrdens.SelectedRows[0].Cells["clienteID"].Value.ToString();
            cmbCliente.Text = dgvOrdens.SelectedRows[0].Cells["nomeCli"].Value.ToString();
        }

    }
}
