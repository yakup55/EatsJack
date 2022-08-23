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
    public class ServiceManager:IServiceService
    {
        IServiceDal serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            this.serviceDal = serviceDal;
        }

        public List<Service> GetList()
        {
            return serviceDal.List();
        }

        public Service GetServiceById(int id)
        {
            return serviceDal.Get(x=>x.ServiceId==id);
        }

        public void ServiceAdd(Service service)
        {
            serviceDal.Add(service);
        }

        public void ServiceDelete(Service service)
        {
            serviceDal.Delete(service);
        }

        public void ServiceUpdate(Service service)
        {
            serviceDal.Update(service);
        }
    }
}
