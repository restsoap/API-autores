using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //damos el nombre a la tabla 
        public DbSet<Autor> Autores { get; set; }

        //dbset de libros para hacer consultas a la tabla
        public DbSet<Libro> Libros { get; set; }

        //para agregar una tabla ponemos Add-Migration Libros  
        // Update-Database
    }
}
