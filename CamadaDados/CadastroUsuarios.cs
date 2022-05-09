using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace LoginScreenApplication.CamadaDados
{
    class CadastroUsuarios
    {

        public string Cpf { get; set;}
        public string Nome { get; set; }
        public string Datanascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }


        // Método que insere no banco de dados as informações de novos usuários.
        public void CadastrarUsuario(string cpf, string nome, string dataNascimento, string sexo, string email, string contato, string login, string senha, Label status)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.Datanascimento = dataNascimento;
            this.Sexo = sexo;
            this.Email = email;
            this.Contato = contato;
            this.Login = login;
            this.Senha = senha;

            var cn = new SqlConnection();
            cn.ConnectionString = Conexao.Cn;

            var queryInserir = @"INSERT INTO tb_cadastrados VALUES (@cpf, @nome, @datanascimento, @sexo, @email, @contato)
                                 INSERT INTO tb_loginCadastrados VALUES (@cpf, @login, @senha, GETDATE())";
           
            try
            {

                if(cpf == "   .   .   .   -" || nome== "" || dataNascimento == "  /  /" || sexo == "" || email == "" || contato == "(  )     -" || login == "" || senha == "")
                {
                    MessageBox.Show("Campos em branco, favor preecher todos", "Falha - LoginScreenSystem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if(status.ForeColor == Color.Red || status.Text == "Login já cadastrado")
                {
                    MessageBox.Show("Login já cadastrado em nosso banco de dados, escolha outro", "Falha - LoginScreenSystem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cn.Open();
                    var cmd = new SqlCommand(queryInserir, cn);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@datanascimento", dataNascimento);
                    cmd.Parameters.AddWithValue("@contato", contato);
                    cmd.Parameters.AddWithValue("@sexo", sexo);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@login", login); 
                    cmd.Parameters.AddWithValue("@senha", senha);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Usuário cadastrado com sucesso!", "LoginScreenSystem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar executar a operação:\n\n" + "[" + ex + "]\n\n", "Error - LoginScreenSystem" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
