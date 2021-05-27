using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using AbstractShopBusinessLogic.Enums;

namespace AbstractShopBusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int DressId { get; set; }

        [DataMember]
        public int? ClientId { get; set; }

        [DataMember]
        public int? ImplementerId { get; set; }

        [DataMember]
        public string DressName { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }

        [DataMember]
        public OrderStatus Status { get; set; }

        [DataMember]
        public DateTime DateCreate { get; set; }

        [DataMember]
        public DateTime? DateImplement { get; set; }

        [DataMember]
        public DateTime? DateFrom { get; set; }

        [DataMember]
        public DateTime? DateTo { get; set; }

        [DataMember]
        public bool? FreeOrders { get; set; }

    }
}
