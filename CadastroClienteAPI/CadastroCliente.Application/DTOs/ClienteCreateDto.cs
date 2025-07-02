using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Application.DTOs
{
    public class ClienteCreateDto
    {
        public string NomeCompleto { get; set; } = string.Empty;
        public string CpfOuCnpj { get; set; } = string.Empty;
        public string EnderecoResidencial { get; set; } = string.Empty;
        public string EnderecoTrabalho { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? InformacoesAdicionais { get; set; }

    }
}
