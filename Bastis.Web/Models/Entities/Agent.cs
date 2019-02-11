using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bastis.Models.Entities
{
    public class Agent
    {
        [Key]
        [Column(Order = 1)]
        public Guid CustomerID { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(128)]
        public string Address { get; set; }

        [Required]
        [MaxLength(128)]
        public string EmploymentCharge { get; set; }

        public string Expirience { get; set; }

        [Required]
        [MaxLength(128)]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        [MaxLength(128)]
        public string Mobile { get; set; }

        [Required]
        [MaxLength(128)]
        public string AboutMe { get; set; }
        //Facebook
        //twitter
        //Google+
        //LinkedIn
        //Instagram
        //Pinterest

        [Required]
        [MaxLength(128)]
        public string SocialNetworks { get; set; }

        public string Website { get; set; }


        //[Required]
        //[MaxLength(128)]
        public string ProfilePicture { get; set; }

        public int AgencyID { get; set; }

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


        public virtual Agency Agency { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}