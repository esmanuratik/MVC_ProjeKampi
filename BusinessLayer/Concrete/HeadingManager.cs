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
    public class HeadingManager : IHeading_Service
    {
        IHeading_DAL _headingDAL;

        public HeadingManager(IHeading_DAL headingDAL)
        {
            _headingDAL = headingDAL;
        }

        public Heading GetByID(int id)
        {
            return _headingDAL.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
           return _headingDAL.List();
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDAL.Insert(heading);  
        }

        public void HeadingDelete(Heading heading)
        {
            //heading.HeadingStatus = false; silme işleminin burada yapılması doğru değil burada en fazla id çağırılmalı.
            _headingDAL.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
           _headingDAL.Update(heading); 
        }
    }
}
