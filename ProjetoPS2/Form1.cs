using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjetoPS2
{
    public partial class Form1 : Form
    {
        int TempoDaq = 0;
        double Fs = 1000;
        List<double> x = new List<double>();
        List<double> y = new List<double>();
        List<Complex> complex = new List<Complex>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearItems();

            if (validaFS())
            {
                ExecutaTransformada.Calcula(TempoDaq, Fs, x, y);

                chart1.Series.Clear();
                var series = new Series();

                int j = 0;
                foreach (double i in y)
                {
                    series.Points.AddXY(x[j], i);
                    complex.Add(new Complex((float)i, 0.0F));
                    j++;
                }

                chart1.Series.Add(series);

                Complex[] dft = Fourier.DFT(complex.ToArray());
                PlotGraph(dft);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearItems();

            if (validaFS())
            {
                ExecutaTransformada.Calcula(TempoDaq, Fs, x, y);

                chart1.Series.Clear();
                var series = new Series();

                int j = 0;
                foreach (double i in y)
                {
                    series.Points.AddXY(x[j], i);
                    complex.Add(new Complex((float)i, 0.0F));
                    j++;
                }

                chart1.Series.Add(series);

                double len = Math.Log(complex.Count, 2);

                if (len % 2 != 0)
                {
                    double tam = Math.Pow(2, Math.Ceiling(len));

                    for (int i = complex.Count; i < tam; i++)
                    {
                        complex.Add(new Complex(0, 0));
                    }
                }
                
                Complex[] fft = Fourier.FFT(complex.ToArray());
                PlotGraph(fft);
            }
        }

        private bool validaFS()
        {
            string textBox = textBox1.Text;
            bool validaFS = true;

            if (!int.TryParse(textBox, out TempoDaq))
            {
                MessageBox.Show("Insira um valor inteiro!");
                validaFS = false;
            }

            return validaFS;
        }

        private void ClearItems()
        {
            x.Clear();
            y.Clear();
            complex.Clear();
            TempoDaq = 0;
        }

        private void PlotGraph(Complex[] response)
        {
            this.chart2.Series.Clear();
            var series = new Series();

            for (int i = 0; i < response.Length; i++)
            {
                series.Points.AddXY((Fs / complex.Count) * i, (2.0 / complex.Count) * response[i].Magnitude());
            }

            chart2.Series.Add(series);

            chart2.ChartAreas[0].AxisX.Maximum = 100;
            chart2.ChartAreas[0].AxisX.Minimum = 0;

            MessageBox.Show("Concluído!");
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
