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
    public class RegisterManager:IRegisterService
    {
        IRegisterDal registerDal;

        public RegisterManager(IRegisterDal registerDal)
        {
            this.registerDal = registerDal;
        }

        public List<Register> GetList()
        {
            return registerDal.List();
        }

        public Register GetRegister(string username, string password)
        {
            return registerDal.Get(x => x.RegisterMail == username && x.RegisterPassword == password);
        }

        public Register GetRegisterById(int id)
        {
            return registerDal.Get(x => x.RegisterId == id);
        }

        public void RegisterAdd(Register register)
        {
            registerDal.Add(register);
        }

        public void RegisterDelete(Register register)
        {
            registerDal.Delete(register);
        }
    }
}
