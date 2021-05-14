using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.Interfaces;
using AbstractShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressShopListImplement
{
    public class DressStorage : IDressStorage
    {
        private readonly DataListSingleton source;
        public DressStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<DressViewModel> GetFullList()
        {
            List<DressViewModel> result = new List<DressViewModel>();
            foreach (var component in source.Dresses)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<DressViewModel> GetFilteredList(DressBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<DressViewModel> result = new List<DressViewModel>();
            foreach (var dress in source.Dresses)
            {
                if (dress.DressName.Contains(model.DressName))
                {
                    result.Add(CreateModel(dress));
                }
            }
            return result;
        }
        public DressViewModel GetElement(DressBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var dress in source.Dresses)
            {
                if (dress.Id == model.Id || dress.DressName ==
                model.DressName)
                {
                    return CreateModel(dress);
                }
            }
            return null;
        }
        public void Insert(DressBindingModel model)
        {
            Dress tempDress = new Dress
            {
                Id = 1,
                DressComponents = new
            Dictionary<int, int>()
            };
            foreach (var dress in source.Dresses)
            {
                if (dress.Id >= tempDress.Id)
                {
                    tempDress.Id = dress.Id + 1;
                }
            }
            source.Dresses.Add(CreateModel(model, tempDress));
        }
        public void Update(DressBindingModel model)
        {
            Dress tempDress = null;
            foreach (var dress in source.Dresses)
            {
                if (dress.Id == model.Id)
                {
                    tempDress = dress;
                }
            }
            if (tempDress == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempDress);
        }
        public void Delete(DressBindingModel model)
        {
            for (int i = 0; i < source.Dresses.Count; ++i)
            {
                if (source.Dresses[i].Id == model.Id)
                {
                    source.Dresses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Dress CreateModel(DressBindingModel model, Dress dress)
        {
            dress.DressName = model.DressName;
            dress.Price = model.Price;

            foreach (var key in dress.DressComponents.Keys.ToList())
            {
                if (!model.DressComponents.ContainsKey(key))
                {
                    dress.DressComponents.Remove(key);
                }
            }

            foreach (var component in model.DressComponents)
            {
                if (dress.DressComponents.ContainsKey(component.Key))
                {
                    dress.DressComponents[component.Key] =
                    model.DressComponents[component.Key].Item2;
                }
                else
                {
                    dress.DressComponents.Add(component.Key,
                    model.DressComponents[component.Key].Item2);
                }
            }
            return dress;
        }
        private DressViewModel CreateModel(Dress dress)
        {
        Dictionary<int, (string, int)> dressComponents = new
        Dictionary<int, (string, int)>();
            foreach (var pc in dress.DressComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                dressComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new DressViewModel
            {
                Id = dress.Id,
                DressName = dress.DressName,
                Price = dress.Price,
                DressComponents = dressComponents
            };
        }
    }

}
