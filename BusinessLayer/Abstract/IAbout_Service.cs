using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAbout_Service
    {
        List<About> GetList();   //about sınıfına ait dizinimi dahil etmiş oldum.
        void AboutAdd(About about);
        //id yi silmek için bulma işleminin metotu (imzası atılacak) yazılacak
        About GetByID(int id);
        void AboutDelete(About about);//silme işlemini tanımlamış oldum. 
        void AboutUpdate(About about);
    }
}

