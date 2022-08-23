using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IChefsService
    {
        List<Chefs> GetList();
        void ChefsAdd(Chefs chefs);
        void ChefsUpdate(Chefs chefs);
        void ChefsDelete(Chefs chefs);
        Chefs GetChefsById(int id);
        Chefs GetChefs(string username,string password);
    }
}
