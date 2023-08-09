using CrudASPN.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudASPN.Datos
{
    public class ApplicationDbContext:DbContext//Dede de heredar la propiedad de DbContex
    {
        //Crear el contructor de la case
        //Base hace de interprete con la base de datos y relaciona y consulta los datos de ella
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        
        }
        //Acá van los modelos
        //Con la propieda de DbSet instaciamos el modelo 
        public DbSet<Contacto> Contactos { get; set;}

    }
}
