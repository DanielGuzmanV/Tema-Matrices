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
