using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Circle : Shape
{

    private int x;
	private int y;
	private int size;

    public Circle(int x, int y, int size)
    {
		this.x = x;
		this.y = y;
		this.size = size;
    }

    public override void Draw(Graphics Canvas)
    {
		Pen pen = new Pen(Color.Black);
        Canvas.DrawEllipse(pen, this.x, this.y, this.size, this.size);
    }

    public override string GetSVG()
    {
        int r = this.size / 2;
        int cx = this.x + r;
        int cy = this.y + r;
        string output = "   <circle cx=\u0022" + cx + "\u0022 cy=\u0022" + cy + "\u0022 r=\u0022" + r + 
            "\u0022 stroke-width=\u00221\u0022 fill=\u0022none\u0022 stroke=\u0022black\u0022 />";

        return output;
    }

}
