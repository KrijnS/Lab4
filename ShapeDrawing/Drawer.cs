using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ShapeDrawing
{
    public class Drawer : Bridge
    {
        public Graphics Canvas;

        public Drawer(Graphics canvas)
        {
            this.Canvas = canvas;
        }

        public override void CreateCircle(int x, int y, int size, int color)
        {
            //Pen pen = new Pen(Color.Black);
            Pen pen = SetColor(color);
            Canvas.DrawEllipse(pen, x, y, size, size);
        }

        public override void CreateRectangle(int x, int y, int width, int height, int color)
        {
            //Pen pen = new Pen(Color.Black);
            Pen pen = SetColor(color);
            Canvas.DrawLine(pen,x,y,x + width,y);
            Canvas.DrawLine(pen,x+width,y,x+width,y+height);
            Canvas.DrawLine(pen,x+width,y+height,x,y+height);
            Canvas.DrawLine(pen,x,y+height,x,y);
        }

        public override void CreateStar(int x, int y, int width, int height, int color)
        {
            //Pen pen = new Pen(Color.Black);
            Pen pen = SetColor(color);
            Star star = new Star(null,0,0,0,0,0);
            int numPoints = star.numPoints;
            Point[] points = star.CalculateStarPoints(x, y, width, height, numPoints);

            for (int i = 0; i < numPoints; i++) 
            {
            	Canvas.DrawLine(pen,points[i].X,
                                          points[i].Y,
                                          points[(i+1) % numPoints].X,
                                          points[(i+1) % numPoints].Y);
            }
        }

        public Pen SetColor(int color)
        {
            if (color == 1)
            {
                Pen pen = new Pen(Color.Red);
                return pen;
            }
            else if (color == 2)
            {
                Pen pen = new Pen(Color.Blue);
                return pen;
            }
            else if (color == 3)
            {
                Pen pen = new Pen(Color.Green);
                return pen;
            }
            else
            {
                Pen pen = new Pen(Color.Yellow);
                return pen;
            }
        }

    }
}
