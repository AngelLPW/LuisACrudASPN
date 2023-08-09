using CrudASPN.Datos;
using CrudASPN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudASPN.Controllers
{
    public class InicioController : Controller
    {
        private readonly ApplicationDbContext _Context; //Quitamo este _logger:ILogger<InicioController> _logger;

        public InicioController(ApplicationDbContext context)
        {
            //Aplicamos las inyecciones de dependencias por medio de la variable contexto, pondremos acceder a cualqiuer propiedad o modelo que contenga el programa
            _Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {//accedemos por medio de dbset con las utilidades de ENTITY FRAMEWORK para acceder a nuestra entidad
            return View(await _Context.Contactos.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Crear()//Click derecho agregamos la vista y selecionamos la vista Rezor_vacia
        {//cuando se crea retrona la vista

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]// para evitar los ataques xcs 
        public async Task<IActionResult> Crear(Contacto contacto)
        {//cunado el modelo contenga datos 
            if (ModelState.IsValid)
            {
                _Context.Contactos.Add(contacto);//mandamos la entidad a contactos paa asi realizar el guadado ecxitoso
                contacto.FechaCreacion = DateTime.Now;
                await _Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        ///Metodo para editar, validamos que el id que buscamos no venga vacio
        [HttpGet]
        public IActionResult Editar(int? Id)
        {
            if (Id== null)
            {
                return NotFound();
            }
            var contacto = _Context.Contactos.Find(Id);
            if (contacto==null)
            {
                return NotFound();
            }
            return View(contacto);
        }
        //Realizamos el metodo de editar el usuario
        [HttpPost]
        [ValidateAntiForgeryToken]// para evitar los ataques xcs 
        public async Task<IActionResult> Editar(Contacto contacto)
        {//cunado el modelo contenga datos 
            if (ModelState.IsValid)
            {
                _Context.Update(contacto);//mandamos la entidad a contactos paa asi realizar el guadado ecxitoso
                contacto.FechaCreacion = DateTime.Today;
                await _Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //creamos el detalle
        [HttpGet]
        public IActionResult Detalle(int? Id)
        { // solamente mostraremos los datos de los contactos
            if (Id== null)
            {
                return NotFound();
            }
            var contacto = _Context.Contactos.Find(Id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }
        //creamos elimininar
        [HttpGet]
        public IActionResult Borrar(int? Id)
        { // solamente mostraremos los datos de los contactos
            if (Id == null)
            {
                return NotFound();
            }
            var contacto = _Context.Contactos.Find(Id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarContacto(int id)
        {
            var contacto = await _Context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }

            // Borramos el contacto
            _Context.Contactos.Remove(contacto);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //creamos elimininar
        #region VistaParcial

        [HttpGet]

        public IActionResult  _BorrarContacto(int? id)
        {if (id == null)
        {
            return NotFound();
        }

        var contacto = _Context.Contactos.Find(id);
        if (contacto == null)
        {
            return NotFound();
        }

        return PartialView("_BorrarContacto", contacto);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        [ActionName("_BorrarContacto")]
        public async Task<IActionResult> ConfirmarBorrarContacto(int id)
        {
            var contacto = await _Context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }

            _Context.Contactos.Remove(contacto);
            await _Context.SaveChangesAsync();

            return Ok(); // Devolver una respuesta exitosa (200 OK) al cliente.
        }


        #endregion

        [HttpGet]
        public IActionResult _Detalle(int? Id)
        { // solamente mostraremos los datos de los contactos
         
            var contacto = _Context.Contactos.Find(Id);
            return PartialView("_Detalle",contacto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}