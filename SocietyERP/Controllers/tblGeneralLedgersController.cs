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
    public class tblGeneralLedgersController : Controller
    {
        private Society_Entities db = new Society_Entities();

        // GET: tblGeneralLedgers
        public ActionResult Index()
        {
            return View(db.tblGeneralLedgers.ToList());
        }

        // GET: tblGeneralLedgers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGeneralLedger tblGeneralLedger = db.tblGeneralLedgers.Find(id);
            if (tblGeneralLedger == null)
            {
                return HttpNotFound();
            }
            return View(tblGeneralLedger);
        }

        // GET: tblGeneralLedgers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblGeneralLedgers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LedgerName")] tblGeneralLedger tblGeneralLedger)
        {
            if (ModelState.IsValid)
            {
                db.tblGeneralLedgers.Add(tblGeneralLedger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblGeneralLedger);
        }

        // GET: tblGeneralLedgers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGeneralLedger tblGeneralLedger = db.tblGeneralLedgers.Find(id);
            if (tblGeneralLedger == null)
            {
                return HttpNotFound();
            }
            return View(tblGeneralLedger);
        }

        // POST: tblGeneralLedgers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LedgerName")] tblGeneralLedger tblGeneralLedger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblGeneralLedger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblGeneralLedger);
        }

        // GET: tblGeneralLedgers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGeneralLedger tblGeneralLedger = db.tblGeneralLedgers.Find(id);
            if (tblGeneralLedger == null)
            {
                return HttpNotFound();
            }
            return View(tblGeneralLedger);
        }

        // POST: tblGeneralLedgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblGeneralLedger tblGeneralLedger = db.tblGeneralLedgers.Find(id);
            db.tblGeneralLedgers.Remove(tblGeneralLedger);
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
