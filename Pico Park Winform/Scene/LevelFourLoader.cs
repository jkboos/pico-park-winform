using Pico_Park_Winform.ButtonEvents;
using Pico_Park_Winform.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.Scene
{
    internal class LevelFourLoader
    {
        private static int centralX;
        private static int centralY;

        private static Player player1;
        private static Player player2;
        private static Door door = new Door(0);
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
        private static PictureBox wall_9 = new PictureBox();
        private static PictureBox wall_10 = new PictureBox();
        private static PictureBox wall_11 = new PictureBox();
        private static PictureBox wall_12 = new PictureBox();

        private static Elevator elevator_0;
        private static Elevator elevator_1;

        private static PictureBox trigger = new PictureBox();

        public static void Load(Panel panel)
        {
            panel.Location = new Point(-5750, -4500);
            centralX = Math.Abs(panel.Location.X);
            centralY = Math.Abs(panel.Location.Y);

            StateController.elevators.Clear();
            StateController.boxes.Clear();

            elevator_0 = new Elevator(centralY - 360, centralY + 185, 2);
            elevator_1 = new Elevator(centralY + 187, centralY - 273, 2);
            StateController.elevators.Add(elevator_0);
            StateController.elevators.Add(elevator_1);

            LevelFourEvent.wall_0 = wall_2;
            LevelFourEvent.wall_1 = wall_5;
            LevelFourEvent.startX = centralX + 2530;
            LevelFourEvent.endX = centralX + 1446;
            LevelFourEvent.startEvent1 = false;
            LevelFourEvent.speed_0 = 0;
            LevelFourEvent.speed_1 = -5;
            LevelFourEvent.max_h = centralY - 180;
            LevelFourEvent.min_h = centralY + 313;

            door = new Door(0);
            key = new Key(centralX + 3913, centralY - 315);
            StateController.key = key;
            StateController.door = door;
            StateController.trigger = trigger;

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
            panel.Controls.Add(wall_9);
            panel.Controls.Add(wall_10);
            panel.Controls.Add(wall_11);
            panel.Controls.Add(wall_12);
            panel.Controls.Add(trigger);
            panel.Controls.Add(door);
            panel.Controls.Add(elevator_0);
            panel.Controls.Add(elevator_1);
            panel.Controls.Add(key);

            setObject(
                wall_0,
                new Size(6786, 360),
                centralX - 840,
                centralY + 385,
                Color.FromArgb(255, 134, 77),
                "wall_0",
                "wall"
                );

            setObject(
                wall_1,
                new Size(679, 1731),
                centralX - 1519,
                centralY - 986,
                Color.FromArgb(255, 134, 77),
                "wall_1",
                "wall"
                );

            setObject(
                wall_2,
                new Size(381, 44),
                centralX + 981,
                centralY + 313,
                Color.FromArgb(255, 134, 77),
                "wall_2",
                "wall"
                );

            setObject(
                wall_3,
                new Size(640, 142),
                centralX + 1392,
                centralY - 216,
                Color.FromArgb(255, 134, 77),
                "wall_3",
                "wall"
                );

            setObject(
                wall_4,
                new Size(682, 142),
                centralX + 2465,
                centralY - 216,
                Color.FromArgb(255, 134, 77),
                "wall_4",
                "wall"
                );

            setObject(
                wall_5,
                new Size(38, 250),
                centralX + 2530,
                centralY - 466,
                Color.FromArgb(255, 134, 77),
                "wall_5",
                "wall"
                );

            setObject(
                wall_6,
                new Size(218, 601),
                centralX + 3147,
                centralY - 216,
                Color.FromArgb(255, 134, 77),
                "wall_6",
                "wall"
                );

            setObject(
                wall_7,
                new Size(218, 445),
                centralX + 3365,
                centralY - 60,
                Color.FromArgb(255, 134, 77),
                "wall_7",
                "wall"
                );

            setObject(
                wall_8,
                new Size(218, 297),
                centralX + 3583,
                centralY + 88,
                Color.FromArgb(255, 134, 77),
                "wall_8",
                "wall"
                );

            setObject(
                wall_9,
                new Size(218, 140),
                centralX + 3801,
                centralY + 245,
                Color.FromArgb(255, 134, 77),
                "wall_9",
                "wall"
                );

            setObject(
                wall_10,
                new Size(1268, 1731),
                centralX + 5946,
                centralY - 986,
                Color.FromArgb(255, 134, 77),
                "wall_10",
                "wall"
                );

            setObject(
                wall_11,
                new Size(6786, 520),
                centralX - 840,
                centralY - 986,
                Color.FromArgb(255, 134, 77),
                "wall_11",
                "wall"
                );

            setObject(
                wall_12,
                new Size(617, 140),
                centralX + 5329,
                centralY - 128,
                Color.FromArgb(255, 134, 77),
                "wall_12",
                "wall"
                );

            setObject(
                elevator_0,
                new Size(432, 180),
                centralX + 2033,
                centralY - 360,
                Color.Transparent,
                "elevator_0",
                "elevator"
                );

            setObject(
                elevator_1,
                new Size(432, 180),
                centralX + 4897,
                centralY + 187,
                Color.Transparent,
                "elevator_1",
                "elevator"
                );

            setObject(
                trigger,
                new Size(200, 200),
                centralX + 1392,
                centralY - 416,
                Color.Transparent,
                "trigger",
                "trigger"
                );

            setObject(
                door,
                new Size(150, 150),
                centralX + 5563,
                centralY - 278,
                Color.Transparent,
                "door",
                "door"
                );

            setObject(
                key,
                new Size(54, 108),
                centralX + 2986,
                centralY + 95,
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

            StateController.level_index = 4;

            key.BringToFront();
            player1.BringToFront();
            player2.BringToFront();

            BackgroundMusicController.play("./sound/doremi.wav");

            LevelFourEvent.Start();
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
