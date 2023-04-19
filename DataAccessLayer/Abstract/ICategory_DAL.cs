using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategory_DAL:IRepository<Category>
    {
    }
}
















////CRUD işlemlerini gerçekleştirecek metotları yazıyoruz.
//List<Category> List();  //Raad=listeleme
//void Insert(Category p); //create=ekleme
//void Update(Category p); //update=güncelleme
//void Delete(Category p); //delete=silme
////bunu yapmak dry yani yazılım fazladan karmaşık işlme yapma yazılım ilkesine aykırı onun için bu kullanılmayacak bunun yerine Entity leri çağırarak işlem yapacağız.
