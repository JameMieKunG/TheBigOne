using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheBigOne
{
    public partial class Form1 : Form
    {
        int player_score = 0;
        int bot_score = 0;
        int[] bot_number;
        public Form1()
        {
            InitializeComponent();
            butt_disable();
        }
        public void butt_disable() //ปิดปุ่มทั้งหมด
        {
            //player
            player_1.Enabled = false;
            player_2.Enabled = false;
            player_3.Enabled = false;
            player_4.Enabled = false;
            player_5.Enabled = false;
            player_6.Enabled = false;
            player_7.Enabled = false;
            player_8.Enabled = false;
            player_9.Enabled = false;
            player_10.Enabled = false;
            player_11.Enabled = false;
            player_12.Enabled = false;
            player_13.Enabled = false;
            player_14.Enabled = false;
            player_15.Enabled = false;

            //bot
            bot_1.Enabled = false;
            bot_2.Enabled = false;
            bot_3.Enabled = false;
            bot_4.Enabled = false;
            bot_5.Enabled = false;
            bot_6.Enabled = false;
            bot_7.Enabled = false;
            bot_8.Enabled = false;
            bot_9.Enabled = false;
            bot_10.Enabled = false;
            bot_11.Enabled = false;
            bot_12.Enabled = false;
            bot_13.Enabled = false;
            bot_14.Enabled = false;
            bot_15.Enabled = false;
        }
        public void butt_enabled() //เปิดปุ่มทั้งหมด
        {
            //player
            player_1.Enabled = true;
            player_2.Enabled = true;
            player_3.Enabled = true;
            player_4.Enabled = true;
            player_5.Enabled = true;
            player_6.Enabled = true;
            player_7.Enabled = true;
            player_8.Enabled = true;
            player_9.Enabled = true;
            player_10.Enabled = true;
            player_11.Enabled = true;
            player_12.Enabled = true;
            player_13.Enabled = true;
            player_14.Enabled = true;
            player_15.Enabled = true;

            //bot
            bot_1.Enabled = true;
            bot_2.Enabled = true;
            bot_3.Enabled = true;
            bot_4.Enabled = true;
            bot_5.Enabled = true;
            bot_6.Enabled = true;
            bot_7.Enabled = true;
            bot_8.Enabled = true;
            bot_9.Enabled = true;
            bot_10.Enabled = true;
            bot_11.Enabled = true;
            bot_12.Enabled = true;
            bot_13.Enabled = true;
            bot_14.Enabled = true;
            bot_15.Enabled = true;
        }
        public void player_win() //แสดง Player Win , เพิ่ม Score Player , Update แสดง Score
        {
            player_win_la.Visible = true;
            player_score++;
            player_score_show.Text = Convert.ToString(player_score);
        }
        public void bot_win() //เหมือนอันบนแต่เป็น Bot
        {
            bot_win_la.Visible = true;
            bot_score++;
            bot_score_show.Text = Convert.ToString(bot_score);
        }
        public void tie_win() //แสดงเสมอ
        {
            tie_win_la.Visible = true;
        }
        public int random_bot(int player_pick) // สุ่มบอท + เช็คคะแนน player_pick = ปุ่ม (เลขที่ผู้เล่นเลือก)
        {
            bot_win_la.Visible = false;
            player_win_la.Visible = false;
            tie_win_la.Visible = false;
            if(bot_number.Length == 1)
            {
                start_butt.Enabled = true;
                start_butt.Text = "Play Again";
                butt_disable();
            }
            Random rand = new Random();
            int bot_random = rand.Next(0, bot_number.Length);
            int bot_pick = bot_number[bot_random];
            if (player_pick == 1 && bot_pick == 15) player_win();
            else if (player_pick == 15 && bot_pick == 1) bot_win();
            else if (player_pick == bot_pick) tie_win();
            else if (player_pick > bot_pick) player_win();
            else if (player_pick < bot_pick) bot_win();
            player_bet.Text = Convert.ToString(player_pick);
            bot_bet.Text = Convert.ToString(bot_pick);
            switch (bot_number[bot_random]) // ปิดปุ่มบอท
            {
                case 1:
                    bot_1.Enabled = false;
                    break;
                case 2:
                    bot_2.Enabled = false;
                    break;
                case 3:
                    bot_3.Enabled = false;
                    break;
                case 4:
                    bot_4.Enabled = false;
                    break;
                case 5:
                    bot_5.Enabled = false;
                    break;
                case 6:
                    bot_6.Enabled = false;
                    break;
                case 7:
                    bot_7.Enabled = false;
                    break;
                case 8:
                    bot_8.Enabled = false;
                    break;
                case 9:
                    bot_9.Enabled = false;
                    break;
                case 10:
                    bot_10.Enabled = false;
                    break;
                case 11:
                    bot_11.Enabled = false;
                    break;
                case 12:
                    bot_12.Enabled = false;
                    break;
                case 13:
                    bot_13.Enabled = false;
                    break;
                case 14:
                    bot_14.Enabled = false;
                    break;
                case 15:
                    bot_15.Enabled = false;
                    break;

            }
            bot_number = bot_number.Where(val => val != bot_number[bot_random]).ToArray();
            if (bot_number.Length == 0) //ถ้า Array เหลือ 0 จบเกม
            {
                bot_win_la.Visible = false;
                player_win_la.Visible = false;
                tie_win_la.Visible = false;
                if (player_score > bot_score) end_label.Text = "END GAME PLAYER WIN!";
                else if (player_score < bot_score) end_label.Text = "END GAME BOT WIN!";
                else end_label.Text = "END GAME TIE!";
                end_label.Visible = true;
            }

            return 1;
        }
        int lol = 100;
        public void push_array()
        {
            bot_number = new int[15];
            int i = 1;
            while(i <= 15)
            {
                bot_number[i - 1] = i;
                i++;
                if (i < 15) lol = 150;
            }
        }
        private void start_butt_Click(object sender, EventArgs e)
        {
            start_butt.Enabled = false;
            player_score = 0;
            bot_score = 0;
            bot_win_la.Visible = false;
            player_win_la.Visible = false;
            tie_win_la.Visible = false;
            end_label.Visible = false;
            bot_number = new int[15];
            push_array();
            while (lol < 160)
            {
                if(lol == 150) butt_enabled(); break;
            }
        }

        private void player_1_Click(object sender, EventArgs e)
        {
            random_bot(1);
            player_1.Enabled = false;

        }

        private void player_2_Click(object sender, EventArgs e)
        {
            random_bot(2);
            player_2.Enabled = false;
        }

        private void player_3_Click(object sender, EventArgs e)
        {
            random_bot(3);
            player_3.Enabled = false;
        }

        private void player_4_Click(object sender, EventArgs e)
        {
            random_bot(4);
            player_4.Enabled = false;
        }

        private void player_5_Click(object sender, EventArgs e)
        {
            random_bot(5);
            player_5.Enabled = false;
        }

        private void player_6_Click(object sender, EventArgs e)
        {
            random_bot(6);
            player_6.Enabled = false;
        }

        private void player_7_Click(object sender, EventArgs e)
        {
            random_bot(7);
            player_7.Enabled = false;
        }

        private void player_8_Click(object sender, EventArgs e)
        {
            random_bot(8);
            player_8.Enabled = false;
        }

        private void player_9_Click(object sender, EventArgs e)
        {
            random_bot(9);
            player_9.Enabled = false;
        }

        private void player_10_Click(object sender, EventArgs e)
        {
            random_bot(10);
            player_10.Enabled = false;
        }

        private void player_11_Click(object sender, EventArgs e)
        {
            random_bot(11);
            player_11.Enabled = false;
        }

        private void player_12_Click(object sender, EventArgs e)
        {
            random_bot(12);
            player_12.Enabled = false;
        }

        private void player_13_Click(object sender, EventArgs e)
        {
            random_bot(13);
            player_13.Enabled = false;
        }

        private void player_14_Click(object sender, EventArgs e)
        {
            random_bot(14);
            player_14.Enabled = false;
        }

        private void player_15_Click(object sender, EventArgs e)
        {
            random_bot(15);
            player_15.Enabled = false;
        }
    }
}
