using Pico_Park_Winform.ButtonEvents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pico_Park_Winform
{
    public class RedButtonEvent
    {
        private RedButtonEvents _event = 0;

        public RedButtonEvent(RedButtonEvents _event)
        {
            this._event = _event;

        }

        public void Start()
        {
            switch(_event)
            {
                case RedButtonEvents.LEVEL_ONE_GROUND:
                    LevelOneGroundEvent.Start();
                    break;
                case RedButtonEvents.LEVEL_THREE_EVENT_0:
                    LevelThreeEvent0.Start();
                    break;
                case RedButtonEvents.LEVEL_THREE_EVENT_1:
                    LevelThreeEvent1.Start();
                    break;
            }
        }
    }
}
