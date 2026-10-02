using Pico_Park_Winform.Level;
using Pico_Park_Winform.Scene;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.GameObject
{
    public class pausePanel : UserControl
    {
        SoundPlayer soundPlayer = new SoundPlayer("./sound/click.wav");

        public pausePanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            return_game = new PictureBox();
            retry = new PictureBox();
            level_select = new PictureBox();
            title = new PictureBox();
            border = new PictureBox();
            exit = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)return_game).BeginInit();
            ((System.ComponentModel.ISupportInitialize)retry).BeginInit();
            ((System.ComponentModel.ISupportInitialize)level_select).BeginInit();
            ((System.ComponentModel.ISupportInitialize)title).BeginInit();
            ((System.ComponentModel.ISupportInitialize)border).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            //
            // return_game
            //
            return_game.Image = Properties.Resources._return;
            return_game.Location = new Point(96, 174);
            return_game.Name = "return_game";
            return_game.Size = new Size(322, 44);
            return_game.SizeMode = PictureBoxSizeMode.StretchImage;
            return_game.TabIndex = 1;
            return_game.TabStop = false;
            return_game.Click += return_game_Click;
            return_game.MouseEnter += return_game_MouseEnter;
            //
            // retry
            //
            retry.Image = Properties.Resources.retry;
            retry.Location = new Point(96, 249);
            retry.Name = "retry";
            retry.Size = new Size(322, 39);
            retry.SizeMode = PictureBoxSizeMode.StretchImage;
            retry.TabIndex = 2;
            retry.TabStop = false;
            retry.Click += retry_Click;
            retry.MouseEnter += retry_MouseEnter;
            //
            // level_select
            //
            level_select.Image = Properties.Resources.level_select;
            level_select.Location = new Point(96, 311);
            level_select.Name = "level_select";
            level_select.Size = new Size(322, 45);
            level_select.SizeMode = PictureBoxSizeMode.StretchImage;
            level_select.TabIndex = 3;
            level_select.TabStop = false;
            level_select.Click += level_select_Click;
            level_select.MouseEnter += level_select_MouseEnter;
            //
            // title
            //
            title.Image = Properties.Resources.lobby;
            title.Location = new Point(192, 376);
            title.Name = "title";
            title.Size = new Size(135, 42);
            title.SizeMode = PictureBoxSizeMode.StretchImage;
            title.TabIndex = 4;
            title.TabStop = false;
            title.Click += title_Click;
            title.MouseEnter += title_MouseEnter;
            //
            // border
            //
            border.BackColor = Color.White;
            border.Image = Properties.Resources.border;
            border.Location = new Point(80, 162);
            border.Name = "border";
            border.Size = new Size(355, 69);
            border.SizeMode = PictureBoxSizeMode.StretchImage;
            border.TabIndex = 5;
            border.TabStop = false;
            //
            // exit
            //
            exit.Image = Properties.Resources.exit;
            exit.Location = new Point(128, 438);
            exit.Name = "exit";
            exit.Size = new Size(251, 40);
            exit.SizeMode = PictureBoxSizeMode.StretchImage;
            exit.TabIndex = 6;
            exit.TabStop = false;
            exit.Click += exit_Click;
            exit.MouseEnter += exit_MouseEnter;
            //
            // pictureBox1
            //
            pictureBox1.Image = Properties.Resources.pause_panel;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(512, 533);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            //
            // pausePanel
            //
            BackColor = SystemColors.Control;
            Controls.Add(exit);
            Controls.Add(title);
            Controls.Add(level_select);
            Controls.Add(retry);
            Controls.Add(return_game);
            Controls.Add(border);
            Controls.Add(pictureBox1);
            Name = "pausePanel";
            Size = new Size(512, 533);
            ((System.ComponentModel.ISupportInitialize)return_game).EndInit();
            ((System.ComponentModel.ISupportInitialize)retry).EndInit();
            ((System.ComponentModel.ISupportInitialize)level_select).EndInit();
            ((System.ComponentModel.ISupportInitialize)title).EndInit();
            ((System.ComponentModel.ISupportInitialize)border).EndInit();
            ((System.ComponentModel.ISupportInitialize)exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private PictureBox return_game;
        private PictureBox retry;
        private PictureBox level_select;
        private PictureBox title;
        private PictureBox exit;
        private PictureBox pictureBox1;
        private PictureBox border;

        private void return_game_MouseEnter(object sender, EventArgs e)
        {
            border.Top = return_game.Top - 12;
        }

        private void retry_MouseEnter(object sender, EventArgs e)
        {
            border.Top = retry.Top - 12;
        }

        private void level_select_MouseEnter(object sender, EventArgs e)
        {
            border.Top = level_select.Top - 12;
        }

        private void title_MouseEnter(object sender, EventArgs e)
        {
            border.Top = title.Top - 12;
        }

        private void exit_MouseEnter(object sender, EventArgs e)
        {
            border.Top = exit.Top - 12;
        }

        private void return_game_Click(object sender, EventArgs e)
        {
            soundPlayer.Play();

            this.Enabled = false;
            this.Visible = false;
            StateController.isPause = false;
        }

        private void retry_Click(object sender, EventArgs e)
        {
            soundPlayer.Play();

            this.Enabled = false;
            this.Visible = false;
            StateController.isPause = false;

            switch (StateController.level_index)
            {
                case 0:
                    LobbyLoader.Load(StateController.panel);
                    break;
                case 1:
                    LevelOneLoader.Load(StateController.panel);
                    break;
                case 2:
                    LevelTwoLoader.Load(StateController.panel);
                    break;
                case 3:
                    LevelThreeLoader.Load(StateController.panel);
                    break;
                case 4:
                    LevelFourLoader.Load(StateController.panel);
                    break;
            }
        }

        private void level_select_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Visible = false;

            StateController.selectLevelPanel.updateRecord();

            StateController.selectLevelPanel.Enabled = true;
            StateController.selectLevelPanel.Visible = true;
            StateController.selectLevelPanel.BringToFront();

            soundPlayer.Play();
        }

        private void title_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Visible = false;
            StateController.isPause = false;

            soundPlayer.Play();

            LobbyLoader.Load(StateController.panel);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
