using CrudASPN.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//La variable Builder se usas como constructor para la creacion de objetos
//Configurar la conexion a sql y asi vamos a configura nuestra base de datos 
builder.Services.AddDbContext<ApplicationDbContext>(Opciones =>
Opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

// Add services to the container.
builder.Services.AddControllersWithViews();



    
var app = builder.Build();

// Los APP son Middelword 
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=Index}/{id?}");

app.Run();

