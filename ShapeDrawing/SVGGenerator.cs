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

        public override void CreateCircle(int x, int y, int size, Color color)
        {
            int r = size / 2;
            int cx = x + r;
            int cy = y + r;
            string output = "   <circle cx=\u0022" + cx + "\u0022 cy=\u0022" + cy + "\u0022 r=\u0022" + r +
                "\u0022 stroke=\u0022rgb(" + color.R + ',' + color.G + ',' + color.B + ")\u0022 fill=\u0022none\u0022 />";

            svgOutput.Add(output);
        }

        public override void CreateRectangle(int x, int y, int width, int height, Color color)
        {
            string output = "   <rect x=\u0022" + x + "\u0022 y=\u0022 " + y + "\u0022 width=\u0022" + width + "\u0022 height=\u0022" + height + 
            "\u0022 stroke=\u0022rgb(" + color.R + ',' + color.G + ',' + color.B + ")\u0022 fill=\u0022none\u0022/>";

            svgOutput.Add(output);
        }

        public override void CreateStar(int x, int y, int width, int height, Color color)
        { 
            Star star = new Star(null, 0, 0, 0, 0, color);
            Point[] points = star.CalculateStarPoints(x, y, width, height, star.numPoints);
            string output = "   <polyline points=\u0022" + points[0].X + ',' + points[0].Y;
            for (int i = 1; i < points.Length; i++)
            {
                output += " " + points[i].X + "," + points[i].Y;
            }

            output += " " + points[0].X + "," + points[0].Y + "\u0022 stroke=\u0022rgb(" + color.R + ',' + color.G + ',' + color.B + ")\u0022 fill=\u0022none\u0022/>";

            svgOutput.Add(output);
        }
    }
}
