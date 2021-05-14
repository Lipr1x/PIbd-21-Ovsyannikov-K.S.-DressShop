using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.Interfaces;
using AbstractShopBusinessLogic.ViewModels;
using DressShopListImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DressShopFileImplement.Implements
{
	public class DressStorage : IDressStorage
	{
		private readonly FileDataListSingleton source;

		public DressStorage()
		{
			source = FileDataListSingleton.GetInstance();
		}

		public List<DressViewModel> GetFullList()
		{
			return source.Dresses
			.Select(CreateModel)
			.ToList();
		}

		public List<DressViewModel> GetFilteredList(DressBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return source.Dresses
			.Where(rec => rec.DressName.Contains(model.DressName))
			.Select(CreateModel)
			.ToList();
		}

		public DressViewModel GetElement(DressBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			var dress = source.Dresses
			.FirstOrDefault(rec => rec.DressName == model.DressName || rec.Id
		   == model.Id);
			return dress != null ? CreateModel(dress) : null;
		}

		public void Insert(DressBindingModel model)
		{
			int maxId = source.Dresses.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
			var element = new Dress
			{
				Id = maxId + 1,
				DressComponents = new
		   Dictionary<int, int>()
			};
			source.Dresses.Add(CreateModel(model, element));
		}

		public void Update(DressBindingModel model)
		{
			var element = source.Dresses.FirstOrDefault(rec => rec.Id == model.Id);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			CreateModel(model, element);
		}

		public void Delete(DressBindingModel model)
		{
			Dress element = source.Dresses.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				source.Dresses.Remove(element);
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}

		private Dress CreateModel(DressBindingModel model, Dress dress)
		{
			dress.DressName = model.DressName;
			dress.Price = model.Price;
			// удаляем убранные
			foreach (var key in dress.DressComponents.Keys.ToList())
			{
				if (!model.DressComponents.ContainsKey(key))
				{
					dress.DressComponents.Remove(key);
				}
			}
			// обновляем существуюущие и добавляем новые
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
			return new DressViewModel
			{
				Id = dress.Id,
				DressName = dress.DressName,
				Price = dress.Price,
				DressComponents = dress.DressComponents
				 .ToDictionary(recPC => recPC.Key, recPC =>
				 (source.Components.FirstOrDefault(recC => recC.Id ==
				recPC.Key)?.ComponentName, recPC.Value))
			};
		}
	}
}