using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakesAndLadders
{
    public partial class SnakesAndLadders : Form
    {

        // declare the number of rows and columns in the panel
        // NOTE TO DEVELOPER : if changing num_rows or num_cols, must make sure that they are even
        int num_rows = 10;
        int num_cols = 10;

        // declare the integers pixel_width and pixel_height
        int pixel_width;
        int pixel_height;

        //declare starting positions for each player's game piece
        int player1_game_piece_row;
        int player1_game_piece_col;
        int player1_position_num;

        int player2_game_piece_row;
        int player2_game_piece_col;
        int player2_position_num;

        List<int> snake_heads = new List<int>() { };
        List<int> snake_tails = new List<int>() { };

        List<int> ladder_tops = new List<int>() { };
        List<int> ladder_bottoms = new List<int>() { };

        // declare different coloured brushes
        private SolidBrush sb_black = new SolidBrush(Color.Black);
        private SolidBrush sb_white = new SolidBrush(Color.White);
        private SolidBrush sb_blue = new SolidBrush(Color.Blue);
        private SolidBrush sb_red = new SolidBrush(Color.Red);

        private Pen pen_green = new Pen(Color.Green, 10);
        private Pen pen_brown = new Pen(Color.SaddleBrown, 10);
        

        public GameForm()
        {
            InitializeComponent();

            //declare starting positions for each player's game piece
            player1_game_piece_row = num_rows - 1;
            player1_game_piece_col = num_cols - 1;
            player1_position_num = 1;

            player2_game_piece_row = num_rows - 1;
            player2_game_piece_col = num_cols - 1;
            player2_position_num = 1;

            // setup the initial state of the UI
            UI_setup();
            create_snakes_and_ladders();
        }

        private void UI_setup()
        {
            // player 1 goes first --> player 1's button is enabled and player 2's button is disabled
            player1_roll_button.Enabled = true;
            player2_roll_button.Enabled = false;

        }

        private void create_snakes_and_ladders()
        {
            Random random = new Random();

            for (var i = 0; i < 3; i++)
            {
                int snake_head = random.Next(num_rows * 2, (num_rows * num_cols));
                while (snake_heads.Contains(snake_head) || snake_tails.Contains(snake_head) || ladder_tops.Contains(snake_head) || ladder_bottoms.Contains(snake_head))
                {
                    snake_head = random.Next(num_rows * 2, (num_rows * num_cols));
                }
                snake_heads.Add(snake_head);

                int snake_tail = random.Next(2, (num_rows * num_cols) - num_cols);
                while ( snake_tail > snake_head ||snake_heads.Contains(snake_tail) || snake_tails.Contains(snake_tail) || ladder_tops.Contains(snake_tail) || ladder_bottoms.Contains(snake_tail) || get_row(snake_head) == get_row(snake_tail) || get_col(get_row(snake_head),snake_head) == get_col(get_row(snake_tail),snake_tail))
                {
                    snake_tail = random.Next(2, (num_rows * num_cols) - num_cols);
                }
                snake_tails.Add(snake_tail);

                int ladder_top = random.Next(num_rows * 2, (num_rows * num_cols));
                while (snake_heads.Contains(ladder_top) || snake_tails.Contains(ladder_top) || ladder_tops.Contains(ladder_top) || ladder_bottoms.Contains(ladder_top))
                {
                    ladder_top = random.Next(num_rows * 2, (num_rows * num_cols));
                }
                ladder_tops.Add(ladder_top);

                int ladder_bottom = random.Next(2, (num_rows * num_cols) - num_cols);
                while (ladder_bottom > ladder_top || snake_heads.Contains(ladder_bottom) || snake_tails.Contains(ladder_bottom) || ladder_tops.Contains(ladder_bottom) || ladder_bottoms.Contains(ladder_bottom) || get_row(ladder_top) == get_row(ladder_bottom) || get_col(get_row(ladder_top), ladder_top) == get_col(get_row(ladder_bottom), ladder_bottom))
                {
                    ladder_bottom = random.Next(2, (num_rows * num_cols) - num_cols);
                }
                ladder_bottoms.Add(ladder_bottom);
            }

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            // assign values to pixel_width and pixel_height
            pixel_width = game_board_panel.ClientSize.Width / num_cols;
            pixel_height = game_board_panel.ClientSize.Height / num_rows;

            Graphics targetGraphics = e.Graphics;

            int square_num = (num_cols * num_rows) + 1;

            // draw in alternate black and white panel squares
            for (int row_counter = 0; row_counter < num_cols; row_counter++)
            {
                square_num -= num_cols;

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

            for (int count = 0; count < 3; count++)
            {
                Point snake_head_point = get_point(count, snake_heads);
                Point snake_tail_point = get_point(count, snake_tails);
                targetGraphics.DrawLine(pen_green, snake_head_point, snake_tail_point);

                Point ladder_top_point = get_point(count, ladder_tops);
                Point ladder_bottom_point = get_point(count, ladder_bottoms);
                targetGraphics.DrawLine(pen_brown, ladder_top_point, ladder_bottom_point);
            }

        }        

        private void player1_roll_button_Click(object sender, EventArgs e)
        {
            // call method, pass the player number (1)
            roll_dice_then_move(1);
        }

        private void player2_roll_button_Click(object sender, EventArgs e)
        {
            // call the method, pass the player number (2)
            roll_dice_then_move(2);
            
        }

        private void roll_dice_then_move(int player_num)
        {
            // declare integer variables
            int initial_position;
            int end_position;
            
            // generate random numbers
            Random random = new Random();
            int num = random.Next(1, 7);

            if (player_num == 1)
            {
                player1_num_label.Text = num.ToString();
                initial_position = player1_position_num;

                move_description_label.ForeColor = Color.Blue;

            }
            else
            {
                player2_num_label.Text = num.ToString();
                initial_position = player2_position_num;

                move_description_label.ForeColor = Color.Red;

            }

            end_position = initial_position + num;
            if (end_position > 100)
            {
                end_position = 100;
            }

            

            // show message in move_description_label
            move_description_label.Text = ($"Player {player_num} has moved from {initial_position} to {end_position}.");

            // refresh the form
            this.Refresh();

            int position_num;

            // move player's game piece one square at a time
            for (int i = 0; i < num; i++)
            {

                position_num = update_game_piece_positions(player_num, 1);
                System.Threading.Thread.Sleep(500);

                if (position_num == 100)
                {
                    end_sequence(player_num);
                    return;
                }

                

                if (i == num - 1)
                {
                    while (snake_heads.Contains(position_num) || ladder_bottoms.Contains(position_num))
                    {
                        if (snake_heads.Contains(position_num))
                        {
                            int index = snake_heads.IndexOf(position_num);
                            int move_back = snake_tails[index] - position_num;
                            position_num = update_game_piece_positions(player_num, move_back);

                            move_description_label.Text = ($"Player {player_num} has moved from {snake_heads[index]} to {snake_tails[index]}");
                        }

                        if (ladder_bottoms.Contains(position_num))
                        {
                            int index = ladder_bottoms.IndexOf(position_num);
                            int move_forward = ladder_tops[index] - position_num;
                            position_num = update_game_piece_positions(player_num, move_forward);

                            move_description_label.Text = ($"Player {player_num} has moved from {ladder_bottoms[index]} to {ladder_tops[index]}");
                        }

                    }
                }
            }

                     



            // swap enabled states of the dice roll buttons
            player1_roll_button.Enabled = !(player1_roll_button.Enabled);
            player2_roll_button.Enabled = !(player2_roll_button.Enabled);

        }

        private void end_sequence(int player_num)
        {
            move_description_label.Text = ($"Player {player_num} WINS!");
            player1_roll_button.Enabled = false;
            player2_roll_button.Enabled = false;            
        }
        
        // calculate and return the row number of the game piece using its position number
        private int get_row(int position_num)
        {
            int game_piece_row;

            if (position_num % num_rows == 0)
            {
                game_piece_row = 9 - ((position_num / num_rows) - 1);
            }
            else
            {
                game_piece_row = 9 - (position_num / num_rows);
            }
            
            return game_piece_row;
        }

        // calculate and return the column number of the game piece using its row number and position number
        private int get_col(int game_piece_row, int position_num)
        {
            int col_zero_num;
            int game_piece_col;
            
            if (game_piece_row % 2 == 1)
            {
                col_zero_num = (num_rows - game_piece_row) * num_rows;
                game_piece_col = col_zero_num - position_num;
                return game_piece_col;

            }
            else
            {
                col_zero_num = ((num_rows - (game_piece_row + 1)) * num_rows) + 1;
                game_piece_col = position_num - col_zero_num;
                return game_piece_col;
            }
        }

        private int update_game_piece_positions(int player_num, int dice_roll_num)
        {
            
            if (player_num == 1)
            {
                // update position number of game piece
                int new_player1_position_num = player1_position_num + dice_roll_num;
                player1_position_num = new_player1_position_num;

                // get the game piece's row number and column number
                player1_game_piece_row = get_row(player1_position_num);
                player1_game_piece_col = get_col(player1_game_piece_row, player1_position_num);

            }
            else if (player_num == 2)
            {
                // update the position number of the game piece
                int new_player2_position_num = player2_position_num + dice_roll_num;
                player2_position_num = new_player2_position_num;


                // get the game piece's row number and column number
                player2_game_piece_row = get_row(player2_position_num);
                player2_game_piece_col = get_col(player2_game_piece_row, player2_position_num);
                
            }


            // refresh the game piece panel
            game_pieces_panel.Refresh();

            if (player_num == 1)
            {
                return player1_position_num;
            }
            else
            {
                return player2_position_num;
            }
        }

        private Point get_point(int count, List<int> items)
        {
            int position_num = items[count];
            int position_row = get_row(position_num);
            int position_col = get_col(position_row, position_num);
            Point point = new Point((position_col * pixel_width) + (pixel_width / 2), (position_row * pixel_height) + (pixel_height / 2));

            return point;
        }

        private void game_pieces_panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics targetGraphics = e.Graphics;
            
            // draw the game piece in its new position
            targetGraphics.FillEllipse(sb_blue, player1_game_piece_col * pixel_width, (player1_game_piece_row*pixel_height) + (pixel_height/2), pixel_width/3, pixel_height/3);
            targetGraphics.FillEllipse(sb_red, (player2_game_piece_col * pixel_width) + (pixel_width/2), (player2_game_piece_row * pixel_height) + (pixel_height/2), pixel_width/3, pixel_height/3);

                       

        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            // to prevent panel flickering
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, game_board_panel, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, game_pieces_panel, new object[] { true });
        }
    }
}
