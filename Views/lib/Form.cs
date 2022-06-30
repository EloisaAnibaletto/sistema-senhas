using System.Windows.Forms;
using System.Drawing;

namespace Views.Lib {
    public enum SizeScreen
    {
        Small,
        Medium,
        Large,
        Different
    }


    public class BaseForm : Form
    {
        public BaseForm(
            string Title,
            SizeScreen size
        )
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            switch (size)
            {
                case SizeScreen.Large:
                    this.ClientSize = new System.Drawing.Size(900, 900);
                    break;
                case SizeScreen.Medium:
                    this.ClientSize = new System.Drawing.Size(600, 600);
                    break;
                case SizeScreen.Small:
                    this.ClientSize = new System.Drawing.Size(300, 300);
                    break;
                default:
                    this.ClientSize = new System.Drawing.Size(300, 900);
                    break;
            }
            this.Text = Title;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightSteelBlue;
        }
    }
    
}
