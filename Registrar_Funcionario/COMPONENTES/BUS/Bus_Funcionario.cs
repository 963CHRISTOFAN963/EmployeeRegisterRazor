using Registrar_Funcionario.COMPONENTES.DB;
using Registrar_Funcionario.Models;

namespace Registrar_Funcionario.COMPONENTES.BUS
{
    public class Bus_Funcionario
    {
        private readonly Db_Funcionario _db;

        public Bus_Funcionario(Db_Funcionario db)
        {
            _db = db;
        }

        public void Cadastrar(Funcionario funcionario)
        {
            // 🔹 Regras de negócio
            if (string.IsNullOrWhiteSpace(funcionario.Nome))
                throw new Exception("Nome é obrigatório");

            if (funcionario.Salario < 0)
                throw new Exception("Salário inválido");

            // Chama o DB
            _db.Inserir(funcionario);
        }

        public List<Funcionario> Listar()
        {
            return _db.Listar();
        }
    }
}
