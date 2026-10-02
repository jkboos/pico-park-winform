using Pico_Park_Winform.ButtonEvents;
using Pico_Park_Winform.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.Scene
{
    public class LevelThreeLoader
    {
        private static int centralX;
        private static int centralY;

        private static Player player1;
        private static Player player2;
        private static Door door = new Door(4);
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
        private static PictureBox wall_13 = new PictureBox();
        private static PictureBox wall_14 = new PictureBox();
        private static PictureBox wall_15 = new PictureBox();

        private static Box box_0 = new Box(125, 140, 1);
        private static Box box_1 = new Box(125, 140, 1);
        private static Box box_2 = new Box(125, 140, 1);

        private static PictureBox respawnArea0 = new PictureBox();
        private static PictureBox respawn0 = new PictureBox();

        private static RedButton redButton_0 = new RedButton(RedButtonEvents.LEVEL_THREE_EVENT_0, false);
        private static RedButton redButton_1 = new RedButton(RedButtonEvents.LEVEL_THREE_EVENT_1, true);
        private static RedButton redButton_2 = new RedButton(RedButtonEvents.LEVEL_THREE_EVENT_1, true);
        private static RedButton redButton_3 = new RedButton(RedButtonEvents.LEVEL_THREE_EVENT_1, true);
        private static RedButton redButton_4 = new RedButton(RedButtonEvents.LEVEL_THREE_EVENT_1, true);


        public static void Load(Panel panel)
        {
            LevelThreeEvent0.wall_0 = wall_9;
            LevelThreeEvent0.wall_1 = wall_10;
            LevelThreeEvent1.buttons[0] = redButton_1;
            LevelThreeEvent1.buttons[1] = redButton_2;
            LevelThreeEvent1.buttons[2] = redButton_3;
            LevelThreeEvent1.buttons[3] = redButton_4;
            LevelThreeEvent1.wall_0 = wall_11;
            LevelThreeEvent1.wall_1 = wall_12;
            LevelThreeEvent1.wall_2 = wall_13;
            LevelThreeEvent1.wall_3 = wall_14;

            panel.Location = new Point(-5750, -4500);
            centralX = Math.Abs(panel.Location.X);
            centralY = Math.Abs(panel.Location.Y);

            StateController.elevators.Clear();
            StateController.boxes.Clear();
            StateController.buttons.Clear();

            StateController.boxes.Add(box_0);
            StateController.boxes.Add(box_1);
            StateController.boxes.Add(box_2);

            StateController.buttons.Add(redButton_0);
            StateController.buttons.Add(redButton_1);
            StateController.buttons.Add(redButton_2);
            StateController.buttons.Add(redButton_3);
            StateController.buttons.Add(redButton_4);

            door = new Door(4);
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
            panel.Controls.Add(wall_9);
            panel.Controls.Add(wall_10);
            panel.Controls.Add(wall_11);
            panel.Controls.Add(wall_12);
            panel.Controls.Add(wall_13);
            panel.Controls.Add(wall_14);
            panel.Controls.Add(wall_15);
            panel.Controls.Add(door);
            panel.Controls.Add(key);
            panel.Controls.Add(box_0);
            panel.Controls.Add(box_1);
            panel.Controls.Add(box_2);
            panel.Controls.Add(respawnArea0);
            panel.Controls.Add(respawn0);
            panel.Controls.Add(redButton_0);
            panel.Controls.Add(redButton_1);
            panel.Controls.Add(redButton_2);
            panel.Controls.Add(redButton_3);
            panel.Controls.Add(redButton_4);

            setObject(
                wall_0,
                new Size(130, 745),
                centralX - 65,
                centralY + 465,
                Color.FromArgb(255, 134, 77),
                "wall_0",
                "wall"
                );

            setObject(
                wall_1,
                new Size(627, 1860),
                centralX - 1434,
                centralY - 649,
                Color.FromArgb(255, 134, 77),
                "wall_1",
                "wall"
                );

            setObject(
                wall_2,
                new Size(100, 100),
                centralX + 328,
                centralY + 55,
                Color.FromArgb(255, 134, 77),
                "wall_2",
                "wall"
                );

            setObject(
                wall_3,
                new Size(100, 100),
                centralX + 428,
                centralY - 44,
                Color.FromArgb(255, 134, 77),
                "wall_3",
                "wall"
                );

            setObject(
                wall_4,
                new Size(100, 100),
                centralX + 528,
                centralY - 144,
                Color.FromArgb(255, 134, 77),
                "wall_4",
                "wall"
                );

            setObject(
                wall_5,
                new Size(100, 100),
                centralX + 628,
                centralY - 244,
                Color.FromArgb(255, 134, 77),
                "wall_5",
                "wall"
                );

            setObject(
                wall_6,
                new Size(3117, 745),
                centralX + 818,
                centralY + 465,
                Color.FromArgb(255, 134, 77),
                "wall_6",
                "wall"
                );

            setObject(
                wall_7,
                new Size(2378, 100),
                centralX + 728,
                centralY - 344,
                Color.FromArgb(255, 134, 77),
                "wall_7",
                "wall"
                );

            setObject(
                wall_8,
                new Size(100, 100),
                centralX + 1600,
                centralY + 195,
                Color.FromArgb(255, 134, 77),
                "wall_8",
                "wall"
                );

            setObject(
                wall_9,
                new Size(100, 100),
                centralX + 818,
                centralY + 465,
                Color.FromArgb(255, 134, 77),
                "wall_9",
                "wall"
                );

            setObject(
                wall_10,
                new Size(50, 100),
                centralX + 804,
                centralY - 344,
                Color.FromArgb(255, 134, 77),
                "wall_10",
                "wall"
                );

            setObject(
                wall_11,
                new Size(50, 404),
                centralX + 2755,
                centralY - 649,
                Color.FromArgb(255, 134, 77),
                "wall_11",
                "wall"
                );

            setObject(
                wall_12,
                new Size(50, 404),
                centralX + 2846,
                centralY - 649,
                Color.FromArgb(255, 134, 77),
                "wall_12",
                "wall"
                );

            setObject(
                wall_13,
                new Size(50, 404),
                centralX + 2934,
                centralY - 649,
                Color.FromArgb(255, 134, 77),
                "wall_13",
                "wall"
                );

            setObject(
                wall_14,
                new Size(50, 404),
                centralX + 3020,
                centralY - 649,
                Color.FromArgb(255, 134, 77),
                "wall_14",
                "wall"
                );

            setObject(
                wall_15,
                new Size(1049, 2851),
                centralX + 3935,
                centralY - 1641,
                Color.FromArgb(255, 134, 77),
                "wall_15",
                "wall"
                );

            setObject(
                box_0,
                new Size(125, 140),
                centralX - 62,
                centralY + 55,
                Color.FromArgb(255, 134, 77),
                "box_0",
                "box"
                );

            setObject(
                box_1,
                new Size(125, 140),
                centralX + 1188,
                centralY + 295,
                Color.FromArgb(255, 134, 77),
                "box_1",
                "box"
                );

            setObject(
                box_2,
                new Size(125, 140),
                centralX + 1922,
                centralY + 295,
                Color.FromArgb(255, 134, 77),
                "box_2",
                "box"
                );

            setObject(
                respawnArea0,
                new Size(1626, 336),
                centralX - 808,
                centralY + 873,
                Color.Transparent,
                "0",
                "respawn");

            setObject(
                respawn0,
                new Size(125, 140),
                centralX - 62,
                centralY - 698,
                Color.Transparent,
                null,
                "0");

            setObject(
                redButton_0,
                new Size(72, 32),
                centralX + 1356,
                centralY - 376,
                Color.Transparent,
                "redButton_0",
                "button");
            redButton_0.pressed = false;
            redButton_0.pictureBox1.Image = Properties.Resources.button_0;

            setObject(
                redButton_1,
                new Size(72, 32),
                centralX + 2453,
                centralY + 436,
                Color.Transparent,
                "redButton_1",
                "button");
            redButton_1.pressed = false;
            redButton_1.pictureBox1.Image = Properties.Resources.button_0;

            setObject(
                redButton_2,
                new Size(72, 32),
                centralX + 2622,
                centralY + 436,
                Color.Transparent,
                "redButton_2",
                "button");
            redButton_2.pressed = false;
            redButton_2.pictureBox1.Image = Properties.Resources.button_0;

            setObject(
                redButton_3,
                new Size(72, 32),
                centralX + 2788,
                centralY + 436,
                Color.Transparent,
                "redButton_3",
                "button");
            redButton_3.pressed = false;
            redButton_3.pictureBox1.Image = Properties.Resources.button_0;

            setObject(
                redButton_4,
                new Size(72, 32),
                centralX + 2948,
                centralY + 436,
                Color.Transparent,
                "redButton_4",
                "button");
            redButton_4.pressed = false;
            redButton_4.pictureBox1.Image = Properties.Resources.button_0;

            setObject(
                door,
                new Size(150, 150),
                centralX + 3405,
                centralY + 325,
                Color.Transparent,
                "door",
                "door");

            setObject(
                key,
                new Size(54, 108),
                centralX + 1733,
                centralY - 500,
                Color.Transparent,
                "key",
                "key");

            panel.Location = new Point(panel.Size.Width / 2 + 750, panel.Size.Height / 2 - 500);

            player1.Top = centralY + 324;
            player1.Left = centralX - 62;
            player1.isEnter = false;
            player1.Visible = true;


            player2.Top = centralY + 195;
            player2.Left = centralX - 62;
            player2.isEnter = false;
            player2.Visible = true;

            StateController.level_index = 3;

            key.BringToFront();
            player1.BringToFront();
            player2.BringToFront();
            door.SendToBack();

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
