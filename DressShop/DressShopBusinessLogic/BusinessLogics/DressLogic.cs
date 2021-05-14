using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.Interfaces;
using AbstractShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractShopBusinessLogic.BusinessLogics
{
    public class DressLogic
    {
        private readonly IDressStorage _dressStorage;
        public DressLogic(IDressStorage dressStorage)
        {
            _dressStorage = dressStorage;
        }

        public List<DressViewModel> Read(DressBindingModel model)
        {
            if (model == null)
            {
                return _dressStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<DressViewModel> { _dressStorage.GetElement(model) };
            }
            return _dressStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(DressBindingModel model)
        {
            var element = _dressStorage.GetElement(new DressBindingModel
            {
                DressName = model.DressName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть подарок с таким названием");
            }
            if (model.Id.HasValue)
            {
                _dressStorage.Update(model);
            }
            else
            {
                _dressStorage.Insert(model);
            }
        }
        public void Delete(DressBindingModel model)

        {
            var element = _dressStorage.GetElement(new DressBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _dressStorage.Delete(model);
        }
    }
}
