using DataAccesLayer.Abstract;
using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEatsService
    {
        List<Eats> GetList();
        List<Eats> GetListByid(int id);
        List<Eats> GetListBystring(string p);
        void EatsAdd(Eats eats);
        void EatsUpdate(Eats eats);
        void EatsDelete(Eats eats);
        Eats GetEatsById(int id);

    }
}
