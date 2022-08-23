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
    public class ChefsManager:IChefsService
    {
        IChefsDal chefsDal;

        public ChefsManager(IChefsDal chefsDal)
        {
            this.chefsDal = chefsDal;
        }

        public void ChefsAdd(Chefs chefs)
        {
            chefsDal.Add(chefs);
        }

        public void ChefsDelete(Chefs chefs)
        {
            chefsDal.Delete(chefs);
        }

        public void ChefsUpdate(Chefs chefs)
        {
            chefsDal.Update(chefs);
        }

        public Chefs GetChefs(string username, string password)
        {
            return chefsDal.Get(x => x.ChefsMail==username && x.ChefsPassword==password);
        }

        public Chefs GetChefsById(int id)
        {
            return chefsDal.Get(x => x.ChefsId == id);
        }

        public List<Chefs> GetList()
        {
            return chefsDal.List();
        }
    }
}
