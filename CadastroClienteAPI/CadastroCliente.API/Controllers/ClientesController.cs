using CadastroCliente.Application.DTOs;
using CadastroCliente.Application.Services;
using CadastroCliente.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ClienteService _clienteService;
    private readonly AppDbContext _context;

    public ClientesController(ClienteService clienteService, AppDbContext context)
    {
        _clienteService = clienteService;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CriarCliente([FromBody] ClienteCreateDto dto)
    {
        var cliente = await _clienteService.CriarClienteAsync(dto);
        return CreatedAtAction(null, new { id = cliente.Id }, cliente);
    }

    [HttpGet]
    public IActionResult Get()
    {
        var clientes = _context.Clientes.ToList();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente == null)
            return NotFound();

        return Ok(cliente);
    }
}