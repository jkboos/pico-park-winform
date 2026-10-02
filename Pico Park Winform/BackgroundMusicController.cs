using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Pico_Park_Winform
{

    public class BackgroundMusicController
    {
        private static WindowsMediaPlayer mediaPlayer = new WindowsMediaPlayer();
        private static bool added = false;
        private static bool looping = true;
        private static bool musicEnd = false;

        private static void MediaPlayer_PlayStateChange(int NewState)
        {
            if (NewState == 1 && musicEnd && looping)
            {
                mediaPlayer.controls.play();
            }
            else if (NewState == 8)
            {
                musicEnd = true;
            }
            else if (NewState == 2 || NewState == 3)
            {
                musicEnd = false;
            }
        }

        public static void setLoop(bool loop)
        {
            looping = loop;
        }

        public static void stop()
        {
            mediaPlayer.controls.stop();
        }

        public static void play(string path)
        {
            if (!added)
            {
                mediaPlayer.PlayStateChange += MediaPlayer_PlayStateChange;
            }

            mediaPlayer.URL = path;
            mediaPlayer.controls.play();
        }
    }
}
