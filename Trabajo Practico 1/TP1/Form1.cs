using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class Form1 : Form
    {
        string operador;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperacion.SelectedIndex = -1;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);
            operador = cmbOperacion.Text;
            operador = Calculadora.validarOperador(operador);
            resultado = Calculadora.operar(numero1, numero2, operador);
            lblResultado.Text = resultado.ToString();
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            operador = cmbOperacion.Items.ToString();            
        }
    }
}
