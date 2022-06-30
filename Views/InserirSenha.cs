using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using Controllers;
using Models;

namespace Views
{
    public class InserirSenha : BaseForm
    {
        SenhaCrud parent;
        FieldForm fieldNome;
        FieldForm fieldCategoria;
        FieldForm fieldUrl;
        FieldForm fieldUsuario;
        FieldForm fieldSenha;
        FieldForm fieldProcedimento;
        FieldForm fieldTag;
        CheckedListBox checkedList;
        ComboBox comboBox;
        RichTextBox richBox;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public InserirSenha(SenhaCrud parent) : base("InserirSenha", SizeScreen.Different)
        {
            this.parent = parent;
            this.parent.Hide();

            fieldNome = new FieldForm("Nome", 20, 10, 260, 20);
            fieldCategoria = new FieldForm("Categoria", 20, 80, 260, 60);
            fieldUrl = new FieldForm("Url", 20, 150, 260, 60);
            fieldUsuario = new FieldForm("Usuario", 20, 225, 260, 60);
            fieldSenha = new FieldForm("Senha", 20, 300, 260, 60);
            fieldProcedimento = new FieldForm("Procedimento", 20, 390, 260, 60);
            fieldTag = new FieldForm("Tag", 20, 520, 260, 60);

            IEnumerable<Tag> tags = TagController.GetTags();
            checkedList = new CheckedListBox();
            this.checkedList.Location = new System.Drawing.Point(20, 550);
            this.checkedList.Size = new System.Drawing.Size(260, 100);
            this.checkedList.TabIndex = 0;
            foreach (Tag item in tags)
            {
                checkedList.Items.Add(item.Id + " - " + item.Descricao);
            }

            IEnumerable<Categoria> categorias = CategoriaController.GetCategorias();
            comboBox = new ComboBox();
            comboBox.Location = new System.Drawing.Point(20, 110);
            comboBox.Name = "Categoria";
            comboBox.Size = new System.Drawing.Size(245, 15);
            foreach (Categoria item in categorias)
            {
                comboBox.Items.Add(item.Id + " - " + item.Nome);
            }

            richBox = new RichTextBox();
            richBox.Location = new Point(20, 410);
            richBox.Size = new System.Drawing.Size(230, 100);

            btnConfirmar = new ButtonForm("Confirmar", 100, 700, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 100, 760, this.handleCancel);

            this.Controls.Add(checkedList);
            this.Controls.Add(comboBox);
            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldCategoria.lblField);
            this.Controls.Add(fieldUrl.lblField);
            this.Controls.Add(fieldUrl.txtField);
            this.Controls.Add(fieldUsuario.lblField);
            this.Controls.Add(fieldUsuario.txtField);
            this.Controls.Add(fieldSenha.lblField);
            this.Controls.Add(fieldSenha.txtField);
            this.Controls.Add(fieldProcedimento.lblField);
            this.Controls.Add(richBox);
            this.Controls.Add(fieldTag.lblField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }
        private void handleConfirm(object sender, EventArgs e)
        {
            try
            {
                string comboBoxValue = this.comboBox.Text; // "1 - Nome"
                string[] destructComboBoxValue = comboBoxValue.Split('-'); // ["1 ", " Nome"];
                string idCategoria = destructComboBoxValue[0].Trim(); // "1 " => "1"
                Senha senha = SenhaController.InserirSenha(
                    this.fieldNome.txtField.Text,
                    Convert.ToInt32(idCategoria),
                    this.fieldUrl.txtField.Text,
                    this.fieldUsuario.txtField.Text,
                    this.fieldSenha.txtField.Text,
                    this.fieldProcedimento.txtField.Text
                );
                if (checkedList.CheckedItems.Count > 0)
                {
                    foreach (object itemList in checkedList.CheckedItems)
                    {
                        string checkedValue = itemList.ToString(); // "1 - Nome"
                        string[] destructCheckedValue = checkedValue.Split('-'); // ["1 ", " Nome"];
                        string idTagString = destructCheckedValue[0].Trim(); // "1 " => "1"
                        int idTag = Convert.ToInt32(idTagString);
                        SenhaTagController.InserirSenhaTag(senha.Id, idTag);
                    }
                    //this.Hide();
                }
                else
                {
                    MessageBox.Show("Selecione 1 Tag da lista");
                }
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