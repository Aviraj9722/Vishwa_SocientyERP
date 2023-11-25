using DataLayer;
using DataLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IMentorBusiness
    {
        List<tblAdmin> GetAll();

        tblAdmin GetById(int id);

        bool Save(tblAdmin obj);

        bool Delete(int id);
    }

    public class AdminBusiness : IMentorBusiness
    {
        IMentor _m;
        public AdminBusiness(IMentor m)
        {
            _m = m;
        }

        public bool Delete(int id)
        {
            return _m.Delete(id);
        }

        public List<tblAdmin> GetAll()
        {
            return _m.GetAll();
        }

        public tblAdmin GetById(int id)
        {
            return _m.GetById(id);
        }

        public bool Save(tblAdmin obj)
        {
            return _m.Save(obj);
        }
    }
}
