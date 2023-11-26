using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace SocietyERP.Controllers
{
    public class tblSecretariesController : Controller
    {
        private Society_Entities db = new Society_Entities();

        // GET: tblSecretaries
        public ActionResult Index()
        {
            var tblSecretaries = db.tblSecretaries.Include(t => t.tblSocietyMaster);
            return View(tblSecretaries.ToList());
        }

        // GET: tblSecretaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSecretary tblSecretary = db.tblSecretaries.Find(id);
            if (tblSecretary == null)
            {
                return HttpNotFound();
            }
            return View(tblSecretary);
        }

        // GET: tblSecretaries/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.tblSocietyMasters, "ID", "Name");
            return View();
        }

        // POST: tblSecretaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MobileNo,Email,Address,LoginName,Password,CreatedBy")] tblSecretary tblSecretary)
        {
            if (ModelState.IsValid)
            {
                db.tblSecretaries.Add(tblSecretary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.tblSocietyMasters, "ID", "Name", tblSecretary.CreatedBy);
            return View(tblSecretary);
        }

        // GET: tblSecretaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSecretary tblSecretary = db.tblSecretaries.Find(id);
            if (tblSecretary == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.tblSocietyMasters, "ID", "Name", tblSecretary.CreatedBy);
            return View(tblSecretary);
        }

        // POST: tblSecretaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,MobileNo,Email,Address,LoginName,Password,CreatedBy")] tblSecretary tblSecretary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSecretary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.tblSocietyMasters, "ID", "Name", tblSecretary.CreatedBy);
            return View(tblSecretary);
        }

        // GET: tblSecretaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSecretary tblSecretary = db.tblSecretaries.Find(id);
            if (tblSecretary == null)
            {
                return HttpNotFound();
            }
            return View(tblSecretary);
        }

        // POST: tblSecretaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSecretary tblSecretary = db.tblSecretaries.Find(id);
            db.tblSecretaries.Remove(tblSecretary);
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
