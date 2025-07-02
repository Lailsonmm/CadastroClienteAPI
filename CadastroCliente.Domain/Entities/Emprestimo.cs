using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Domain.Entities
{
    public class Emprestimo
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public decimal ValorOriginal { get; set; }
        public decimal TaxaJurosMensal { get; set; }
        public int TotalParcelas { get; set; }
        public int ParcelasPagas => Pagamentos.Count;
        public int ParcelasRestantes => TotalParcelas - ParcelasPagas;


        public DateTime DataContratacao { get; set; }

        public ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
        public decimal ValorAtualizado
        {
            get { //Exemplo simples: calcular o valor com juros acumulado
                  var mesesPassados = (int)((DateTime.Now - DataContratacao).TotalDays / 30);
                decimal valorComJuros = ValorOriginal;
                for (int i = 0; i < mesesPassados; i++)
                {
                    valorComJuros += valorComJuros * (TaxaJurosMensal / 100);
                }

                decimal totalPago = Pagamentos.Sum(p => p.ValorPago);
                return Math.Max(valorComJuros - totalPago, 0);
            }
        }

    }
}
