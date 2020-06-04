using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Data.Entities
{
    public class Document
    {
        [Key]
        [Display(Name = "Código")]
        public int Document_Id { get; set; }


        [Display(Name = "Tipo Documento")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Document_Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
