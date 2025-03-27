using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfDrivingCar
{
    //this class contains all the methods necesary for graphic creation
    public class Canvas
    {

        public const int roadWidth = 300;
        public int width;
        public int height;
        public Canvas(int width, int height) 
        { 
            this.width = width;
            this.height = height;
        }

        public void DrawScenery(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Green),new Rectangle(0,0,width,height));
            g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(width/2-roadWidth/2, 0, roadWidth, height));
        }

        public void DrawCar(Graphics g, Car car)
        {
            //Init translation center
            Rectangle rect = new Rectangle(car.x, car.y, Car.width, Car.height);
            g.TranslateTransform(rect.X+rect.Width/2, rect.Y+rect.Height/2) ;
            // Rotate the graphics by angle degrees
            g.RotateTransform((float)(car.angle * 180 / Math.PI));
            g.FillRectangle(new SolidBrush(Color.Red), -rect.Width / 2, -rect.Height / 2, rect.Width, rect.Height);
            //Reset transform to prevent rotation in other drawn elements
            g.ResetTransform();
        }
    }
}
