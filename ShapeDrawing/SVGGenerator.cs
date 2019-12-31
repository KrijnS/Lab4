using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ShapeDrawing
{
    class SVGGenerator : Bridge
    {
        public List<string> svgOutput { get; set; }

        public SVGGenerator()
        {
            svgOutput = new List<string>();
        }

        public override void CreateCircle(int x, int y, int size, int color)
        {
            Pen pen = SetColor(color);
            int r = size / 2;
            int cx = x + r;
            int cy = y + r;
            string output = "   <circle cx=\u0022" + cx + "\u0022 cy=\u0022" + cy + "\u0022 r=\u0022" + r +
                "\u0022 stroke-width=\u00221\u0022 fill=\u0022none\u0022 stroke=\u0022" + pen + "\u0022 />";

            svgOutput.Add(output);
        }

        public override void CreateRectangle(int x, int y, int width, int height, int color)
        {
            Pen pen = SetColor(color);
            int x1 = x;
            int x2 = x1 + width;
            int y1 = y;
            int y2 = y1 + height;
            string output = "   <polyline points=\u0022" + x1 + ',' + y1 + ' ' + x2 + ',' + y1 + ' ' + x2 + ',' + y2 + ' ' + x1 + ',' + y2 + ' ' + x1 + ',' + y1 +
            "\u0022 style=\u0022fill:none;stroke:\u0022" + pen + "\u0022;stroke-width:1\u0022 />";

            svgOutput.Add(output);
        }

        public override void CreateStar(int x, int y, int width, int height, int color)
        {
            Pen pen = SetColor(color);
            Star star = new Star(null, 0, 0, 0, 0, 0);
            Point[] points = star.CalculateStarPoints(x, y, width, height, star.numPoints);
            string output = "   <polyline points=\u0022" + points[0].X + ',' + points[0].Y;
            for (int i = 1; i < points.Length; i++)
            {
                output += " " + points[i].X + "," + points[i].Y;
            }

            output += " " + points[0].X + "," + points[0].Y + "\u0022 style=\u0022fill:none;stroke:\u0022" + pen + "\u0022;stroke-width:1\u0022 />";

            svgOutput.Add(output);
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
