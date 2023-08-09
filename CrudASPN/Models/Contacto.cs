using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudASPN.Models
{
    public class Contacto
    {

        //Vamos a realizar las etiquetas para la validacion y evitar el ingreso no valido de  datos
        [Key]//Hace que el atributo sea una llave primaria pero con solo el  nombre de Id se Hace automaticamente ademas de ser autoincrementable
        public int ID { get; set; }
        [Required(ErrorMessage ="El nombre es Obligatorio")]
        public string Nombre { get; set; }
        
        //------------------------------------------
        [Required(ErrorMessage ="El telefono es Obligatorio")]
        [Display(Name ="Telefono")]
        public string Telefono { get; set; }
        //------------------------------------------
        [Required(ErrorMessage ="El cedular es Obligatorio")]
        public string Celular { get; set; }
        //--------------------------------------------
        [EmailAddress]
        [Required(ErrorMessage = "El Correo es Obligatorio")]
        public string Email { get; set; }
        //------------------------------------------

        [Required(ErrorMessage = "la fecha es Obligatorio")]
        public DateTime FechaCreacion { get; set; }
    }
}
