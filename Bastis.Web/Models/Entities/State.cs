using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bastis.Models.Entities
{
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Number")]
        public Int64 ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
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


        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}