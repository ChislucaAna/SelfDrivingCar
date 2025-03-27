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

        public int x;
        public int y;
        public const int width=25;
        public const int height=50;
        public const int MaxSpeed= 50;
        public string direction;

        public int speed=0; //by default the car is not moving
        public int acceleration=3;//the value by which the speed increases or decreases when a key is presssed
        public int friction = 2;


        public Car(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void HandleKeyPress()
        {
            switch (direction)
            {
                case "front":
                    speed += acceleration;
                    if (speed > MaxSpeed)
                        speed = MaxSpeed;
                    break;
                case "reverse":
                    speed -= acceleration;
                    if (speed < -MaxSpeed / 2)
                        speed = -MaxSpeed / 2;
                    break;
                case "left":
                    x--;
                    break;
                case "right":
                    x++;
                    break;
            }
        }

        public void EvaluateDirection()
        {

            if (speed > 0)
                speed -= friction;
            if (speed < 0)
                speed += friction;

            this.y-=this.speed;
        }
    }
}
