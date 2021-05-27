using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.Interfaces;
using AbstractShopBusinessLogic.ViewModels;
using DressShopListImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DresseshopListImplement
{
    public class Dressestorage : IDressStorage
	{
 
		private readonly DataListSingleton source;

		public Dressestorage()
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
			foreach (var Dress in source.Dresses)
			{
				if (Dress.DressName.Contains(model.DressName))
				{
					result.Add(CreateModel(Dress));
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
			foreach (var Dress in source.Dresses)
			{
				if (Dress.Id == model.Id || Dress.DressName ==
				model.DressName)
				{
					return CreateModel(Dress);
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
			foreach (var Dress in source.Dresses)
			{
				if (Dress.Id >= tempDress.Id)
				{
					tempDress.Id = Dress.Id + 1;
				}
			}
			source.Dresses.Add(CreateModel(model, tempDress));
		}

		public void Update(DressBindingModel model)
		{
			Dress tempDress = null;
			foreach (var Dress in source.Dresses)
			{
				if (Dress.Id == model.Id)
				{
					tempDress = Dress;
				}
			}
			if (tempDress == null)
			{
				throw new Exception("Element not found");
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
			throw new Exception("Element not found");
		}

		private Dress CreateModel(DressBindingModel model, Dress Dress)
		{
			Dress.DressName = model.DressName;
			Dress.Price = model.Price;
			// удаляем убранные
			foreach (var key in Dress.DressComponents.Keys.ToList())
			{
				if (!model.DressComponents.ContainsKey(key))
				{
					Dress.DressComponents.Remove(key);
				}
			}
			// обновляем существуюущие и добавляем новые
			foreach (var component in model.DressComponents)
			{
				if (Dress.DressComponents.ContainsKey(component.Key))
				{
					Dress.DressComponents[component.Key] =
					model.DressComponents[component.Key].Item2;
				}
				else
				{
					Dress.DressComponents.Add(component.Key,
					model.DressComponents[component.Key].Item2);
				}
			}
			return Dress;
		}

		private DressViewModel CreateModel(Dress Dress)
		{
			// требуется дополнительно получить список компонентов для изделия с
			//названиями и их количество
			Dictionary<int, (string, int)> DressComponents = new
			Dictionary<int, (string, int)>();
			foreach (var pc in Dress.DressComponents)
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
				DressComponents.Add(pc.Key, (componentName, pc.Value));
			}
			return new DressViewModel
			{
				Id = Dress.Id,
				DressName = Dress.DressName,
				Price = Dress.Price,
				DressComponents = DressComponents
			};
		}
	}
}