using System;
using System.ComponentModel.DataAnnotations;

namespace Bastis.Models.Entities
{
    public class Permission
    {
        [Key]
        [Required(ErrorMessage = "xxxxx")]
        public int PermissionID { get; set; }

        [Required(ErrorMessage = "xxxxx")]
        //[StringLength(128)]
        //public string RoleID { get; set; }
        public string ApplicationRoleId { get; set; }


        [Required(ErrorMessage = "xxxxx")]
        public int MenuID { get; set; }

        public bool ViewMenu { get; set; }
        public bool CreateOption { get; set; }
        public bool ReadOption { get; set; }
        public bool UpdateOption { get; set; }
        public bool DeleteOption { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}