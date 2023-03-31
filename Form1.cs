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
    // Obter as especificações da cerca do usuário
    double altura = double.Parse(txtAltura.Text);
    double largura = double.Parse(txtLargura.Text);

    // Calcular o comprimento da cerca
    double comprimento = 2 * altura + 2 * largura;

            // Gerar o código HTML para o gráfico
            string html = @"
<!DOCTYPE html>
<html>
<head>
	<title>Gráfico da cerca</title>
	<script src='https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.min.js'></script>
</head>
<body>
	<canvas id='myChart'></canvas>

	<script>
		var ctx = document.getElementById('myChart').getContext('2d');
		var myChart = new Chart(ctx, {
			type: 'bar',
			data: {
				labels: ['Telas', 'Postes', 'Fixadores', 'Parafusos', 'Cor da Tela', 'Diferença'],
				datasets: [{
					label: 'Quantidade',
					data: [" + quantidade_telas + ", " + quantidade_postes + ", " + quantidade_fixadores + ", " + quantidade_parafusos + ", 1, '" + cor + "', " + diferenca + @"],
					backgroundColor: [
						'rgba(255, 99, 132, 0.2)',
						'rgba(54, 162, 235, 0.2)',
						'rgba(255, 206, 86, 0.2)',
						'rgba(75, 192, 192, 0.2)',
						'rgba(153, 102, 255, 0.2)',
						'rgba(255, 159, 64, 0.2)'
					],
					borderColor: [
						'rgba(255, 99, 132, 1)',
						'rgba(54, 162, 235, 1)',
						'rgba(255, 206, 86, 1)',
						'rgba(75, 192, 192, 1)',
						'rgba(153, 102, 255, 1)',
						'rgba(255, 159, 64, 1)'
					],
					borderWidth: 1
				}]
			},
			options: {
				scales: {
					yAxes: [{
						ticks: {
							beginAtZero: true
						}
					}]
				}
			}
		});
	</script>
</body>
</html>
";

            // Exibir o gráfico no WebBrowser
            webBrowser1.DocumentText = html;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Cria uma instância do StreamWriter e abre um arquivo CSV para escrita
            using (StreamWriter writer = new StreamWriter("resultados.csv"))
            {
                // Escreve o cabeçalho do arquivo CSV
                writer.WriteLine("Produto,Quantidade");

                // Escreve cada linha do DataGridView como uma linha no arquivo CSV
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string produto = row.Cells["Produto"].Value.ToString();
                    string quantidade = row.Cells["Quantidade"].Value.ToString();
                    writer.WriteLine(produto + "," + quantidade);
                }
            }

            // Exibe uma mensagem de sucesso para o usuário
            MessageBox.Show("Os resultados foram salvos em resultados.csv.");
        }
    }
}
