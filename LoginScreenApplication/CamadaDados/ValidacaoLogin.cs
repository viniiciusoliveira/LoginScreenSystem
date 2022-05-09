using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginScreenApplication.Telas;

namespace LoginScreenApplication.CamadaDados
{
    class ValidacaoLogin
    {
        public string Login { get; set; }
        public string Senha { get; set; }

             // Método que faz a validação de LOGIN 
        public void Acesso_ValidacaoLogin(string login, string senha, TextBox txtsenha)
        {
            this.Login = login;
            this.Senha = senha;

            var cn = new SqlConnection();
            cn.ConnectionString = Conexao.Cn;
            SqlDataReader dr;

            var queryValidacaoLogin = @"SELECT * FROM tb_loginCadastrados WHERE [login] = @login and senha = @senha";

            try
            {
                cn.Open();
                var cmd = new SqlCommand(queryValidacaoLogin, cn);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@senha", senha);
                cmd.ExecuteNonQuery();

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    MessageBox.Show("Logado com sucesso!", "Bem-Vindo | LoginScreenSystem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TelaLogin telaLogin = new TelaLogin();
                    MenuPrincipal menuPrincipal = new MenuPrincipal();
                    telaLogin.Hide();
                    menuPrincipal.Show();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha imvalidos, tente novamente!", "Falha ao Logar | LoginScreenSystem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtsenha.Text = string.Empty;
                    txtsenha.Focus();


                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar executar a operação:\n\n" + "[" + ex + "]\n\n", "Error - LoginScreenSystem", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
