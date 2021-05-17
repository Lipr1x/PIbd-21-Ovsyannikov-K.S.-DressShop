using AbstractShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractShopBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        public string DressName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
    }
}
