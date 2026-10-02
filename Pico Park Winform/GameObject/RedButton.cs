using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform.GameObject
{
    public class RedButton : UserControl
    {
        public PictureBox pictureBox1;
        private RedButtonEvent redButtonEvent;
        public bool pressed = false;
        public bool canPop = false;

        public RedButton(RedButtonEvents redButtonEvent, bool canPop)
        {
            InitializeComponent();

            this.redButtonEvent = new RedButtonEvent(redButtonEvent);
            this.canPop = canPop;
        }

        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            //
            // pictureBox1
            //
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.button_0;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(72, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            //
            // RedButton
            //
            BackColor = Color.Transparent;
            Controls.Add(pictureBox1);
            Name = "RedButton";
            Size = new Size(72, 32);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        public void Press()
        {
            redButtonEvent.Start();
        }
    }
}
