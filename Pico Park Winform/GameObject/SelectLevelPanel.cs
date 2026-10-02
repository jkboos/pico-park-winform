using Pico_Park_Winform.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Diagnostics;

namespace Pico_Park_Winform.GameObject
{
    public class SelectLevelPanel : UserControl
    {
        SoundPlayer soundPlayer = new SoundPlayer("./sound/click.wav");
        string jsonPath = "./record.json";
        string[] levels_name = new string[] { "level_1", "level_2", "level_3", "level_4" };
        PictureBox[] crowns = new PictureBox[4];
        public SelectLevelPanel()
        {
            InitializeComponent();

            crowns[0] = crown_1;
            crowns[1] = crown_2;
            crowns[2] = crown_3;
            crowns[3] = crown_4;
        }

        private void InitializeComponent()
        {
            level_1 = new PictureBox();
            level_2 = new PictureBox();
            level_3 = new PictureBox();
            level_4 = new PictureBox();
            crown_1 = new PictureBox();
            crown_2 = new PictureBox();
            crown_3 = new PictureBox();
            crown_4 = new PictureBox();
            border = new PictureBox();
            line = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)level_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)level_2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)level_3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)level_4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)crown_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)crown_2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)crown_3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)crown_4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)border).BeginInit();
            ((System.ComponentModel.ISupportInitialize)line).BeginInit();
            SuspendLayout();
            //
            // level_1
            //
            level_1.Image = Properties.Resources.one;
            level_1.Location = new Point(161, 386);
            level_1.Name = "level_1";
            level_1.Size = new Size(300, 300);
            level_1.SizeMode = PictureBoxSizeMode.StretchImage;
            level_1.TabIndex = 0;
            level_1.TabStop = false;
            level_1.Tag = "select_level";
            level_1.Click += level_1_Click;
            level_1.MouseEnter += level_1_MouseEnter;
            //
            // level_2
            //
            level_2.Image = Properties.Resources.two;
            level_2.Location = new Point(594, 386);
            level_2.Name = "level_2";
            level_2.Size = new Size(300, 300);
            level_2.SizeMode = PictureBoxSizeMode.StretchImage;
            level_2.TabIndex = 1;
            level_2.TabStop = false;
            level_2.Click += level_2_Click;
            level_2.MouseEnter += level_2_MouseEnter;
            //
            // level_3
            //
            level_3.Image = Properties.Resources.three;
            level_3.Location = new Point(1034, 386);
            level_3.Name = "level_3";
            level_3.Size = new Size(300, 300);
            level_3.SizeMode = PictureBoxSizeMode.StretchImage;
            level_3.TabIndex = 2;
            level_3.TabStop = false;
            level_3.Click += level_3_Click;
            level_3.MouseEnter += level_3_MouseEnter;
            //
            // level_4
            //
            level_4.Image = Properties.Resources.four;
            level_4.Location = new Point(1475, 386);
            level_4.Name = "level_4";
            level_4.Size = new Size(300, 300);
            level_4.SizeMode = PictureBoxSizeMode.StretchImage;
            level_4.TabIndex = 3;
            level_4.TabStop = false;
            level_4.Click += level_4_Click;
            level_4.MouseEnter += level_4_MouseEnter;
            //
            // crown_1
            //
            crown_1.Image = Properties.Resources.crown;
            crown_1.Location = new Point(250, 238);
            crown_1.Name = "crown_1";
            crown_1.Size = new Size(120, 94);
            crown_1.SizeMode = PictureBoxSizeMode.StretchImage;
            crown_1.TabIndex = 4;
            crown_1.TabStop = false;
            //
            // crown_2
            //
            crown_2.Image = Properties.Resources.crown;
            crown_2.Location = new Point(687, 238);
            crown_2.Name = "crown_2";
            crown_2.Size = new Size(120, 94);
            crown_2.SizeMode = PictureBoxSizeMode.StretchImage;
            crown_2.TabIndex = 5;
            crown_2.TabStop = false;
            //
            // crown_3
            //
            crown_3.Image = Properties.Resources.crown;
            crown_3.Location = new Point(1128, 238);
            crown_3.Name = "crown_3";
            crown_3.Size = new Size(120, 94);
            crown_3.SizeMode = PictureBoxSizeMode.StretchImage;
            crown_3.TabIndex = 6;
            crown_3.TabStop = false;
            //
            // crown_4
            //
            crown_4.Image = Properties.Resources.crown;
            crown_4.Location = new Point(1559, 238);
            crown_4.Name = "crown_4";
            crown_4.Size = new Size(120, 94);
            crown_4.SizeMode = PictureBoxSizeMode.StretchImage;
            crown_4.TabIndex = 7;
            crown_4.TabStop = false;
            //
            // border
            //
            border.Image = Properties.Resources.border2;
            border.Location = new Point(110, 338);
            border.Name = "border";
            border.Size = new Size(400, 400);
            border.SizeMode = PictureBoxSizeMode.StretchImage;
            border.TabIndex = 8;
            border.TabStop = false;
            //
            // line
            //
            line.BackColor = Color.FromArgb(255, 134, 77);
            line.Location = new Point(454, 523);
            line.Name = "line";
            line.Size = new Size(1035, 20);
            line.TabIndex = 9;
            line.TabStop = false;
            //
            // SelectLevelPanel
            //
            BackColor = Color.FromArgb(255, 240, 219);
            Controls.Add(level_4);
            Controls.Add(level_3);
            Controls.Add(level_2);
            Controls.Add(level_1);
            Controls.Add(crown_4);
            Controls.Add(crown_3);
            Controls.Add(crown_2);
            Controls.Add(crown_1);
            Controls.Add(line);
            Controls.Add(border);
            Name = "SelectLevelPanel";
            Size = new Size(1920, 1080);
            ((System.ComponentModel.ISupportInitialize)level_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)level_2).EndInit();
            ((System.ComponentModel.ISupportInitialize)level_3).EndInit();
            ((System.ComponentModel.ISupportInitialize)level_4).EndInit();
            ((System.ComponentModel.ISupportInitialize)crown_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)crown_2).EndInit();
            ((System.ComponentModel.ISupportInitialize)crown_3).EndInit();
            ((System.ComponentModel.ISupportInitialize)crown_4).EndInit();
            ((System.ComponentModel.ISupportInitialize)border).EndInit();
            ((System.ComponentModel.ISupportInitialize)line).EndInit();
            ResumeLayout(false);
        }

        private PictureBox level_1;
        private PictureBox level_2;
        private PictureBox level_3;
        private PictureBox level_4;
        private PictureBox crown_1;
        private PictureBox crown_2;
        private PictureBox crown_3;
        private PictureBox crown_4;
        private PictureBox border;
        private PictureBox line;

        private void level_1_MouseEnter(object sender, EventArgs e)
        {
            border.Top = level_1.Top - (border.Height - level_1.Height) / 2;
            border.Left = level_1.Left - (border.Width - level_1.Width) / 2;
        }

        private void level_2_MouseEnter(object sender, EventArgs e)
        {
            border.Top = level_2.Top - (border.Height - level_2.Height) / 2;
            border.Left = level_2.Left - (border.Width - level_2.Width) / 2;
        }

        private void level_3_MouseEnter(object sender, EventArgs e)
        {
            border.Top = level_3.Top - (border.Height - level_3.Height) / 2;
            border.Left = level_3.Left - (border.Width - level_3.Width) / 2;
        }

        private void level_4_MouseEnter(object sender, EventArgs e)
        {
            border.Top = level_4.Top - (border.Height - level_4.Height) / 2;
            border.Left = level_4.Left - (border.Width - level_4.Width) / 2;
        }

        private void level_1_Click(object sender, EventArgs e)
        {
            LevelOneLoader.Load(StateController.panel);

            this.Visible = false;
            this.Enabled = false;
            StateController.isPause = false;

            soundPlayer.Play();
        }

        private void level_2_Click(object sender, EventArgs e)
        {
            LevelTwoLoader.Load(StateController.panel);

            this.Visible = false;
            this.Enabled = false;
            StateController.isPause = false;

            soundPlayer.Play();
        }

        private void level_3_Click(object sender, EventArgs e)
        {
            LevelThreeLoader.Load(StateController.panel);

            this.Visible = false;
            this.Enabled = false;
            StateController.isPause = false;

            soundPlayer.Play();
        }

        private void level_4_Click(object sender, EventArgs e)
        {
            LevelFourLoader.Load(StateController.panel);

            this.Visible = false;
            this.Enabled = false;
            StateController.isPause = false;

            soundPlayer.Play();
        }


        public void updateRecord()
        {
            string jsonContent = File.ReadAllText(jsonPath);
            JObject jsonObject = JObject.Parse(jsonContent);

            int i = 0;
            foreach (string level_name in levels_name)
            {
                if (jsonObject.SelectToken("record").SelectToken(level_name).Value<bool>())
                {
                    crowns[i].Visible = true;
                }
                else
                {
                    crowns[i].Visible = false;
                }
                i++;
            }
        }
    }
}
