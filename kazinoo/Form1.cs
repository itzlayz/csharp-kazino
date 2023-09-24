using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kazinoo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int money = 30;
        string[] photos = { "алмаз.png", "вишня.png", "доллар.png" };
        Random rand = new Random();

        private void button1_Click(object sender, EventArgs e)
        { 
            string[] lots = { photos[rand.Next(0, 3)], photos[rand.Next(0, 3)], photos[rand.Next(0, 3)] };
            pictureBox1.Image = Image.FromFile(lots[0]);
            pictureBox2.Image = Image.FromFile(lots[1]);
            pictureBox3.Image = Image.FromFile(lots[2]);

            int almaz, vishnya, dollar;

            almaz = 0;
            vishnya = 0;
            dollar = 0;

            for (int i = 2; !(i==-1); i--)
            {
                if (lots[i] == "алмаз.png")
                {
                    almaz += 1;
                }else if (lots[i] == "вишня.png")
                {
                    vishnya += 1;
                }
                else if (lots[i] == "доллар.png")
                {
                    dollar += 1;
                }
            }

            if (almaz > 1)
            {
                if (almaz == 2)
                {
                    money += 100;
                }
                else
                {
                    money += almaz * 100;
                }
            }
            else if (vishnya > 1)
            {
                money += vishnya * 10;
            }
            else if (dollar > 1)
            {
                if (dollar == 3)
                {
                    money *= 2;
                }
                else
                { 
                    money = (money / 50) * 100;
                }
            }
            money -= 5;

            if (money < 5 && money <= 0)
            {
                // Проиграл
                Form2 lose = new Form2();
                lose.label1.Text = "лудоман бож, ты проиграл";
                lose.Show();
                this.Hide();
            }
            else
            {
                label1.Text = $"Счет: {money}";
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 won = new Form3();
            won.label1.Text = $"Ты выиграл {money} денек";
            won.Show();
            this.Hide();
        }
    }
}
