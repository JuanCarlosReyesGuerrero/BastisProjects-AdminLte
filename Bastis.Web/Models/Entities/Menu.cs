using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bastis.Models.Entities
{
    public class Menu
    {
        [Key]
        [Required(ErrorMessage = "xxxxx")]
        public int MenuID { get; set; }

        [Required(ErrorMessage = "xxxxx")]
        [StringLength(50)]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "xxxx")]
        public int ParentMenuID { get; set; }

        [Required(ErrorMessage = "xxxxx")]
        public int OrderNumber { get; set; }

        [StringLength(100)]
        public string MenuURL { get; set; }

        [StringLength(25)]
        public string MenuIcon { get; set; }

        public virtual ICollection<CustomPermission> CustomPermissions { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}


//[DataType(DataType.MultilineText)]
//[DisplayName("Body:")]
//public string Body { get; set; }


//https://www.c-sharpcorner.com/article/code-first-approach-in-mvc-5/