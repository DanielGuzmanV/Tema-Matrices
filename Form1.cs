using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace temaMatrices
{
    public partial class Form1 : Form
    {
        classMatriz objM1, objM2, objM3, objM4;

        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox5.Text = objM1.getDate();
        }

        private void serieMatrizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM1.cargarSerie(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            textBox5.Text = objM1.getDate();
        }

        private void proMedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox6.Text = string.Concat(objM1.proMedio());
        }

        private void numeroMaximoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox6.Text = string.Concat(objM1.numberMaximo());
        }

        private void cargarAbajoArribaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM1.cargarAbjArr(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            textBox5.Text = objM1.getDate();
        }

        private void cargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objM2.setDateRandom(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void cargarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            objM3.setDateRandom(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void descargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox7.Text = objM2.getDate();
        }

        private void descargarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            textBox8.Text = objM3.getDate();
        }

        private void cargarSerieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM2.cargarSerie(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            textBox7.Text = objM2.getDate();
        }

        private void cargarSerieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objM3.cargarSerie(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            textBox8.Text = objM3.getDate();
        }

        private void cargarAbjArrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM2.cargarAbjArr(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            textBox7.Text = objM2.getDate();
        }

        private void cargarAbjArrToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objM3.cargarAbjArr(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            textBox8.Text = objM3.getDate();
        }

        private void sumaDeMatricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM1.sumaMatriz(objM2, ref objM3);

        }

        private void multimatricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int fil1, col1, fil2, col2;
            fil1 = 0; col1 = 0; fil2 = 0; col2 = 0;

            objM1.ReturnDimension(ref fil1, ref col1);
            objM2.ReturnDimension(ref fil2, ref col2);

            if (col1 == fil2)
            {
                objM1.multiplicarMatriz(objM2, ref objM3);
                textBox8.Text = objM3.getDate();
            }
            else
            {
                textBox8.Text = "Revise las dimensiones de la matriz";
            }

        }

        private void busquedaDeElemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox6.Text = string.Concat(objM1.busquedaElem(int.Parse(textBox1.Text)));
        }

        private void busqEleXFilYColToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int fila, colum;
            fila = 0; colum = 0;
            objM1.busquedaElem2(int.Parse(textBox1.Text), ref fila, ref colum);
            textBox6.Text = string.Concat("la fila es: " + fila + " la columa es: " + colum);

        }

        private void verfiAprobadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox6.Text = string.Concat(objM1.verifAprobado());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objM1 = new classMatriz();
            objM2 = new classMatriz();
            objM3 = new classMatriz();
            objM4 = new classMatriz();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM1.setDateRandom(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }
    }
}
