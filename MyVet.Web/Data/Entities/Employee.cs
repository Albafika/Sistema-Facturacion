using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Web.Data.Entities
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }

        [Display(Name = "ID Empleado")]
        public int Codigo_Empleado { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Employee_Name { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Employee_Lastname { get; set; }

        //-----Relacion Document-----
        [Display(Name = "Documento")]
        [ForeignKey("Document")]
        public int Document_Id { get; set; }
        public Document Document { get; set; }

        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Celular")]
        public string Cellphone { get; set; }

        [MaxLength(6, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Extensión")]
        public string Extension { get; set; }

        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Estado")]
        public bool Status { get; set; }

        //-----Relacion Position-----
        [Display(Name = "Posición")]
        [ForeignKey("Position")]
        public int Position_Id { get; set; }
        public Position Position { get; set; }

        [Display(Name = "Fecha_Ingreso")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/ yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Ingreso { get; set; }
    }
}
