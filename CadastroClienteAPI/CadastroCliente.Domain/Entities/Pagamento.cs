using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Domain.Entities
{
    public class Pagamento
    {
        public Guid Id { get; set; }
        public Guid EmprestimoId { get; set; }
        public Emprestimo Emprestimo { get; set; } = null!;
        public decimal ValorPago { get; set; }
        public DateTime DataPagamento { get; set; }
       
    }
}
