using CadastroCliente.Application.DTOs;
using CadastroCliente.Domain.Entities;
using CadastroCliente.Infrastructure.Context;

namespace CadastroCliente.Application.Services;

public class ClienteService
{
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente> CriarClienteAsync(ClienteCreateDto dto)
    {
        var cliente = new Cliente
        {
            Id = Guid.NewGuid(),
            NomeCompleto = dto.NomeCompleto,
            CpfOuCnpj = dto.CpfOuCnpj,
            EnderecoResidencial = dto.EnderecoResidencial,
            EnderecoTrabalho = dto.EnderecoTrabalho,
            Telefone = dto.Telefone,
            Email = dto.Email,
            InformacoesAdicionais = dto.InformacoesAdicionais
        };

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }
}