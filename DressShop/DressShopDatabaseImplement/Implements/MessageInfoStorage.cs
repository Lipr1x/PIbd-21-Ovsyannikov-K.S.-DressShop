﻿using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.Interfaces;
using AbstractShopBusinessLogic.ViewModels;
using DressShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DressShopDatabaseImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        public List<MessageInfoViewModel> GetFullList()
        {
            using (var context = new DressShopDatabase())
            {
                return context.Messages
                .Select(rec => new MessageInfoViewModel
                {
                    MessageId = rec.MessageId,
                    SenderName = rec.SenderName,
                    DateDelivery = rec.DateDelivery,
                    Subject = rec.Subject,
                    Body = rec.Body
                })
                .ToList();
            }
        }
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DressShopDatabase())
            {
                return context.Messages
                .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
                (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date))
                .Select(rec => new MessageInfoViewModel
                {
                    MessageId = rec.MessageId,
                    SenderName = rec.SenderName,
                    DateDelivery = rec.DateDelivery,
                    Subject = rec.Subject,
                    Body = rec.Body
                })
                .ToList();
            }
        }
        public void Insert(MessageInfoBindingModel model)
        {
            using (var context = new DressShopDatabase())
            {
                MessageInfo element = context.Messages.FirstOrDefault(rec => rec.MessageId == model.MessageId);
                if (element != null)
                {
                    throw new Exception("Уже есть письмо с таким идентификатором");
                }
                context.Messages.Add(new MessageInfo
                {
                    MessageId = model.MessageId,
                    ClientId = model.ClientId,
                    SenderName = model.FromMailAddress,
                    DateDelivery = model.DateDelivery,
                    Subject = model.Subject,
                    Body = model.Body
                });
                context.SaveChanges();
            }
        }
    }
}