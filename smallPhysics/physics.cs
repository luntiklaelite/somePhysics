using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smallPhysics
{
    public class Physics
    {
        public const float gravity = 9.8f;
        public const float tick = 1f;
        public static float hMax = 0;
        public static float hNow = 0;
        
        public static void refresh()
        {
            hMax = (ControllerGame.ball.speed * ControllerGame.ball.speed) / (2 * gravity);
            Ball ball = ControllerGame.ball;
            Box box = ControllerGame.box;


            #region Коллизия
            if(isCollision(ball,box))
            {

                ControllerGame.left = false;
                ControllerGame.right = false;
            }
            #endregion


            #region Падения
            if (ControllerGame.clientSize.Height < ball.y + ball.rad)
            {
                ControllerGame.ball.y = ControllerGame.clientSize.Height - ball.rad + 1;
                 ControllerGame.jump = false;
                hNow = 0;
            }
            else // свободное падение
            {
                if ( !ControllerGame.jump)
                {
                    ControllerGame.ball.y = ball.y + ball.speed * tick - (gravity * tick * tick) / 2;
                    ControllerGame.jump = false;
                }
                else if (ControllerGame.jump)
                {
                    hNow += ball.speed / 30;
                    if (hNow >= hMax)
                        ControllerGame.jump = false;
                }
            }
            #endregion
        }
        public static bool isCollision(Ball ball, Box box)
        {

            if (ball.y + ball.rad > box.y && ball.x + ball.rad > box.x && ball.x - ball.rad < box.x + box.width && ball.y - ball.rad < box.y)
            {
                ControllerGame.ball.y = box.y - ball.rad - 5;
                return true;
            }
            //sides
            else if (ball.x + ball.rad > box.x && ball.x + ball.rad < box.x + box.width && ball.y + ball.rad >= box.y)
            {
                ControllerGame.ball.x = box.x-ball.rad;
                return true;
            }
            else if (ball.x - ball.rad < box.x + box.width && ball.x - ball.rad > box.x && ball.y + ball.rad >= box.y)
            {
                ControllerGame.ball.x = box.x + box.width + ball.rad;
                return true;
            }
            //top
            return false;
        }
    }
}
