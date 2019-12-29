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

    public Rectangle(Bridge bridge, int x, int y, int width, int height) : base(bridge)
    {
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
    }
    
	public override void Create()
    {
        bridge.CreateRectangle(x, y, width, height);
    }

    public string GetSVG()
    {
        int x1 = this.x;
        int x2 = x1 + this.width;
        int y1 = this.y;
        int y2 = y1 + this.height;
        string output = "   <polyline points=\u0022" + x1 + ',' + y1 + ' ' + x2 + ',' + y1 + ' ' + x2 + ',' + y2 + ' ' + x1 + ',' + y2 + ' ' + x1 + ',' + y1 +
        "\u0022 style=\u0022fill:none;stroke:black;stroke-width:1\u0022 />";

        return output;
    }
}

