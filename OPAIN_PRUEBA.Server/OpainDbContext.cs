using Microsoft.EntityFrameworkCore;
using OPAIN_PRUEBA.Server.Models;

namespace OPAIN_PRUEBA.Server
{
    public class OpainDbContext : DbContext
    {
        public OpainDbContext(DbContextOptions<OpainDbContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
    }
}
