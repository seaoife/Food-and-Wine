
namespace WindowsFormsApp1
{
    partial class IntroWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroWindow));
            this.textBox1IntoMessage = new System.Windows.Forms.TextBox();
            this.Button1ToPage2 = new WindowsFormsApp1.RJButton();
            this.SuspendLayout();
            // 
            // textBox1IntoMessage
            // 
            this.textBox1IntoMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(234)))), ((int)(((byte)(199)))));
            this.textBox1IntoMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1IntoMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1IntoMessage.ForeColor = System.Drawing.Color.Green;
            this.textBox1IntoMessage.Location = new System.Drawing.Point(309, 143);
            this.textBox1IntoMessage.Multiline = true;
            this.textBox1IntoMessage.Name = "textBox1IntoMessage";
            this.textBox1IntoMessage.Size = new System.Drawing.Size(985, 166);
            this.textBox1IntoMessage.TabIndex = 3;
            this.textBox1IntoMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Button1ToPage2
            // 
            this.Button1ToPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(234)))), ((int)(((byte)(199)))));
            this.Button1ToPage2.FlatAppearance.BorderSize = 0;
            this.Button1ToPage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1ToPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1ToPage2.ForeColor = System.Drawing.Color.Green;
            this.Button1ToPage2.Location = new System.Drawing.Point(534, 509);
            this.Button1ToPage2.Margin = new System.Windows.Forms.Padding(10);
            this.Button1ToPage2.Name = "Button1ToPage2";
            this.Button1ToPage2.Size = new System.Drawing.Size(480, 156);
            this.Button1ToPage2.TabIndex = 2;
            this.Button1ToPage2.Text = "Find Your Recipes";
            this.Button1ToPage2.UseVisualStyleBackColor = false;
            this.Button1ToPage2.Click += new System.EventHandler(this.Button1ToPage2_Click);
            // 
            // IntroWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1751, 731);
            this.Controls.Add(this.textBox1IntoMessage);
            this.Controls.Add(this.Button1ToPage2);
            this.Name = "IntroWindow";
            this.Text = "IntroWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RJButton Button1ToPage2;
        private System.Windows.Forms.TextBox textBox1IntoMessage;
    }
}