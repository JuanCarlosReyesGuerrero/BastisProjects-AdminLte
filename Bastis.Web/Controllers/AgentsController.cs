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

namespace Bastis.Controllers
{
    public class AgentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Agents
        public ActionResult Index()
        {
            var agents = db.Agents.Include(a => a.Agency);
            return View(agents.ToList());
        }

        // GET: Agents/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // GET: Agents/Create
        public ActionResult Create()
        {
            ViewBag.AgencyID = new SelectList(db.Agencies, "AgencyID", "AgencyID");
            return View();
        }

        // POST: Agents/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgentID,FirstName,LastName,Address,EmploymentCharge,Expirience,Email,Phone,Mobile,AboutMe,SocialNetworks,Website,ProfilePicture,AgencyID,UserRegisters,DateRegister,UserModifies,DateModified")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                agent.AgentID = Guid.NewGuid();
                db.Agents.Add(agent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgencyID = new SelectList(db.Agencies, "AgencyID", "AgencyID", agent.AgencyID);
            return View(agent);
        }

        // GET: Agents/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgencyID = new SelectList(db.Agencies, "AgencyID", "AgencyID", agent.AgencyID);
            return View(agent);
        }

        // POST: Agents/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgentID,FirstName,LastName,Address,EmploymentCharge,Expirience,Email,Phone,Mobile,AboutMe,SocialNetworks,Website,ProfilePicture,AgencyID,UserRegisters,DateRegister,UserModifies,DateModified")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgencyID = new SelectList(db.Agencies, "AgencyID", "AgencyID", agent.AgencyID);
            return View(agent);
        }

        // GET: Agents/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Agent agent = db.Agents.Find(id);
            db.Agents.Remove(agent);
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
    }
}
