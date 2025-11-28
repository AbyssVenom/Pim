using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Pim.Model;
using System.Text;
using System.IO;

namespace Pim.View
{
    public partial class ucRelatorios : UserControl
    {
        public ucRelatorios()
        {
            InitializeComponent();
        }
        private void ConfigurarGraficos()
        {
            // --- GRÁFICO 1: TIMELINE (Colunas) ---
            ConfigurarUmGrafico(chartTimeline, "Chamados por Mês", SeriesChartType.Column);
            // Adicionando dados de teste
            chartTimeline.Series[0].Points.AddXY("Jun", 10);
            chartTimeline.Series[0].Points.AddXY("Jul", 25);
            chartTimeline.Series[0].Points.AddXY("Ago", 15);
            chartTimeline.Series[0].Color = Color.Teal;

            // --- GRÁFICO 2: CATEGORIAS (Rosca) ---
            ConfigurarUmGrafico(chartCategorias, "Por Categoria", SeriesChartType.Doughnut);
            chartCategorias.Series[0].Points.AddXY("Hardware", 40);
            chartCategorias.Series[0].Points.AddXY("Software", 30);
            chartCategorias.Series[0].Points.AddXY("Rede", 20);
            // Cores manuais para ficar bonito
            chartCategorias.Series[0].Points[0].Color = Color.RoyalBlue;
            chartCategorias.Series[0].Points[1].Color = Color.MediumSeaGreen;
            chartCategorias.Series[0].Points[2].Color = Color.Orange;

            // --- GRÁFICO 3: PRIORIDADE (Barras Horizontais) ---
            ConfigurarUmGrafico(chartPrioridade, "Por Prioridade", SeriesChartType.Bar);
            chartPrioridade.Series[0].Points.AddXY("Baixa", 10);
            chartPrioridade.Series[0].Points.AddXY("Média", 50);
            chartPrioridade.Series[0].Points.AddXY("Alta", 20);
            chartPrioridade.Series[0].Color = Color.SlateBlue;

            // --- GRÁFICO 4: DETALHES (Barras Horizontais) ---
            ConfigurarUmGrafico(chartDetalheCategoria, "Detalhes", SeriesChartType.Bar);
            chartDetalheCategoria.Series[0].Points.AddXY("Impressora", 5);
            chartDetalheCategoria.Series[0].Points.AddXY("Login", 12);
            chartDetalheCategoria.Series[0].Color = Color.Gray;
        }
        private void ConfigurarUmGrafico(Chart grafico, string titulo, SeriesChartType tipo)
        {
            grafico.Series.Clear();
            grafico.Titles.Clear();
            grafico.Titles.Add(titulo).Font = new Font("Segoe UI", 12, FontStyle.Bold);

            Series serie = new Series("Dados");
            serie.ChartType = tipo;
            serie.IsValueShownAsLabel = true; 
            grafico.Series.Add(serie);

            // Ajustes visuais extras
            grafico.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            grafico.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            grafico.ChartAreas[0].BackColor = Color.Transparent;
        }

        private void ucRelatorios_Load(object sender, EventArgs e)
        {
            ConfigurarGraficos();
            CarregarDadosReais();
        }
        private void CarregarDadosReais()
        {
            // 1. Busca TODOS os chamados do banco de dados
            var listaCompleta = ChamadoRepository.BuscarTodosViewModel();

            // Se não tiver nada no banco, para por aqui para não dar erro
            if (listaCompleta.Count == 0) return;

            // ==========================================
            // PARTE A: PREENCHER OS CARDS (KPIs)
            // ==========================================

            // 1. Total de Chamados
            int totalChamados = listaCompleta.Count;
            lblCardTotal.Text = totalChamados.ToString(); 

            // 2. Taxa de Resolução (Resolvidos / Total)
            int resolvidos = listaCompleta.Count(c => c.Status == "Resolvido");
            double taxaResolucao = 0;
            if (totalChamados > 0)
                taxaResolucao = ((double)resolvidos / totalChamados) * 100;

            lblCardTaxa.Text = $"{taxaResolucao:F1}%"; // F1 = 1 casa decimal

            // ==========================================
            // PARTE B: GRÁFICO 1 - LINHA DO TEMPO (Por Mês)
            // ==========================================
            chartTimeline.Series[0].Points.Clear();

            // Agrupa os chamados por Mês/Ano
            var chamadosPorMes = listaCompleta
                .GroupBy(c => c.DataAbertura.ToString("MMM/yy")) // Ex: "Nov/25"
                .Select(g => new { Mes = g.Key, Quantidade = g.Count() })
                .ToList();

            foreach (var item in chamadosPorMes)
            {
                chartTimeline.Series[0].Points.AddXY(item.Mes, item.Quantidade);
            }
            chartTimeline.Series[0].Color = Color.Teal;


            // ==========================================
            // PARTE C: GRÁFICO 2 - POR CATEGORIA (Rosca)
            // ==========================================
            chartCategorias.Series[0].Points.Clear();

            var porCategoria = listaCompleta
                .GroupBy(c => c.CategoriaNome)
                .Select(g => new { Categoria = g.Key, Quantidade = g.Count() })
                .ToList();

            foreach (var item in porCategoria)
            {
                // Adiciona o ponto (Nome da Categoria, Quantidade)
                int index = chartCategorias.Series[0].Points.AddXY(item.Categoria, item.Quantidade);

                // Dica: Coloca o valor como legenda no gráfico
                chartCategorias.Series[0].Points[index].Label = "#VALX (#VALY)";
                chartCategorias.Series[0].Points[index].LegendText = item.Categoria;
            }


            // ==========================================
            // PARTE D: GRÁFICO 3 - POR PRIORIDADE (Barras)
            // ==========================================
            chartPrioridade.Series[0].Points.Clear();

            var porPrioridade = listaCompleta
                .GroupBy(c => c.Prioridade)
                .Select(g => new { Prio = g.Key, Quantidade = g.Count() })
                .ToList();

            foreach (var item in porPrioridade)
            {
                chartPrioridade.Series[0].Points.AddXY(item.Prio, item.Quantidade);
            }
            chartPrioridade.Series[0].Color = Color.SeaGreen;


            // ==========================================
            // PARTE E: GRÁFICO 4 - DETALHES (Top 5 Categorias)
            // ==========================================
            chartDetalheCategoria.Series[0].Points.Clear();

            // Pega as top categorias mais usadas
            var topCategorias = listaCompleta
                .GroupBy(c => c.CategoriaNome)
                .Select(g => new { Categoria = g.Key, Quantidade = g.Count() })
                .OrderByDescending(x => x.Quantidade) 
                .Take(5) 
                .ToList();

            foreach (var item in topCategorias)
            {
                chartDetalheCategoria.Series[0].Points.AddXY(item.Categoria, item.Quantidade);
            }
            chartDetalheCategoria.Series[0].Color = Color.SlateBlue;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tlpCards_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Busca os dados atuais
                var dados = ChamadoRepository.BuscarTodosViewModel();

                if (dados.Count == 0)
                {
                    MessageBox.Show("Não há dados para exportar.");
                    return;
                }

                // 2. Configura a janela de salvar arquivo
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Arquivo CSV (*.csv)|*.csv";
                saveDialog.FileName = $"Relatorio_Chamados_{DateTime.Now:yyyyMMdd_HHmm}.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // 3. Monta o conteúdo do CSV (Separado por ponto e vírgula)
                    StringBuilder sb = new StringBuilder();

                    // Cabeçalho
                    sb.AppendLine("ID;Titulo;Categoria;Prioridade;Status;Data Abertura;Solicitante;Tecnico");

                    // Linhas de Dados
                    foreach (var item in dados)
                    {
                        // Limpa ponto e vírgula dos textos para não quebrar o CSV
                        string titulo = item.Titulo.Replace(";", ",");
                        string tecnico = item.NomeTecnico ?? "Nao Atribuido";

                        sb.AppendLine($"{item.IdFormatado};{titulo};{item.CategoriaNome};{item.Prioridade};{item.Status};{item.DataFormatada};{item.NomeSolicitante};{tecnico}");
                    }

                    // 4. Salva o arquivo no disco
                    File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("Relatório exportado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exportar: " + ex.Message);
            }
        }
    }
}
