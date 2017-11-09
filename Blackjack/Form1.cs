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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); //inchid jocul de la X
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); //inchid jocul de la butonul Iesire
        }

        //deschid meniul
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Nume().Show();
        }

        //fac background-ul de la butonul Start transparent cand tin mouse-ul pe el respectiv cand dau click
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        }

        //fac background-ul de la butonul Iesire transparent cand tin mouse-ul pe el respectiv cand dau click
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
