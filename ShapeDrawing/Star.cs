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
    public int numPoints { get ;} 

	public Star (Bridge bridge, int x, int y, int width, int height) : base(bridge)
	{
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
        numPoints = 5;
	}

	public override void Create()
	{
        bridge.CreateStar(x, y, width, height); 		
	}

    public Point[] CalculateStarPoints(int x, int y, int width, int height, int numPoints)
    {
        Point[] points = new Point[numPoints];
        double rx = width / 2;
        double ry = height / 2;
        double cx = x + rx;
        double cy = y + ry;

        double theta = -Math.PI / 2;
        double dtheta = 4 * Math.PI / numPoints;
        int i;
        for (i = 0; i < numPoints; i++)
        {
            points[i] = new Point(
                Convert.ToInt32(cx + rx * Math.Cos(theta)),
                Convert.ToInt32(cy + ry * Math.Sin(theta)));
            theta += dtheta;
        }

        return points;
    }
}


