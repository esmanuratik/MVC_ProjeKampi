using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IHeading_Service
    {
        List<Heading> GetList();   //Heading sınıfına ait dizinimi dahil etmiş oldum.
        void HeadingAdd(Heading heading);
        //id yi silmek için bulma işleminin metotu (imzası atılacak) yazılacak
        Heading GetByID(int id);
        void HeadingDelete(Heading heading);//silme işlemini tanımlamış oldum. 
        void HeadingUpdate(Heading heading);
    }
}
