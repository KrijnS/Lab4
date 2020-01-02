using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
            double correctedX = x / 50f;
            double correctedY = y / 50f;
            double correctedR = size / 100f;
          
            string output = "\\definecolor{myColor}{RGB}{" +color.R + ',' + color.G + ',' + color.B + "}\n\\draw[myColor] (" + correctedX.ToString(new CultureInfo("en-US")) 
                + ',' + correctedY.ToString(new CultureInfo("en-US")) + ") circle (" + correctedR.ToString(new CultureInfo("en-US")) + "cm);";
            texOutput.Add(output);
        }

        public override void CreateRectangle(int x, int y, int width, int height, Color color)
        {
            double correctedX = x / 50f;
            double correctedY = y / 50f;
            double x2 = (x + width) / 50f;
            double y2 = (y + height) / 50f;
    
            string output = "\\definecolor{myColor}{RGB}{" + color.R + ',' + color.G + ',' + color.B + "}\n\\draw[myColor] (" + correctedX.ToString(new CultureInfo("en-US")) 
                + ',' + correctedY.ToString(new CultureInfo("en-US")) + ") rectangle (" + x2.ToString(new CultureInfo("en-US")) + ',' + y2.ToString(new CultureInfo("en-US")) + ");";
            texOutput.Add(output);
        }

        public override void CreateStar(int x, int y, int width, int height, Color color)
        { 
            Star star = new Star(null, 0, 0, 0, 0, color);
            Point[] points = star.CalculateStarPoints(x, y, width, height, star.numPoints);
            float correctedX1 = points[0].X / 50f;
            float correctedY1 = points[0].Y / 50f;
            string output = "\\definecolor{myColor}{RGB}{" + color.R + ',' + color.G + ',' + color.B + "}\n\\draw[myColor] (" + correctedX1.ToString(new CultureInfo("en-US")) + ',' + correctedY1.ToString(new CultureInfo("en-US")) + ')';
            for (int i = 1; i < points.Length; i++)
            {
                float correctedX = points[i].X / 50f;
                float correctedY = points[i].Y / 50f;
                output += " -- (" + correctedX.ToString(new CultureInfo("en-US")) + "," + correctedY.ToString(new CultureInfo("en-US")) + ')';
            }

            output += " -- (" + correctedX1.ToString(new CultureInfo("en-US")) + ',' + correctedY1.ToString(new CultureInfo("en-US")) + ");";
        
            texOutput.Add(output);
        }
    }
}
