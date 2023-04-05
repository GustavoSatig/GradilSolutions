using System;
using System.Drawing;
using System.Windows.Forms;

namespace GradilSolutions
{
    public partial class GradilSolutions : Form
    {

        string cor;

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
        private void btnConfirmar_Click(object sender, EventArgs e)
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

        private void generateGradil_Click_1(object sender, EventArgs e)
        {
            // Chamar o método btnConfirmar_Click para calcular a quantidade de postes
            btnConfirmar_Click(sender, e);

            // Obter a quantidade de postes a partir do valor na primeira célula da coluna "Postes" no dataGridView1
            if (!int.TryParse(dataGridView1.Rows[1].Cells[1].Value.ToString(), out int quantidadePostes))
            {
                MessageBox.Show("Por favor, calcule a quantidade de postes antes de gerar a imagem.");
                return;
            }

            // Obter a altura da cerca a partir da opção selecionada no comboBox1
            double altura = double.TryParse(comboBox1.SelectedItem?.ToString(), out double result) ? result : 0;

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

            string cor = comboBox2.SelectedItem?.ToString();
            Color corTaubas;
            switch (cor)
            {
                case "Sem pintura":
                    corTaubas = Color.Transparent;
                    break;
                case "Branca":
                    corTaubas = Color.White;
                    break;
                case "Preta":
                    corTaubas = Color.Black;
                    break;
                case "Verde":
                    corTaubas = Color.Green;
                    break;
                default:
                    MessageBox.Show("Por favor, selecione uma cor válida.");
                    return;
            }

            Color corPostes = Color.Black;

            // Calcular a altura dos postes e das tábuas da cerca
            double alturaPostes = altura;
            double alturaTábuas = altura;

            // Calcular as dimensões da imagem
            int larguraDesenho = 670;
            int alturaDesenho = 315;

            // Criar bitmap para desenhar
            Bitmap bmp = new Bitmap(larguraDesenho, alturaDesenho);
            Graphics g = Graphics.FromImage(bmp);
            {
                g.Clear(Color.White);

                //int x = larguraDesenho / 6700;
                //int y = 10;

                // Definir a largura dos postes e das tábuas da cerca
                int larguraPostes = 2;
                int larguraTabuas = 100;
                int deslocamentoInicial = 1;

                for (int i = 0; i < quantidadePostes; i++)
                {
                    // Calcular a posição x do poste
                    int x = Convert.ToInt32(Math.Round(deslocamentoInicial + (i + 0.01) * larguraDesenho / quantidadePostes));

                    // Desenhar linha vertical do poste
                    g.DrawLine(new Pen(corPostes, larguraPostes), (int)x, 0, (int)x, alturaDesenho);

                    // Desenhar linhas horizontais representando as tábuas da cerca
                    for (int j = 1; j <= 100; j++)
                    {
                        int y = j * alturaDesenho / 25;
                        g.DrawLine(new Pen(corTaubas, larguraTabuas), (int)(x - larguraPostes / 2 - larguraTabuas), y, (int)(x + larguraPostes / 2 + larguraTabuas), y);

                    }
                }

            }

            // Exibir a imagem no pictureBox
            pictureBox1.Image = bmp;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
