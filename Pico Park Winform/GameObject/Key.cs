using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.GameObject
{
    public class Key : UserControl
    {
        public Key(int posX, int posY)
        {
            InitializeComponent();
            this.posX = posX;
            this.posY = posY;
        }

        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            //
            // pictureBox1
            //
            pictureBox1.Image = Properties.Resources.key;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(54, 108);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            //
            // Key
            //
            BackColor = Color.Transparent;
            Controls.Add(pictureBox1);
            Name = "Key";
            Size = new Size(54, 108);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        public void reset()
        {
            Debug.WriteLine($"{posX} {posY}");
            this.Location = new Point(posX, posY);
            this.player = null;
            this.speedX = 0;
            this.speedY = 0;
        }

        private PictureBox pictureBox1;
        private int posX = 0;
        private int posY = 0;

        public Player player = null;
        public int speedX = 0;
        public int speedY = 0;
        public int maxSpeed = 8;
        public int targetX;
        public int targetY;
    }
}
