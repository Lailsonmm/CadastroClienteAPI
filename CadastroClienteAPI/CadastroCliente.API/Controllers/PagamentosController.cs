using Microsoft.AspNetCore.Mvc;
using CadastroCliente.Infrastructure.Context;
using CadastroCliente.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CadastroCliente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PagamentosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pagamento pagamento)
        {
            var emprestimo = await _context.Emprestimos.FindAsync(pagamento.EmprestimoId);
            if (emprestimo == null)
            {
                return NotFound("Empréstimo não encontrado.");
            }

            pagamento.Id = Guid.NewGuid();
            await _context.Pagamentos.AddAsync(pagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Post), new { id = pagamento.Id }, pagamento);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pagamentos = _context.Pagamentos.ToList();
            return Ok(pagamentos);
        }

        [HttpGet("emprestimo/{emprestimoId}")]
        public IActionResult GetByEmprestimo(Guid emprestimoId)
        {
            var pagamentos = _context.Pagamentos
                .Where(p => p.EmprestimoId == emprestimoId)
                .ToList();

            return Ok(pagamentos);
        }

    }
}