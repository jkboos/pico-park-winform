namespace Pico_Park_Winform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Movement = new System.Windows.Forms.Timer(components);
            MoveAnimation = new System.Windows.Forms.Timer(components);
            Gravity = new System.Windows.Forms.Timer(components);
            CollisionDetection = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            clear = new PictureBox();
            selectLevelPanel1 = new GameObject.SelectLevelPanel();
            pausePanel1 = new GameObject.pausePanel();
            player2 = new GameObject.Player();
            player1 = new GameObject.Player();
            Camera = new System.Windows.Forms.Timer(components);
            Respawner = new System.Windows.Forms.Timer(components);
            PauseTimer = new System.Windows.Forms.Timer(components);
            LevelOneEventGroundTimer = new System.Windows.Forms.Timer(components);
            ElevatorMovement = new System.Windows.Forms.Timer(components);
            KeyTimer = new System.Windows.Forms.Timer(components);
            KeyAcceleration = new System.Windows.Forms.Timer(components);
            DoorCheck = new System.Windows.Forms.Timer(components);
            GameOverAnimation = new System.Windows.Forms.Timer(components);
            BoxPlayerCheck = new System.Windows.Forms.Timer(components);
            LevelThreeEventTimer0 = new System.Windows.Forms.Timer(components);
            LevelThreeEventTimer1 = new System.Windows.Forms.Timer(components);
            LevelFourEventTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clear).BeginInit();
            SuspendLayout();
            //
            // Movement
            //
            Movement.Enabled = true;
            Movement.Interval = 1;
            Movement.Tick += Movement_Tick;
            //
            // MoveAnimation
            //
            MoveAnimation.Enabled = true;
            MoveAnimation.Interval = 200;
            MoveAnimation.Tick += MoveAnimation_Tick;
            //
            // Gravity
            //
            Gravity.Enabled = true;
            Gravity.Interval = 1;
            Gravity.Tick += Gravity_Tick;
            //
            // CollisionDetection
            //
            CollisionDetection.Enabled = true;
            CollisionDetection.Interval = 1;
            CollisionDetection.Tick += CollisionDetection_Tick;
            //
            // panel1
            //
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(clear);
            panel1.Controls.Add(selectLevelPanel1);
            panel1.Controls.Add(pausePanel1);
            panel1.Controls.Add(player2);
            panel1.Controls.Add(player1);
            panel1.Location = new Point(-5750, -4500);
            panel1.Name = "panel1";
            panel1.Size = new Size(20000, 20000);
            panel1.TabIndex = 6;
            //
            // clear
            //
            clear.Image = Properties.Resources.clear;
            clear.Location = new Point(6567, 4959);
            clear.Name = "clear";
            clear.Size = new Size(260, 67);
            clear.SizeMode = PictureBoxSizeMode.StretchImage;
            clear.TabIndex = 7;
            clear.TabStop = false;
            clear.Tag = "clear";
            clear.Visible = false;
            //
            // selectLevelPanel1
            //
            selectLevelPanel1.BackColor = Color.FromArgb(255, 240, 219);
            selectLevelPanel1.Enabled = false;
            selectLevelPanel1.Location = new Point(5740, 4455);
            selectLevelPanel1.Name = "selectLevelPanel1";
            selectLevelPanel1.Size = new Size(1920, 1080);
            selectLevelPanel1.TabIndex = 8;
            selectLevelPanel1.Tag = "select_level";
            selectLevelPanel1.Visible = false;
            //
            // pausePanel1
            //
            pausePanel1.BackColor = SystemColors.Control;
            pausePanel1.Enabled = false;
            pausePanel1.Location = new Point(6467, 4619);
            pausePanel1.Name = "pausePanel1";
            pausePanel1.Size = new Size(512, 533);
            pausePanel1.TabIndex = 7;
            pausePanel1.Tag = "pause_panel";
            pausePanel1.Visible = false;
            //
            // player2
            //
            player2.AutoScroll = true;
            player2.BackColor = Color.Transparent;
            player2.Location = new Point(7141, 5178);
            player2.Name = "player2";
            player2.Size = new Size(125, 143);
            player2.TabIndex = 6;
            player2.Tag = "player2";
            //
            // player1
            //
            player1.BackColor = Color.Transparent;
            player1.Location = new Point(6174, 5184);
            player1.Name = "player1";
            player1.Size = new Size(125, 140);
            player1.TabIndex = 5;
            player1.Tag = "player1";
            //
            // Camera
            //
            Camera.Enabled = true;
            Camera.Interval = 1;
            Camera.Tick += Camera_Tick;
            //
            // Respawner
            //
            Respawner.Enabled = true;
            Respawner.Interval = 1;
            Respawner.Tick += Respawner_Tick;
            //
            // PauseTimer
            //
            PauseTimer.Interval = 1;
            PauseTimer.Tick += PauseTimer_Tick;
            //
            // LevelOneEventGroundTimer
            //
            LevelOneEventGroundTimer.Interval = 1;
            LevelOneEventGroundTimer.Tick += LevelOneEventGroundTimer_Tick;
            //
            // ElevatorMovement
            //
            ElevatorMovement.Enabled = true;
            ElevatorMovement.Interval = 1;
            ElevatorMovement.Tick += ElevatorMovement_Tick;
            //
            // KeyTimer
            //
            KeyTimer.Enabled = true;
            KeyTimer.Interval = 1;
            KeyTimer.Tick += KeyTimer_Tick;
            //
            // KeyAcceleration
            //
            KeyAcceleration.Enabled = true;
            KeyAcceleration.Interval = 10;
            KeyAcceleration.Tick += KeyAcceleration_Tick;
            //
            // DoorCheck
            //
            DoorCheck.Enabled = true;
            DoorCheck.Interval = 1;
            DoorCheck.Tick += DoorCheck_Tick;
            //
            // GameOverAnimation
            //
            GameOverAnimation.Interval = 1;
            GameOverAnimation.Tick += GameOverAnimation_Tick;
            //
            // BoxPlayerCheck
            //
            BoxPlayerCheck.Enabled = true;
            BoxPlayerCheck.Interval = 1;
            BoxPlayerCheck.Tick += BoxPlayerCheck_Tick;
            //
            // LevelThreeEventTimer0
            //
            LevelThreeEventTimer0.Interval = 1;
            LevelThreeEventTimer0.Tick += LevelTwoEventTimer0_Tick;
            //
            // LevelThreeEventTimer1
            //
            LevelThreeEventTimer1.Interval = 1;
            LevelThreeEventTimer1.Tick += LevelTwoEventTimer1_Tick;
            //
            // LevelFourEventTimer
            //
            LevelFourEventTimer.Interval = 1;
            LevelFourEventTimer.Tick += LevelFourEventTimer_Tick;
            //
            // Form1
            //
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1898, 1024);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Name = "Form1";
            Text = "Pico Park but the budget is 0$";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)clear).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer Movement;
        private System.Windows.Forms.Timer MoveAnimation;
        private System.Windows.Forms.Timer Gravity;
        private System.Windows.Forms.Timer CollisionDetection;
        private Panel panel1;
        private GameObject.Player player2;
        private GameObject.Player player1;
        private System.Windows.Forms.Timer Camera;
        private System.Windows.Forms.Timer Respawner;
        private GameObject.pausePanel pausePanel1;
        private System.Windows.Forms.Timer PauseTimer;
        private GameObject.SelectLevelPanel selectLevelPanel1;
        private System.Windows.Forms.Timer LevelOneEventGroundTimer;
        private System.Windows.Forms.Timer ElevatorMovement;
        private System.Windows.Forms.Timer KeyTimer;
        private System.Windows.Forms.Timer KeyAcceleration;
        private System.Windows.Forms.Timer DoorCheck;
        private System.Windows.Forms.Timer GameOverAnimation;
        private PictureBox clear;
        private System.Windows.Forms.Timer BoxPlayerCheck;
        private System.Windows.Forms.Timer LevelThreeEventTimer0;
        private System.Windows.Forms.Timer LevelThreeEventTimer1;
        private System.Windows.Forms.Timer LevelFourEventTimer;
    }
}
