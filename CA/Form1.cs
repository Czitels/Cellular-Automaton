using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CA
{
    public partial class Form1 : Form
    {
        private string neighboor;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            neighboor = this.comboBox1.Text;
            Population PopAct = new Population();
            Population PopNew = new Population();
            Simulation sim = new Simulation();

            PopAct.height = int.Parse(textBox1.Text);
            PopNew.height = int.Parse(textBox1.Text);
            PopAct.width = int.Parse(textBox2.Text);
            PopNew.width = int.Parse(textBox2.Text);
            PopAct.setZeros();
            PopNew.setZeros();

            chooseNucleation(PopAct);
            sim.RozrostZiaren(PopAct.tablePop, PopNew.tablePop, PopAct.height, PopNew.width, formGraphics, PopAct.amountNucleos, neighboor);
            Console.ReadLine();            
        }
        private void chooseNucleation(Population PopAct)
        {
            string nucleationType = comboBox2.Text;
            switch (nucleationType)
            {
                case "homogeneous":
                    {
                        PopAct.homogenousNucleation(int.Parse(textBox4.Text), int.Parse(textBox5.Text));
                        break;
                    }
                case "random":
                    {
                        PopAct.randomNucleation(int.Parse(textBox3.Text));
                        break;
                    }
                default:
                    {
                        PopAct.randomNucleation(1);
                        break;
                    }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
               
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
