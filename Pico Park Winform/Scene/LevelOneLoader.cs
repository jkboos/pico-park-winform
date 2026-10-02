using Pico_Park_Winform.ButtonEvents;
using Pico_Park_Winform.GameObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.Scene
{
    public class LevelOneLoader
    {
        private static int centralX;
        private static int centralY;

        private static PictureBox wall_0 = new PictureBox();
        private static PictureBox wall_1 = new PictureBox();
        private static PictureBox wall_2 = new PictureBox();
        private static PictureBox wall_3 = new PictureBox();
        private static PictureBox wall_4 = new PictureBox();
        private static PictureBox wall_5 = new PictureBox();
        private static PictureBox wall_6 = new PictureBox();
        private static PictureBox wall_7 = new PictureBox();
        private static PictureBox wall_8 = new PictureBox();

        private static PictureBox respawnArea0 = new PictureBox();
        private static PictureBox respawn0 = new PictureBox();
        private static PictureBox respawnArea1 = new PictureBox();
        private static PictureBox respawn1 = new PictureBox();


        private static Player player1;
        private static Player player2;
        private static Door door = new Door(2);
        private static RedButton redButton = new RedButton(RedButtonEvents.LEVEL_ONE_GROUND, false);
        private static Elevator elevator;
        private static Key key;

        public static void Load(Panel panel)
        {
            panel.Location = new Point(-5750, -4500);
            centralX = Math.Abs(panel.Location.X);
            centralY = Math.Abs(panel.Location.Y);

            StateController.elevators.Clear();
            StateController.boxes.Clear();
            StateController.buttons.Clear();

            LevelOneGroundEvent.ground = wall_5;

            door = new Door(2);
            elevator = new Elevator(centralY + 211, centralY - 303, 2);
            key = new Key(centralX + 3913, centralY - 315);
            StateController.elevators.Add(elevator);
            StateController.buttons.Add(redButton);
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
            } while (panel.Controls.Count > 5) ;

            panel.Location = new Point(panel.Size.Width / 2 + 750, panel.Size.Height / 2 - 500);

            panel.Controls.Add(respawnArea0);
            panel.Controls.Add(respawn0);
            panel.Controls.Add(respawnArea1);
            panel.Controls.Add(respawn1);
            panel.Controls.Add(wall_0);
            panel.Controls.Add(wall_1);
            panel.Controls.Add(wall_2);
            panel.Controls.Add(wall_3);
            panel.Controls.Add(wall_4);
            panel.Controls.Add(wall_5);
            panel.Controls.Add(wall_6);
            panel.Controls.Add(wall_7);
            panel.Controls.Add(wall_8);
            panel.Controls.Add(door);
            panel.Controls.Add(redButton);
            panel.Controls.Add(elevator);
            panel.Controls.Add(key);

            // respawnArea0
            setObject(
                respawnArea0,
                new Size(182, 136),
                centralX + 960,
                centralY + 713,
                Color.Transparent,
                "0",
                "respawn");

            // respawn0
            setObject(
                respawn0,
                new Size(182, 136),
                centralX + 778,
                centralY - 540,
                Color.Transparent,
                null,
                "0");

            // respawnArea1
            setObject(
                respawnArea1,
                new Size(1097, 136),
                centralX + 2381,
                centralY + 713,
                Color.Transparent,
                "1",
                "respawn");

            // respawn1
            setObject(
                respawn1,
                new Size(182, 136),
                centralX + 2199,
                centralY - 540,
                Color.Transparent,
                null,
                "1");

            // wall_0
            setObject(
                wall_0,
                new Size(2011, 2183),
                centralX - 2917,
                centralY - 1405,
                Color.FromArgb(255, 134, 77),
                "wall_0",
                "wall");

            //wall_1
            setObject(
                wall_1,
                new Size(1965, 433),
                centralX - 1005,
                centralY + 415,
                Color.FromArgb(255, 134, 77),
                "wall_1",
                "wall");

            // wall_2
            setObject(
                wall_2,
                new Size(563, 434),
                centralX + 1143,
                centralY + 415,
                Color.FromArgb(255, 134, 77),
                "wall_2",
                "wall");

            // wall_3
            setObject(
                wall_3,
                new Size(165, 592),
                centralX + 1706,
                centralY + 257,
                Color.FromArgb(255, 134, 77),
                "wall_3",
                "wall");

            // wall_4
            setObject(
                wall_4,
                new Size(510, 760),
                centralX + 1871,
                centralY + 90,
                Color.FromArgb(255, 134, 77),
                "wall_4",
                "wall");

            // wall_5
            setObject(
                wall_5,
                new Size(604, 90),
                centralX + 2851,
                centralY + 415,
                Color.FromArgb(255, 134, 77),
                "wall_5",
                "wall");

            // wall_6
            setObject(
                wall_6,
                new Size(1540, 434),
                centralX + 3406,
                centralY + 415,
                Color.FromArgb(255, 134, 77),
                "wall_6",
                "wall");

            // wall_7
            setObject(
                wall_7,
                new Size(493, 1021),
                centralX + 4637,
                centralY - 159,
                Color.FromArgb(255, 134, 77),
                "wall_7",
                "wall");

            // wall_8
            setObject(
                wall_8,
                new Size(1525, 2652),
                centralX + 5130,
                centralY - 1790,
                Color.FromArgb(255, 134, 77),
                "wall_8",
                "wall");

            // redButton
            setObject(
                redButton,
                new Size(72, 32),
                centralX + 3372,
                centralY + 384,
                Color.Transparent,
                "redButton",
                "button");
            redButton.pressed = false;
            redButton.pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("button_0");

            // Elevator
            setObject(
                elevator,
                new Size(432, 180),
                centralX + 4205,
                centralY + 211,
                Color.Transparent,
                "elevator",
                "elevator");

            // Key
            setObject(
                key,
                new Size(54, 108),
                centralX + 3913,
                centralY - 315,
                Color.Transparent,
                "key",
                "key");

            // Door
            setObject(
                door,
                new Size(150, 150),
                centralX + 4809,
                centralY - 309,
                Color.Transparent,
                "door",
                "door");

            player1.Top = centralY + 200;
            player1.Left = centralX - 800;
            player1.isEnter = false;
            player1.Visible = true;


            player2.Top = centralY + 200;
            player2.Left = player1.Right + 100;
            player2.isEnter = false;
            player2.Visible = true;

            StateController.level_index = 1;

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
