using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Blackjack
{

    public struct carte
    {
        public Image imag;
        public int val;
    };
    public partial class Form2 : Form
    {
        public int scor=0; //punctele 
        public int ok = 0; //stop/play muzica
        int i, nr = 0, nr2 = 0;
        Random rnd = new Random();
        int ran, ran2;
        int[] ap = new int[53];
        int[] ap2 = new int[53];
        carte[] c = new carte[53];
        carte[] c2 = new carte[53];
        public int sum = 0; //suma cartilor mele
        public int sum2 = 0;//suma cartilor inamicului
        PictureBox[] pb = new PictureBox[10];
        PictureBox[] pb2 = new PictureBox[10];
        int ok_reset = 0;

        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer(); //player-ul
        public Form2()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.Visible = false; //fac sa nu se vada pe form player-ul
            player.URL = "music.mp3"; //selectez muzica

            for (i = 1; i <= 52; i++)
                c[i].imag = Image.FromFile("image"+i+".png"); //pun cartile in vector

            for (i = 1; i <= 52; i++)
                c2[i].imag = Image.FromFile("image" + i + ".png"); //pun cartile in vector

            c[1].val = c[2].val = c[3].val = c[4].val = 11;     //
            c[5].val = c[6].val = c[7].val = c[8].val = 2;      //
            c[9].val = c[10].val = c[11].val = c[12].val = 3;   //
            c[13].val = c[14].val = c[15].val = c[16].val = 4;  //
            c[17].val = c[18].val = c[19].val = c[20].val = 5;  //
            c[21].val = c[22].val = c[23].val = c[24].val = 6;  //
            c[25].val = c[26].val = c[27].val = c[28].val = 7;  //setez valoarea cartilor
            c[29].val = c[30].val = c[31].val = c[32].val = 8;  //
            c[33].val = c[34].val = c[35].val = c[36].val = 9;  //
            c[37].val = c[38].val = c[39].val = c[40].val = 10; //
            c[41].val = c[42].val = c[43].val = c[44].val = 12; //
            c[45].val = c[46].val = c[47].val = c[48].val = 13; //
            c[49].val = c[50].val = c[51].val = c[52].val = 14; //


            c2[1].val = c2[2].val = c2[3].val = c2[4].val = 11;     //
            c2[5].val = c2[6].val = c2[7].val = c2[8].val = 2;      //
            c2[9].val = c2[10].val = c2[11].val = c2[12].val = 3;   //
            c2[13].val = c2[14].val = c2[15].val = c2[16].val = 4;  //
            c2[17].val = c2[18].val = c2[19].val = c2[20].val = 5;  //
            c2[21].val = c2[22].val = c2[23].val = c2[24].val = 6;  //
            c2[25].val = c2[26].val = c2[27].val = c2[28].val = 7;  //setez valoarea c2artilor
            c2[29].val = c2[30].val = c2[31].val = c2[32].val = 8;  //
            c2[33].val = c2[34].val = c2[35].val = c2[36].val = 9;  //
            c2[37].val = c2[38].val = c2[39].val = c2[40].val = 10; //
            c2[41].val = c2[42].val = c2[43].val = c2[44].val = 12; //
            c2[45].val = c2[46].val = c2[47].val = c2[48].val = 13; //
            c2[49].val = c2[50].val = c2[51].val = c2[52].val = 14; //

            pb[1] = pictureBox1;
            pb[2] = pictureBox2;
            pb[3] = pictureBox3;
            pb[4] = pictureBox4;
            pb[5] = pictureBox5;
            pb[6] = pictureBox6;
            pb[7] = pictureBox7;
            pb[8] = pictureBox8;
            pb[9] = pictureBox9;

            pb2[1] = pictureBox10;
            pb2[2] = pictureBox11;
            pb2[3] = pictureBox12;
            pb2[4] = pictureBox13;
            pb2[5] = pictureBox14;
            pb2[6] = pictureBox15;
            pb2[7] = pictureBox16;
            pb2[8] = pictureBox17;
            pb2[9] = pictureBox18;

            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

        }

        public void generare()
        {
            ran = rnd.Next(1, 53); //generaz o carte random pentru mine
            do                           //
            {                            //
                ran = rnd.Next(1, 53);   //ma asigura ca nu generez de 2 ori aceeasi carte
            } while (ap[ran] == 1);      //
            ap[ran] = 1;                 //
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); //inchid jocul de la X
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label3.Visible = false; //ai pierdut
            label4.Visible = false; //ai castigat
            label5.Visible = false; //remiza
            button3.Visible = false;
            label6.Visible = false;


            var pos = this.PointToScreen(label6.Location);  //
            pos = button3.PointToClient(pos);               //
            label6.Parent = button3;                        // pun labe-ul cu (spacebar) peste button3
            label6.Location = pos;                          //
            label6.BackColor = Color.Transparent;           //

            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;

            player.controls.play(); //pornesc muzica

            label1.BackColor = Color.Transparent; //fac background-ul de la label-ul cu numele meu transparent
            label2.BackColor = Color.Transparent; //fac background-ul de la label-ul cu numele robotului transparent

            label1.Text = Blackjack.nume.j_name+": "+scor; //actualizez scorul
        }

        private void ieșireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //inchid jocul de pe bara de meniu
        }

        //deschid meniul de pe bara de meniu
        private void meniuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            new Form1().Show();
        }

        private void sunetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ok++;
            if(ok%2==1)
                player.controls.pause();
            else
                player.controls.play();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            new Form2().Show();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                button3_Click(this, new EventArgs());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;

            while (sum2 < 16)
            {
                nr2++;
                ran2 = rnd.Next(1, 53); //generaz o carte random pentru inamic
                do                           //
                {                            //
                    ran2 = rnd.Next(1, 53);   //ma asigura ca nu generez de 2 ori aceeasi carte
                } while (ap2[ran2] == 1);      //
                ap2[ran2] = 1;                 //

                sum2 += c2[ran2].val;
                label2.Text = "Inamic: " + sum2.ToString();
                pb2[nr2].Visible = true;
                pb2[nr2].Image = c2[ran2].imag;
            }


            if (sum > 21 && sum2 <= 21)
            {
                label3.Visible = true;
                ok_reset = 1;
            }
            else
               if (sum <= 21 && sum2 > 21)
            {
                label4.Visible = true;
                ok_reset = 1;
            }
            else
                  if (sum < 21 && sum2 < 21)
            {
                int d1 = 21 - sum;
                int d2 = 21 - sum2;
                if (d1 < d2)
                {
                    label4.Visible = true;
                    ok_reset = 1;
                }
                else
                  if (d1 > d2)
                {
                    label3.Visible = true;
                    ok_reset = 1;
                }
                else
                {
                    label5.Visible = true;
                    ok_reset = 1;
                }
            }
            else
               if (sum == 21 && sum2 != 21)
            {
                label4.Visible = true;
                ok_reset = 1;
            }
            else
               if (sum2 == 21 && sum != 21)
            {
                label3.Visible = true;
                ok_reset = 1;
            }

            else
                if (sum > 21 && sum2 > 21)
            {
                label5.Visible = true;
                ok_reset = 1;
            }

            if (ok_reset == 1)
            {
                button3.Visible = true;
                label6.Visible = true;
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nr++;
            generare();
            pb[nr].Visible = true;
            pb[nr].Image = c[ran].imag;
            sum += c[ran].val;

            label1.Text = Blackjack.nume.j_name+": "+ sum.ToString();
        }
    }
}
