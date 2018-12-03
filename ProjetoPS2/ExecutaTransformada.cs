using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPS2
{
    class ExecutaTransformada
    {
        public static void Calcula(int TempoDaq, double Fs, List<double> x, List<double> y)
        {
            //int TempoDaq = 5;
            //double Fs = 1000;
            double Ts = 0;

            Ts = 1 / Fs;

            int SinalAmpl1 = 1;
            double SinalFreqHz1 = 2 * Math.PI * 30;

            int SinalAmpl2 = 3;
            double SinalFreqHz2 = 2 * Math.PI * 50;

            int SinalAmpl3 = 2;
            double SinalFreqHz3 = 2 * Math.PI * 60;

            List<Complex> complex = new List<Complex>();

            for (double i = 0; i < TempoDaq; i += Ts)
            {
                x.Add(i);
            }

            for (int i = 0; i < x.Count; i++)
            {
                y.Add(SinalAmpl1 * Math.Sin(SinalFreqHz1 * x[i]) + SinalAmpl2 * Math.Sin(SinalFreqHz2 * x[i]) + SinalAmpl3 * Math.Sin(SinalFreqHz3 * x[i]));
            }
        }
    }
}
