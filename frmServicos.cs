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
            //Camadas.DAL.Ordens dalOrd = new Camadas.DAL.Ordens();
            //dgvFiltro.DataSource = dalOrd.Select();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvFiltro_DoubleClick(object sender, EventArgs e)
        {
            txtIdOs.Text = dgvFiltro.SelectedRows[0].Cells["idOrd"].Value.ToString();
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            lblFiltro.Visible = false;
            txtFiltro.Visible = false;
        }

        private void rdbId_CheckedChanged(object sender, EventArgs e)
        {
            lblFiltro.Text = "Informe o ID da Ordem de Pagamento:";
            txtFiltro.Text = null;
            lblFiltro.Visible = true;
            txtFiltro.Visible = true;
            txtFiltro.Focus();
        }

        private void rdbEquipamento_CheckedChanged(object sender, EventArgs e)
        {
            lblFiltro.Text = "Informe o nome do Equipamento:";
            txtFiltro.Text = null;
            lblFiltro.Visible = true;
            txtFiltro.Visible = true;
            txtFiltro.Focus();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            Camadas.BLL.Ordens bllOrdem = new Camadas.BLL.Ordens();
            List<Camadas.MODEL.Ordens> lstOrdens = new List<Camadas.MODEL.Ordens>();
            if (rdbTodos.Checked)
            {
                lstOrdens = bllOrdem.Select();
            }
            else if (rdbEquipamento.Checked)
            {
                lstOrdens = bllOrdem.SelectByEquipamento(txtFiltro.Text);
            }
            else
            {
                int id = Convert.ToInt32(txtFiltro.Text);
                lstOrdens = bllOrdem.SelectById(id);                
            }

            dgvFiltro.DataSource = "";
            dgvFiltro.DataSource = lstOrdens;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtIdOs.Text == "")
            {
                MessageBox.Show("Selecionar Ordem de Serviço!");
            }
            else
            {
                //Incluir Serviço
                Camadas.BLL.Servicos bllServicos = new Camadas.BLL.Servicos();
                Camadas.MODEL.Servicos servico = new Camadas.MODEL.Servicos();
                //servico.idSer = Convert.ToInt32();
                servico.saida = Convert.ToDateTime(dtpSaida.Value);
                servico.ordemID = Convert.ToInt32(txtIdOs.Text);

                bllServicos.Insert(servico);

                //Limpar label e textbox
                txtIdOs.Text = "";
                rdbTodos.Checked = true;
                lblFiltro.Visible = false;
                txtFiltro.Visible = false;

                MessageBox.Show("Ordem de Serviço fechada!");

                //Listar na Grid apenas a OS alterada
                Camadas.DAL.Ordens dalOrd = new Camadas.DAL.Ordens();
                dgvFiltro.DataSource = dalOrd.SelectById(servico.ordemID);
            }                        
        }
    }
}
