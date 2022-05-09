using LoginScreenApplication.CamadaDados;
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
    public partial class CadastroUsuario : Form
    {

        ValidacaoLoginExistente vle = new ValidacaoLoginExistente();
        CadastroUsuarios cad = new CadastroUsuarios();



        public CadastroUsuario()
        {
            InitializeComponent();
        }

        private void txtLogin_TextAlignChanged(object sender, EventArgs e)
        {
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void CadastroUsuario_Load(object sender, EventArgs e)
        {
            lblStatusDeLogin.Visible = false;
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            if(txtLogin.Text == "")
            {
                lblStatusDeLogin.Visible = false;
            }
            else
            {
                vle.ValidacaoSeJaExisteLoginCadastrado(txtLogin.Text, lblStatusDeLogin);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cad.CadastrarUsuario(txtCpf.Text.Trim(), txtNome.Text.Trim(), txtDtNasc.Text.Trim(), txtSexo.Text.Trim(), txtEmail.Text.Trim(), txtContato.Text.Trim(), txtLogin.Text.Trim(), txtSenha.Text.Trim(), lblStatusDeLogin); 
        }

        private void btnMinimaze_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var opcao = MessageBox.Show("Deseja realmente sair?", "LoginScreen System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcao == DialogResult.Yes) { Application.Exit(); }
            else { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var opcao = MessageBox.Show("Deseja realmente sair?", "LoginScreen System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcao == DialogResult.Yes) { TelaLogin tela = new TelaLogin(); tela.Show(); this.Hide(); }
            else { }
        }
    }
}
