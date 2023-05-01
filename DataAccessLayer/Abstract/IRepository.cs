using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> //Dışarıdan gelecek olan Entity yi bu şekilde gönderiyorum.T değeri bir type ve bir                                entity karşılayacak.SQL den hangi entyt yi göndermek istesem.
    {
        List<T> List();
        void Insert(T p);
        T Get(Expression<Func<T, bool>>filter);//silme işlemi yapmak için tek bir değer tutacak burada koşullu olarak tutacağı değer ıd olacak
        void Delete(T p);
        void Update(T p);
        List<T> List(Expression<Func<T, bool>> filter);


    }
}
