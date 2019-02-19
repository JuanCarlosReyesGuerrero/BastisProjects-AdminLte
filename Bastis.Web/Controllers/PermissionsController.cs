using Bastis.Common;
using Bastis.Models;
using Bastis.Models.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using static Bastis.Common.Enums;

namespace Bastis.Controllers
{
    public class PermissionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        Autentication userAutentication = new Autentication();

        // GET: Permissions
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Permissions));

                if (PermissionUser[0].ViewMenu)
                {

                    var permissions = db.Permissions.Include(p => p.ApplicationRole).Include(p => p.Menu);
                    return View(permissions.ToList());
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

        // GET: Permissions/Details/5
        public ActionResult Details(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Permissions));

                if (PermissionUser[0].ReadOption)
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

        // GET: Permissions/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Permissions));

                if (PermissionUser[0].CreateOption)
                {
                    ViewBag.ApplicationRoleId = new SelectList(db.Roles, "Id", "Name");
                    ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "DisplayName");
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

        // POST: Permissions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermissionID,ApplicationRoleId,MenuID,ViewMenu,CreateOption,ReadOption,UpdateOption,DeleteOption")] Permission permission)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Permissions));

                if (PermissionUser[0].CreateOption)
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

        // GET: Permissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Permissions));

                if (PermissionUser[0].UpdateOption)
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

        // POST: Permissions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PermissionID,ApplicationRoleId,MenuID,ViewMenu,CreateOption,ReadOption,UpdateOption,DeleteOption")] Permission permission)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Permissions));

                if (PermissionUser[0].UpdateOption)
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

        // GET: Permissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Permissions));

                if (PermissionUser[0].DeleteOption)
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

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Permissions));

                if (PermissionUser[0].DeleteOption)
                {
                    Permission permission = db.Permissions.Find(id);
                    db.Permissions.Remove(permission);
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
    }
}
