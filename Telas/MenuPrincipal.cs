using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginScreenApplication.Telas
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroUsuario caduser = new CadastroUsuario();
            caduser.Show();
            this.Hide();
        }

        

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var opcao = MessageBox.Show("Deseja realmente sair?", "LoginScreen System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcao == DialogResult.Yes) { Application.Exit(); }
            else { }
        }

        private void btnMinimaze_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var opcao = MessageBox.Show("Deseja realmente sair?", "LoginScreen System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcao == DialogResult.Yes) { TelaLogin tela = new TelaLogin(); tela.Show(); this.Hide(); }
            else { }
        }
    }
}
