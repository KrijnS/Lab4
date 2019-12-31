using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShapeDrawing;

class Rectangle : Shape
{ 

    private int x;
	private int y;
	private int width;
	private int height;
    public int color;

    public Rectangle(Bridge bridge, int x, int y, int width, int height, int color) : base(bridge)
    {
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
        this.color = color;
    }
    
	public override void Create()
    {
        bridge.CreateRectangle(x, y, width, height, color);
    }

}

