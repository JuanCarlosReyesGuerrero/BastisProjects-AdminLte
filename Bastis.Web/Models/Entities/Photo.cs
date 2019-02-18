using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bastis.Models.Entities
{
    public class Photo
    {
        [Key]
        [Column(Order = 1)]
        public Guid PhotoID { get; set; }

        public string URLPhoto { get; set; }

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

        public virtual Property Property { get; set; }
    }
}