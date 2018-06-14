using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livro_C_Sharp___Capitulo_7__exercicios_parte_4_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("colId", "ID");
            dataGridView1.Columns.Add("colNome", "Nome");
            dataGridView1.Columns.Add("colDepartamento", "Departamento");

            DataClasses1DataContext dc = new DataClasses1DataContext();
            var lista = from Funcionarios in dc.Funcionarios select Funcionarios;
            int idxLinha = 0;
            DataGridViewCellStyle vermelho = new DataGridViewCellStyle();
            vermelho.ForeColor = Color.Red;
            foreach (Funcionarios func in lista) {
                DataGridViewRow linha = new DataGridViewRow();
                dataGridView1.Rows.Add(linha);
                dataGridView1.Rows[idxLinha].Cells[0].Value = func.ID;
                dataGridView1.Rows[idxLinha].Cells[1].Value = func.Nome;
                dataGridView1.Rows[idxLinha].Cells[2].Value = func.Departamento;
                if ((string)dataGridView1.Rows[idxLinha].Cells[2].Value == "DC") {
                    dataGridView1.Rows[idxLinha].DefaultCellStyle = vermelho;
                }
                idxLinha = idxLinha + 1;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
