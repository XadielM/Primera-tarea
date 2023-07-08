using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        double Numero1 = 0, Numero2 = 0;
        char Operador;

        public Form1()
        {
            InitializeComponent();
        }

        private void agregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender); // Declarando variable del boton

            if (txtResultado.Text == "0")
                txtResultado.Text = "";

            txtResultado.Text += boton.Text;
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            Numero2 = Convert.ToDouble(txtResultado.Text);

            if (Operador == '+') //Suma
            {
                txtResultado.Text = (Numero1 + Numero2).ToString();
                Numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if(Operador == '-') //Resta
            {
                txtResultado.Text = (Numero1 - Numero2).ToString();
                Numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (Operador == 'x') //Multiplicacion
            {
                txtResultado.Text = (Numero1 * Numero2).ToString();
                Numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (Operador == '/') //Division
            {
                if(txtResultado.Text != "0")
                {
                    txtResultado.Text = (Numero1 / Numero2).ToString();
                    Numero1 = Convert.ToDouble(txtResultado.Text);
                }
                else
                {
                    MessageBox.Show("No se puede dividir por cero!!"); 
                    // Añadimos un mensaje en una box que da un cierto aviso

                }
             
            }

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if(txtResultado.Text.Length > 1)
            {
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }
            else
            {
                txtResultado.Text = "0";
            }
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            Numero1 = 0;
            Numero2 = 0;
            Operador ='\0'; // Para que sea caracter vacio
            txtResultado.Text = "0";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if(!txtResultado.Text.Contains(".")) // Si el resultado no tiene punto agregarle uno
            {
                txtResultado.Text += ".";
            }
        }

        private void btnSigno_Click_1(object sender, EventArgs e)
        {
            string texto = txtResultado.Text;

            if (texto.StartsWith("-"))
            {
                texto = texto.Substring(1);
            }
            else
            {
                texto = "-" + texto;
            }

            txtResultado.Text = texto;
        }

        private void clickOperador(object sender, EventArgs e)
        {
            var boton = ((Button)sender); // Declarando variable del boton
            Numero1 = Convert.ToDouble(txtResultado.Text);
            Operador = Convert.ToChar(boton.Tag); // Obteniendo el operador

            if (Operador == '²')
            {
                Numero1 = Math.Pow(Numero1, 2); //Operacion para numeros al cuadrado
                txtResultado.Text = Numero1.ToString();
            }
            else if (Operador == '√')
            {
                Numero1 = Math.Sqrt(Numero1); //Operacion matematica para raiz cuadrada
                txtResultado.Text = Numero1.ToString();
            }

            else
            {
                txtResultado.Text = "0";
            }
        }
       
    }
}
