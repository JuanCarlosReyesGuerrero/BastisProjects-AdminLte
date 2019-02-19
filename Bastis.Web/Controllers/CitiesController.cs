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
    public class CitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        Autentication userAutentication = new Autentication();

        // GET: Cities
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Cities));

                if (PermissionUser[0].ViewMenu)
                {

                    var cities = db.Cities.Include(c => c.State);
                    return View(cities.ToList());
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

        // GET: Cities/Details/5
        public ActionResult Details(long? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Cities));

                if (PermissionUser[0].ReadOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    City city = db.Cities.Find(id);
                    if (city == null)
                    {
                        return HttpNotFound();
                    }
                    return View(city);
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

        // GET: Cities/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Cities));

                if (PermissionUser[0].CreateOption)
                {
                    ViewBag.StateID = new SelectList(db.States, "StateID", "Code");
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

        // POST: Cities/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityID,Code,Name,UnifiedCode,StateID,StateCode,Status,UserRegisters,DateRegister,UserModifies,DateModified")] City city)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Cities));

                if (PermissionUser[0].CreateOption)
                {
                    if (ModelState.IsValid)
                    {
                        db.Cities.Add(city);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    ViewBag.StateID = new SelectList(db.States, "StateID", "Code", city.StateID);
                    return View(city);
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

        // GET: Cities/Edit/5
        public ActionResult Edit(long? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Cities));

                if (PermissionUser[0].UpdateOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    City city = db.Cities.Find(id);
                    if (city == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.StateID = new SelectList(db.States, "StateID", "Code", city.StateID);
                    return View(city);
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

        // POST: Cities/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityID,Code,Name,UnifiedCode,StateID,StateCode,Status,UserRegisters,DateRegister,UserModifies,DateModified")] City city)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Cities));

                if (PermissionUser[0].UpdateOption)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(city).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    ViewBag.StateID = new SelectList(db.States, "StateID", "Code", city.StateID);
                    return View(city);
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

        // GET: Cities/Delete/5
        public ActionResult Delete(long? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Cities));

                if (PermissionUser[0].DeleteOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    City city = db.Cities.Find(id);
                    if (city == null)
                    {
                        return HttpNotFound();
                    }
                    return View(city);
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

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Cities));

                if (PermissionUser[0].DeleteOption)
                {
                    City city = db.Cities.Find(id);
                    db.Cities.Remove(city);
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
