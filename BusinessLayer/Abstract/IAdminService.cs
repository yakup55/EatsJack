using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        void AdminAdd(Admin admin);
        void AdminUpdate(Admin admin);
        void AdminDelete(Admin admin);
        Admin GetByAdminId(int id);
        Admin GetAdmin(string username,string password);
    }
}
