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
    public class PropertiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        Autentication userAutentication = new Autentication();

        // GET: Properties
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Properties));

                if (PermissionUser[0].ViewMenu)
                {
                    return View(db.Properties.ToList());
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

        // GET: Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Properties));

                if (PermissionUser[0].ReadOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Property property = db.Properties.Find(id);
                    if (property == null)
                    {
                        return HttpNotFound();
                    }
                    return View(property);
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

        // GET: Properties/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Properties));

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

        // POST: Properties/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PropertyID,Title,Description,TypeID,StatusID,Location,Bedrooms,Bathrooms,Floors,Garages,Area,Size,SaleRentPrice,BeforePriceLabel,AfterPriceLabel,VideoURL,PropertyFeatures,PropertyGallery,Address,CountryID,CityID,StateID,ZipPostalCode,Neighborhood,PropertyIdentification,DepartamentID,UserRegisters,DateRegister,UserModifies,DateModified")] Property property)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Properties));

                if (PermissionUser[0].CreateOption)
                {
                    if (ModelState.IsValid)
                    {
                        db.Properties.Add(property);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(property);
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

        // GET: Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Properties));

                if (PermissionUser[0].UpdateOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Property property = db.Properties.Find(id);
                    if (property == null)
                    {
                        return HttpNotFound();
                    }
                    return View(property);
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

        // POST: Properties/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PropertyID,Title,Description,TypeID,StatusID,Location,Bedrooms,Bathrooms,Floors,Garages,Area,Size,SaleRentPrice,BeforePriceLabel,AfterPriceLabel,VideoURL,PropertyFeatures,PropertyGallery,Address,CountryID,CityID,StateID,ZipPostalCode,Neighborhood,PropertyIdentification,DepartamentID,UserRegisters,DateRegister,UserModifies,DateModified")] Property property)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Properties));

                if (PermissionUser[0].UpdateOption)
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(property).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(property);
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

        // GET: Properties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Properties));

                if (PermissionUser[0].DeleteOption)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Property property = db.Properties.Find(id);
                    if (property == null)
                    {
                        return HttpNotFound();
                    }
                    return View(property);
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

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var PermissionUser = userAutentication.ListPermissions(User.Identity.GetUserId(), Convert.ToInt32(MenuOptions.Properties));

                if (PermissionUser[0].DeleteOption)
                {
                    Property property = db.Properties.Find(id);
                    db.Properties.Remove(property);
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
