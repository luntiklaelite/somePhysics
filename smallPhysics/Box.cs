using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smallPhysics
{
    public class Box
    {
        internal float x, y;
        internal float width, height, mass;
        public Box(float x, float y, float width, float height, float mass)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.mass = mass;
            ControllerGame.box = this;
        }
        public void draw(Graphics gr)
        {
            gr.DrawRectangle(new Pen(Brushes.Black, 2), x, y, width, height);
        }
    }
}
