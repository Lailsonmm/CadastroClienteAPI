using CadastroCliente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Emprestimo> Emprestimos => Set<Emprestimo>();
        public DbSet<Pagamento> Pagamentos => Set<Pagamento>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de entidades, relacionamentos, etc. podem ser feitas aqui
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
            modelBuilder.Entity<Emprestimo>().HasKey(e => e.Id);
            modelBuilder.Entity<Pagamento>().HasKey(p => p.Id);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Emprestimos)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId);

            modelBuilder.Entity<Emprestimo>()
                .HasMany(e => e.Pagamentos)
                .WithOne(p => p.Emprestimo)
                .HasForeignKey(p => p.EmprestimoId);

        }
    }
}