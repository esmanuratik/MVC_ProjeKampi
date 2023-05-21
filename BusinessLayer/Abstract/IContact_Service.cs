using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContact_Service
    {
        List<Contact> GetList();   //contact sınıfına ait dizinimi dahil etmiş oldum.
        void ContactyAdd(Contact contact);//mesaj gönderme işlemi
        //id yi silmek için bulma işleminin metotu (imzası atılacak) yazılacak
        Contact GetByID(int id);
        void ContactDelete(Contact contact);//silme işlemini tanımlamış oldum. 
        void ContactUpdate(Contact contact);
    }
}
