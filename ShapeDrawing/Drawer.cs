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

        public override void DrawCircle(int x, int y, int size)
        {
            Pen pen = new Pen(Color.Black);
            Canvas.DrawEllipse(pen, x, y, size, size);
        }

        public override void DrawRectangle(int x, int y, int width, int height)
        {
            Pen pen = new Pen(Color.Black);
            Canvas.DrawLine(pen,x,y,x + width,y);
            Canvas.DrawLine(pen,x+width,y,x+width,y+height);
            Canvas.DrawLine(pen,x+width,y+height,x,y+height);
            Canvas.DrawLine(pen,x,y+height,x,y);
        }

        public override void DrawStar(int x, int y, int width, int height)
        {
            Pen pen = new Pen (Color.Black);
            int numPoints = 5;
            Point[] points = CalculateStarPoints(x, y, width, height, numPoints);

            for (int i = 0; i < numPoints; i++) 
            {
            	Canvas.DrawLine(pen,points[i].X,
                                          points[i].Y,
                                          points[(i+1) % numPoints].X,
                                          points[(i+1) % numPoints].Y);
            }
        }

        public Point[] CalculateStarPoints(int x, int y, int width, int height, int numPoints)
        {
            Point[] points = new Point[numPoints];
            double rx = width / 2;
            double ry = height / 2;
            double cx = x + rx;
            double cy = y + ry;

            double theta = -Math.PI / 2;
            double dtheta = 4 * Math.PI / numPoints;
            int i;
            for (i = 0; i < numPoints; i++)
            {
                points[i] = new Point(
                    Convert.ToInt32(cx + rx * Math.Cos(theta)),
                    Convert.ToInt32(cy + ry * Math.Sin(theta)));
                theta += dtheta;
            }

            return points;
        }
    }
}
