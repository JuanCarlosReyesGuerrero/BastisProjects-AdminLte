using System;
using System.ComponentModel.DataAnnotations;

namespace Bastis.Models.Entities
{
    public class CustomPermission
    {
        [Key]
        [Required(ErrorMessage = "xxxxx")]
        public int CustomPermissionID { get; set; }

        [Required(ErrorMessage = "xxxxx")]
        //[StringLength(128)]
        // public string UserID { get; set; }
        public string ApplicationUserId { get; set; }

        [Required(ErrorMessage = "xxxxx")]
        public int MenuID { get; set; }

        public virtual Menu Menu { get; set; }
        // public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}