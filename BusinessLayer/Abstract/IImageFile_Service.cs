using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageFile_Service
    {
        List<ImageFile> GetList();   //ımagefile sınıfına ait dizinimi dahil etmiş oldum.listelem işlemi yapıyorum.
   
    }
}
