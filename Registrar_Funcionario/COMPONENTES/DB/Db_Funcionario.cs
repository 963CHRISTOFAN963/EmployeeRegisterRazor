using System.Data;
using System.Data.SqlClient;
using Registrar_Funcionario.Models;

namespace Registrar_Funcionario.COMPONENTES.DB
{
    public class Db_Funcionario
    {
        private readonly string _connectionString;

        public Db_Funcionario(string connectionString)
        {
            _connectionString = connectionString;
        }

        // CREATE
        internal void Inserir(Funcionario f)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_Funcionario_Insert", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nome", f.Nome);
            cmd.Parameters.AddWithValue("@Email", f.Email);
            cmd.Parameters.AddWithValue("@Cpf", f.Cpf);
            cmd.Parameters.AddWithValue("@Cargo", f.Cargo);
            cmd.Parameters.AddWithValue("@DataAdmissao", f.DataAdmissao);
            cmd.Parameters.AddWithValue("@Salario", f.Salario);
            cmd.Parameters.AddWithValue("@Situacao", f.Situacao);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        // READ
        internal List<Funcionario> Listar()
        {
            var lista = new List<Funcionario>();

            using var conn = new SqlConnection(_connectionString);s
            using var cmd = new SqlCommand("sp_Funcionario_Listar", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Funcionario
                {
                    Id = (int)reader["Id"],
                    Nome = reader["Nome"].ToString(),
                    Email = reader["Email"].ToString(),
                    Cpf = reader["Cpf"].ToString(),
                    Cargo = reader["Cargo"].ToString(),
                    Situacao = reader["Situacao"].ToString()
                });
            }

            return lista;
        }
    }
}
