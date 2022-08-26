using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Windows.Forms;


namespace WindowsFormsApp1
{
   
        class RJButton : Button
        {
            private int borderSize = 0;
            private int borderRadius = 40;
            private Color borderColor = Color.LimeGreen;

            public RJButton()
            {
                this.FlatStyle = FlatStyle.Flat;
                this.FlatAppearance.BorderSize = 0;
                this.Size = new Size(150, 40);
                this.BackColor = Color.MediumSlateBlue;
                this.ForeColor = Color.White;
            }
            //Method to devise a graphics Path with customisable border radius
            private GraphicsPath GetFigurePath(RectangleF rect, float radius)
            {
                GraphicsPath path = new GraphicsPath();
                path.StartFigure();// we start the figure of the path.
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);//adding arcs
                path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);//lower right hand corner
                path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();// closes the graphics path

                return path;



            }

            // now we need to override the button functionality.
            protected override void OnPaint(PaintEventArgs pevent)
            {
                base.OnPaint(pevent);
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;// antiAlias will smotth edges, no visible pixels

                RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
                RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

                if (borderRadius > 2)//rounded button
                {
                    //declaring variables
                    using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))// using allows to dispose of the objects correctly
                    using (GraphicsPath pathBorder = GetFigurePath(rectSurface, borderRadius - 1F))
                    using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        this.Region = new Region(pathSurface);
                        pevent.Graphics.DrawPath(penSurface, pathSurface);
                        if (borderSize >= 1)
                        {
                            pevent.Graphics.DrawPath(penBorder, pathBorder);
                        }

                    }
                }

                else // normal button
                {
                    this.Region = new Region(rectSurface);
                    if (borderSize >= 1)
                    {
                        using (Pen penBorder = new Pen(borderColor, borderSize))
                        {
                            penBorder.Alignment = PenAlignment.Inset;
                            pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                        }
                    }
                }


            }
            protected override void OnHandleCreated(EventArgs e)
            {
                base.OnHandleCreated(e);
                this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
            }

            private void Container_BackColorChanged(object sender, EventArgs e)
            {
                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }
    }


