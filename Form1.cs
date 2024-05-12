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
