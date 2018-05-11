using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrackMe
{
    public partial class FCrackMe : Form
    {
        public FCrackMe()
        {
            InitializeComponent();

            using(CrackMeEntities context = new CrackMeEntities())
            {
                if (context.User.Count() == 0)
                {
                    CreateUsers createUsers = new CreateUsers();
                }
            }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            using(CrackMeEntities context = new CrackMeEntities())
            {
                if(context.User.Where(x => x.Usuario == tbUsuario.Text && x.Senha == tbSenha.Text).Count() > 0)
                {
                    MessageBox.Show("Logado", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpaCampo();
                }
                else
                {
                    MessageBox.Show("Falha na autenticação do usuário.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpaCampo();
                }
            }
        }

        private void limpaCampo()
        {
            tbUsuario.Clear();
            tbSenha.Clear();
        }
    }
}
