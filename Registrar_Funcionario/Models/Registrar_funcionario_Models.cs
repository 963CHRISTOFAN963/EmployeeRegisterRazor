using System;
using System.ComponentModel.DataAnnotations;

namespace Registrar_Funcionario.Models
{
    public class Funcionario
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        public string Cpf { get; set; }

        public string Cargo { get; set; }

        public DateTime? DataAdmissao { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Salário inválido")]
        public decimal Salario { get; set; }

        public string Situacao { get; set; }
    }
}
