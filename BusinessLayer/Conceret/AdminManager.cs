using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Conceret
{
    public class AdminManager:IAdminService
    {
        IAdminDal AdminDal;

        public AdminManager(IAdminDal adminDal)
        {
            AdminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
           AdminDal.Add(admin);
        }

        public void AdminDelete(Admin admin)
        {
           AdminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            AdminDal.Update(admin);
        }

        public Admin GetAdmin(string username, string password)
        {
            return AdminDal.Get(x => x.AdminName == username && x.AdminPassword == password);
        }

        public Admin GetByAdminId(int id)
        {
            return AdminDal.Get(x => x.AdminİD == id);
        }

        public List<Admin> GetList()
        {
            return AdminDal.List();
        }
    }
}
