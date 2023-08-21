using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Stack<Buttons>  buttons = new Stack<Buttons>();
        int x=0,y=0, count=0, yy=0,xx=0;
        int h = 100, w = 30;
        private void button1_Click(object sender, EventArgs e)
        {
            count = ((int)numericUpDown1.Value);
            yy = w * count + 100;
            xx = x;
        }
                
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                if (count == y) { x++; y = 0; xx += h + 10; yy = w * count + 100; }
                Buttons b = new Buttons();
                b.Size = new Size(h, w);
                b.Location = new Point(xx, yy -= w);
                b.Pozition = new Point(x, y++);
                b.BackColor = Color.White;
                panel1.Controls.Add(b);
                b.Text = x.ToString() + "; " + y.ToString();
                buttons.Push(b);
            }
            else
            {
                MessageBox.Show("choose number of bricks");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                Button b = new Buttons();
                b = (Buttons)buttons.Pop();
                panel1.Controls.Remove(b);

                y--;
                if (y < 0) y = count - 1;
                if (y == 0) x--;
                xx = b.Location.X;
                yy = b.Location.Y + w;
            }
            else
            {
                MessageBox.Show("Stack is empty");
            }
        }

    }
}
