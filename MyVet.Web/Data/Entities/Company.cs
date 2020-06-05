using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace Sistema.Web.Data.Entities
{
    public class Company
    {/// aqui revisa  la entidad emperesa, con su relacion de municipios  lo deje en comentarios 
        [Key]
        public int Company_Id { get; set; }

        [Required]
        [Display(Name = "Nombre De Empresa")]
        public string Company_Name { get; set; }
		
        //-----Relacion ClassifiCustomer-----
        [Display(Name = "Tipo De Empresa")]
        [ForeignKey("Clasificación Empresa")]
        public int ClientClass_Id { get; set; }
        public Client_Classification Client_Classification { get; set; }

        //-----Relacion Document-----
        [Display(Name = "Documento")]
        [ForeignKey("Document")]
        public int ID_Doc { get; set; }
        public Document Documents { get; set; }
		
        [Required]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Numero De Referencia")]
        public string Document { get; set; }
		
        [Required]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        //-----Relacion Neighborhood-----
		[Display(Name = "Municipio")]
        [ForeignKey("Neighborhood")]
        public int Neighborhood_Id { get; set; }
        public Neighborhood Neighborhood { get; set; }
		
        [Required]
        [Display(Name = "Email")]
        public string correo { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public string phone { get; set; }

    }
}
