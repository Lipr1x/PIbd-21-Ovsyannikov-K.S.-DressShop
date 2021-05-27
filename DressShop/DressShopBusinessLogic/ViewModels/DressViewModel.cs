using AbstractShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractShopBusinessLogic.ViewModels
{
    [DataContract]
    public class DressViewModel
    {
        [Column(title: "Number", width: 100)]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Column(title: "Dress name", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string DressName { get; set; }

        [DataMember]
        [Column(title: "Price", width: 100)]
        public decimal Price { get; set; }

        [DataMember]
        [Column(visible: false)]
        public Dictionary<int, (string, int)> DressComponents { get; set; }
    }
}
