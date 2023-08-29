using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace JSONGridApp_Gabriel
{
    public partial class MainForm_Gabriel : Form
    {
        public MainForm_Gabriel()
        {
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            DataGridView dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;

            DataGridViewTextBoxColumn colunaCodigo = new DataGridViewTextBoxColumn();
            colunaCodigo.HeaderText = "Código";
            dataGridView.Columns.Add(colunaCodigo);

            DataGridViewTextBoxColumn colunaDescricao = new DataGridViewTextBoxColumn();
            colunaDescricao.HeaderText = "Descrição";
            dataGridView.Columns.Add(colunaDescricao);

            string caminhoArquivo = "data.json";
            string json = File.ReadAllText(caminhoArquivo);

            List<clsTeste> lista = JsonConvert.DeserializeObject<List<clsTeste>>(json);

            foreach (clsTeste item in lista)
            {
                dataGridView.Rows.Add(item.Codigo, item.Descricao);
            }

            Controls.Add(dataGridView);
        }
    }

    public class clsTeste
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; } = "";
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm_Gabriel());
        }
    }
}
