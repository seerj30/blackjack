using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class Nume : Form
    {
        public Nume()
        {
            InitializeComponent();
            textBox1.ForeColor = SystemColors.GrayText;           // setez sa am pe textbox-ul unde trebuie sa introduc numele, textul "Vă rugăm să vă introduceți numele:"
            textBox1.Text = "Vă rugăm să vă introduceți numele:"; // cu, culoarea GRI
        }

        private void Nume_Load(object sender, EventArgs e)
        {
            this.textBox1.Enter += new EventHandler(textBox1_Enter);  //apelez functia enter (explicata mai jos)
            this.textBox1.Leave += new EventHandler(textBox1_Leave); //apelez functia leave (explicata mai jos)
        }

        private void textBox1_Enter(object sender, EventArgs e)         //
        {                                                               //
            if (textBox1.Text == "Vă rugăm să vă introduceți numele:")  //
            {                                                           //cand apas click sa-mi introduc numele, se sterge textul implicit
                textBox1.Text = "";                                     //"Vă rugăm să vă introduceți numele:", fiind inlocuit cu sirul vid, iar textul pe care urmeaza
                textBox1.ForeColor = SystemColors.WindowText;           //sa-l introduc, adica numele, va avea culoarea NEAGRA, nu GRI
            }                                                           //
        }
        private void textBox1_Leave(object sender, EventArgs e)         //
        {                                                               //
            if (textBox1.Text.Length == 0)                              //
            {                                                           //pun inapoi textul "Vă rugăm să vă introduceți numele:" daca nu sunt pe textbox1
                textBox1.Text = "Vă rugăm să vă introduceți numele:";   //(daca focus-ul nu e pe el)
                textBox1.ForeColor = SystemColors.GrayText;             //
            }                                                           //
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox1.Text == "Vă rugăm să vă introduceți numele:")
                MessageBox.Show("Vă rugăm să vă introduceți numele !", "Atenție !", MessageBoxButtons.OK, MessageBoxIcon.Warning); //il oblic sa-si introduca numele
            else
            {
                Blackjack.nume.j_name = textBox1.Text; //salvez numele in variabila j_name care va urma sa o afisez pe label1
                this.Hide();
                new Form2().Show();
            }
        }

        private void Nume_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); //inchid jocul de la X
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)                //pot sa dau enter dupa ce si-a introdus numele si face acelasi lucru ca si cand as da click pe button1
                button1_Click(this, new EventArgs());   //mai exact, acelasi lucru ca si functia "button1_Click"
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back); //nu il las sa introduca altceva, decat LITERE
        }


    }
}