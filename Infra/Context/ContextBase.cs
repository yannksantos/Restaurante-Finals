using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase( DbContextOptions options) : base (options) {}

        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Entregador> Entregador { get; set; }
        public DbSet<ItensMenu> ItensMenu { get; set; }
        public DbSet<ItensPedido> ItensPedido { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            builder.Entity<Pedidos>()
                .HasOne(p => p.Entregador)
                .WithMany()
                .HasForeignKey(p => p.EntregadorId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
