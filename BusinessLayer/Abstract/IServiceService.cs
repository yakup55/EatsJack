using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IServiceService
    {
        List<Service> GetList();
        void ServiceAdd(Service service);
        void ServiceUpdate(Service service);
        void ServiceDelete(Service service);
        Service GetServiceById(int id);
    }

}
