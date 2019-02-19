using Bastis.Models;
using Bastis.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using static Bastis.Common.Enums;

namespace Bastis.Common
{
    public class Autentication : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Permission> ListPermissions(string vUserId, int vMenuId)
        {
            string vRolId = "";


            //PermissionsController permiso = new PermissionsController();

            //var userId = User.Identity.GetUserId();

            //var user = User.Identity;
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var s = UserManager.GetRoles(vUserId);
            vRolId = s[0].ToString();

            //var usersPerRoles = ListPermissions(vRolId, Convert.ToInt32(MenuOptions.States));

            var listPermissions = db.Permissions.Include(p => p.ApplicationRole);

            if (!String.IsNullOrEmpty(vRolId))
            {
                listPermissions = listPermissions.Where(x => x.ApplicationRole.Name.Contains(vRolId)
                                       && x.MenuID.Equals(vMenuId));
            }

            //return usersPerRoles;
            return listPermissions.ToList();
        }


        //public List<Permission> ListPermissions(string vRolId, int vMenuId)
        //{
        //    var listPermissions = db.Permissions.Include(p => p.ApplicationRole);

        //    if (!String.IsNullOrEmpty(vRolId))
        //    {
        //        listPermissions = listPermissions.Where(x => x.ApplicationRole.Name.Contains(vRolId)
        //                               && x.MenuID.Equals(vMenuId));
        //    }

        //    return listPermissions.ToList();
        //}

    }
}