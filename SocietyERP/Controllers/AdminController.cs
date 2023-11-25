using BusinessLayer.IService;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc5;

namespace SocietyERP.Controllers
{
    public class AdminController : Controller
    {
        Society_Entities db = new Society_Entities();
        IMentorBusiness _admin;

        public AdminController(IMentorBusiness admin)
        {
            _admin = admin;
        }

        // GET: Admin
        public ActionResult Index(int Id=0)
        {
            ViewBag.AdminList = db.tblAdmins.ToList();
           

            if (Id> 0)
            {
                return View(db.tblAdmins.Find(Id));
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(tblAdmin obj) 
        {
            try
            {
                if (obj != null)
                {
                    db.tblAdmins.Attach(obj);
                    db.Entry(obj).State = obj.ID == 0 ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    ViewBag.msg = "Saved Successfully";
                }
                else
                {
                    ViewBag.msg = "Insertion Failed";
                }

                return RedirectToAction("Index");
            }
            catch (Exception er)
            {
                return View(er.Message);
            }
        }
    }
}