using ShapeDrawing;
using System;
using System.Drawing;

public abstract class Shape
{
    public Bridge bridge;

    public Shape(Bridge bridge)
    {
        this.bridge = bridge;
    }

    public abstract void Create();


    public void SetBridge(Bridge bridge)
    {
        this.bridge = bridge;
    }

    //public Pen SetColor(int color)
    //{
    //    if (color == 1)
    //    {
    //        Pen pen = new Pen(Color.Red);
    //        return pen;
    //    }
    //    else if (color == 2)
    //    {
    //        Pen pen = new Pen(Color.Blue);
    //        return pen;
    //    }
    //    else if (color == 3)
    //    {
    //        Pen pen = new Pen(Color.Green);
    //        return pen;
    //    }
    //    else
    //    {
    //        Pen pen = new Pen(Color.Yellow);
    //        return pen;
    //    }
    //}
}