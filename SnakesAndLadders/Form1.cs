using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakesAndLadders
{
    public partial class Form : System.Windows.Forms.Form
    {

        int num_rows = 10;
        int num_cols = 10;

        int pixel_width;
        int pixel_height;

        private SolidBrush sb_black = new SolidBrush(Color.Black);
        private SolidBrush sb_white = new SolidBrush(Color.White);
        private SolidBrush sb_blue = new SolidBrush(Color.Blue);
        private SolidBrush sb_red = new SolidBrush(Color.Red);

        

        public Form()
        {
            InitializeComponent();
            UI_setup();
        }

        private void UI_setup()
        {
            player1_roll_button.Enabled = true;

            player2_roll_button.Enabled = false;

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            pixel_width = panel.ClientSize.Width / num_cols;
            pixel_height = panel.ClientSize.Height / num_rows;

            Graphics targetGraphics = e.Graphics;


            int square_num = 101;

            for (int row_counter = 0; row_counter < num_cols; row_counter++)
            {
                square_num -= 10;

                for (int col_counter = 0; col_counter < num_rows; col_counter++)
                {
                    Color num_color = new Color();

                    if (((row_counter % 2 == 0) && (col_counter % 2 == 1)) || ((row_counter % 2 == 1) && (col_counter % 2 == 0)))
                    {
                        targetGraphics.FillRectangle(sb_black,col_counter * pixel_width, row_counter * pixel_height, pixel_width, pixel_height);

                        num_color = Color.White;                        
                    }
                    else
                    {
                        targetGraphics.FillRectangle(sb_white, col_counter * pixel_width, row_counter * pixel_height, pixel_width, pixel_height);

                        num_color = Color.Black;
                    }

                    using (Font font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        Point point = new Point(col_counter * pixel_width, row_counter * pixel_height);
                        TextRenderer.DrawText(e.Graphics, square_num.ToString(), font, point, num_color);
                    }

                    if (col_counter != num_cols - 1)
                    {
                        if (row_counter % 2 == 0)
                        {
                            square_num += 1;
                        }
                        else if (row_counter % 2 == 1)
                        {
                            square_num -= 1;
                        }
                    }
                }
            }

            
        }

        

        private void player1_roll_button_Click(object sender, EventArgs e)
        {
            player1_roll_button.Enabled = false;

            player2_roll_button.Enabled = true;

            generate_random_number(1);
        }

        private void player2_roll_button_Click(object sender, EventArgs e)
        {
            player2_roll_button.Enabled = false;


            player1_roll_button.Enabled = true;

            generate_random_number(2);
        }

        private void generate_random_number(int player_num)
        {
            Random random = new Random();
            int num = random.Next(1, 7);

            if (player_num == 1)
            {
                player1_num_label.Text = num.ToString();
            }
            else if (player_num == 2)
            {
                player2_num_label.Text = num.ToString();
            }

        }
    }
}
