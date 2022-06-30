using System;
using System.Windows.Forms;
using Views.Lib;
using Controllers;

namespace Views
{
    public class InserirUsuario : BaseForm
    {
        UsuarioCrud parent;
        FieldForm fieldNome;
        FieldForm fieldEmail;
        FieldForm fieldSenha;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public InserirUsuario(UsuarioCrud parent) : base("InserirUsuario", SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            fieldNome = new FieldForm("Nome", 20, 10, 260, 20);
            fieldEmail = new FieldForm("Email", 20, 80, 260, 60);
            fieldSenha = new FieldForm("Senha", 20, 140, 260, 60);

            btnConfirmar = new ButtonForm("Confirmar", 100, 220, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 100, 260, this.handleCancel);

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
                this.parent.LoadInfo();
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
            if (MessageBox.Show(" Deseja mesmo sair? ", "Mensage do sistema ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.parent.Show();
                this.Close();
            }
        }

    }
}