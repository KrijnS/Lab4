using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShapeDrawing;

class Rectangle : Shape
{ 
	private int width;
	private int height;

    public Rectangle(Bridge bridge, int x, int y, int width, int height, Color color) : base(bridge)
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

