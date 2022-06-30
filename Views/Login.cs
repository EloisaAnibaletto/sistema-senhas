using System;
using System.Windows.Forms;
using Views.Lib;
using Controllers;

namespace Views
{
    public class Login : BaseForm
    {
        Title login;
        FieldForm fieldUsuario;
        FieldForm fieldSenha;
        FieldForm fieldAcesso;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;
        ButtonForm btnCadastrar;

        public Login() : base("Login", SizeScreen.Small)
        {
            login = new Title("Login", SizeScreen.Small);
            login.Padding = new Padding(125, 10, 0, 0);
            fieldUsuario = new FieldForm("Usuário", 20, 40, 260, 20);
            fieldSenha = new FieldForm("Senha", 20, 100, 260, 60);
            fieldAcesso = new FieldForm("Seu primeiro acesso? Clique para cadastrar", 40, 245, 260, 100);
            fieldSenha.txtField.PasswordChar = '*';

            btnConfirmar = new ButtonForm("Confirmar", 100, 170, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 100, 210, this.handleCancel);
            btnCadastrar = new ButtonForm("Cadastrar", 100, 265, this.handleCadastrarUsuario);

            this.Controls.Add(login);
            this.Controls.Add(fieldUsuario.lblField);
            this.Controls.Add(fieldUsuario.txtField);
            this.Controls.Add(fieldSenha.lblField);
            this.Controls.Add(fieldSenha.txtField);
            this.Controls.Add(fieldAcesso.lblField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
            this.Controls.Add(btnCadastrar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try
            {
                UsuarioController.Auth(
                    this.fieldUsuario.txtField.Text,
                    this.fieldSenha.txtField.Text
                );
                (new Menu(this)).Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void handleCancel(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Deseja mesmo sair? ", "Mensage do sistema ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void handleCadastrarUsuario(object sender, EventArgs e)
        {
            (new CadastrarUsuario(this)).Show();
            this.Hide();

        }
    }
}