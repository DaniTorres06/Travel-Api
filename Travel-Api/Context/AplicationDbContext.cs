using Microsoft.EntityFrameworkCore;
using Travel_Api.Models;

namespace Travel_Api.Context
{
    public class AplicationDbContext : DbContext
    {
        
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {
        }

        public AplicationDbContext()
        {

        }


        public DbSet<Autores>Autores { get; set; }
        public DbSet<Autores_has_libros> Autores_has_libros { get; set; }
        public DbSet<Editoriales> Editoriales{ get; set; }
        public DbSet<Libros> Libros { get; set; }

    }
}
