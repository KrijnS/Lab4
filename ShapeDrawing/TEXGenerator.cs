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
            double correctedR = size / 100f;
          
            string output = "\\definecolor{myColor}{RGB}{" +color.R + ',' + color.G + ',' + color.B + "}\n\\draw[myColor] (" + ConvertX(x)
                + ',' + ConvertY(y) + ") circle (" + correctedR.ToString(new CultureInfo("en-US")) + "cm);";
            texOutput.Add(output);
        }

        public override void CreateRectangle(int x, int y, int width, int height, Color color)
        {        
            string output = "\\definecolor{myColor}{RGB}{" + color.R + ',' + color.G + ',' + color.B + "}\n\\draw[myColor] (" + ConvertX(x)
                + ',' + ConvertY(y) + ") rectangle (" + ConvertX(x+width) + ',' + ConvertY(y+height) + ");";
            texOutput.Add(output);
        }

        public override void CreateStar(int x, int y, int width, int height, Color color)
        { 
            Star star = new Star(null, 0, 0, 0, 0, color);
            Point[] points = star.CalculateStarPoints(x, y, width, height, star.numPoints);
            string output = "\\definecolor{myColor}{RGB}{" + color.R + ',' + color.G + ',' + color.B + "}\n\\draw[myColor] (" + ConvertX(points[0].X) + ',' + ConvertY(points[0].Y) + ')';
            for (int i = 1; i < points.Length; i++)
            {
                output += " -- (" + ConvertX(points[i].X) + "," + ConvertY(points[i].Y) + ')';
            }

            output += " -- (" + ConvertX(points[0].X) + ',' + ConvertY(points[0].Y) + ");";
        
            texOutput.Add(output);
        }

        //Method that firstly divides y and then inverts the y with a given number to fit the LaTeX format. Afterwards it converts to a decimal dot notation
        public string ConvertY(int y)
        {
            //divide to fit pixels to centimeters
            float divide = y / 50f;
            //20 is the number that is about the height of a LaTeX page
            float result = 20 - divide;
            return result.ToString(new CultureInfo("en-US"));
        }

        //Method that divides x to make pixels to centimeters. Afterwards it converts to a decimal dot notation
        public string ConvertX(int x)
        {
            float result = x / 50f;
            return result.ToString(new CultureInfo("en-US"));
        }
    }
}
