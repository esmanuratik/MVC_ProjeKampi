using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessage_Service
    {
        List<Message> GetListInbox(string p);   //gelen message sınıfına ait dizinimi dahil etmiş oldum.Sessiondan değer çekmek iççin p parametereesi gönderdim.
        List<Message> GetListSendbox(string p);   //gönderilen message sınıfına ait dizinimi dahil etmiş oldum.
        void MessageAdd(Message message);
        //id yi silmek için bulma işleminin metotu (imzası atılacak) yazılacak
        Message GetByID(int id);
        void MessageDelete(Message message);//silme işlemini tanımlamış oldum. 
        void MessageUpdate(Message message);
    }
}
