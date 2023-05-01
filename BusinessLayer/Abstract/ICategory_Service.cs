using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    
    public interface ICategory_Service
    {
        List<Category> GetList();   //category sınıfına ait dizinimi dahil etmiş oldum.
        void CategoryAdd(Category category);
        //id yi silmek için bulma işleminin metotu (imzası atılacak) yazılacak
        Category GetByID(int id);
        void CategoryDelete(Category category);//silme işlemini tanımlamış oldum. 
        void CategoryUpdate(Category category);
    }
}
