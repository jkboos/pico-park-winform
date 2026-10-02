using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.GameObject
{
    public class Player : UserControl
    {
        public PictureBox pictureBox1;
        public bool right = false;
        public bool left = false;
        public bool flip = false;
        public bool isGrounded = false;
        public bool isPush = false;
        public float verticalSpeed = 0;
        public bool stepOnPlayer = false;
        public float g = 1.5f;
        public bool onElevator = false;
        public Elevator elevator;
        public bool isEnter = false;

        public int moveAnimationIndex = 0;

        public Player()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            //
            // pictureBox1
            //
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.idle_0;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(122, 140);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            //
            // Player
            //
            BackColor = Color.Transparent;
            Controls.Add(pictureBox1);
            Name = "Player";
            Size = new Size(122, 140);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        public bool Move(int moveSpeed, bool right, Panel panel, int cameraWidth)
        {
            bool collisionDetect = false;
            Player newPlayer = new Player();
            newPlayer.Location = this.Location;
            newPlayer.Size = this.Size;

            bool isRightWall = false;

            Control hitObject = new Control();

            /*
             * Camera collision detect
             */
            if (right)
            {
                newPlayer.Location = new Point(newPlayer.Location.X + (int)moveSpeed, newPlayer.Location.Y);
                if (panel.Location.X + newPlayer.Right >= cameraWidth)
                {
                    return false;
                }
            }
            if (!right)
            {
                newPlayer.Location = new Point(newPlayer.Location.X - (int)moveSpeed, newPlayer.Location.Y);
                if (panel.Location.X + newPlayer.Left < 0)
                {
                    return false;
                }

            }

            /*
             * Collision detect
             */
            foreach (Control x in panel.Controls)
            {
                if ((x.Tag != null && x.Tag == "wall") || (x is Player && !((Player)x).isEnter) || x is Elevator || x is Box)
                {
                    if (x is Elevator)
                    {
                        PictureBox elevator_bottom = new PictureBox();
                        elevator_bottom.Location = new Point(x.Location.X, x.Location.Y + ((Elevator)x).elevator_bottom.Location.Y);
                        elevator_bottom.Size = ((Elevator)x).elevator_bottom.Size;

                        if (newPlayer.Bounds.IntersectsWith(elevator_bottom.Bounds))
                        {
                            if (this.Right <= elevator_bottom.Left)
                            {
                                isRightWall = true;
                            }
                            collisionDetect = true;
                            hitObject = ((Elevator)x).elevator_bottom;
                        }
                    }
                    else if (this.Name != x.Name && newPlayer.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (this.Right <= x.Left)
                        {
                            isRightWall = true;
                        }

                        collisionDetect = true;
                        hitObject = x;
                    }
                }
            }

            if (!collisionDetect)
            {
                this.Location = newPlayer.Location;

                if (right)
                {
                    newPlayer.Location = new Point(newPlayer.Location.X + 20, newPlayer.Location.Y);
                }
                if (!right)
                {
                    newPlayer.Location = new Point(newPlayer.Location.X - 20, newPlayer.Location.Y);
                }

                bool flag = false;
                foreach(Control x in panel.Controls)
                {
                    if(x is Box && newPlayer.Bounds.IntersectsWith(x.Bounds))
                    {
                        flag = true;
                        break;
                    }
                    else if(x.Name != this.Name && x is Player && newPlayer.Bounds.IntersectsWith(x.Bounds))
                    {
                        foreach (Box box in StateController.boxes)
                        {
                            if(box.players.Contains((Player)x))
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
                }
                isPush = flag;

                foreach(Box box in StateController.boxes)
                {

                    if(box.players_down.Contains(this))
                    {
                        PictureBox newBox = new PictureBox();
                        newBox.Location = box.Location;
                        newBox.Size = box.Size;
                        newBox.Name = box.Name;

                        if(right)
                        {
                            newBox.Left += moveSpeed;
                        }
                        else
                        {
                            newBox.Left -= moveSpeed;
                        }

                        flag = false;
                        foreach(Control x in panel.Controls)
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
                            if (right)
                            {
                                box.Move(moveSpeed);
                            }
                            else
                            {
                                box.Move(-moveSpeed);
                            }
                        }
                    }
                }
            }
            else
            {
                /*
                * TODO:
                *  1. Push the left or right wall
                */
                isPush = true;
                if (isRightWall)
                {
                    Debug.WriteLine(this.Name + " push the " + hitObject.Name);
                    if(hitObject is Box)
                    {
                        if(!((Box)hitObject).players.Contains(this))
                        {
                            ((Box)hitObject).players.Add(this);
                        }
                        if(((Box)hitObject).players.Count >= ((Box)hitObject).max_num)
                        {
                            ((Box)hitObject).right = true;
                        }

                    }
                    if(hitObject is Player)
                    {
                        Box box = null;
                        foreach(Box b in StateController.boxes)
                        {
                            if(b.players.Contains(((Player)hitObject)))
                            {
                                box = b;
                                break;
                            }
                        }
                        if (box != null && !box.players.Contains(this))
                        {
                            box.players.Add(this);
                        }
                        if (box != null && box.players.Count >= box.max_num)
                        {
                            box.right = true;
                        }
                    }
                }
                else
                {
                    Debug.WriteLine(this.Name + " push the " + hitObject.Name);
                    if (hitObject is Box)
                    {
                        if (!((Box)hitObject).players.Contains(this))
                        {
                            ((Box)hitObject).players.Add(this);
                        }
                        if (((Box)hitObject) != null && ((Box)hitObject).players.Count >= ((Box)hitObject).max_num)
                        {
                            ((Box)hitObject).right = false;
                        }
                    }
                    if (hitObject is Player)
                    {
                        Box box = null;
                        foreach (Box b in StateController.boxes)
                        {
                            if (b.players.Contains(((Player)hitObject)))
                            {
                                box = b;
                                break;
                            }
                        }
                        if (box != null && !box.players.Contains(this))
                        {
                            box.players.Add(this);
                        }
                        if (box != null && box.players.Count >= box.max_num)
                        {
                            box.right = false;
                        }
                    }
                }
            }

            return !collisionDetect;
        }

        public void VerticalMove(Panel panel)
        {
            bool collisionDetect = false;
            Player newPlayer = new Player();
            newPlayer.Location = this.Location;
            newPlayer.Size = this.Size;

            bool isFloor = false;

            Control hitObject = new Control();

            newPlayer.Location = new Point(newPlayer.Location.X, newPlayer.Location.Y - (int)verticalSpeed);
            verticalSpeed -= g;

            foreach (Control x in panel.Controls)
            {
                if ((x.Tag != null && x.Tag == "wall") || (x is Player && !((Player)x).isEnter) || x is Elevator || x is Box)
                {
                    if (x is Elevator)
                    {
                        PictureBox elevator_bottom = new PictureBox();
                        elevator_bottom.Location = new Point(x.Location.X, x.Location.Y + ((Elevator)x).elevator_bottom.Location.Y);
                        elevator_bottom.Size = ((Elevator)x).elevator_bottom.Size;

                        if (newPlayer.Bounds.IntersectsWith(elevator_bottom.Bounds))
                        {
                            if (this.Location.Y >= elevator_bottom.Bottom)
                            {
                                isFloor = true;
                            }
                            collisionDetect = true;
                            hitObject = ((Elevator)x).elevator_bottom;

                            if(!((Elevator)x).players.Contains(this))
                            {
                                ((Elevator)x).players.Add(this);
                                this.elevator = (Elevator)x;
                                this.onElevator = true;
                            }
                        }
                    }
                    else if (this.Name != x.Name && newPlayer.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (this.Location.Y >= x.Bottom)
                        {
                            isFloor = true;
                        }
                        collisionDetect = true;
                        hitObject = x;
                    }
                }
            }

            newPlayer.Location = new Point(newPlayer.Location.X, newPlayer.Location.Y + 80);
            foreach (Control x in panel.Controls)
            {
                if (this.Name != x.Name && newPlayer.Bounds.IntersectsWith(x.Bounds))
                {
                    if (x is Player)
                    {
                        stepOnPlayer = true;
                        break;
                    }
                }
                else
                {
                    stepOnPlayer = false;
                }
            }
            newPlayer.Location = new Point(newPlayer.Location.X, newPlayer.Location.Y - 80);

            newPlayer.Location = new Point(newPlayer.Location.X, newPlayer.Location.Y + 10);
            bool flag = false;
            foreach (Control x in panel.Controls)
            {
                if (this.Name != x.Name && newPlayer.Bounds.IntersectsWith(x.Bounds))
                {
                    if (x is Elevator)
                    {
                        PictureBox elevator_bottom = new PictureBox();
                        elevator_bottom.Location = new Point(x.Location.X, x.Location.Y + ((Elevator)x).elevator_bottom.Location.Y);
                        elevator_bottom.Size = ((Elevator)x).elevator_bottom.Size;
                        if (newPlayer.Bounds.IntersectsWith(elevator_bottom.Bounds))
                        {
                            flag = true;
                        }
                    }
                    else if(x is Player && ((Player)x).onElevator)
                    {
                        flag = true;
                    }
                }
            }
            if(!flag)
            {
                foreach(Elevator elevator in StateController.elevators)
                {
                    elevator.players.Remove(this);
                    this.onElevator = false;
                }
            }
            newPlayer.Location = new Point(newPlayer.Location.X, newPlayer.Location.Y - 10);

            if (!collisionDetect)
            {
                isGrounded = false;
                this.Location = newPlayer.Location;
            }
            else
            {

                if (!isFloor)
                {
                    if (!isGrounded)
                    {
                        Debug.WriteLine(this.Name + " step on the " + hitObject.Name);
                    }

                    isGrounded = true;
                    if (hitObject.Name.Contains("player"))
                    {
                        if(((Player)hitObject).onElevator && !((Player)hitObject).elevator.players.Contains(this))
                        {
                            ((Player)hitObject).elevator.players.Add(this);
                            this.onElevator = true;
                        }
                        stepOnPlayer = true;
                    }
                    else
                    {
                        stepOnPlayer = false;
                    }

                    /* TODO:
                     *  1. Press button on the ground.
                     *  2. Enable the elevator object.
                     */
                }
                else
                {
                    Debug.WriteLine(this.Name + " hit the " + hitObject.Name);
                }
                verticalSpeed = -1;
            }
        }
    }
}
