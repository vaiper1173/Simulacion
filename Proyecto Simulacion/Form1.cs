using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Proyecto_Simulacion
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        


        public double bd = 0;
        public double pc = 0;
        public double pc2 = 0;
        public double to = 0;
        public double cmb = 0;
        public double numeroAleatorio = 0;


        public void Tiempo()
        {

            //decicion de tiempo 
            if (bd < 0.1)
            {
                bd = 10;
            }
            if (bd > 0.1 && bd < 0.28)
            {
                bd = 15;
            }
            if (bd > 0.28 && bd < 0.5)
            {
                bd = 20;
            }
            if (bd > 0.5 && bd < 0.68)
            {
                bd = 25;
            }
            if (bd > 0.68 && bd < 0.78)
            {
                bd = 30;
            }
            if (bd > 0.78 && bd < 0.86)
            {
                bd = 35;
            }
            if (bd > 0.86 && bd < 0.92)
            {
                bd = 40;
            }
            if (bd > 0.92 && bd < 0.97)
            {
                bd = 45;
            }
            if (bd > 0.97 && bd < 1)
            {
                bd = 50;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmb = int.Parse(comboBox1.SelectedItem.ToString());


            //variables para la generacion de numeros 
            int X1 = Convert.ToInt16(textBox7.Text);
            int AA = Convert.ToInt16(textBox5.Text);
            int BB = Convert.ToInt16(textBox3.Text);
            int NN = Convert.ToInt16(textBox2.Text);

            int X0 = Convert.ToInt16(textBox8.Text);
            int A = Convert.ToInt16(textBox6.Text);
            int B = Convert.ToInt16(textBox4.Text);
            int N = Convert.ToInt16(textBox9.Text);

            for (int i = 0; i < cmb; i++)
            {
                //Calculo de Variables Pseudo-aleatorias
                X0 = (X0 * A + B) % N;
                numeroAleatorio = (double)X0 / N;
                textBox1.Text = $"{pc}";
                listBox1.Items.Add($"{numeroAleatorio}");

                //Asignacion de tiempo por variable

                bd = numeroAleatorio;
                Tiempo();
                listBox2.Items.Add(bd);
                pc = pc + bd - pc2;
                if (pc < 0)
                {
                    to = pc * -1;
                    pc = 0;
                }
                else
                {
                    to = 0;
                }
                listBox6.Items.Add(to);
                listBox3.Items.Add(pc);

                //Calculo de Variables Pseudo-aleatorias 2

                X1 = (X1 * AA + BB) % NN;
                double numeroAleatorio2 = (double)X1 / NN;

                //Asigancion de Tiempos por Variables 2
                bd = numeroAleatorio2;
                listBox4.Items.Add(bd);
                Tiempo();
                pc2 = bd;
                listBox5.Items.Add(bd);

                int ph = Convert.ToInt32(textBox1.Text);
                if (ph > 130 && ph < 250)
                {
                    label18.Text = "Hay una pequeña acumulacion de camiones";
                }
                if (ph > 250 && ph < 400)
                {
                    label18.Text = "Hay una acumulacion de camiones";
                }
                if (ph > 400)
                {
                    label18.Text = "Hay una peligrosa acumulacion de camiones";
                }
                if (ph < 130)
                {
                    label18.Text = " ";
                }

            }

        }
        public static string NewLine => "\r\n";


        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();

            bd = 0;
            pc = 0;
            pc2 = 0;
            to = 0;
            cmb = 0;
            numeroAleatorio = 0;
            label18.Text = " ";

        }
    }
}
