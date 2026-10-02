using Pico_Park_Winform.GameObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.Scene
{
    internal class LevelTwoLoader
    {
        private static int centralX;
        private static int centralY;

        private static Player player1;
        private static Player player2;
        private static Door door = new Door(3);
        private static Key key;

        private static PictureBox wall_0 = new PictureBox();
        private static PictureBox wall_1 = new PictureBox();
        private static PictureBox wall_2 = new PictureBox();
        private static PictureBox wall_3 = new PictureBox();
        private static PictureBox wall_4 = new PictureBox();
        private static PictureBox wall_5 = new PictureBox();
        private static PictureBox wall_6 = new PictureBox();
        private static PictureBox wall_7 = new PictureBox();
        private static PictureBox wall_8 = new PictureBox();

        private static Box box_0 = new Box(130, 800, 2);
        private static Box box_1 = new Box(130, 800, 1);
        private static Box box_2 = new Box(250, 250, 1);

        public static void Load(Panel panel)
        {
            panel.Location = new Point(-5750, -4500);
            centralX = Math.Abs(panel.Location.X);
            centralY = Math.Abs(panel.Location.Y);

            StateController.elevators.Clear();
            StateController.boxes.Clear();

            StateController.boxes.Add(box_0);
            StateController.boxes.Add(box_1);
            StateController.boxes.Add(box_2);

            door = new Door(3);
            key = new Key(centralX + 3913, centralY - 315);
            StateController.key = key;
            StateController.door = door;

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
                    else if (control.Tag != null)
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
            } while (panel.Controls.Count > 5);

            panel.Controls.Add(wall_0);
            panel.Controls.Add(wall_1);
            panel.Controls.Add(wall_2);
            panel.Controls.Add(wall_3);
            panel.Controls.Add(wall_4);
            panel.Controls.Add(wall_5);
            panel.Controls.Add(wall_6);
            panel.Controls.Add(wall_7);
            panel.Controls.Add(wall_8);
            panel.Controls.Add(box_0);
            panel.Controls.Add(box_1);
            panel.Controls.Add(box_2);
            panel.Controls.Add(door);
            panel.Controls.Add(key);

            setObject(
                wall_0,
                new Size(2100, 360),
                centralX - 1062,
                centralY + 384,
                Color.FromArgb(255, 134, 77),
                "wall_0",
                "wall"
                );

            setObject(
                wall_1,
                new Size(926, 1574),
                centralX - 1988,
                centralY - 829,
                Color.FromArgb(255, 134, 77),
                "wall_1",
                "wall"
                );

            setObject(
                wall_2,
                new Size(130, 133),
                centralX + 1041,
                centralY + 1000,
                Color.FromArgb(255, 134, 77),
                "wall_2",
                "wall"
                );

            setObject(
                wall_3,
                new Size(130, 745),
                centralX + 1171,
                centralY,
                Color.FromArgb(255, 134, 77),
                "wall_3",
                "wall"
                );

            setObject(
                wall_4,
                new Size(130, 544),
                centralX + 1301,
                centralY + 201,
                Color.FromArgb(255, 134, 77),
                "wall_4",
                "wall"
                );

            setObject(
                wall_5,
                new Size(1535, 360),
                centralX + 1431,
                centralY + 385,
                Color.FromArgb(255, 134, 77),
                "wall_5",
                "wall"
                );

            setObject(
                wall_6,
                new Size(490, 500),
                centralX + 2966,
                centralY + 245,
                Color.FromArgb(255, 134, 77),
                "wall_6",
                "wall"
                );
            setObject(
                wall_7,
                new Size(1084, 1574),
                centralX + 3456,
                centralY - 829,
                Color.FromArgb(255, 134, 77),
                "wall_7",
                "wall"
                );

            setObject(
                wall_8,
                new Size(4519, 414),
                centralX - 1062,
                centralY - 830,
                Color.FromArgb(255, 134, 77),
                "wall_8",
                "wall"
                );

            setObject(
                box_0,
                new Size(box_0.Width, box_0.Height),
                centralX + 545,
                centralY - 416,
                Color.FromArgb(255, 134, 77),
                "box_0",
                "box"
                );

            setObject(
                box_1,
                new Size(box_1.Width, box_1.Height),
                centralX - 634,
                centralY - 416,
                Color.FromArgb(255, 134, 77),
                "box_1",
                "box"
                );

            setObject(
                box_2,
                new Size(box_2.Width, box_2.Height),
                centralX + 2303,
                centralY + 134,
                Color.FromArgb(255, 134, 77),
                "box_2",
                "box"
                );

            setObject(
                door,
                new Size(150, 150),
                centralX + 3136,
                centralY + 95,
                Color.Transparent,
                "door",
                "door"
                );

            setObject(
                key,
                new Size(54, 108),
                centralX - 900,
                centralY - 140,
                Color.Transparent,
                "key",
                "key"
                );


            panel.Location = new Point(panel.Size.Width / 2 + 750, panel.Size.Height / 2 - 500);

            player1.Top = centralY + 244;
            player1.Left = centralX - 396;
            player1.isEnter = false;
            player1.Visible = true;


            player2.Top = centralY + 244;
            player2.Left = centralX - 125;
            player2.isEnter = false;
            player2.Visible = true;

            StateController.level_index = 2;

            key.BringToFront();
            player1.BringToFront();
            player2.BringToFront();

            BackgroundMusicController.play("./sound/doremi.wav");
        }

        private static void setObject(Control control, Size size, int left, int top, Color color, string name, string tag)
        {
            control.Size = size;
            control.Top = top;
            control.Left = left;
            control.BackColor = color;
            control.Name = name;
            control.Tag = tag;
        }
    }
}
