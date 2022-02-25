﻿
namespace SnakesAndLadders
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.game_board_panel = new System.Windows.Forms.Panel();
            this.game_pieces_panel = new System.Windows.Forms.Panel();
            this.player1_label = new System.Windows.Forms.Label();
            this.player2_label = new System.Windows.Forms.Label();
            this.player1_roll_button = new System.Windows.Forms.Button();
            this.player2_roll_button = new System.Windows.Forms.Button();
            this.player1_num_label = new System.Windows.Forms.Label();
            this.player2_num_label = new System.Windows.Forms.Label();
            this.move_description_label = new System.Windows.Forms.Label();
            this.game_board_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // game_board_panel
            // 
            this.game_board_panel.BackColor = System.Drawing.Color.Red;
            this.game_board_panel.Controls.Add(this.game_pieces_panel);
            this.game_board_panel.Location = new System.Drawing.Point(0, 0);
            this.game_board_panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.game_board_panel.Name = "game_board_panel";
            this.game_board_panel.Size = new System.Drawing.Size(400, 400);
            this.game_board_panel.TabIndex = 0;
            this.game_board_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // game_pieces_panel
            // 
            this.game_pieces_panel.BackColor = System.Drawing.Color.Transparent;
            this.game_pieces_panel.Location = new System.Drawing.Point(2, 0);
            this.game_pieces_panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.game_pieces_panel.Name = "game_pieces_panel";
            this.game_pieces_panel.Size = new System.Drawing.Size(400, 400);
            this.game_pieces_panel.TabIndex = 7;
            this.game_pieces_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.game_pieces_panel_Paint);
            // 
            // player1_label
            // 
            this.player1_label.AutoSize = true;
            this.player1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1_label.ForeColor = System.Drawing.Color.Blue;
            this.player1_label.Location = new System.Drawing.Point(446, 19);
            this.player1_label.Name = "player1_label";
            this.player1_label.Size = new System.Drawing.Size(85, 24);
            this.player1_label.TabIndex = 1;
            this.player1_label.Text = "Player 1";
            // 
            // player2_label
            // 
            this.player2_label.AutoSize = true;
            this.player2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2_label.ForeColor = System.Drawing.Color.Red;
            this.player2_label.Location = new System.Drawing.Point(446, 190);
            this.player2_label.Name = "player2_label";
            this.player2_label.Size = new System.Drawing.Size(85, 24);
            this.player2_label.TabIndex = 2;
            this.player2_label.Text = "Player 2";
            // 
            // player1_roll_button
            // 
            this.player1_roll_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1_roll_button.Location = new System.Drawing.Point(423, 55);
            this.player1_roll_button.Name = "player1_roll_button";
            this.player1_roll_button.Size = new System.Drawing.Size(75, 38);
            this.player1_roll_button.TabIndex = 3;
            this.player1_roll_button.Text = "ROLL DICE";
            this.player1_roll_button.UseVisualStyleBackColor = true;
            this.player1_roll_button.Click += new System.EventHandler(this.player1_roll_button_Click);
            // 
            // player2_roll_button
            // 
            this.player2_roll_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2_roll_button.Location = new System.Drawing.Point(423, 230);
            this.player2_roll_button.Name = "player2_roll_button";
            this.player2_roll_button.Size = new System.Drawing.Size(75, 38);
            this.player2_roll_button.TabIndex = 4;
            this.player2_roll_button.Text = "ROLL DICE";
            this.player2_roll_button.UseVisualStyleBackColor = true;
            this.player2_roll_button.Click += new System.EventHandler(this.player2_roll_button_Click);
            // 
            // player1_num_label
            // 
            this.player1_num_label.AutoSize = true;
            this.player1_num_label.BackColor = System.Drawing.Color.White;
            this.player1_num_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player1_num_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1_num_label.Location = new System.Drawing.Point(504, 59);
            this.player1_num_label.Name = "player1_num_label";
            this.player1_num_label.Size = new System.Drawing.Size(21, 28);
            this.player1_num_label.TabIndex = 5;
            this.player1_num_label.Text = " ";
            // 
            // player2_num_label
            // 
            this.player2_num_label.AutoSize = true;
            this.player2_num_label.BackColor = System.Drawing.Color.White;
            this.player2_num_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player2_num_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2_num_label.Location = new System.Drawing.Point(504, 234);
            this.player2_num_label.Name = "player2_num_label";
            this.player2_num_label.Size = new System.Drawing.Size(21, 28);
            this.player2_num_label.TabIndex = 6;
            this.player2_num_label.Text = " ";
            // 
            // move_description_label
            // 
            this.move_description_label.AutoSize = true;
            this.move_description_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.move_description_label.Location = new System.Drawing.Point(24, 463);
            this.move_description_label.Name = "move_description_label";
            this.move_description_label.Size = new System.Drawing.Size(0, 31);
            this.move_description_label.TabIndex = 7;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.move_description_label);
            this.Controls.Add(this.player2_num_label);
            this.Controls.Add(this.player1_num_label);
            this.Controls.Add(this.player2_roll_button);
            this.Controls.Add(this.player1_roll_button);
            this.Controls.Add(this.player2_label);
            this.Controls.Add(this.player1_label);
            this.Controls.Add(this.game_board_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form";
            this.Text = "Snakes and Ladders";
            this.game_board_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel game_board_panel;
        private System.Windows.Forms.Label player1_label;
        private System.Windows.Forms.Label player2_label;
        private System.Windows.Forms.Button player1_roll_button;
        private System.Windows.Forms.Button player2_roll_button;
        private System.Windows.Forms.Label player1_num_label;
        private System.Windows.Forms.Label player2_num_label;
        private System.Windows.Forms.Panel game_pieces_panel;
        private System.Windows.Forms.Label move_description_label;
    }
}

