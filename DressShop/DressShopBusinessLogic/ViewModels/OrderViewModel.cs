    using AbstractShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Runtime.Serialization;
using AbstractShopBusinessLogic.Attributes;

namespace AbstractShopBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [Column(title: "Number", width: 100)]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int? ImplementerId { get; set; }

        [DataMember]
        public int DressId { get; set; }

        [DataMember]
        [Column(title: "Client", width: 150)]
        public string ClientFIO { get; set; }

        [DataMember]
        [Column(title: "Implementer", width: 150)]
        public string ImplementerName { get; set; }

        [DataMember]
        [Column(title: "Dress", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string DressName { get; set; }

        [DataMember]
        [Column(title: "Quantity", width: 100)]
        public int Count { get; set; }

        [DataMember]
        [Column(title: "Sum", width: 50)]
        public decimal Sum { get; set; }

        [DataMember]
        [Column(title: "Status", width: 100)]
        public OrderStatus Status { get; set; }

        [DataMember]
        [Column(title: "Creation date", width: 100)]
        public DateTime DateCreate { get; set; }

        [DataMember]
        [Column(title: "Complition date", width: 100)]
        public DateTime? DateImplement { get; set; }
    }
}
