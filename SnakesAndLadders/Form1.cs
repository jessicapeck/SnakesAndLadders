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
    public partial class GameForm : System.Windows.Forms.Form
    {

        // declare the number of rows and columns in the panel
        int num_rows = 10;
        int num_cols = 10;

        // declare the integers pixel_width and pixel_height
        int pixel_width;
        int pixel_height;

        //declare starting positions for each player's game piece
        int player1_game_piece_row = 9;
        int player1_game_piece_col = 9;
        int player1_position_num = 1;

        int player2_game_piece_row = 9;
        int player2_game_piece_col = 9;
        int player2_position_num = 1;


        // declare different coloured brushes
        private SolidBrush sb_black = new SolidBrush(Color.Black);
        private SolidBrush sb_white = new SolidBrush(Color.White);
        private SolidBrush sb_blue = new SolidBrush(Color.Blue);
        private SolidBrush sb_red = new SolidBrush(Color.Red);

        

        public GameForm()
        {
            InitializeComponent();
            
            // setup the initial state of the UI
            UI_setup();
        }

        private void UI_setup()
        {
            // player 1 goes first --> player 1's button is enabled and player 2's button is disabled
            player1_roll_button.Enabled = true;
            player2_roll_button.Enabled = false;

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            // assign values to pixel_width and pixel_height
            pixel_width = game_board_panel.ClientSize.Width / num_cols;
            pixel_height = game_board_panel.ClientSize.Height / num_rows;

            Graphics targetGraphics = e.Graphics;

            int square_num = 101;

            // draw in alternate black and white panel squares
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

                    // write the number in the corner of each panel square
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
            // call method, pass the player number (1)
            generate_random_number(1);
        }

        private void player2_roll_button_Click(object sender, EventArgs e)
        {
            // call the method, pass the player number (2)
            generate_random_number(2);
        }

        private void generate_random_number(int player_num)
        {
            // declare integer variables
            int initial_position;
            int end_position;
            
            // generate random numbers
            Random random = new Random();
            int num = random.Next(1, 7);

            // work out the end position, show message in move_description_label
            if (player_num == 1)
            {
                player1_num_label.Text = num.ToString();
                initial_position = player1_position_num; 
                end_position = initial_position + num;

                move_description_label.ForeColor = Color.Blue;
                move_description_label.Text = ($"Player {player_num} has moved from {initial_position} to {end_position}.");


            }
            else if (player_num == 2)
            {
                player2_num_label.Text = num.ToString();
                initial_position = player2_position_num;
                end_position = initial_position + num;

                move_description_label.ForeColor = Color.Red;
                move_description_label.Text = ($"Player {player_num} has moved from {initial_position} to {end_position}.");


            }

            // refresh the form
            this.Refresh();

            // move player's game piece one square at a time
            for (int i = 0; i < num; i++)
            {
                update_game_piece_positions(player_num, 1);
                System.Threading.Thread.Sleep(500);
            }

            // swap enabled states of the dice roll buttons
            player1_roll_button.Enabled = !(player1_roll_button.Enabled);
            player2_roll_button.Enabled = !(player2_roll_button.Enabled);

        }

        // calculate and return the row number of the game piece using its position number
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

        // calculate and return the column number of the game piece using its row number and position number
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
                // update position number of game piece
                int new_player1_position_num = player1_position_num + dice_roll_num;
                player1_position_num = new_player1_position_num;

                // get the game piece's row number and column number
                player1_game_piece_row = get_game_piece_row(player1_position_num);
                player1_game_piece_col = get_game_piece_col(player1_game_piece_row, player1_position_num);

            }
            else if (player_num == 2)
            {
                // update the position number of the game piece
                int new_player2_position_num = player2_position_num + dice_roll_num;
                player2_position_num = new_player2_position_num;

                // get the game piece's row number and column number
                player2_game_piece_row = get_game_piece_row(player2_position_num);
                player2_game_piece_col = get_game_piece_col(player2_game_piece_row, player2_position_num);
                
            }

            // TODO check if the player has landed on a snake or ladder and change position accordingly

            // refresh the game piece panel
            game_pieces_panel.Refresh();

        }

        private void game_pieces_panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics targetGraphics = e.Graphics;
            
            // draw the game piece in its new position
            targetGraphics.FillEllipse(sb_blue, player1_game_piece_col * pixel_width, (player1_game_piece_row*pixel_height) + (pixel_height/2), pixel_width/3, pixel_height/3);
            targetGraphics.FillEllipse(sb_red, (player2_game_piece_col * pixel_width) + (pixel_width/2), (player2_game_piece_row * pixel_height) + (pixel_height/2), pixel_width/3, pixel_height/3);

        }
    }
}
