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
    public class tblComplaintsController : Controller
    {
        private Society_Entities db = new Society_Entities();

        // GET: tblComplaints
        public ActionResult Index()
        {
            var tblComplaints = db.tblComplaints.Include(t => t.tblMember).Include(t => t.tblSecretary);
            return View(tblComplaints.ToList());
        }

        // GET: tblComplaints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblComplaint tblComplaint = db.tblComplaints.Find(id);
            if (tblComplaint == null)
            {
                return HttpNotFound();
            }
            return View(tblComplaint);
        }

        // GET: tblComplaints/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.tblMembers, "ID", "Name");
            ViewBag.SecretaryId = new SelectList(db.tblSecretaries, "ID", "Name");
            return View();
        }

        // POST: tblComplaints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MemberId,SecretaryId,Reason,DateOfComplaint,Status")] tblComplaint tblComplaint)
        {
            if (ModelState.IsValid)
            {
                db.tblComplaints.Add(tblComplaint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.tblMembers, "ID", "Name", tblComplaint.MemberId);
            ViewBag.SecretaryId = new SelectList(db.tblSecretaries, "ID", "Name", tblComplaint.SecretaryId);
            return View(tblComplaint);
        }

        // GET: tblComplaints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblComplaint tblComplaint = db.tblComplaints.Find(id);
            if (tblComplaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.tblMembers, "ID", "Name", tblComplaint.MemberId);
            ViewBag.SecretaryId = new SelectList(db.tblSecretaries, "ID", "Name", tblComplaint.SecretaryId);
            return View(tblComplaint);
        }

        // POST: tblComplaints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MemberId,SecretaryId,Reason,DateOfComplaint,Status")] tblComplaint tblComplaint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblComplaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.tblMembers, "ID", "Name", tblComplaint.MemberId);
            ViewBag.SecretaryId = new SelectList(db.tblSecretaries, "ID", "Name", tblComplaint.SecretaryId);
            return View(tblComplaint);
        }

        // GET: tblComplaints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblComplaint tblComplaint = db.tblComplaints.Find(id);
            if (tblComplaint == null)
            {
                return HttpNotFound();
            }
            return View(tblComplaint);
        }

        // POST: tblComplaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblComplaint tblComplaint = db.tblComplaints.Find(id);
            db.tblComplaints.Remove(tblComplaint);
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
