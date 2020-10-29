using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EX_GridForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        DataTable Tbl;

        private void button1_Click(object sender, EventArgs e)
        {


            // Cria uma nova tabela
            Tbl = new DataTable();
            // Adiciona os nomes e tipos das colunas
            Tbl.Columns.Add("Meses", typeof(int));
            Tbl.Columns.Add("Saldo Devedor (R$)", typeof(double));
            Tbl.Columns.Add("Amortização", typeof(double));
            Tbl.Columns.Add("Juros", typeof(double));
            Tbl.Columns.Add("Prestação", typeof(double));
            Tbl.Columns.Add("Prestação acumulada", typeof(double));
            Tbl.Columns.Add("Juros Acumulado", typeof(double));
            
            // Declara classe para gerenciar registros
            DataRow Linha;
            // ******************** Forma 1 de criar registro
            // e acrescentar no DataGrid


            int prestacoes = 360;
            double taxa = 0.01;
            double[] SaldoDevedor = new double[prestacoes + 1];
            double amortizacao;
            double[] juros = new double[prestacoes + 1];
            double[] parcelas = new double[prestacoes + 1];
            double jAcumulado = 0;
            double pAcumulado = 0;
           
            SaldoDevedor[0] = 300000;
            juros[0] = 0;

            /// Calculo da Amortização:
            amortizacao = SaldoDevedor[0] / 360;

            for (int i = 1; i < juros.Length; i++)
            {
                /// Calculo do Saldo Devedor:
                SaldoDevedor[i] = SaldoDevedor[i - 1] - amortizacao;
                /// Cálculo do juros:
                juros[i] = SaldoDevedor[i] * taxa;

                /// Calculo do Valor da Parcela:
                parcelas[i] = juros[i] + amortizacao;                

                /// Calculo do Juros Acumulado:
                jAcumulado += juros[i];

                /// Calculo das parcelas acumuladas:
                pAcumulado += parcelas[i];

                amortizacao = SaldoDevedor[0] / 360;

                /// Aredondamento:
                amortizacao = Math.Round(amortizacao, 2);
                juros[i] = Math.Round(juros[i], 2);
                parcelas[i] = Math.Round(parcelas[i], 2);
                SaldoDevedor[i] = Math.Round(SaldoDevedor[i], 2);
                jAcumulado = Math.Round(jAcumulado, 2);
                pAcumulado = Math.Round(pAcumulado, 2);

                /// Cria uma nova linha
                Linha = Tbl.NewRow();
                /// Coloca os dados em cada uma das colunas desta linha
                Linha[0] = i;
                Linha[1] = SaldoDevedor[i];
                Linha[2] = amortizacao;
                Linha[3] = juros[i];
                Linha[4] = parcelas[i];
                Linha[5] = jAcumulado;
                Linha[6] = pAcumulado;

                /// Adiciona a linha na tabela
                Tbl.Rows.Add(Linha);
            }
            Grid1.DataSource = Tbl;
        }
    }
}
