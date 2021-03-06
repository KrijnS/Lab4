﻿using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using ShapeDrawing;

public class ShapeDrawingForm : Form
{
	private List<Shape> shapes;

	public ShapeDrawingForm()
	{
        MenuStrip menuStrip;
        menuStrip = new MenuStrip();

        ToolStripDropDownItem menu;
        menu = new ToolStripMenuItem("File");
		menu.DropDownItems.Add("Open...", null, this.openFileHandler);
		menu.DropDownItems.Add("Export...", null, this.exportHandler);
        menu.DropDownItems.Add("Exit", null, this.closeHandler);
        menuStrip.Items.Add(menu);

        this.Controls.Add(menuStrip);
		// Some basic settings
		Text = "Shape Drawing and Converter";
		Size = new Size(400, 400);
		CenterToScreen();
		SetStyle(ControlStyles.ResizeRedraw, true);
		
		// Initialize shapes
        shapes = new List<Shape>();
		
		// Listen to Paint event to draw shapes
		this.Paint += new PaintEventHandler(this.OnPaint); 
	}

    // What to do when the user closes the program
    private void closeHandler(object sender, EventArgs e)
    {
        this.Close();
    }

    // What to do when the user opens a file
    private void openFileHandler(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = "";
        dialog.Title = "Open file...";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            shapes = Parser.ParseShapes(dialog.FileName);
            this.Refresh();
        }

    }

    // What to do when the user wants to export a TeX file
	private void exportHandler (object sender, EventArgs e)
	{        
		Stream stream;
		SaveFileDialog saveFileDialog = new SaveFileDialog();

		saveFileDialog.Filter = "SVG files|*.svg|LaTeX files|*.tex";
		saveFileDialog.RestoreDirectory = true;

		if(saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			if((stream = saveFileDialog.OpenFile()) != null)
			{
                string extension = Path.GetExtension(saveFileDialog.FileName);

                switch (extension.ToLower())
                {
                    case ".svg":
                        WriteSVG(stream);
                        break;
                    case ".tex":
                        WriteTEX(stream);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(extension);
                }
			}
		}
	}

    private void WriteSVG(Stream stream)
    {
        string intro = "<?xml version=\u00221.0\u0022 standalone=\u0022no\u0022?>\n<!DOCTYPE svg PUBLIC \u0022-//W3C//DTD SVG 1.1//EN\u0022"
                    + "\n   \u0022http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd" + "\u0022>\n<svg xmlns=\u0022http://www.w3.org/2000/svg" + "\u0022 version=\u00221.1\u0022>";
        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.WriteLine(intro);
            SVGGenerator svgGenerator = new SVGGenerator();
            foreach (Shape shape in shapes)
            {
                shape.SetBridge(svgGenerator);
                shape.Create();
            }
            foreach (string output in svgGenerator.svgOutput)
            {
                writer.WriteLine(output);
            }
            writer.WriteLine("</svg>");
        }
    }

    private void WriteTEX(Stream stream)
    {
        string intro = "\\documentclass{article}\n\\usepackage{tikz}\n\\usepackage{xcolor}\n\\begin{document}\n\\begin{tikzpicture}";
        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.WriteLine(intro);
            TEXGenerator texGenerator = new TEXGenerator();
            foreach (Shape shape in shapes)
            {
                shape.SetBridge(texGenerator);
                shape.Create();
            }
            foreach (string output in texGenerator.texOutput)
            {
                writer.WriteLine(output);
            }
            writer.WriteLine("\\end{tikzpicture}\n\\end{document}");
        }

    }

    private void OnPaint(object sender, PaintEventArgs e)
	{
        //Initiate drawer
        Drawer drawer = new Drawer(e.Graphics);
        // Draw all the shapes
        foreach (Shape shape in shapes)
        {
            shape.SetBridge(drawer);
            shape.Create();
        }        
	}
}