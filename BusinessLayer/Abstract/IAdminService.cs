using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IAdminService
	{
		List<Admin> GetList();   //category sınıfına ait dizinimi dahil etmiş oldum.
		void AdminAdd(Admin admin);
		//id yi silmek için bulma işleminin metotu (imzası atılacak) yazılacak
		Admin GetByID(int id);
		void AdminDelete(Admin admin);//silme işlemini tanımlamış oldum. 
		void AdminUpdate(Admin admin);
	}
}
