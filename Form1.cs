using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace GradilSolutions
{
    public partial class GradilSolutions : Form
    {

        double comprimento;
        double altura;
        string cor;
        int quantidade_telas;
        int quantidade_postes;
        int quantidade_fixadores;
        int quantidade_parafusos;
        double diferenca;

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
            // Verificar se o usuário confirmou as opções antes de gerar o gráfico
            if (quantidade_postes == 0 || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Por favor, confirme as opções antes de gerar o gráfico.");
                return;
            }

            // Criar o objeto ZedGraphControl
            ZedGraphControl zedGraphControl = new ZedGraphControl();
            zedGraphControl.Dock = DockStyle.Fill;
            this.Controls.Add(zedGraphControl);

            // Criar o objeto GraphPane para o gráfico
            GraphPane myPane = zedGraphControl.GraphPane;

            // Definir o título do gráfico
            myPane.Title.Text = "Gradil Solutions";

            // Definir o título do eixo X
            myPane.XAxis.Title.Text = "Quantidade de Postes";

            // Definir o título do eixo Y
            myPane.YAxis.Title.Text = "Altura da Cerca (m)";

            // Criar um objeto PointPairList para armazenar os valores dos postes e alturas
            PointPairList pontos = new PointPairList();
            for (int i = 1; i <= quantidade_postes; i++)
            {
                pontos.Add(i, altura);
            }

            // Definir o tipo de gráfico como Coluna
            BarItem curve = myPane.AddBar("Quantidade de Postes", pontos, Color.FromName(cor));
            curve.Bar.Fill = new Fill(Color.FromName(cor));

            // Atualizar o gráfico
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
