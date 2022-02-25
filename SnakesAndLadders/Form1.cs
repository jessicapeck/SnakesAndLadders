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

        int player1_game_piece_row = 9;
        int player1_game_piece_col = 9;
        int player1_position_num = 1;

        int player2_game_piece_row = 9;
        int player2_game_piece_col = 9;
        int player2_position_num = 1;


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
            pixel_width = game_board_panel.ClientSize.Width / num_cols;
            pixel_height = game_board_panel.ClientSize.Height / num_rows;

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

            for (int i = 0; i < num; i++)
            {
                update_game_piece_positions(player_num, 1);
                System.Threading.Thread.Sleep(500);
            }

        }

        private int get_game_piece_row(int position_num)
        {
            int game_piece_row;

            if (position_num % 10 == 0)
            {
                game_piece_row = 9 - ((position_num / 10) - 1);
            }
            else
            {
                game_piece_row = 9 - (position_num / 10);
            }
            
            return game_piece_row;
        }

        private int get_game_piece_col(int game_piece_row, int position_num)
        {
            int col_zero_num;
            int game_piece_col;
            
            if (game_piece_row % 2 == 1)
            {
                col_zero_num = (10 - game_piece_row) * 10;
                game_piece_col = col_zero_num - position_num;
                return game_piece_col;

            }
            else
            {
                col_zero_num = ((10 - (game_piece_row + 1)) * 10) + 1;
                game_piece_col = position_num - col_zero_num;
                return game_piece_col;
            }
        }

        private void update_game_piece_positions(int player_num, int dice_roll_num)
        {
            if (player_num == 1)
            {
                int new_player1_position_num = player1_position_num + dice_roll_num;
                move_description_label.ForeColor = Color.Blue;
                move_description_label.Text = ($"Player {player_num} has moved from position {player1_position_num} to {new_player1_position_num}.");
                player1_position_num = new_player1_position_num;

                player1_game_piece_row = get_game_piece_row(player1_position_num);
                player1_game_piece_col = get_game_piece_col(player1_game_piece_row, player1_position_num);

            }
            else if (player_num == 2)
            {
                int new_player2_position_num = player2_position_num + dice_roll_num;
                move_description_label.ForeColor = Color.Red;
                move_description_label.Text = ($"Player {player_num} has moved from position {player2_position_num} to {new_player2_position_num}.");
                player2_position_num = new_player2_position_num;

                player2_game_piece_row = get_game_piece_row(player2_position_num);
                player2_game_piece_col = get_game_piece_col(player2_game_piece_row, player2_position_num);
                
            }

            // TODO check if the player has landed on a snake or ladder and change position accordingly

            game_pieces_panel.Refresh();

        }

        private void game_pieces_panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics targetGraphics = e.Graphics;

            
            targetGraphics.FillEllipse(sb_blue, player1_game_piece_col * pixel_width, (player1_game_piece_row*pixel_height) + (pixel_height/2), pixel_width/3, pixel_height/3);
            targetGraphics.FillEllipse(sb_red, (player2_game_piece_col * pixel_width) + (pixel_width/2), (player2_game_piece_row * pixel_height) + (pixel_height/2), pixel_width/3, pixel_height/3);




        }
    }
}
