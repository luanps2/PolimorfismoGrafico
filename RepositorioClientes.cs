using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PolimorfismoGrafico
{
    public class RepositorioClientes : Clientes
    {

        private ConexaoBD conexaoBD;
        private Clientes clientes;

        public RepositorioClientes()
        {
            conexaoBD = new ConexaoBD();
            clientes = new Clientes();
        }

        public List<RepositorioClientes> BuscarCliente(int idCliente)
        {
            List<RepositorioClientes> clientes = new List<RepositorioClientes>();

            using (SqlConnection connection = conexaoBD.ObterConexao())
            {
                string sql = "SELECT * FROM Clientes WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.Parameters.AddWithValue("@ID", idCliente);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            RepositorioClientes cliente = new RepositorioClientes();
                            cliente.Id = reader.GetInt32(0);
                            cliente.Nome = reader.GetString(1);
                            cliente.Telefone = reader.GetString(2);

                            clientes.Add(cliente);

                        }
                    }
                }
            }

            return clientes;
        }
        public List<RepositorioClientes> BuscarCliente(string NomeCliente)
        {
            List<RepositorioClientes> clientes = new List<RepositorioClientes>();

            using (SqlConnection connection = conexaoBD.ObterConexao())
            {
                string sql = "SELECT * FROM Clientes WHERE Nome LIKE @Nome";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", "%" + NomeCliente + "%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            RepositorioClientes cliente = new RepositorioClientes();
                            cliente.Id = reader.GetInt32(0);
                            cliente.Nome = reader.GetString(1);
                            cliente.Telefone = reader.GetString(2);

                            clientes.Add(cliente);

                        }
                    }
                }
            }

            return clientes;
        }

    }
}
