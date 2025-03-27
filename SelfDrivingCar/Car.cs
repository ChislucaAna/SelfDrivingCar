using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelfDrivingCar
{
    public class Car
    {
        //upper-left-corner coords(where we draw the rectangle from)
        public int x;
        public int y;

        //center of the car(where we rotate from)
        public int centerx;
        public int centery;

        public const int width=25;
        public const int height=50;
        public const int MaxSpeed= 50;
        public const int acceleration = 5;//the value by which the speed increases or decreases when a key is presssed
        public const int friction = 2;
        
        public int speed=0; //by default the car is not moving
        public float angle=0; //for car rotation

        public Car(int x, int y)
        {
            this.x = x;
            this.y = y;
            centerx = x + width / 2;
            centery = y + height / 2;
        }

        public void EvaluateDirection()
        {

            if (speed > 0)
                speed -= friction;
            if (speed < 0)
                speed += friction;
            if(Math.Abs(speed)<friction)
                speed = 0;
            x -= Convert.ToInt32(Math.Sin(-angle)*speed);
            y-= Convert.ToInt32(Math.Cos(-angle)*speed);
        }
    }
}
