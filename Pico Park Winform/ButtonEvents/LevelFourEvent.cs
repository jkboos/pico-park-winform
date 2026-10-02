using Pico_Park_Winform.GameObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.ButtonEvents
{
    internal class LevelFourEvent
    {
        public static PictureBox wall_0 = null;
        public static PictureBox wall_1 = null;
        public static int startX;
        public static int endX;

        public static System.Windows.Forms.Timer timer;

        public static bool startEvent1 = false;

        public static float speed_0 = 0;
        public static int speed_1 = -5;
        private static float a = -0.2f;
        private static float t = 50;

        private static List<Player> player_list = new List<Player>();
        private static List<Player> player_list_1 = new List<Player>();

        private static bool stop = false;
        public static int max_h;
        public static int min_h;

        public static void Start()
        {
            if(wall_0 != null)
            {
                timer.Start();
            }
        }

        public static void Event0(Player[] players)
        {
            if (!stop)
            {
                speed_0 += a;
            }

            PictureBox newGround = new PictureBox();
            newGround.Location = wall_0.Location;
            newGround.Size = wall_0.Size;

            newGround.Top -= 10;
            bool flag = false;
            foreach (Player player in players)
            {
                if (player.Bounds.IntersectsWith(newGround.Bounds))
                {
                    if(!player_list.Contains(player))
                    {
                        player_list.Add(player);
                    }
                }
                else
                {
                    if (player_list.Contains(player))
                    {
                        player_list.Remove(player);
                    }
                }
            }
            newGround.Top += 10 + (int)speed_0;
            foreach (Player player in players)
            {
                if (player.Bounds.IntersectsWith(newGround.Bounds))
                {
                    if (!player_list.Contains(player))
                    {
                        flag = true;
                    }
                }
            }

            if (!flag)
            {
                if (speed_0 <= -10 || speed_0 >= 10)
                {
                    a *= -1f;
                }

                for(int i = 0; i< player_list.Count; i++)
                {
                    foreach(Player player in players)
                    {
                        if (player != player_list[i])
                        {
                            if (player.stepOnPlayer && !player_list.Contains(player))
                            {
                                player_list.Add(player);
                            }
                        }
                    }
                }

                bool flag2 = false;
                foreach(Player player in player_list)
                {
                    PictureBox newPlayer = new PictureBox();
                    newPlayer.Location = player.Location;
                    newPlayer.Size = player.Size;

                    newPlayer.Top += (int)speed_0;

                    foreach(Control x in StateController.panel.Controls)
                    {
                        if(x.Tag == "wall" && x.Name != wall_0.Name && x.Bounds.IntersectsWith(newPlayer.Bounds))
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
                    foreach (Player player in player_list)
                    {
                        player.Top += (int)speed_0;
                    }
                    wall_0.Location = newGround.Location;

                    if(wall_0.Top < max_h)
                    {
                        wall_0.Top = max_h;

                        speed_0 = 0;
                        a = 0.2f;
                    }
                    else if(wall_0.Top > min_h)
                    {
                        int offset = wall_0.Top - min_h;
                        wall_0.Top = min_h;
                        foreach (Player player in player_list)
                        {
                            player.Top -= offset;
                        }
                        speed_0 = 0;
                        a = -0.2f;
                    }
                    stop = false;
                }
                else
                {
                    stop = true;
                }
            }
            else
            {
                stop = true;
            }

        }

        public static void Event1(Player[] players)
        {
            if (t >= 100)
            {
                PictureBox newWall = new PictureBox();
                newWall.Location = wall_1.Location;
                newWall.Size = wall_1.Size;
                newWall.Left += speed_1;

                foreach (Player player in players)
                {
                    if (newWall.Bounds.IntersectsWith(player.Bounds))
                    {
                        if (!(player_list_1.Contains(player)))
                        {
                            player_list_1.Add(player);
                        }
                    }
                    else
                    {
                        if (player_list_1.Contains(player))
                        {
                            player_list_1.Remove(player);
                        }
                    }
                }

                for(int i = 0; i< player_list_1.Count; i++)
                {
                    PictureBox newPlayer = new PictureBox();
                    newPlayer.Location = player_list_1[i].Location;
                    newPlayer.Size = player_list_1[i].Size;
                    newPlayer.Left += speed_1;

                    foreach(Player player in players)
                    {
                        if(player.Bounds.IntersectsWith(newPlayer.Bounds))
                        {
                            if (!(player_list_1.Contains(player)))
                            {
                                player_list_1.Add(player);
                            }
                        }
                    }
                }

                bool flag = false;
                foreach (Player player in player_list_1)
                {
                    PictureBox newPlayer = new PictureBox();
                    newPlayer.Location = player.Location;
                    newPlayer.Size = player.Size;
                    newPlayer.Left += speed_1;

                    foreach(Control x in StateController.panel.Controls)
                    {
                        if(x.Tag == "wall" && x.Bounds.IntersectsWith(newPlayer.Bounds))
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
                    foreach (Player player in player_list_1)
                    {
                        player.Left += speed_1;
                    }
                    wall_1.Left = newWall.Left;
                }

                if(wall_1.Left <= endX || wall_1.Left >= startX)
                {
                    t = 0;
                    speed_1 *= -1;
                }
            }
            else
            {
                t++;
            }
        }
    }
}
