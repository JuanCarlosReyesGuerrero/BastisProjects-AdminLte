using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bastis.Models;
using Bastis.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bastis.Controllers
{
    public class PermissionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Permissions
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (isAdminUser())
                {
                    var permissions = db.Permissions.Include(p => p.ApplicationRole).Include(p => p.Menu);
                    return View(permissions.ToList());
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // GET: Permissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // GET: Permissions/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationRoleId = new SelectList(db.Roles, "Id", "Name");
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "DisplayName");
            return View();
        }

        // POST: Permissions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermissionID,ApplicationRoleId,MenuID,ViewMenu,CreateOption,ReadOption,UpdateOption,DeleteOption")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                db.Permissions.Add(permission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationRoleId = new SelectList(db.Roles, "Id", "Name", permission.ApplicationRoleId);
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "DisplayName", permission.MenuID);
            return View(permission);
        }

        // GET: Permissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationRoleId = new SelectList(db.Roles, "Id", "Name", permission.ApplicationRoleId);
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "DisplayName", permission.MenuID);
            return View(permission);
        }

        // POST: Permissions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PermissionID,ApplicationRoleId,MenuID,ViewMenu,CreateOption,ReadOption,UpdateOption,DeleteOption")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationRoleId = new SelectList(db.Roles, "Id", "Name", permission.ApplicationRoleId);
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "DisplayName", permission.MenuID);
            return View(permission);
        }

        // GET: Permissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Permission permission = db.Permissions.Find(id);
            db.Permissions.Remove(permission);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "AppAdmin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public List<Permission> ListPermissions()
        {

            //var query = _applicationDbContext.Enrollment
            //    .Include(a => a.Course)
            //    .Include(x => x.Student)
            //    .ToList();

            //return query;

            //var permissions = db.Permissions.Include(p => p.ApplicationRole).Include(p => p.Menu);
            var permissions = db.Permissions.ToList();
            return permissions;

        }
    }
}
