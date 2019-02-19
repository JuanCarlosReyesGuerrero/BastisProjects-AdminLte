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
    public class AgenciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        Autentication userAutentication = new Autentication();

        // GET: Agencies
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Agencies));

                if (PermissionUser[0].ViewMenu)
                {

                    return View(db.Agencies.ToList());
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

        // GET: Agencies/Details/5
        public ActionResult Details(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Agencies));

                if (PermissionUser[0].ReadOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Agency agency = db.Agencies.Find(id);
                    if (agency == null)
                    {
                        return HttpNotFound();
                    }
                    return View(agency);
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

        // GET: Agencies/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Agencies));

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

        // POST: Agencies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgencyID,UserRegisters,DateRegister,UserModifies,DateModified")] Agency agency)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Agencies));

                if (PermissionUser[0].CreateOption)
                {
                    if (ModelState.IsValid)
                    {
                        db.Agencies.Add(agency);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(agency);
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

        // GET: Agencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Agencies));

                if (PermissionUser[0].UpdateOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Agency agency = db.Agencies.Find(id);
                    if (agency == null)
                    {
                        return HttpNotFound();
                    }
                    return View(agency);
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

        // POST: Agencies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgencyID,UserRegisters,DateRegister,UserModifies,DateModified")] Agency agency)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Agencies));

                if (PermissionUser[0].UpdateOption)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(agency).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(agency);
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

        // GET: Agencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Agencies));

                if (PermissionUser[0].DeleteOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Agency agency = db.Agencies.Find(id);
                    if (agency == null)
                    {
                        return HttpNotFound();
                    }
                    return View(agency);
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

        // POST: Agencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Agencies));

                if (PermissionUser[0].DeleteOption)
                {
                    Agency agency = db.Agencies.Find(id);
                    db.Agencies.Remove(agency);
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
