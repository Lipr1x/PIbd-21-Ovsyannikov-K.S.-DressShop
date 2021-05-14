using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractShopBusinessLogic.ViewModels
{
    public class DressViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string DressName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> DressComponents { get; set; }
    }
}
