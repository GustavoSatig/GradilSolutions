using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradilSolutions
{
    public partial class GradilSolutions : Form
    {
        public GradilSolutions()
        {
            InitializeComponent();

            // Adicionar colunas a tela
            dataGridView1.Columns.Add("Produto", "Nome do Produto");
            dataGridView1.Columns.Add("Quantidade", "Quantidade do Produto");

            // Definir tamanho das células
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns["Produto"].Width = 150;
            dataGridView1.Columns["Quantidade"].Width = 175;
            dataGridView1.Columns["Produto"].DefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.Columns["Quantidade"].DefaultCellStyle.BackColor = Color.LightCyan;

            // Adiciona os tamanhos de altura da cerca
            comboBox1.Items.Add("1,03");
            comboBox1.Items.Add("1,53");
            comboBox1.Items.Add("2,03");

            // Adiciona as cores de acordo com as especificadas
            comboBox2.Items.Add("Sem pintura");
            comboBox2.Items.Add("Branca");
            comboBox2.Items.Add("Preta");
            comboBox2.Items.Add("Verde");

            // Define o valor padrão da cor
            comboBox2.SelectedIndex = 0;

            // Define o valor padrão do comprimento da cerca
            textBox1.Text = "0";
        }

        //botao de confirmar que deve se conectar com o datagridview
        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar se o usuário selecionou opções válidas
            if (string.IsNullOrEmpty(textBox1.Text) || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione todas as opções antes de confirmar.");
                return;
            }

            // Obter comprimento total da cerca
            if (!double.TryParse(textBox1.Text, out double comprimento))
            {
                MessageBox.Show("Por favor, insira um comprimento válido.");
                return;
            }

            // Obter altura da cerca
            double altura;
            switch (comboBox1.SelectedItem.ToString())
            {
                case "1,03":
                    altura = 1.03;
                    break;
                case "1,53":
                    altura = 1.53;
                    break;
                case "2,03":
                    altura = 2.03;
                    break;
                default:
                    MessageBox.Show("Por favor, selecione uma altura válida.");
                    return;
            }

            // Obter cor da cerca
            string cor = comboBox2.SelectedItem.ToString();

            // Realizar os cálculos
            int quantidade_telas = (int)Math.Ceiling(comprimento / 2.5);
            int quantidade_postes = quantidade_telas * 2;
            int quantidade_fixadores = 0;
            switch (comboBox1.SelectedItem.ToString())
            {
                case "1,03":
                    quantidade_fixadores = quantidade_telas * 3;
                    break;
                case "1,53":
                    quantidade_fixadores = quantidade_telas * 4;
                    break;
                case "2,03":
                    quantidade_fixadores = quantidade_telas * 6;
                    break;
            }
            int quantidade_parafusos = quantidade_postes * 4;

            double diferenca;
            diferenca = (quantidade_telas * 2.5) - comprimento;

            // Mostrar os resultados na tela
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add("Telas:", quantidade_telas);
            dataGridView1.Rows.Add("Postes:", quantidade_postes);
            dataGridView1.Rows.Add("Fixadores:", quantidade_fixadores);
            dataGridView1.Rows.Add("Parafusos:", quantidade_parafusos);
            dataGridView1.Rows.Add("Cor da Tela:", cor);
            dataGridView1.Rows.Add("Diferença:", diferenca);
        }
        //altura da cerca
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
        //cor da cerca
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Comprimento total da cerca em metros
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }
        //apenas uma label
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Aqui preciso mostrar os resultados dos calculos 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //apenas uma label
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void GradilSolutions_Load(object sender, EventArgs e)
        {
  
        }

        private void generateGradil_Click(object sender, EventArgs e)
        {
    // Obter as especificações da cerca do usuário
    double altura = double.Parse(txtAltura.Text);
    double largura = double.Parse(txtLargura.Text);

    // Calcular o comprimento da cerca
    double comprimento = 2 * altura + 2 * largura;

    // Gerar o código HTML para o gráfico
    string html = "<html><head><script src=\"https://cdn.jsdelivr.net/npm/chart.js\"></script></head><body>";
    html += "<canvas id=\"myChart\"></canvas>";
    html += "<script>var ctx = document.getElementById('myChart').getContext('2d');";
    html += "var myChart = new Chart(ctx, {type: 'bar',data: {labels: ['Comprimento'],datasets: [{label: 'Comprimento da cerca',data: [" + comprimento + "],backgroundColor: ['rgba(255, 99, 132, 0.2)'],borderColor: ['rgba(255, 99, 132, 1)'],borderWidth: 1}]}});</script>";
    html += "</body></html>";

    // Exibir o gráfico no WebBrowser
    webBrowser.DocumentText = html;
}

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
