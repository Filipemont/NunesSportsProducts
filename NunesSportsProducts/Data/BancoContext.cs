using Microsoft.EntityFrameworkCore;
using NunesSportsProducts.Models;

namespace NunesSportsProducts.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }


        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
