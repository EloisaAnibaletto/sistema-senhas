using System;
using System.Windows.Forms;
using Views.Lib;
using Controllers;

namespace Views
{
    public class AlterarCategoria : BaseForm
    {
        CategoriaCrud parent;
        FieldForm fieldNome;
        FieldForm fieldDescricao;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public AlterarCategoria(CategoriaCrud parent) : base("AlterarCategoria", SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            fieldNome = new FieldForm("Nome", 20, 20, 260, 20);
            fieldDescricao = new FieldForm("Descricao", 20, 100, 260, 60);

            btnConfirmar = new ButtonForm("Confirmar", 100, 180, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 100, 220, this.handleCancel);

            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldDescricao.lblField);
            this.Controls.Add(fieldDescricao.txtField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = this.parent.listView.SelectedItems[0];
                int id = Convert.ToInt32(item.Text);
                CategoriaController.AlterarCategoria(
                    id,
                    this.fieldNome.txtField.Text,
                    this.fieldDescricao.txtField.Text
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
                Application.Exit();
            }
        }

    }
}