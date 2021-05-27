using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractShopBusinessLogic.ViewModels
{
    public class ImplementerViewModel
    {
        public int Id { get; set; }
        [DisplayName("ФИО исполнителя")]
        public string Name { get; set; }
        [DisplayName("Время на заказ")]
        public int WorkingTime { get; set; }
        [DisplayName("Время на перерыв")]
        public int PauseTime { get; set; }
    }
}
