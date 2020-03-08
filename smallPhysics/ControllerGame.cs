using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smallPhysics
{
    public class ControllerGame
    {
        internal static Ball ball;
        internal static Box box;
        internal static Size clientSize;
        internal static bool jump = false;
        internal static bool right = false;
        internal static bool left = false;
        public static void init(Size siz)
        {
            clientSize = siz;
        }
        public static void createBall(Ball ball_1)
        {
            ball = ball_1;
        }
    }
}
