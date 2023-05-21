using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContact_Service
    {
        IContact_DAL _contactDal;

        public ContactManager(IContact_DAL contactDal)
        {
            this._contactDal = contactDal;
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);    
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public void ContactyAdd(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public Contact GetByID(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }
    }
}
