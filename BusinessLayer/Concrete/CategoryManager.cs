using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
       Generic__Repository<Category> repo = new Generic__Repository<Category>();
         public List<Category> GetAll_BL()
        {
            return repo.List(); 
        }
        public void CategoryAdd_BL(Category p)
        {
            if (p.CategoryName==""||p.CategoryName.Length<=3||p.CategoryDescription==""||p.CategoryName.Length>=5)
            {
                 //Hata mesajı
            }
            else
            {
                repo.Insert(p);
            }


        }
    }
}
