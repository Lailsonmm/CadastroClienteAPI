using Microsoft.AspNetCore.Mvc;
using CadastroCliente.Infrastructure.Context;
using CadastroCliente.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CadastroCliente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmprestimosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Emprestimo emprestimo)
        {
            var cliente = await _context.Clientes.FindAsync(emprestimo.ClienteId);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            emprestimo.Id = Guid.NewGuid();
            await _context.Emprestimos.AddAsync(emprestimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Post), new { id = emprestimo.Id }, emprestimo);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var emprestimos = _context.Emprestimos.ToList();
            return Ok(emprestimos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var emprestimo = _context.Emprestimos.Find(id);
            if (emprestimo == null)
                return NotFound();

            return Ok(emprestimo);
        }

        [HttpGet("cliente/{clienteId}")]
        public IActionResult GetByCliente(Guid clienteId)
        {
            var emprestimos = _context.Emprestimos
                .Where(e => e.ClienteId == clienteId)
                .ToList();

            return Ok(emprestimos);
        }


    }
}