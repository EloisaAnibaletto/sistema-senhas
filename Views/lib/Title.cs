using System.Windows.Forms;
using System.Drawing;

namespace Views.Lib
{
    public class Title : Label
    {
        public Title(string Titulo, SizeScreen W)
        {

			this.Text = Titulo;
            switch (W)
            {
                case SizeScreen.Large:
                    this.Size = new Size(900, 40);
                    break;
                case SizeScreen.Medium:
                    this.Size = new Size(600, 40);
                    break;
                case SizeScreen.Small:
                    this.Size = new Size(300, 40);
                    break;
                default:
                    this.Size = new Size(300, 40);
                    break;
            }
            this.BackColor = Color.CornflowerBlue;
            this.Location = new Point(0, 0);
            this.Font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold);
        }       
    }
     
}
