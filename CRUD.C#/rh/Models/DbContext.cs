using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace YourNamespace.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Funcionario> Funcionarios {get; set;}
        public DbSet<Ferias> Ferias {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Ferias>()
                .HasOne(f => f.Funcionario)
                .WithMany()
                .HasForeignKey(f => f.FuncionarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
