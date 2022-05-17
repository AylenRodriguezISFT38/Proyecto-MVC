using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cursoMVC1.Models
{
    public class AlumnoCE
    {

        public int id { get; set; }
        [Required, MinLength(10), MaxLength(30)]
        [Display(Name = "Ingrese nombres")]
        public string nombres { get; set; }

        [Required, MinLength(10), MaxLength(30)]
        [Display(Name = "Ingrese apellidos")]
        public string apellidos { get; set; }

        [Required,MaxLength(2),Range(18,99,ErrorMessage = "La edad del alumno debe estar comprendida entre 18 - 99")]
        [Display(Name = "Edad del alumno")]
        public int edad { get; set; }

        [Required,MinLength(1),MaxLength(1)]
        [Display(Name = "Ingrese sexo del alumno")]
        public string sexo { get; set; }

        [Required, MinLength(10), MaxLength(30)]
        [Display(Name = "Ingrese ciudad del alumno")]
        public int codCiudad { get; set; }


        public string nombreCiudad { get; set; }

        public string nombreCompleto { get { return nombres + " " + apellidos; } }

        public System.DateTime fechaRegistro { get; set; }

    }
    public partial class Alumno {
        public string NombreCompleto { get { return nombres + " " + apellidos; } }
        public string nombreCiudad { get; set; }
    }
}