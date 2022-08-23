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
    public class ContactManager:IContactService
    {
        IContactDal contactDal;

        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }

        public void AddContact(Contact contact)
        {
            contactDal.Add(contact);
        }

        public void DeleteContact(Contact contact)
        {
         contactDal.Delete(contact);
        }

        public Contact GetByContactId(int id)
        {
            return contactDal.Get(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return contactDal.List();
        }

        public void UpdateContact(Contact contact)
        {
            contactDal.Update(contact);
        }
    }
}
