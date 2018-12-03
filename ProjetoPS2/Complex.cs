using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPS2
{
    class Complex
    {
        public double real = 0;
        public double imag = 0;

        public Complex()
        {
        }

        public Complex(double real, double imag)
        {
            this.real = real;
            this.imag = imag;
        }

        public string ToString()
        {
            string data = real.ToString() + " " + imag.ToString() + "i";
            return data;
        }

        //Converte de polar para retangular
        public static Complex From_polar(double r, double radians)
        {
            Complex data = new Complex(r * Math.Cos(radians), r * Math.Sin(radians));
            return data;
        }
        //Soma de Complexos
        public static Complex operator +(Complex a, Complex b)
        {
            Complex data = new Complex(a.real + b.real, a.imag + b.imag);
            return data;
        }
        //Subtração de Complexos
        public static Complex operator -(Complex a, Complex b)
        {
            Complex data = new Complex(a.real - b.real, a.imag - b.imag);
            return data;
        }
        //Multiplicação de Complexos
        public static Complex operator *(Complex a, Complex b)
        {
            Complex data = new Complex((a.real * b.real) - (a.imag * b.imag), (a.real * b.imag + (a.imag * b.real)));

            return data;
        }
        //Magnitude de um numero imaginario
        public double Magnitude()
        {
            return Math.Sqrt(Math.Pow(real, 2) + Math.Pow(imag, 2));
        }

        //Fase de um numero imaginario
        public double Phase()
        {
            return Math.Atan(imag / real);
        }
    }
}
