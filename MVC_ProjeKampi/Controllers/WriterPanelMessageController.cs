﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKampi.Controllers
{

    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EF_MessageDAL());
        Message_Validatior messagevalidatior = new Message_Validatior();
     
        public ActionResult Inbox()//gelen mesajlar burada listelenecek.(veriler listelenecek)
        {
            string p = (string)Session["WriterMail"];          
            var messagelist = mm.GetListInbox(p);//sessionla mesaj göndermek için p parametresi gönderdim.

            return View(messagelist); 
        }
        public ActionResult Sendbox()//gönderilen mesajlar burada listelenecek.(veriler listelenecek)
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }
        public ActionResult GetInboxDetails(int id)//id ye göre işlem yapılacağı için dışarıdan id göndr. ve GetByID kull. 
        {//gelen mesajlarda bazı mesajlar görüntülenemediği için bunu buraya yazıyorum
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendBoxDetails(int id)//gönderilen mesajların detaylarını burada inceleyeceğiz.
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidatior.Validate(p);
            string sender = (string)Session["WriterMail"];

            if (results.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        } 
    }
}