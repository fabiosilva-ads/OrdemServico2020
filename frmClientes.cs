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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            Camadas.DAL.Clientes dalCli = new Camadas.DAL.Clientes();
            dgvClientes.DataSource = dalCli.Select();
        }

        private void limparControles()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtFone.Text = "";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparControles();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            Camadas.MODEL.Clientes cliente = new Camadas.MODEL.Clientes();
            cliente.nome = txtNome.Text;
            cliente.endereco = txtEndereco.Text;
            cliente.fone = txtFone.Text;

            Camadas.DAL.Clientes dalCli = new Camadas.DAL.Clientes();
            dalCli.Insert(cliente);

            dgvClientes.DataSource = "";
            dgvClientes.DataSource = dalCli.Select();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Camadas.MODEL.Clientes cliente = new Camadas.MODEL.Clientes();
            cliente.idCli = Convert.ToInt32(txtId.Text);
            cliente.nome = txtNome.Text;
            cliente.endereco = txtEndereco.Text;
            cliente.fone = txtFone.Text;

            Camadas.DAL.Clientes dalCli = new Camadas.DAL.Clientes();
            dalCli.Update(cliente);

            dgvClientes.DataSource = "";
            dgvClientes.DataSource = dalCli.Select();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Camadas.DAL.Clientes dalCli = new Camadas.DAL.Clientes();

            if (txtId.Text != "")
            {
                DialogResult resp = MessageBox.Show("Deseja excluir o Cliente?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (resp == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(txtId.Text);
                    dalCli.Delete(id);
                }                
            }
            else MessageBox.Show("Não há dados para remover!", "Remover", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvClientes.DataSource = "";
            dgvClientes.DataSource = dalCli.Select();
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            txtId.Text = dgvClientes.SelectedRows[0].Cells["idCli"].Value.ToString();
            txtNome.Text = dgvClientes.SelectedRows[0].Cells["Nome"].Value.ToString();
            txtEndereco.Text = dgvClientes.SelectedRows[0].Cells["Endereco"].Value.ToString();
            txtFone.Text = dgvClientes.SelectedRows[0].Cells["Fone"].Value.ToString();
        }
    }
}
