using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContent_Service
    {
        List<Content> GetList();   //content sınıfına ait dizinimi dahil etmiş oldum.

        List<Content> GetListByHeadingID(int id);//GetByListID ise Id ye göre bütün listeyi döndürür.Böylece başlığa hazırlamış olurum yapıyı
        void ContentAdd(Content content);
        //id yi silmek için bulma işleminin metotu (imzası atılacak) yazılacak
        Category GetByID(int id);//GetByID tek bir değer döndürür 
        void ContentDelete(Content content);//silme işlemini tanımlamış oldum. FirstorDefault ile tek bir değer döndürecek şekilde yazmıştık
        void ContentUpdate(Content content);
    }
}
