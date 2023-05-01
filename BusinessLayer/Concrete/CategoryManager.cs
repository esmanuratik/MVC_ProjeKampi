using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategory_Service //bu inteface sayesinde listeyi dolduracağım
    {
        //Generic__Repository<Category> repo = new Generic__Repository<Category>();
        //yorum satırına almamın sebebi bu işlemleri artık ICategory_Service e bağlı olarak çalışan ctor ile gerçekleştireceğim.

        // public List<Category> GetAll_BL()
        // {
        //    return repo.List(); 
        // }
        //public void CategoryAdd_BL(Category p)
        //{

        //    repo.Insert(p);

        //    //if (p.CategoryName==""||p.CategoryName.Length<=3||p.CategoryDescription==""||p.CategoryName.Length>=5)
        //    //{
        //    //     //Hata mesajı
        //    //}
        //    //else
        //    //{
        //    //repo.Insert(p);
        //    //}


        //}
        
        ICategory_DAL _categoryDal; //bir field oluşturdum bu field a değer ataması yapmam için ctor oluşturmalıyım.

        public CategoryManager(ICategory_DAL categoryDal) //CategoryManager ctrl. generate constractor fielde atama yapabilmekmiçin ctor oluşturdum.
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)  //validation işlemi
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category); 
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            //sileceğim ıd nin koşulu.id ye eşit olanları sil.
            return _categoryDal.Get(x => x.CategoryID == id); 
        }

        public List<Category> GetList() 
        {
            return _categoryDal.List();
        }
       

        //public void CategoryAddBL(Category p)
        //{
        //    if (p.CategoryName == "" || p.CategoryStatus == false)
        //    {
        //        //hata mesajı
        //    }
        //    else
        //    {
        //        _categoryDal.Insert(p);
        //    }
        //    -----burada yaptığımız bu işlemi validasyon işlemi ile yapıyoruz.(public void CategoyAdd)
        //}

    }
}
