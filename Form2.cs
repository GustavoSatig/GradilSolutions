using System.IO;
using System.Windows.Forms;
using System.Data;

namespace GradilSolutions
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
            
            // Chame o método para carregar os dados do CSV no DataGridView
            DataGridViewHistory();
        }

        private void DataGridViewHistory()
        {

            // Defina o caminho para a pasta Histórico na raiz do projeto
            string folderPath = Path.Combine(Application.StartupPath, "Histórico");

            // Obtenha a lista de arquivos CSV na pasta Histórico
            string[] csvFiles = Directory.GetFiles(folderPath, "*.csv");

            // Crie uma nova tabela para armazenar todos os dados do CSV
            DataTable dt = new DataTable();

            // Adicione as colunas à tabela com base no cabeçalho do primeiro arquivo CSV
            if (csvFiles.Length > 0)
            {
                string[] lines = File.ReadAllLines(csvFiles[0]);
                string[] headers = lines[0].Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
            }

            // Adicione as linhas à tabela com base nos dados de cada arquivo CSV
            foreach (string csvFile in csvFiles)
            {
                string[] lines = File.ReadAllLines(csvFile);
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(',');
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        dr[j] = data[j];
                    }
                    dt.Rows.Add(dr);
                }
            }

            // Exiba os dados do CSV no DataGridView
            dataGridViewHistory.DataSource = dt;
        }


        private void dataGridViewHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            // Fechar o Form2
            if (MessageBox.Show("Voce deseja mesmo voltar a aplicação inicial??", "Voltar a Aplicação Inicial", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
