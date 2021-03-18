using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistroTareas.Models
{
    public class FechaEntregaValida : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var tarea = (Tarea)validationContext.ObjectInstance;
                var fecha_entrega = (DateTime)value;

                if (DateTime.Compare(fecha_entrega, tarea.Fecha_Inicio) < 0)
                {
                    return new ValidationResult("La Fecha de Entrega no puede ser anterior a la Fecha Inicial");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Debe seleccionar una Fecha de Entrega");
            }
        }
    }
}