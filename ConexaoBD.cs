using System.Data;
using System.Data.SqlClient;

namespace PolimorfismoGrafico
{
    public class ConexaoBD
    {
        private string connectionString = "Data Source=LUANPC\\SQLEXPRESS;Initial Catalog=empresa;User ID=sa;Password=@dmin";

        public SqlConnection ObterConexao()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void FecharConexao(SqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }



    }
}
