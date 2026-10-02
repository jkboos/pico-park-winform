using Pico_Park_Winform.GameObject;
using System.Diagnostics;
using System.Resources;
using System.Media;
using Pico_Park_Winform.Level;
using Pico_Park_Winform.Scene;
using System.Numerics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pico_Park_Winform.ButtonEvents;

namespace Pico_Park_Winform
{
    public partial class Form1 : Form
    {

        int moveSpeed = 8;
        int jumpSpeed = 25;

        int cx;
        int cy;

        Player[] players = new Player[2];

        SoundPlayer jumpSound = new SoundPlayer("./sound/jump sound.wav");
        SoundPlayer clickSound = new SoundPlayer("./sound/click.wav");
        SoundPlayer clearSound = new SoundPlayer("./sound/clear.wav");

        bool playingAnimation = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;*/

            StateController.panel = panel1;
            StateController.selectLevelPanel = selectLevelPanel1;
            LevelOneGroundEvent.timer = LevelOneEventGroundTimer;
            LevelThreeEvent0.timer = LevelThreeEventTimer0;
            LevelThreeEvent1.timer = LevelThreeEventTimer1;
            LevelFourEvent.timer = LevelFourEventTimer;

            /*selectLevelPanel1.Width = 1920;
            selectLevelPanel1.Height = 1080;*/

            this.Width = 1920;
            this.Height = 1080;

            cx = ClientRectangle.Width / 2;
            cy = ClientRectangle.Height / 2;

            players[0] = player1;
            players[1] = player2;

            player2.flip = true;

            player1.Size = new Size(102, 116);
            player1.pictureBox1.Size = new Size(102, 116);
            player2.Size = new Size(102, 116);
            player2.pictureBox1.Size = new Size(102, 116);

            foreach (UserControl player in players)
            {
                player.SendToBack();
            }

            this.Focus();
            this.BackColor = Color.FromArgb(255, 240, 219);
            LobbyLoader.Load(panel1);
        }

        private void Movement_Tick(object sender, EventArgs e)
        {
            if (!StateController.isPause)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].right)
                    {
                        bool isMoved = players[i].Move(moveSpeed, true, panel1, ClientRectangle.Width);
                        if ((isMoved && players[(i + 1) % 2].stepOnPlayer))
                        {
                            players[(i + 1) % 2].Move(moveSpeed, true, panel1, ClientRectangle.Width);
                        }
                    }
                    else if (players[i].left)
                    {
                        bool isMoved = players[i].Move(moveSpeed, false, panel1, ClientRectangle.Width);
                        if ((isMoved && players[(i + 1) % 2].stepOnPlayer))
                        {
                            players[(i + 1) % 2].Move(moveSpeed, false, panel1, ClientRectangle.Width);
                        }
                    }
                    else
                    {
                        players[i].isPush = false;
                    }
                }
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!StateController.isPause)
            {
                /*
                 * 1P Control
                 */
                if (e.KeyCode == Keys.D && !player1.isEnter)
                {
                    player1.right = true;
                    if (player1.flip)
                    {
                        Image image = player1.pictureBox1.Image;
                        image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        player1.pictureBox1.Image = image;
                        player1.flip = false;
                    }

                }
                if (e.KeyCode == Keys.A && !player1.isEnter)
                {
                    player1.left = true;
                    if (!player1.flip)
                    {
                        Image image = player1.pictureBox1.Image;
                        image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        player1.pictureBox1.Image = image;
                        player1.flip = true;
                    }
                }
                if (e.KeyCode == Keys.W && (player1.isGrounded || player1.stepOnPlayer))
                {
                    if (player1.Bounds.IntersectsWith(StateController.door.Bounds) && StateController.door.isOpen)
                    {
                        if (player1.isEnter && !player1.Bounds.IntersectsWith(player2.Bounds) || (player1.isEnter && player2.isEnter))
                        {
                            player1.Visible = true;
                            StateController.door.count--;
                            player1.isEnter = false;
                        }
                        else if (!player1.isEnter)
                        {
                            player1.Visible = false;
                            StateController.door.count++;
                            player1.isEnter = true;
                            player1.Location = StateController.door.Location;
                            player1.Left += 30;
                            jumpSound.Play();
                        }
                    }
                    else if (!player1.isEnter)
                    {
                        Player newPlayer = new Player();
                        newPlayer.Location = player1.Location;
                        newPlayer.Size = player1.Size;
                        newPlayer.Top -= 5;
                        foreach (Box box in StateController.boxes)
                        {
                            if (newPlayer.Bounds.IntersectsWith(box.Bounds))
                            {
                                box.vertical_speed = -10;
                            }
                        }
                        player1.verticalSpeed = jumpSpeed;
                        jumpSound.Play();
                    }
                }

                /*
                 * 2P Control
                 */
                if (e.KeyCode == Keys.L && !player2.isEnter)
                {
                    player2.right = true;
                    if (player2.flip)
                    {
                        Image image = player2.pictureBox1.Image;
                        image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        player2.pictureBox1.Image = image;
                        player2.flip = false;
                    }

                }
                if (e.KeyCode == Keys.J && !player2.isEnter)
                {
                    player2.left = true;
                    if (!player2.flip)
                    {
                        Image image = player2.pictureBox1.Image;
                        image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        player2.pictureBox1.Image = image;
                        player2.flip = true;
                    }
                }
                if (e.KeyCode == Keys.I && (player2.isGrounded || player2.stepOnPlayer))
                {
                    if (player2.Bounds.IntersectsWith(StateController.door.Bounds) && StateController.door.isOpen)
                    {
                        if ((player2.isEnter && !player1.Bounds.IntersectsWith(player2.Bounds)) || (player1.isEnter && player2.isEnter))
                        {
                            player2.Visible = true;
                            StateController.door.count--;
                            player2.isEnter = false;
                        }
                        else if (!player2.isEnter)
                        {
                            player2.Visible = false;
                            StateController.door.count++;
                            player2.isEnter = true;
                            player2.Location = StateController.door.Location;
                            player2.Left += 30;
                            jumpSound.Play();
                        }
                    }
                    else if (!player2.isEnter)
                    {
                        Player newPlayer = new Player();
                        newPlayer.Location = player2.Location;
                        newPlayer.Size = player1.Size;
                        newPlayer.Top -= 5;
                        foreach (Box box in StateController.boxes)
                        {
                            if (newPlayer.Bounds.IntersectsWith(box.Bounds))
                            {
                                box.vertical_speed = -10;
                            }
                        }
                        player2.verticalSpeed = jumpSpeed;
                        jumpSound.Play();
                    }
                }
            }
            if (e.KeyCode == Keys.Escape && !playingAnimation)
            {
                if (StateController.isPause)
                {
                    pausePanel1.Enabled = false;
                    pausePanel1.Visible = false;

                    selectLevelPanel1.Enabled = false;
                    selectLevelPanel1.Visible = false;

                    StateController.isPause = false;
                }
                else
                {
                    pausePanel1.Location = new Point(Math.Abs(panel1.Location.X) + ClientRectangle.Width / 2 - pausePanel1.Width / 2, Math.Abs(panel1.Location.Y) + ClientRectangle.Height / 2 - pausePanel1.Height / 2);
                    pausePanel1.Enabled = true;
                    pausePanel1.Visible = true;
                    pausePanel1.BringToFront();

                    StateController.isPause = true;
                    PauseTimer.Start();
                }
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            /*
                * 1P Control
                */
            if (e.KeyCode == Keys.D)
            {
                player1.right = false;
                player1.moveAnimationIndex = 0;
                if (player1.left)
                {
                    player1.flip = true;
                }
            }
            if (e.KeyCode == Keys.A)
            {
                player1.left = false;
                player1.moveAnimationIndex = 0;
                if (player1.right)
                {
                    player1.flip = false;
                }
            }

            /*
                * 2P Control
                */
            if (e.KeyCode == Keys.L)
            {
                player2.right = false;
                player2.moveAnimationIndex = 0;
                if (player2.left)
                {
                    player2.flip = true;
                }
            }
            if (e.KeyCode == Keys.J)
            {
                player2.left = false;
                player2.moveAnimationIndex = 0;
                if (player2.right)
                {
                    player2.flip = false;
                }
            }

        }

        private void MoveAnimation_Tick(object sender, EventArgs e)
        {
            if (!StateController.isPause)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].isGrounded && !(players[i].left || players[i].right))
                    {
                        Image image = (Image)Properties.Resources.ResourceManager.GetObject("idle_" + i);
                        if (players[i].flip)
                        {
                            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        }
                        players[i].pictureBox1.Image = image;
                    }

                    if (players[i].isGrounded && (players[i].left || players[i].right) && !players[i].isPush)
                    {
                        Image image = (Image)Properties.Resources.ResourceManager.GetObject("move" + (players[i].moveAnimationIndex++ % 8) + "_" + i);
                        if (players[i].flip)
                        {
                            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        }
                        players[i].pictureBox1.Image = image;
                    }
                    else if (players[i].isGrounded && (players[i].left || players[i].right) && players[i].isPush)
                    {
                        Image image = (Image)Properties.Resources.ResourceManager.GetObject("push" + (players[i].moveAnimationIndex++ % 8) + "_" + i);
                        if (players[i].flip)
                        {
                            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        }
                        players[i].pictureBox1.Image = image;
                    }

                    if (!players[i].isGrounded)
                    {
                        Image image = (Image)Properties.Resources.ResourceManager.GetObject("jump_" + i);
                        if (players[i].flip)
                        {
                            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        }
                        players[i].pictureBox1.Image = image;
                    }
                }
            }
        }

        private void Gravity_Tick(object sender, EventArgs e)
        {
            if (!StateController.isPause)
            {
                foreach (Player player in players)
                {
                    player.VerticalMove(panel1);
                }
                foreach (Box box in StateController.boxes)
                {
                    box.VerticalMove();
                }
            }
        }

        private void Camera_Tick(object sender, EventArgs e)
        {
            if (!StateController.isPause)
            {
                /*
                 * TODO:
                 *  1. Move the camera to the center of the players by moving the panel.
                 *
                 */

                int player1X = panel1.Location.X + player1.Location.X + player1.Size.Width / 2;
                int player1Y = panel1.Location.Y + player1.Location.Y + player1.Size.Height / 2 - 300;
                int player2X = panel1.Location.X + player2.Location.X + player2.Size.Width / 2;
                int player2Y = panel1.Location.Y + player2.Location.Y + player2.Size.Height / 2 - 300;

                int cameraMoveX = cx - (player1X + player2X) / 2;
                int cameraMoveY = cy - (player1Y + player2Y) / 2;

                //panel1.Location = new Point(panel1.Location.X + cameraMoveX, panel1.Location.Y + cameraMoveY);
                panel1.Location = new Point(panel1.Location.X + cameraMoveX, -4000);
            }
        }

        private void Respawner_Tick(object sender, EventArgs e)
        {

            if (!StateController.isPause)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    foreach (Control control in panel1.Controls)
                    {
                        if (control.Tag == "respawn" && players[i].Bounds.IntersectsWith(control.Bounds))
                        {
                            foreach (Control respawn in panel1.Controls)
                            {
                                if (respawn.Tag != null && respawn.Tag.ToString() == control.Name.ToString())
                                {
                                    players[i].Location = respawn.Location;
                                }
                                if (StateController.key.player != null && StateController.key.player.Name == players[i].Name)
                                {
                                    StateController.key.reset();
                                }
                            }
                        }
                    }
                }

                foreach (Box box in StateController.boxes)
                {
                    foreach (Control control in panel1.Controls)
                    {
                        if (control.Tag == "respawn" && box.Bounds.IntersectsWith(control.Bounds))
                        {
                            foreach (Control respawn in panel1.Controls)
                            {
                                if (respawn.Tag != null && respawn.Tag.ToString() == control.Name.ToString())
                                {
                                    box.Location = respawn.Location;
                                    box.Top -= 100;
                                }
                                if (StateController.key.player != null && StateController.key.player.Name == box.Name)
                                {
                                    StateController.key.reset();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CollisionDetection_Tick(object sender, EventArgs e)
        {
            if (!StateController.isPause)
            {
                /*
                 * TODO:
                 *  Collect something like keys.
                 *  ...
                 */
                foreach (Control control in panel1.Controls)
                {
                    for (int i = 0; i < players.Length; i++)
                    {
                        if (players[i].Bounds.IntersectsWith(control.Bounds))
                        {
                            if (control is RedButton && !((RedButton)control).pressed)
                            {
                                RedButton redButton = (RedButton)control;
                                redButton.pressed = true;
                                clickSound.Play();
                                redButton.Press();
                                redButton.pictureBox1.Image = Properties.Resources.button_1;
                            }
                            else if (control is Key)
                            {
                                if (StateController.key.player != null && StateController.key.player.Name != players[i].Name)
                                {
                                    StateController.key.player = players[i];
                                }
                                else if (StateController.key.player == null)
                                {
                                    StateController.key.player = players[i];
                                    clickSound.Play();
                                }
                            }
                        }
                    }
                    foreach (Box box in StateController.boxes)
                    {
                        if (box.Bounds.IntersectsWith(control.Bounds))
                        {
                            if (control is RedButton && !((RedButton)control).pressed)
                            {
                                RedButton redButton = (RedButton)control;
                                redButton.pressed = true;
                                clickSound.Play();
                                redButton.Press();
                                redButton.pictureBox1.Image = Properties.Resources.button_1;
                            }
                        }
                    }
                }

                foreach (RedButton button in StateController.buttons)
                {
                    if (button.canPop)
                    {
                        bool flag = false;
                        foreach (Control control in panel1.Controls)
                        {
                            if ((control is Player || control is Box) && button.Bounds.IntersectsWith(control.Bounds))
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            button.pressed = false;
                            button.pictureBox1.Image = Properties.Resources.button_0;
                        }
                    }
                }

                if (StateController.level_index == 4 && StateController.trigger != null)
                {
                    foreach (Player player in players)
                    {
                        if (player.Bounds.IntersectsWith(StateController.trigger.Bounds))
                        {
                            LevelFourEvent.startEvent1 = true;
                        }
                    }
                }

                if (StateController.key != null && StateController.door != null && StateController.key.Bounds.IntersectsWith(StateController.door.Bounds))
                {
                    StateController.key.Enabled = false;
                    StateController.key.Visible = false;
                    StateController.door.isOpen = true;
                    StateController.door.pictureBox1.Image = Properties.Resources.door_open;
                    clickSound.Play();
                }
            }
        }

        private void PauseTimer_Tick(object sender, EventArgs e)
        {
            pausePanel1.Location = new Point(Math.Abs(panel1.Location.X) + ClientRectangle.Width / 2 - pausePanel1.Width / 2, Math.Abs(panel1.Location.Y) + ClientRectangle.Height / 2 - pausePanel1.Height / 2);
            selectLevelPanel1.Location = new Point(Math.Abs(panel1.Location.X), Math.Abs(panel1.Location.Y));

            if (!StateController.isPause)
            {
                PauseTimer.Stop();
            }
        }

        private void ElevatorMovement_Tick(object sender, EventArgs e)
        {
            if (!StateController.isPause)
            {
                foreach (Elevator elevator in StateController.elevators)
                {
                    switch (elevator.max_num - elevator.players.Count)
                    {
                        case 0:
                            elevator.elevator_num.Image = Properties.Resources.num_0;
                            break;
                        case 1:
                            elevator.elevator_num.Image = Properties.Resources.num_1;
                            break;
                        case 2:
                            elevator.elevator_num.Image = Properties.Resources.num_2;
                            break;
                    }

                    if (elevator.players.Count >= elevator.max_num)
                    {
                        if(elevator.startY - elevator.endY < 0)
                        {
                            if (elevator.Top < elevator.endY)
                            {
                                elevator.Down();
                            }
                        }
                        else
                        {
                            if (elevator.Top > elevator.endY)
                            {
                                elevator.Up();
                            }
                        }
                    }
                    else
                    {
                        if (elevator.startY - elevator.endY < 0)
                        {
                            if (elevator.Top > elevator.startY)
                            {
                                elevator.Up();
                            }
                        }
                        else
                        {
                            if (elevator.Top < elevator.startY)
                            {
                                elevator.Down();
                            }
                        }
                    }
                }
            }
        }

        private void KeyTimer_Tick(object sender, EventArgs e)
        {
            if (!StateController.isPause)
            {
                if (StateController.key != null)
                {
                    if (StateController.key.player != null)
                    {
                        if (!StateController.key.player.flip)
                        {
                            StateController.key.targetX = StateController.key.player.Left - StateController.key.Width;
                            StateController.key.targetY = StateController.key.player.Top - StateController.key.Height;
                        }
                        else
                        {
                            StateController.key.targetX = StateController.key.player.Right;
                            StateController.key.targetY = StateController.key.player.Top - StateController.key.Height;
                        }

                        if (Math.Abs(StateController.key.Location.X - StateController.key.targetX) > 5)
                        {
                            int a = Math.Abs(StateController.key.Location.X - StateController.key.targetX);
                            StateController.key.Left += StateController.key.speedX;
                            int b = Math.Abs(StateController.key.Location.X - StateController.key.targetX);
                            if (b > a)
                            {
                                StateController.key.speedX *= -1;
                            }
                        }
                        else
                        {
                            StateController.key.speedX = 0;
                        }
                        if (Math.Abs(StateController.key.Location.Y - StateController.key.targetY) > 5)
                        {
                            int a = Math.Abs(StateController.key.Location.Y - StateController.key.targetY);
                            StateController.key.Top += StateController.key.speedY;
                            int b = Math.Abs(StateController.key.Location.Y - StateController.key.targetY);
                            if (b > a)
                            {
                                StateController.key.speedY *= -1;
                            }
                        }
                        else
                        {
                            StateController.key.speedY = 0;
                        }
                    }
                }
            }
        }

        private void KeyAcceleration_Tick(object sender, EventArgs e)
        {
            if (!StateController.isPause)
            {
                if (StateController.key != null)
                {
                    if (StateController.key.player != null)
                    {
                        if (Math.Abs(StateController.key.speedX) < StateController.key.maxSpeed)
                        {
                            if (StateController.key.targetX - StateController.key.Left < 0)
                            {
                                StateController.key.speedX--;
                            }
                            else
                            {
                                StateController.key.speedX++;
                            }
                        }

                        if (Math.Abs(StateController.key.speedY) < StateController.key.maxSpeed)
                        {
                            if (StateController.key.targetY - StateController.key.Top < 0)
                            {
                                StateController.key.speedY--;
                            }
                            else
                            {
                                StateController.key.speedY++;
                            }
                        }
                    }
                }
            }
        }

        private void DoorCheck_Tick(object sender, EventArgs e)
        {
            if (StateController.door != null)
            {
                if (StateController.door.count == 2 && !playingAnimation)
                {
                    if (LevelThreeEvent1.timer.Enabled)
                    {
                        LevelThreeEvent1.timer.Stop();
                    }

                    string jsonContent = File.ReadAllText("./record.json");
                    JObject jsonObject = JObject.Parse(jsonContent);
                    jsonObject["record"][$"level_{StateController.level_index}"] = true;
                    File.WriteAllText("./record.json", jsonObject.ToString());

                    playingAnimation = true;
                    BackgroundMusicController.stop();
                    clear.Location = new Point(Math.Abs(panel1.Location.X) - clear.Width, Math.Abs(panel1.Location.Y) + this.Height / 2 - clear.Height / 2);
                    clear.BringToFront();
                    clear.Visible = true;
                    StateController.isPause = true;
                    clearSound.Play();
                    Thread.Sleep(1000);
                    GameOverAnimation.Start();
                }
            }
        }

        private void GameOverAnimation_Tick(object sender, EventArgs e)
        {
            if (clear.Left < Math.Abs(panel1.Location.X) + this.Width / 2 - clear.Width / 2)
            {
                clear.Left += 25;
            }
            else
            {
                Thread.Sleep(2000);
                StateController.isPause = false;
                clear.Visible = false;
                playingAnimation = false;
                GameOverAnimation.Stop();
                StateController.door.loadScene();
            }
        }

        private void BoxPlayerCheck_Tick(object sender, EventArgs e)
        {
            if (!StateController.isPause)
            {
                foreach (Box box in StateController.boxes)
                {
                    box.PlayerCheck();
                    if (box.max_num - box.players.Count < 0)
                    {
                        box.number.Image = (Image)Properties.Resources.ResourceManager.GetObject($"num_0_white");
                    }
                    else
                    {
                        box.number.Image = (Image)Properties.Resources.ResourceManager.GetObject($"num_{box.max_num - box.players.Count}_white");
                    }
                    if (box.players.Count >= box.max_num)
                    {
                        if (box.right)
                        {
                            box.Move(3);
                        }
                        else
                        {
                            box.Move(-3);
                        }
                    }
                }
            }
        }

        private void LevelOneEventGroundTimer_Tick(object sender, EventArgs e)
        {
            if (!StateController.isPause)
            {
                LevelOneGroundEvent.Event(players);
            }
        }

        private void LevelTwoEventTimer0_Tick(object sender, EventArgs e)
        {
            if (!StateController.isPause)
            {
                LevelThreeEvent0.Event(players);
            }
        }

        private void LevelTwoEventTimer1_Tick(object sender, EventArgs e)
        {
            if (!StateController.isPause)
            {
                LevelThreeEvent1.Event(players);
            }
        }

        private void LevelFourEventTimer_Tick(object sender, EventArgs e)
        {
            if (!StateController.isPause)
            {
                LevelFourEvent.Event0(players);
                if(LevelFourEvent.startEvent1)
                {
                    LevelFourEvent.Event1(players);
                }
            }
        }
    }
}
