using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bastis.Models.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Number")]
        public Int64 CityID { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Digite el código del municipio")]
        public string Code { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Digite el nombre del municipio")]
        public string Name { get; set; }

        [Display(Name = "Código unificado")]
        [Required(ErrorMessage = "Digite el nombre del código unificado")]
        public string UnifiedCode { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Seleccionar un departamento")]
        //[ForeignKey("States")]
        public Int64 StateID { get; set; }

        public string StateCode { get; set; }

        [Display(Name = "Estado")]
        public bool Status { get; set; }


        // Inicio Auditoria de la tabla ---------------------------------------------------
        public Guid? UserRegisters { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateRegister { get; set; }

        public Guid? UserModifies { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateModified { get; set; }
        // Fin Auditoria de la tabla ---------------------------------------------------


        public virtual State State { get; set; }
    }
}