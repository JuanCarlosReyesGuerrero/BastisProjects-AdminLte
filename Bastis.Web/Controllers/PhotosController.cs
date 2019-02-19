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
    public class PhotosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        Autentication userAutentication = new Autentication();

        // GET: Photos
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Photos));

                if (PermissionUser[0].ViewMenu)
                {
                    return View(db.Photos.ToList());
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

        // GET: Photos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Photos));

                if (PermissionUser[0].ReadOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Photo photo = db.Photos.Find(id);
                    if (photo == null)
                    {
                        return HttpNotFound();
                    }
                    return View(photo);
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

        // GET: Photos/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Photos));

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

        // POST: Photos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhotoID,URLPhoto,UserRegisters,DateRegister,UserModifies,DateModified")] Photo photo)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Photos));

                if (PermissionUser[0].CreateOption)
                {
                    if (ModelState.IsValid)
                    {
                        photo.PhotoID = Guid.NewGuid();
                        db.Photos.Add(photo);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(photo);
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

        // GET: Photos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Photos));

                if (PermissionUser[0].UpdateOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Photo photo = db.Photos.Find(id);
                    if (photo == null)
                    {
                        return HttpNotFound();
                    }
                    return View(photo);
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

        // POST: Photos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhotoID,URLPhoto,UserRegisters,DateRegister,UserModifies,DateModified")] Photo photo)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Photos));

                if (PermissionUser[0].UpdateOption)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(photo).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(photo);
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

        // GET: Photos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Photos));

                if (PermissionUser[0].DeleteOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Photo photo = db.Photos.Find(id);
                    if (photo == null)
                    {
                        return HttpNotFound();
                    }
                    return View(photo);
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

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Photos));

                if (PermissionUser[0].DeleteOption)
                {
                    Photo photo = db.Photos.Find(id);
                    db.Photos.Remove(photo);
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
