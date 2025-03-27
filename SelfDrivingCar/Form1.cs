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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    myCar.direction = "front";
                    break;
                case Keys.S:
                    myCar.direction = "reverse";
                    break;
                case Keys.A:
                    myCar.direction = "left";
                    break;
                case Keys.D:
                    myCar.direction = "right";
                    break;
            }
            myCar.HandleKeyPress();
        }

        private void animate_Tick(object sender, EventArgs e)
        {
            myCar.EvaluateDirection();
            Console.WriteLine("Requesting animation...");
            Refresh();
        }
    }
}
