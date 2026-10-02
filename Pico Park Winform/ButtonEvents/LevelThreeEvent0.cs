using Pico_Park_Winform.GameObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.ButtonEvents
{
    internal class LevelThreeEvent0
    {
        public static PictureBox wall_0 = null;
        public static PictureBox wall_1 = null;

        public static System.Windows.Forms.Timer timer;

        public static void Start()
        {
            if(wall_0 != null)
            {
                timer.Start();
            }
        }

        public static void Event(Player[] players)
        {
            if (wall_0.Width < 854)
            {

                PictureBox newGround = new PictureBox();
                newGround.Location = wall_0.Location;
                newGround.Size = wall_0.Size;

                newGround.Width += 10;
                newGround.Left -= 10;
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

            if(wall_1.Height < 404)
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

            Thread.Sleep(1);
            if (wall_0.Width >= 854 && wall_1.Height >= 404)
            {
                timer.Stop();
            }
        }
    }
}
