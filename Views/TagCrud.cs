using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using Models;
using Controllers;

namespace Views
{
    public class TagCrud : BaseForm
    {
        Form parent;
        public ListView listView;
        ButtonForm btnIncluir;
        ButtonForm btnAlterar;
        ButtonForm btnExcluir;
        ButtonForm btnVoltar;
        public TagCrud(Form parent) : base("Tag", SizeScreen.Medium)
        {
            this.parent = parent;
            this.parent.Hide();
            listView = new ListView();
			listView.Location = new Point(10, 20);
			listView.Size = new Size(580,350);
			listView.View = View.Details;
			listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
			listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);
            listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;
            btnIncluir = new ButtonForm("Incluir",100,450, this.handleIncluir);
            btnAlterar = new ButtonForm("Alterar",200,450, this.handleAlterar);
            btnExcluir = new ButtonForm("Excluir",300,450, this.handleExcluir);
            btnVoltar = new ButtonForm("Voltar",400,450, this.handleVoltar);

            this.LoadInfo();
            this.Controls.Add(listView);
            this.Controls.Add(btnIncluir);
            this.Controls.Add(btnAlterar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnVoltar);
        }
        public void LoadInfo() {
            IEnumerable<Tag> tags = TagController.GetTags();

            this.listView.Items.Clear();
            foreach (Tag item in tags)
            {
                ListViewItem lvItem = new ListViewItem(item.Id.ToString());
                lvItem.SubItems.Add(item.Descricao);

                this.listView.Items.Add(lvItem);
            }
        }

        private void handleIncluir(object sender, EventArgs e)
        {
            (new InserirTag(this)).Show();
            this.Hide();
        }
        private void handleAlterar(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0) {
                (new AlterarTag(this)).Show();
                this.Hide();
            } else {
                MessageBox.Show("Selecione 1 item da lista");
            }
        }
        private void handleExcluir(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0) {
                ListViewItem item = this.listView.SelectedItems[0];
                int id = Convert.ToInt32(item.Text);
                try {
                TagController.ExcluirTag(
                    id
                );
                } catch (Exception err) {
                    MessageBox.Show(err.Message);
                }
             }else {
                MessageBox.Show("Selecione 1 item da lista");
            }
            this.parent.Show();
            this.Close();
        }
        private void handleVoltar(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close(); 
        }
    }
}