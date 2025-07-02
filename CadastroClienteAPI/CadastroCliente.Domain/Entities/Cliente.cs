using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string CpfOuCnpj { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string EnderecoResidencial{ get; set; } = string.Empty;
        public string EnderecoTrabalho { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string InformacoesAdicionais { get; set; } = string.Empty;

        public ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
    }
}
