using Pico_Park_Winform.Level;
using Pico_Park_Winform.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.GameObject
{
    public class Door : UserControl
    {
        public PictureBox pictureBox1;

        int target_loader_index;
        public int count = 0;
        public bool isOpen = false;

        public Door(int target_loader_index)
        {
            this.target_loader_index = target_loader_index;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            //
            // pictureBox1
            //
            pictureBox1.Image = Properties.Resources.door;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            //
            // Door
            //
            BackColor = Color.Transparent;
            Controls.Add(pictureBox1);
            Name = "Door";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        public void loadScene()
        {
            switch(target_loader_index)
            {
                case 0:
                    LobbyLoader.Load(StateController.panel);
                    break;
                case 1:
                    LevelOneLoader.Load(StateController.panel);
                    break;
                case 2:
                    LevelTwoLoader.Load(StateController.panel);
                    break;
                case 3:
                    LevelThreeLoader.Load(StateController.panel);
                    break;
                case 4:
                    LevelFourLoader.Load(StateController.panel);
                    break;
            }
        }
    }
}
