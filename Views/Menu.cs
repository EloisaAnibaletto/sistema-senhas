using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Views.Lib;
using Views;

namespace Views
{
    public class Menu : BaseForm
    {
        Form parent;
        ButtonForm btnCategoria;
        ButtonForm btnTag;
        ButtonForm btnSenhas;
        ButtonForm btnUsuário;
        ButtonForm btnSair;
        public Menu(Form parent) : base("Bem-Vindo", SizeScreen.Small) 
        {
            this.parent = parent;
            this.parent.Hide();
            btnCategoria = new ButtonForm("Categoria", 100, 30, this.handleCategoria);
            btnTag = new ButtonForm("Tag", 100, 80, this.handleTag);
            btnSenhas = new ButtonForm("Senhas", 100, 130, this.handleSenhas);
            btnUsuário = new ButtonForm("Usuário", 100, 180, this.handleUsuário);
            btnSair = new ButtonForm("Sair", 100, 230, this.handleSair);

            this.Controls.Add(btnCategoria);
            this.Controls.Add(btnTag);
            this.Controls.Add(btnSenhas);
            this.Controls.Add(btnUsuário);
            this.Controls.Add(btnSair);
        }
        private void handleCategoria(object sender, EventArgs e)
        {
            (new CategoriaCrud(this)).Show();
            this.Hide();

        }
        private void handleTag(object sender, EventArgs e)
        {
            //(new TagCrud()).Show();
            this.Hide();

        }
        private void handleSenhas(object sender, EventArgs e)
        {
            //(new SenhasCrud()).Show();
            this.Hide();

        }
        private void handleUsuário(object sender, EventArgs e)
        {
            //(new UsuárioCrud()).Show();
            this.Hide();

        }
        private void handleSair(object sender, EventArgs e) {
			this.parent.Show();
            this.Close();
		}
    }
}