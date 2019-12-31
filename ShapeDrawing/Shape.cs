using ShapeDrawing;
using System;
using System.Drawing;

public abstract class Shape
{
    public Bridge bridge;
    public int x;
    public int y;
    public Color color;


    public Shape(Bridge bridge)
    {
        this.bridge = bridge;
    }

    public abstract void Create();


    public void SetBridge(Bridge bridge)
    {
        this.bridge = bridge;
    }

}