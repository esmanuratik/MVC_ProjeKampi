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
    public class ContentManager : IContent_Service
    {
        IContent_DAL _contentDal;

        public ContentManager(IContent_DAL contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Category GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList(string p)//burada bir parametreye bağlı olarak listeleme yapmak için gerekli şartı çağırmalıyım.Çünkü öbür türlü bütün listeyi bana çağıracaktır.Burada bütün kisteyi istemiyorum bir parametre listlemek istiyorum.IContent_Service parametreli listeleme metodu yazıyorum .
        {
            return _contentDal.List(x=>x.ContentValue.Contains(p));//p parametresine göre aram işlemini gerçekleştiriytorum.
        }

        public List<Content> GetListByHeadingID(int id)//listelemeyi başlıktaki id ye göre yapmak istiyorum
        {
            //geriye birşey dönüdrmesi gerekiyor
            return _contentDal.List(x=>x.HeadingID==id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterID == id);//id ye göre yazarın işlemlerini session il getşrmek için yazdık
        }
    }
}
