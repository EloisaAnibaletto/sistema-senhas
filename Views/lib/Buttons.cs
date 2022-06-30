using System;
using System.Windows.Forms;
using System.Drawing;

namespace Views.Lib
{
    public class ButtonForm : Button
    {

        public delegate void HandleButton(object sender, EventArgs e);

        public ButtonForm(string Titulo, int X, int Y, HandleButton eventHandler)
        {
			this.Text = Titulo;
			this.Size = new Size(100,30);
			this.Location = new Point(X, Y);
			this.Click += new EventHandler(eventHandler);
            this.BackColor = Color.AliceBlue;
        }
    }
}
