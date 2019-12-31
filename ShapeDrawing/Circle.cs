using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShapeDrawing;

public class Circle : Shape
{ 
    private int x;
	private int y;
	private int size;
    public int color;

    public Circle(Bridge bridge, int x, int y, int size, int color) : base(bridge)
    {
		this.x = x;
		this.y = y;
		this.size = size;
        this.color = color;
    }

    public override void Create()
    {
        bridge.CreateCircle(x, y, size, color);
    }

}
