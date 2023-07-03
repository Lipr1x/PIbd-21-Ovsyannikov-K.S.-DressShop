using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractShopBusinessLogic.ViewModels
{
    public class ReportDressComponentViewModel
    {
        public string DressName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}
