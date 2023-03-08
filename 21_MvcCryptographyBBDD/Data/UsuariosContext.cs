using _21_MvcCryptographyBBDD.Models;
using Microsoft.EntityFrameworkCore;

namespace _21_MvcCryptographyBBDD.Data
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
