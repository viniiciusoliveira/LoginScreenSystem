using LoginScreenApplication.CamadaDados;
using LoginScreenApplication.Telas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginScreenApplication
{
    public partial class TelaLogin : Form
    {

        ValidacaoLogin valilogin = new ValidacaoLogin();
    
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var opcao = MessageBox.Show("Deseja realmente sair?", "LoginScreen System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(opcao == DialogResult.Yes) { Application.Exit(); } 
            else { }
        }

        private void btnMinimaze_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            valilogin.Acesso_ValidacaoLogin(txtLogin.Text, txtSenha.Text, txtSenha);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CadastroUsuario cad = new CadastroUsuario();
            cad.Show();
            this.Hide();
        }
    }
}
