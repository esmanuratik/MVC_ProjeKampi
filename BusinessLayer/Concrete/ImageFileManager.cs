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
    public class ImageFileManager : IImageFile_Service
    {
        IImageFile_DAL _ımageFile_DAL;

        public ImageFileManager(IImageFile_DAL ımageFile_DAL)
        {
            _ımageFile_DAL = ımageFile_DAL;
        }

        public List<ImageFile> GetList()
        {
            return _ımageFile_DAL.List();
        }
    }
}
