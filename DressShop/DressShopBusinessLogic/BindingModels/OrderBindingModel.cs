using System;
using System.Collections.Generic;
using System.Text;
using AbstractShopBusinessLogic.Enums;

namespace AbstractShopBusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int DressId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public string DressName { get; set; }
    }
}
