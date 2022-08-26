using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace WindowsFormsApp1
{
    class CeLearningTextBox : Control
    {
        private int radius = 15;
        public TextBox textbox = new TextBox();
        private GraphicsPath shape;
        private GraphicsPath innerRect;
        private Color br;


        public CeLearningTextBox()
        {

            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            this.textbox.Parent = this;
            base.Controls.Add(this.textbox);
            this.textbox.BorderStyle = BorderStyle.None;
            textbox.Font = this.Font;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.Transparent;
            this.br = Color.White;
            textbox.BackColor = this.br;
            this.Font = new Font("Microsoft Sans Serif", 12f);
            base.Size = new Size(135, 33);
            this.DoubleBuffered = true;
            textbox.KeyDown += new KeyEventHandler(textbox_keyDown);
            textbox.MouseDoubleClick += new MouseEventHandler(textbox_MouseDoubleClick);
        }



        private void textbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textbox.SelectAll();
            }

        }

        private void textbox_TextChanged(object sender, EventArgs e)

        {
            this.Text = textbox.Text;
            //throw new NotImplementedException();
        }

        private void textbox_keyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Control && (e.KeyCode == Keys.A))
            {

                textbox.SelectionStart = 0;
                textbox.SelectionLength = this.Text.Length;
            }
            //throw new NotImplementedException();
        
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            textbox.Font = this.Font;
            base.Invalidate();

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // base.OnPaint(e);
            this.shape = new MyRectangle((float)base.Width, (float)base.Height, (float)this.radius, 0f, 0f).Path;
            this.innerRect = new MyRectangle(base.Width - 0.5f, base.Height - 0.5f, (float)this.radius, 0.5f, 0.5f).Path;
            if (textbox.Height >= (base.Height - 4));
            {
                base.Height = textbox.Height + 4;
            }
            textbox.Location = new Point(this.radius - 5, (base.Height / 2) - (textbox.Font.Height / 2));
            textbox.Width = base.Width - ((int)(this.radius * 1.5));
            e.Graphics.SmoothingMode = ((SmoothingMode)SmoothingMode.HighQuality);
            Bitmap bitmap = new Bitmap(base.Width, base.Height);
            Graphics graphics = Graphics.FromImage((Image)bitmap);
            e.Graphics.DrawPath(Pens.Black, this.shape);
            using (SolidBrush brush = new SolidBrush(this.br))
            {
                e.Graphics.FillPath((Brush)brush, this.innerRect);
            }
            Trans.MakeTransparent(this, e.Graphics);


            base.OnPaint(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            textbox.Text = this.Text;
            //base.OnTextChanged(e);EventArgs e)

        }

        public void SelectAll()
        {
            textbox.SelectAll();
        }
        public Color Br
        {
            get =>
            this.br;
            set
            {
                this.br = value;
                if(this.br != Color.Transparent)
                {
                    textbox.BackColor = this.br;
                }
                base.Invalidate();
                       
            }
        }

        public override Color BackColor 
        { 
          get => base.BackColor; 
          set => base.BackColor = Color.Transparent; 
        
        }

    }
        

}
