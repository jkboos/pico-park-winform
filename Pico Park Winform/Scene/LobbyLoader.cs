using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pico_Park_Winform.GameObject;
using WMPLib;

namespace Pico_Park_Winform.Level
{
    public class LobbyLoader
    {
        private static int centralX;
        private static int centralY;

        private static PictureBox wall_0 = new PictureBox();
        private static PictureBox wall_1 = new PictureBox();
        private static PictureBox wall_2 = new PictureBox();
        private static PictureBox title = new PictureBox();
        private static Label text = new Label();
        private static Player player1;
        private static Player player2;
        private static Door door = new Door(0);

        private static int offset_Y = -400;

        public static void Load(Panel panel)
        {
            panel.Location = new Point(-5750, -4500);

            StateController.boxes.Clear();
            StateController.elevators.Clear();

            StateController.door = door;
            StateController.key = null;

            centralX = Math.Abs(panel.Location.X);
            centralY = Math.Abs(panel.Location.Y);

            do
            {
                foreach (Control control in panel.Controls)
                {
                    if (control.Tag == null)
                    {
                        panel.Controls.Remove(control);
                    }
                    else if (control.Tag != null && !control.Tag.ToString().Contains("player") && control.Tag.ToString() != "pause_panel" && control.Tag.ToString() != "select_level" && control.Tag.ToString() != "clear")
                    {
                        panel.Controls.Remove(control);
                    }
                    else
                    {
                        if (control.Tag == "player1")
                        {
                            player1 = (Player)control;
                        }
                        else if (control.Tag == "player2")
                        {
                            player2 = (Player)control;
                        }
                    }

                }
            } while (panel.Controls.Count > 5) ;

            panel.Location = new Point(panel.Size.Width / 2 + 750, panel.Size.Height / 2 - 500);

            panel.Controls.Add(wall_0);
            panel.Controls.Add(wall_1);
            panel.Controls.Add(wall_2);
            panel.Controls.Add(door);
            panel.Controls.Add(title);
            panel.Controls.Add(text);


            wall_0.Size = new Size(5000, 10000);
            wall_0.Location = new Point(centralX - 1000 - wall_0.Size.Width, centralY - wall_0.Size.Height / 2 + offset_Y);
            wall_0.BackColor = Color.FromArgb(255, 134, 77);
            wall_0.Name = "wall_0";
            wall_0.Tag = "wall";

            wall_1.Size = new Size(10000, 1000);
            wall_1.Location = new Point(centralX - wall_1.Size.Width / 2, 5266 + offset_Y);
            wall_1.BackColor = Color.FromArgb(255, 134, 77);
            wall_1.Name = "wall_1";
            wall_1.Tag = "wall";

            wall_2.Size = new Size(5000, 10000);
            wall_2.Location = new Point(centralX + 1000, centralY - wall_2.Size.Height / 2 + offset_Y);
            wall_2.BackColor = Color.FromArgb(255, 134, 77);
            wall_2.Name = "wall_2";
            wall_2.Tag = "wall";

            title.Image = (Image)Properties.Resources.ResourceManager.GetObject("title");
            title.SizeMode = PictureBoxSizeMode.StretchImage;
            title.Size = new Size(1249, 282);
            title.Location = new Point(centralX - title.Size.Width / 2, 4545 + offset_Y);
            title.BackColor = Color.Transparent;

            text.Font = new Font(text.Font.Name, 12, text.Font.Style, text.Font.Unit);
            text.AutoSize = true;
            text.Text = "but the budget is 0$";
            text.ForeColor = Color.FromArgb(255, 134, 77);
            text.Location = new Point(centralX - text.Size.Width / 2, 4836 + offset_Y);

            player1.Location = new Point(centralX - 200 - player1.Size.Width, 5125 + offset_Y);
            player1.isEnter = false;
            player1.Visible = true;

            player2.Location = new Point(centralX + 200, 5125 + offset_Y);
            player2.isEnter = false;
            player2.Visible = true;

            door.Size = new Size(150, 150);
            door.Location = new Point(centralX - door.Size.Width / 2, wall_1.Location.Y - door.Size.Height);
            door.Tag = "door";

            StateController.level_index = 0;

            BackgroundMusicController.play("./sound/lobby.wav");
        }
    }
}
