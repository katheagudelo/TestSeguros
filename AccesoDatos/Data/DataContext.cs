using AccesoDatos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Poliza> Polizas { get; set; }

    }
}
