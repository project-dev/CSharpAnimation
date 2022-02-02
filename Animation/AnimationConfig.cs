using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animation
{
    internal class AnimationConfig
    {
        public static int framerate
        {
            get
            {
                return 60;
            }

        }

        public static int maxSprite
        {
            get
            {
                return 100;
            }
        }

        public static int bmpWidth
        {
            get
            {
                return 1024;
            }
        }

        public static int bmpHeight
        {
            get
            {
                return 578;
            }

        }

        public static Boolean isWriteMode
        {
            get;
            set;
        } = false;
        
        public static Boolean isOutCopyrighte
        {
            get;
            set;
        } = false;

        public static int writeFrameCnt
        {
            get;
            set;
        } = 0;
        
        public static int movieLength
        {
            get;
            set;
        } = 0;

    }
}
