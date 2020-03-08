using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smallPhysics
{
    public class Ball
    {
        internal float x, y, rad, speed, mass;
        public Ball(float x, float y, float rad, float speed, float mass)
        {
            this.x = x;
            this.y = y;
            this.rad = rad;
            this.speed = speed;
            this.mass = mass;
            ControllerGame.createBall(this);
        }
        public void draw(Graphics gr)
        {
            gr.FillEllipse(Brushes.Black, x - rad, y - rad, rad * 2, rad * 2);
        }
    }
}
