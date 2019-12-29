using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShapeDrawing;

public class Star : Shape
{
    private int x;
    private int y;
    private int width;
	private int height;

	public Star (Bridge bridge, int x, int y, int width, int height) : base(bridge)
	{
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
	}

	public override void Draw()
	{
        bridge.DrawStar(x, y, width, height); 		
	}

    //public string GetSVG()
    //{
    //    string output = "   <polyline points=\u0022" + points[0].X + ',' + points[0].Y;
    //    for (int i = 1; i < points.Length; i++)
    //    {
    //        output += " " + points[i].X + "," + points[i].Y;
    //    }

    //    output += " " + points[0].X + "," + points[0].Y  +"\u0022 style=\u0022fill:none;stroke:black;stroke-width:1\u0022 />";

    //    return output;
    //}
}


