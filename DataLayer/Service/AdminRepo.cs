using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Service
{
    public class AdminRepo : IService.IMentor
    {
        Society_Entities db = new Society_Entities();

        public bool Delete(int id)
        {
            var obj = db.tblAdmins.Find(id);

            if (obj != null)
            {
                db.tblAdmins.Remove(obj);
                db.SaveChanges();

                return true;
            }

            return false;
        }

        public List<tblAdmin> GetAll()
        {
            return db.tblAdmins.ToList();
        }

        public tblAdmin GetById(int id)
        {
            var obj = db.tblAdmins.Find(id);

            if (obj != null)
            {
                return obj;
            }

            return null;
        }

        public bool Save(tblAdmin obj)
        {
            try
            {
                db.tblAdmins.Attach(obj);
                db.Entry(obj).State = obj.ID == 0 ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
