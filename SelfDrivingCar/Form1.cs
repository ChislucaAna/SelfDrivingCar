using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelfDrivingCar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        Canvas canvas;
        Car myCar;
        private HashSet<Keys> pressedKeys = new HashSet<Keys>(); //we want out car to rotate when front and left are pressed at the same time, for ex

        private void Form1_Load(object sender, EventArgs e)
        {  
            canvas=new Canvas(this.Width,this.Height);
            myCar = new Car(this.Width/2-Car.width/2, this.Height/2);
            animate.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            canvas.DrawScenery(e.Graphics);
            canvas.DrawCar(e.Graphics,myCar);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKeys.Add(e.KeyCode);
        }

        private void animate_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(pressedKeys.Count);
            bool up = pressedKeys.Contains(Keys.W);
            bool left = pressedKeys.Contains(Keys.A);
            bool right = pressedKeys.Contains(Keys.D);
            bool down = pressedKeys.Contains(Keys.S);
            if (up)
            {
                Console.WriteLine("up");
                myCar.speed += Car.acceleration;
                if (myCar.speed > Car.MaxSpeed)
                    myCar.speed = Car.MaxSpeed;
            }
            if (down)
            {
                Console.WriteLine("down");
                myCar.speed -= Car.acceleration;
                if (myCar.speed < -Car.MaxSpeed / 2)
                    myCar.speed = -Car.MaxSpeed / 2;
            }
            if (left)
            {
                Console.WriteLine("left");
                if (myCar.speed != 0) //we can't rotate a car in place
                    myCar.angle -= (float)0.03;
            }
            if (right)
            {
                Console.WriteLine("right");
                if (myCar.speed != 0) //we can't rotate a car in place
                    myCar.angle += (float)0.03;
            }
            myCar.EvaluateDirection();
            Console.WriteLine("Requesting animation...");
            Refresh();
        }
    }
}
