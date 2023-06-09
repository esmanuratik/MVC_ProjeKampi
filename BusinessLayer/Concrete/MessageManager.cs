﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessage_Service
    {
        IMessage_DAL _messageDal; //bir field oluşturdum bu field a değer ataması yapmam için ctor oluşturmalıyım.

        public MessageManager(IMessage_DAL messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        //public List<Message> GetList()//burada getlist dediğimizde bütün mesajlar geliyor bunun için getlistInbox ve GetlistSendBox olarak ikiye ayırıyorum.
        //{
        //    return _messageDal.List(x=>x.ReceiverMail=="admin@gmail.com");
        //    //mesaj iletilme kısmında mesajı alabilmek için receivermaile ihtiyacım var yani alıcı mail.Fakat bu sağlıklı bir yöntem değil.Sadece ilgili değerin çalışıp çalışmadığı kontrol edilicecek
        //}

        public List<Message> GetListInbox(string p)
        {
            //return _messageDal.List(x => x.ReceiverMail == "aliyildiz@gmail.com");//alıcı 
            //mesaj iletilme kısmında mesajı alabilmek için receivermaile ihtiyacım var yani alıcı mail.Fakat bu sağlıklı bir yöntem değil.Sadece ilgili değerin çalışıp çalışmadığı kontrol edilicecek
            return _messageDal.List(x => x.ReceiverMail == p);
            //mesajları mail değil de artık sessiondan çekmek için bir p parametresi gönderiyorum.Bunu IMesaageService de de yapmalısın.
        }

        public List<Message> GetListSendbox(string p)//gönderen
        {
            //return _messageDal.List(x => x.SenderMail == "aliyildiz@gmail.com");
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message message)//yeni bir mesaj ekleyebilmek için 
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
