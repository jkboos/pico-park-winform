using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pico_Park_Winform.GameObject
{
    public class Box : UserControl
    {
        public PictureBox number;
        private System.ComponentModel.IContainer components;
        private PictureBox pictureBox1;

        public float max_vertical_speed = 25;

        public int max_num = 1;
        public List<Control> players_up = new List<Control>();
        public List<Control> players_down = new List<Control>();
        public float vertical_speed = 0;
        public float g = 1f;
        public bool right = false;

        public List<Player> players = new List<Player>();

        public string pushBox = "";

        public Box(int width, int height, int max_num)
        {
            InitializeComponent();

            this.Width = width;
            this.Height = height;
            this.max_num = max_num;

            pictureBox1.Width = this.Width - 20;
            pictureBox1.Height = this.Height - 20;
            pictureBox1.Location = new Point(10, 10);

            number.Location = new Point(this.Width / 2 - number.Width / 2, this.Height / 2 - number.Height / 2);

        }

        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            number = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)number).BeginInit();
            SuspendLayout();
            //
            // pictureBox1
            //
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 125);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            //
            // number
            //
            number.Image = Properties.Resources.num_0_white;
            number.Location = new Point(58, 44);
            number.Name = "number";
            number.Size = new Size(32, 61);
            number.SizeMode = PictureBoxSizeMode.StretchImage;
            number.TabIndex = 1;
            number.TabStop = false;
            //
            // Box
            //
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(number);
            Controls.Add(pictureBox1);
            Name = "Box";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)number).EndInit();
            ResumeLayout(false);
        }

        public void PlayerCheck()
        {
            PictureBox newBox = new PictureBox();
            newBox.Location = this.Location;
            newBox.Size = this.Size;

            foreach (Control x in StateController.panel.Controls)
            {
                if (x is Player)
                {
                    newBox.Top -= 3;
                    if (newBox.Bounds.IntersectsWith(x.Bounds) && !this.players_up.Contains((Player)x))
                    {
                        this.players_up.Add(x);
                    }
                    newBox.Top += 6;
                    if (newBox.Bounds.IntersectsWith(x.Bounds) && !this.players_down.Contains((Player)x))
                    {
                        this.players_down.Add(x);
                    }
                    newBox.Top -= 3;

                }
            }

            newBox.Top -= 3;
            if (this.players_up.Count > 0)
            {
                foreach (Control x in this.players_up)
                {
                    if (!newBox.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.players_up.Remove(x);
                        break;
                    }
                }
            }
            newBox.Top += 6;
            if (this.players_down.Count > 0)
            {
                foreach (Control x in this.players_down)
                {
                    if (!newBox.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.players_down.Remove(x);
                        break;
                    }
                }
            }
            newBox.Top -= 3;

            foreach(Player player in players)
            {
                if(!player.isPush)
                {
                    players.Remove(player);
                    break;
                }
            }

            if(this.players.Count < max_num)
            {
                pushBox = "";
            }
        }

        public void Move(int speed)
        {
            Box newBox = new Box(this.Width, this.Height, 2);
            newBox.Location = this.Location;
            newBox.Name = this.Name;
            newBox.Left += speed;
            bool flag = false;
            foreach (Control x in StateController.panel.Controls)
            {
                if (newBox.Name != x.Name && ((x.Tag != null && x.Tag == "wall") || (x is Player && !((Player)x).isEnter) || x is Elevator || (x is Box && this.pushBox != ((Box)x).Name)))
                {
                    if (newBox.Bounds.IntersectsWith(x.Bounds) && !(x is Box))
                    {
                        flag = true;
                        break;
                    }
                    else if (newBox.Bounds.IntersectsWith(x.Bounds) && x is Box)
                    {
                        foreach(Player player in this.players)
                        {
                            if (!((Box)x).players.Contains(player))
                            {
                                ((Box)x).players.Add(player);
                            }
                        }
                        if (((Box)x).players.Count >= ((Box)x).max_num)
                        {
                            ((Box)x).right = speed >= 0;
                            ((Box)x).pushBox = this.Name;
                            ((Box)x).Move(speed);
                        }
                        flag = true;
                        break;
                    }
                }
            }
            if (!flag)
            {
                this.Left += speed;

                foreach (Player player in this.players_up)
                {
                    PictureBox newPlayer = new PictureBox();
                    newPlayer.Location = player.Location;
                    newPlayer.Name = player.Name;
                    newPlayer.Left += speed;
                    foreach (Control x in StateController.panel.Controls)
                    {
                        if (newPlayer.Name != x.Name && ((x.Tag != null && x.Tag == "wall") || (x is Player && !((Player)x).isEnter) || x is Elevator || x is Box))
                        {
                            if (newPlayer.Bounds.IntersectsWith(x.Bounds))
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (!flag)
                    {
                        player.Left += speed;
                    }
                }
            }
        }

        public void VerticalMove()
        {
            PictureBox newBox = new PictureBox();
            newBox.Location = this.Location;
            newBox.Size = this.Size;
            newBox.Name = this.Name;

            newBox.Top += (int)this.vertical_speed;
            this.vertical_speed += g;

            bool flag = false;
            foreach(Control x in StateController.panel.Controls)
            {
                if(newBox.Name != x.Name && ((x.Tag != null && x.Tag == "wall") || (x is Player && !((Player)x).isEnter) || x is Elevator || x is Box))
                {
                    if(newBox.Bounds.IntersectsWith(x.Bounds))
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if(!flag)
            {
                this.Location = newBox.Location;
            }
            else
            {
                this.vertical_speed = 0;
            }

        }
    }
}
