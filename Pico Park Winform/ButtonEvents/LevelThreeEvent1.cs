using Pico_Park_Winform.GameObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.ButtonEvents
{
    internal class LevelThreeEvent1
    {
        public static PictureBox wall_0 = null;
        public static PictureBox wall_1 = null;
        public static PictureBox wall_2 = null;
        public static PictureBox wall_3 = null;

        public static RedButton[] buttons = new RedButton[4];

        public static System.Windows.Forms.Timer timer;

        public static void Start()
        {
            if (wall_0 != null && wall_1 != null && wall_2 != null && wall_3 != null && !timer.Enabled)
            {
                timer.Start();
            }
        }

        public static void Event(Player[] players)
        {
            int count = 0;
            foreach (RedButton button in buttons)
            {
                if(button.pressed)
                {
                    count++;
                }
            }

            if(count >= 1)
            {
                if (wall_3.Height > 100)
                {
                    PictureBox newGround = new PictureBox();
                    newGround.Location = wall_3.Location;
                    newGround.Size = wall_3.Size;

                    newGround.Height -= 10;
                    newGround.Top += 10;
                    bool flag = false;
                    foreach (Player player in players)
                    {
                        if (player.Bounds.IntersectsWith(newGround.Bounds))
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        wall_3.Location = newGround.Location;
                        wall_3.Size = newGround.Size;
                    }
                }
            }
            else
            {
                if (wall_3.Height < 404)
                {
                    PictureBox newGround = new PictureBox();
                    newGround.Location = wall_3.Location;
                    newGround.Size = wall_3.Size;

                    newGround.Height += 10;
                    newGround.Top -= 10;
                    bool flag = false;
                    foreach (Player player in players)
                    {
                        if (player.Bounds.IntersectsWith(newGround.Bounds))
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        wall_3.Location = newGround.Location;
                        wall_3.Size = newGround.Size;
                    }
                }
            }

            if(count >= 2)
            {
                if (wall_2.Height > 100)
                {
                    PictureBox newGround = new PictureBox();
                    newGround.Location = wall_2.Location;
                    newGround.Size = wall_2.Size;

                    newGround.Height -= 10;
                    newGround.Top += 10;
                    bool flag = false;
                    foreach (Player player in players)
                    {
                        if (player.Bounds.IntersectsWith(newGround.Bounds))
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        wall_2.Location = newGround.Location;
                        wall_2.Size = newGround.Size;
                    }
                }
            }
            else
            {
                if (wall_2.Height < 404)
                {
                    PictureBox newGround = new PictureBox();
                    newGround.Location = wall_2.Location;
                    newGround.Size = wall_2.Size;

                    newGround.Height += 10;
                    newGround.Top -= 10;
                    bool flag = false;
                    foreach (Player player in players)
                    {
                        if (player.Bounds.IntersectsWith(newGround.Bounds))
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        wall_2.Location = newGround.Location;
                        wall_2.Size = newGround.Size;
                    }
                }
            }

            if(count >= 3)
            {
                if (wall_1.Height > 100)
                {
                    PictureBox newGround = new PictureBox();
                    newGround.Location = wall_1.Location;
                    newGround.Size = wall_1.Size;

                    newGround.Height -= 10;
                    newGround.Top += 10;
                    bool flag = false;
                    foreach (Player player in players)
                    {
                        if (player.Bounds.IntersectsWith(newGround.Bounds))
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        wall_1.Location = newGround.Location;
                        wall_1.Size = newGround.Size;
                    }
                }
            }
            else
            {
                if (wall_1.Height < 404)
                {
                    PictureBox newGround = new PictureBox();
                    newGround.Location = wall_1.Location;
                    newGround.Size = wall_1.Size;

                    newGround.Height += 10;
                    newGround.Top -= 10;
                    bool flag = false;
                    foreach (Player player in players)
                    {
                        if (player.Bounds.IntersectsWith(newGround.Bounds))
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        wall_1.Location = newGround.Location;
                        wall_1.Size = newGround.Size;
                    }
                }
            }

            if(count >= 4)
            {
                if (wall_0.Height > 100)
                {
                    PictureBox newGround = new PictureBox();
                    newGround.Location = wall_0.Location;
                    newGround.Size = wall_0.Size;

                    newGround.Height -= 10;
                    newGround.Top += 10;
                    bool flag = false;
                    foreach (Player player in players)
                    {
                        if (player.Bounds.IntersectsWith(newGround.Bounds))
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        wall_0.Location = newGround.Location;
                        wall_0.Size = newGround.Size;
                    }
                }
            }
            else
            {
                if (wall_0.Height < 404)
                {
                    PictureBox newGround = new PictureBox();
                    newGround.Location = wall_0.Location;
                    newGround.Size = wall_0.Size;

                    newGround.Height += 10;
                    newGround.Top -= 10;
                    bool flag = false;
                    foreach (Player player in players)
                    {
                        if (player.Bounds.IntersectsWith(newGround.Bounds))
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        wall_0.Location = newGround.Location;
                        wall_0.Size = newGround.Size;
                    }
                }
            }

            Thread.Sleep(1);
        }
    }
}
