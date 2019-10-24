using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Rectangle : Shape
{

    private int x;
	private int y;
	private int width;
	private int height;

    public Rectangle(int x, int y, int width, int height)
    {
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
    }
    
	public override void Draw(Graphics Canvas)
    {
		Pen pen = new Pen(Color.Black);
		Canvas.DrawLine(pen,x,y,x + width,y);
		Canvas.DrawLine(pen,x+width,y,x+width,y+height);
		Canvas.DrawLine(pen,x+width,y+height,x,y+height);
		Canvas.DrawLine(pen,x,y+height,x,y);

    }

    public override string GetSVG()
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

