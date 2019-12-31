using ShapeDrawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;

public class Parser
{
	public static List<Shape> ParseShapes(string Filename)
	{
		// Load xml documents
		XmlDocument doc = new XmlDocument();
		doc.Load(Filename);
		
		// Parse all shapes
		List<Shape> shapes = new List<Shape>();
		foreach(XmlNode shape in doc.SelectNodes("/shapes/*"))
		{
			string type = shape.Name;
			int x; int y; int width; int height; Color color;
			switch(type)
            {

                case "rectangle":
					x = int.Parse(shape.Attributes["x"].Value);
					y = int.Parse(shape.Attributes["y"].Value);
					width = int.Parse(shape.Attributes["width"].Value);
					height = int.Parse(shape.Attributes["height"].Value);
                    color = Color.FromArgb(
                        int.Parse(shape.Attributes["alpha"].Value),
                        int.Parse(shape.Attributes["red"].Value),
                        int.Parse(shape.Attributes["green"].Value),
                        int.Parse(shape.Attributes["blue"].Value)
                    );
                    shapes.Add(new Rectangle(null, x, y, width, height, color));
                    break;
                case "circle":
					x = int.Parse(shape.Attributes["x"].Value);
					y = int.Parse(shape.Attributes["y"].Value);
					int size = int.Parse(shape.Attributes["size"].Value);
                    color = Color.FromArgb(
                        int.Parse(shape.Attributes["alpha"].Value),
                        int.Parse(shape.Attributes["red"].Value),
                        int.Parse(shape.Attributes["green"].Value),
                        int.Parse(shape.Attributes["blue"].Value)
                    );
                    shapes.Add(new Circle(null, x, y, size, color));
                    break;
				case "star":
					x = int.Parse(shape.Attributes["x"].Value);
					y = int.Parse(shape.Attributes["y"].Value);
					width = int.Parse(shape.Attributes["width"].Value);
					height = int.Parse(shape.Attributes["height"].Value);
                    color = Color.FromArgb(
                        int.Parse(shape.Attributes["alpha"].Value),
                        int.Parse(shape.Attributes["red"].Value),
                        int.Parse(shape.Attributes["green"].Value),
                        int.Parse(shape.Attributes["blue"].Value)
                    );
                    shapes.Add (new Star(null, x,y,width,height, color));
					break;
            }
		}
		
		return shapes;
	}
}