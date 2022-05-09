using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LoginScreenApplication.CamadaDados
{
    class ValidacaoLoginExistente
    {
        public string Login { get; set; }


        // Método que valida se já não existe o mesmo login no banco antes de cadastrar o usuário

        public void ValidacaoSeJaExisteLoginCadastrado(string login, Label statusDisponibilidadeLogin)
        {
            this.Login = login;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = Conexao.Cn;
            SqlDataReader dr;

            try
            {

                cn.Open();
                var query = @"SELECT * FROM tb_loginCadastrados WHERE [login] = @login";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.ExecuteNonQuery();


                dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    statusDisponibilidadeLogin.Visible = true;
                    statusDisponibilidadeLogin.ForeColor = Color.Red;
                    statusDisponibilidadeLogin.Text = "Login já cadastrado";
                }
                else
                {
                    statusDisponibilidadeLogin.Visible = true;
                    statusDisponibilidadeLogin.ForeColor = Color.LightGreen;
                    statusDisponibilidadeLogin.Text = "Login liberado para uso";
                }

                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex + "|", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
