using System.Windows.Forms;
using System.Drawing;

namespace Views.Lib
{
    public class FieldForm : Form
    {
        public TextBox txtField;
        public Label lblField;

        public FieldForm(
            string Titulo,
            int X,
            int Y,
            int WidthTextBox,
            int HeightTextBox
        )
        {
            lblField = new Label();
			lblField.Text = Titulo;
            lblField.Location = new Point(X, Y);
            lblField.Size = new Size(WidthTextBox, 20);

            txtField = new TextBox();
            txtField.Location = new Point(X, Y + 35);
            txtField.Size = new Size(WidthTextBox, HeightTextBox);
        }
    }
}