using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ShapeDrawing
{
    public abstract class Bridge
    {        
        public abstract void CreateCircle(int x, int y, int size, Color color);
        public abstract void CreateStar(int x, int y, int width, int height, Color color);
        public abstract void CreateRectangle(int x, int y, int width, int height, Color color);       
    }
}