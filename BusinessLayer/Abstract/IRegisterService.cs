using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRegisterService
    {
        List<Register> GetList();
        Register GetRegister(string username, string password);
        void RegisterAdd(Register register);
        void RegisterDelete(Register register);
        Register GetRegisterById(int id);

    }
}
