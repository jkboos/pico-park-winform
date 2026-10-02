using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.GameObject
{
    public class Elevator : UserControl
    {
        public Elevator(int startY, int endY, int max_num)
        {
            InitializeComponent();
            this.startY = startY;
            this.endY = endY;
            this.max_num = max_num;
        }

        private void InitializeComponent()
        {
            elevator_top = new PictureBox();
            elevator_num = new PictureBox();
            elevator_bottom = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)elevator_top).BeginInit();
            ((System.ComponentModel.ISupportInitialize)elevator_num).BeginInit();
            ((System.ComponentModel.ISupportInitialize)elevator_bottom).BeginInit();
            SuspendLayout();
            //
            // elevator_top
            //
            elevator_top.BackColor = Color.Transparent;
            elevator_top.Image = Properties.Resources.elevator_top;
            elevator_top.Location = new Point(139, 0);
            elevator_top.Name = "elevator_top";
            elevator_top.Size = new Size(153, 144);
            elevator_top.SizeMode = PictureBoxSizeMode.StretchImage;
            elevator_top.TabIndex = 0;
            elevator_top.TabStop = false;
            //
            // elevator_num
            //
            elevator_num.Image = Properties.Resources.num_0;
            elevator_num.Location = new Point(199, 16);
            elevator_num.Name = "elevator_num";
            elevator_num.Size = new Size(32, 61);
            elevator_num.SizeMode = PictureBoxSizeMode.StretchImage;
            elevator_num.TabIndex = 1;
            elevator_num.TabStop = false;
            //
            // elevator_bottom
            //
            elevator_bottom.Image = Properties.Resources.elevator_bottom;
            elevator_bottom.Location = new Point(0, 144);
            elevator_bottom.Name = "elevator_bottom";
            elevator_bottom.Size = new Size(432, 36);
            elevator_bottom.SizeMode = PictureBoxSizeMode.StretchImage;
            elevator_bottom.TabIndex = 2;
            elevator_bottom.TabStop = false;
            //
            // Elevator
            //
            BackColor = Color.Transparent;
            Controls.Add(elevator_bottom);
            Controls.Add(elevator_num);
            Controls.Add(elevator_top);
            Name = "Elevator";
            Size = new Size(432, 180);
            ((System.ComponentModel.ISupportInitialize)elevator_top).EndInit();
            ((System.ComponentModel.ISupportInitialize)elevator_num).EndInit();
            ((System.ComponentModel.ISupportInitialize)elevator_bottom).EndInit();
            ResumeLayout(false);
        }

        private PictureBox elevator_top;
        public PictureBox elevator_num;
        public PictureBox elevator_bottom;

        public List<Player> players = new List<Player>();

        public int startY;
        public int endY;
        public int max_num;


        public void Down()
        {
            PictureBox elevator_bottom = new PictureBox();
            elevator_bottom.Location = new Point(this.Location.X, this.Location.Y + this.elevator_bottom.Location.Y);
            elevator_bottom.Size = this.elevator_bottom.Size;
            bool flag1 = false;

            elevator_bottom.Top += 3;
            foreach (Control x in StateController.panel.Controls)
            {
                if (x is Player && x.Bounds.IntersectsWith(elevator_bottom.Bounds))
                {

                    flag1 = true;
                    break;
                }
            }
            if (!flag1)
            {
                this.Top += 3;
                bool flag2 = false;
                foreach (Player player in this.players)
                {
                    Player newPlayer = new Player();
                    newPlayer.Location = player.Location;
                    newPlayer.Size = player.Size;
                    newPlayer.Top += 3;
                    foreach (Control x in StateController.panel.Controls)
                    {
                        if (x.Tag == "wall" && x.Bounds.IntersectsWith(newPlayer.Bounds))
                        {
                            flag2 = true;
                            break;
                        }
                    }
                    if(flag2)
                    {
                        break;
                    }

                }
                if (!flag2)
                {
                    foreach (Player player in this.players)
                    {
                        player.Top += 3;
                    }
                }
            }
        }

        public void Up()
        {
            bool flag = false;
            foreach (Player player in this.players)
            {
                Player newPlayer = new Player();
                newPlayer.Location = player.Location;
                newPlayer.Size = player.Size;

                newPlayer.Top -= 3;
                foreach (Control x in StateController.panel.Controls)
                {
                    if (x.Tag == "wall" && x.Bounds.IntersectsWith(newPlayer.Bounds))
                    {
                        flag = true;

                        break;
                    }
                }
                if(flag)
                {
                    break;
                }
            }
            if (!flag)
            {
                foreach (Player player in this.players)
                {
                    player.Top -= 3;
                }
                if (players.Count > 0)
                {
                    this.Top -= 3;
                }
            }

            if (players.Count == 0)
            {
                this.Top -= 3;
            }
        }
    }
}
