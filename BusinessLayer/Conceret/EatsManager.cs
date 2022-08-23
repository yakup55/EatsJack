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
    public class EatsManager : IEatsService
    {
        IEatsDal _eatsDal;

        public EatsManager(IEatsDal eatsDal)
        {
            _eatsDal = eatsDal;
        }

        public void EatsAdd(Eats eats)
        {
            _eatsDal.Add(eats);
        }

        public void EatsDelete(Eats eats)
        {
            _eatsDal.Delete(eats);
        }

        public void EatsUpdate(Eats eats)
        {
            _eatsDal.Update(eats);
        }

        public Eats GetEatsById(int id)
        {
            return _eatsDal.Get(x => x.EatsId == id);
        }

        public List<Eats> GetList()
        {
            return _eatsDal.List();
        }

        public List<Eats> GetListByid(int id)
        {
            return _eatsDal.List(x => x.chefsid == id);
        }

        public List<Eats> GetListBystring(string p)
        {
            return _eatsDal.List(x => x.EatsName.Contains(p) ||x.Chefss.ChefsName.Contains(p)||x.Category.CategoryName.Contains(p));
        }
    }
}
