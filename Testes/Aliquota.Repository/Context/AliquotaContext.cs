using Aliquota.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Repository.Context
{
    public class AliquotaContext : DbContext
    {
        const string stringDeConexao = "Data Source=localhost;Initial Catalog=DesafioKinvo;Integrated Security=False;User ID=sa;Password=1q2w3e4r@#$;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        public DbSet<Aplicacao> Aplicacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(stringDeConexao);
        }
    }
}