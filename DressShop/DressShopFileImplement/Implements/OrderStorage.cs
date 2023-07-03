using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.Enums;
using AbstractShopBusinessLogic.Interfaces;
using AbstractShopBusinessLogic.ViewModels;
using DressShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DressShopFileImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly FileDataFileSingleton source;

        public OrderStorage()
        {
            source = FileDataFileSingleton.GetInstance();
        }

        public List<OrderViewModel> GetFullList()
        {
            return source.Orders
            .Select(CreateModel)
            .ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Orders.Where(rec => (!model.DateFrom.HasValue &&
               !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
               (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >=
               model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
               (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
               (model.FreeOrders.HasValue && model.FreeOrders.Value && rec.Status == OrderStatus.Принят) ||
               (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && rec.Status == OrderStatus.Выполняется))
               .Select(CreateModel)
               .ToList();
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var Order = source.Orders
            .FirstOrDefault(rec => rec.Id == model.Id);
            return Order != null ? CreateModel(Order) : null;
        }

        public void Insert(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            var element = new Order { Id = maxId + 1 };
            source.Orders.Add(CreateModel(model, element));
        }

        public void Update(OrderBindingModel model)
        {
            var element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Orders.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.DressId = model.DressId;
            order.ClientId = model.ClientId.Value;
            order.ImplementerId = model.ImplementerId.Value;
            order.Count = model.Count;
            order.Status = model.Status;
            order.Sum = model.Sum;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }

        private OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                DressId = order.DressId,
                ClientId = order.ClientId.Value,
                ClientFIO = source.Clients.FirstOrDefault(client => client.Id == order.ClientId)?.ClientFIO,
                DressName = source.Dresses.FirstOrDefault(gift => gift.Id == order.DressId)?.DressName,
                ImplementerId = order.ImplementerId.Value,
                ImplementerName = source.Implementers.FirstOrDefault(implementer => implementer.Id == order.ImplementerId)?.Name,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order?.DateImplement
            };
        }
    }
}