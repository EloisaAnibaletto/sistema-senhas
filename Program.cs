using System;
using System.Windows.Forms;
using Views;
using Controllers;

namespace EncryptMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*try {

            UsuarioController.InserirUsuario("Administrador","admin@email.com", "12345678");
            }
            catch (Exception err) {
                MessageBox.Show(err.Message);
            }*/
            Application.EnableVisualStyles();
            Application.Run(new Login());
            //MessageBox.Show("Hellow");
        }
    }
}
