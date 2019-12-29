using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ShapeDrawing
{
    public abstract class Bridge
    {
        public abstract void DrawCircle(int x, int y, int size);
        public abstract void DrawStar(int x, int y, int width, int height);
        public abstract void DrawRectangle(int x, int y, int width, int height);
    }
}