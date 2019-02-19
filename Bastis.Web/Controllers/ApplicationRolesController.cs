using Bastis.Common;
using Bastis.Models;
using Bastis.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using static Bastis.Common.Enums;

namespace Bastis.Controllers
{
    public class ApplicationRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationRoles
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = ListPermissions();

                if (PermissionUser[0].ViewMenu)
                {

                    return View(db.IdentityRoles.ToList());
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            //return View();
        }

        // GET: ApplicationRoles/Details/5
        public ActionResult Details(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = ListPermissions();

                if (PermissionUser[0].ReadOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    ApplicationRole applicationRole = db.IdentityRoles.Find(id);
                    if (applicationRole == null)
                    {
                        return HttpNotFound();
                    }
                    return View(applicationRole);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: ApplicationRoles/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = ListPermissions();

                if (PermissionUser[0].CreateOption)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: ApplicationRoles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] ApplicationRole applicationRole)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = ListPermissions();

                if (PermissionUser[0].CreateOption)
                {
                    if (ModelState.IsValid)
                    {
                        db.Roles.Add(applicationRole);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(applicationRole);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: ApplicationRoles/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = ListPermissions();

                if (PermissionUser[0].UpdateOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    ApplicationRole applicationRole = db.IdentityRoles.Find(id);
                    if (applicationRole == null)
                    {
                        return HttpNotFound();
                    }
                    return View(applicationRole);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: ApplicationRoles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] ApplicationRole applicationRole)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = ListPermissions();

                if (PermissionUser[0].UpdateOption)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(applicationRole).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(applicationRole);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: ApplicationRoles/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = ListPermissions();

                if (PermissionUser[0].DeleteOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    ApplicationRole applicationRole = db.IdentityRoles.Find(id);
                    if (applicationRole == null)
                    {
                        return HttpNotFound();
                    }
                    return View(applicationRole);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: ApplicationRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = ListPermissions();

                if (PermissionUser[0].DeleteOption)
                {
                    ApplicationRole applicationRole = db.IdentityRoles.Find(id);
                    db.Roles.Remove(applicationRole);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public List<Permission> ListPermissions()
        {
            PermissionsController permiso = new PermissionsController();

            var user = User.Identity;
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var s = UserManager.GetRoles(user.GetUserId());
            string vRolId = s[0].ToString();

            var usersPerRoles = permiso.ListPermissions(vRolId, Convert.ToInt32(MenuOptions.States));

            return usersPerRoles;
        }

    }
}
