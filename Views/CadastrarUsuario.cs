using System;
using System.Windows.Forms;
using Views.Lib;
using Controllers;

namespace Views
{
    public class CadastrarUsuario : BaseForm
    {
        Form parent;
        FieldForm fieldNome;
        FieldForm fieldEmail;
        FieldForm fieldSenha;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public CadastrarUsuario(Form parent) : base("Cadastrar Usuário", SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            fieldNome = new FieldForm("Nome", 20, 20, 180, 20);
            fieldEmail = new FieldForm("E-mail", 20, 100, 180, 60);
            fieldSenha = new FieldForm("Senha", 20, 180, 180, 100);

            btnConfirmar = new ButtonForm("Confirmar", 60, 260, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 180, 260, this.handleCancel);

            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldEmail.lblField);
            this.Controls.Add(fieldEmail.txtField);
            this.Controls.Add(fieldSenha.lblField);
            this.Controls.Add(fieldSenha.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try
            {
                UsuarioController.InserirUsuario(
                    this.fieldNome.txtField.Text,
                    this.fieldEmail.txtField.Text,
                    this.fieldSenha.txtField.Text
                );
                this.parent.Show();
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void handleCancel(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close();
        }
    }
}
