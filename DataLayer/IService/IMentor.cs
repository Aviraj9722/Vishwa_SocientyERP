using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IService
{
    public interface IMentor
    {
        List<tblAdmin> GetAll(); 

        tblAdmin GetById(int id);

        bool Save(tblAdmin obj);

        bool Delete(int id);

    }
}
