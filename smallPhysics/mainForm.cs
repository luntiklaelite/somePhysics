using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smallPhysics
{
    public partial class mainForm : Form
    {
        Ball ball;
        Box box;
        
        public mainForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ControllerGame.init(ClientSize);
            ball = new Ball(ClientSize.Width/2, ClientSize.Height/2, 20, 10, 50);
            box = new Box(ClientSize.Width - 200, ClientSize.Height - 50, 50, 50, 50);
            timer1.Start();
        }

        private void mainForm_Paint(object sender, PaintEventArgs e)
        {
            ControllerGame.ball.draw(e.Graphics);
            ControllerGame.box.draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(ControllerGame.jump) { ControllerGame.ball.y -= 7; }
            if(ControllerGame.left) { ControllerGame.ball.x -= 7; }
            if (ControllerGame.right) { ControllerGame.ball.x += 7; }
            Physics.refresh();
            Refresh();
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && !ControllerGame.jump)
                ControllerGame.jump = true;
            if (e.KeyCode == Keys.A)
                ControllerGame.left = true;
            if (e.KeyCode == Keys.D)
                ControllerGame.right = true;
        }

        private void mainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                ControllerGame.left = false;
            if (e.KeyCode == Keys.D)
                ControllerGame.right = false;
        }
    }
}
