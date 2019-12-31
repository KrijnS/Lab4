using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ShapeDrawing
{
    public abstract class Bridge
    {
        //public Shape shape;

        public abstract void CreateCircle(int x, int y, int size, int color);
        public abstract void CreateStar(int x, int y, int width, int height, int color);
        public abstract void CreateRectangle(int x, int y, int width, int height, int color);

    }
}