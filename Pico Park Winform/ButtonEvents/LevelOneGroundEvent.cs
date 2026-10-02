using Pico_Park_Winform.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.ButtonEvents
{
    public class LevelOneGroundEvent
    {
        public static PictureBox ground = null;
        public static System.Windows.Forms.Timer timer;

        public static void Start()
        {
            if (ground != null)
            {
                timer.Start();
            }
        }

        public static void Event(Player[] players)
        {
            if (ground.Width < 1100)
            {
                PictureBox newGround = new PictureBox();
                newGround.Location = ground.Location;
                newGround.Size = ground.Size;

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
                    ground.Location = newGround.Location;
                    ground.Size = newGround.Size;
                }
                Thread.Sleep(1);
            }
            else
            {
                timer.Stop();
            }
        }
    }
}
