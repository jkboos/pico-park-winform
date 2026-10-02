using Pico_Park_Winform.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform
{
    public class StateController
    {
        public static bool isPause = false;
        public static int level_index = 0;
        public static Panel panel;
        public static SelectLevelPanel selectLevelPanel;

        public static Door door = null;
        public static List<Elevator> elevators = new List<Elevator>();
        public static Key key = null;
        public static List<Box> boxes = new List<Box>();
        public static List<RedButton> buttons = new List<RedButton>();

        public static PictureBox trigger;
    }
}
