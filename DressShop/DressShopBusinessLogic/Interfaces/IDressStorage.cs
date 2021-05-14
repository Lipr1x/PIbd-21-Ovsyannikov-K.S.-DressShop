using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractShopBusinessLogic.Interfaces
{
    public interface IDressStorage
    {
        List<DressViewModel> GetFullList();
        List<DressViewModel> GetFilteredList(DressBindingModel model);
        DressViewModel GetElement(DressBindingModel model);
        void Insert(DressBindingModel model);
        void Update(DressBindingModel model);
        void Delete(DressBindingModel model);
    }
}
