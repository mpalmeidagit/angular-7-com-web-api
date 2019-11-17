using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModel
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Cidade { get; set; }

        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}