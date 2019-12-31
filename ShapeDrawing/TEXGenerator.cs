using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ShapeDrawing
{
    class TEXGenerator : Bridge
    {
        public List<string> texOutput { get; set; }

        public TEXGenerator()
        {
            texOutput = new List<string>();
        }

        public override void CreateCircle(int x, int y, int size, Color color)
        {
            Pen pen = new Pen(color);
            //int r = size / 2;
            //int cx = x + r;
            //int cy = y + r;
            //string output = "   <circle cx=\u0022" + cx + "\u0022 cy=\u0022" + cy + "\u0022 r=\u0022" + r +
            //    "\u0022 stroke-width=\u00221\u0022 fill=\u0022none\u0022 stroke=\u0022" + pen + "\u0022 />";
            //texOutput.Add(output);
        }

        public override void CreateRectangle(int x, int y, int width, int height, Color color)
        {
            Pen pen = new Pen(color);

            //int x1 = x;
            //int x2 = x1 + width;
            //int y1 = y;
            //int y2 = y1 + height;
            //string output = "   <polyline points=\u0022" + x1 + ',' + y1 + ' ' + x2 + ',' + y1 + ' ' + x2 + ',' + y2 + ' ' + x1 + ',' + y2 + ' ' + x1 + ',' + y1 +
            //"\u0022 style=\u0022fill:none;stroke:\u0022" + pen + "\u0022;stroke-width:1\u0022 />";
            
            //texOutput.Add(output);
        }

        public override void CreateStar(int x, int y, int width, int height, Color color)
        {
            Pen pen = new Pen(color);
            //Star star = new Star(null, 0, 0, 0, 0, color);
            //Point[] points = star.CalculateStarPoints(x, y, width, height, star.numPoints);
            //string output = "   <polyline points=\u0022" + points[0].X + ',' + points[0].Y;
            //for (int i = 1; i < points.Length; i++)
            //{
            //    output += " " + points[i].X + "," + points[i].Y;
            //}

            //output += " " + points[0].X + "," + points[0].Y + "\u0022 style=\u0022fill:none;stroke:\u0022" + pen + "\u0022;stroke-width:1\u0022 />";

            //texOutput.Add(output);
        }
    }
}
