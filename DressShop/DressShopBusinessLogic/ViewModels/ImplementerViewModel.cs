using AbstractShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractShopBusinessLogic.ViewModels
{
    public class ImplementerViewModel
    {
        [Column(title: "Number", width: 100)]
        public int Id { get; set; }

        [Column(title: "Car", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Name { get; set; }

        [Column(title: "Time to work", width: 100)]
        public int WorkingTime { get; set; }
        [Column(title: "Time to pause", width: 100)]
        public int PauseTime { get; set; }
    }
}
