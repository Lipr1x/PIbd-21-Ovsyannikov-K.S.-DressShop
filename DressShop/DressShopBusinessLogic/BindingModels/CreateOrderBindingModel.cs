using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractShopBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int DressId { get; set; }
        public string DressName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
	}
}
