using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RegistroTareas.Models
{
    [Table("Tarea")]
    public class Tarea
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Ingrese un Nombre de Tarea", MinimumLength = 3)]
        public string Nombre { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Fecha de Inicio")]
        public DateTime Fecha_Inicio { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Fecha de Entrega")]
        [FechaEntregaValida]
        public DateTime Fecha_Entrega { get; set; }
        [StringLength(255, ErrorMessage = "Ingrese una Descripcion de Tarea de hasta 255 caracteres", MinimumLength = 3)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}