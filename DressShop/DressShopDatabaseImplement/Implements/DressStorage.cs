    using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.Interfaces;
using AbstractShopBusinessLogic.ViewModels;
using DressShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DressShopDatabaseImplement.Implements
{
    public class DressStorage : IDressStorage
    {
        public List<DressViewModel> GetFullList()
        {
            using (var context = new DressShopDatabase())
            {
                return context.Dresses
                    .Include(rec => rec.DressComponents)
                    .ThenInclude(rec => rec.Component)
                    .ToList()
                    .Select(rec => new DressViewModel
                    {
                        Id = rec.Id,
                        DressName = rec.DressName,
                        Price = rec.Price,
                        DressComponents = rec.DressComponents
                            .ToDictionary(recDressComponents => recDressComponents.ComponentId,
                            recDressComponents => (recDressComponents.Component?.ComponentName,
                            recDressComponents.Count))
                    })
                    .ToList();
            }
        }
        public List<DressViewModel> GetFilteredList(DressBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new DressShopDatabase())
            {
                return context.Dresses
                    .Include(rec => rec.DressComponents)
                    .ThenInclude(rec => rec.Component)
                    .Where(rec => rec.DressName.Contains(model.DressName))
                    .ToList()
                    .Select(rec => new DressViewModel
                    {
                        Id = rec.Id,
                        DressName = rec.DressName,
                        Price = rec.Price,
                        DressComponents = rec.DressComponents
                            .ToDictionary(recDressComponents => recDressComponents.ComponentId,
                            recDressComponents => (recDressComponents.Component?.ComponentName,
                            recDressComponents.Count))
                    })
                    .ToList();
            }
        }
        public DressViewModel GetElement(DressBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new DressShopDatabase())
            {
                var dress = context.Dresses
                    .Include(rec => rec.DressComponents)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.DressName == model.DressName ||
                    rec.Id == model.Id);

                return dress != null ?
                    new DressViewModel
                    {
                        Id = dress.Id,
                        DressName = dress.DressName,
                        Price = dress.Price,
                        DressComponents = dress.DressComponents
                            .ToDictionary(recDressComponent => recDressComponent.ComponentId,
                            recDressComponent => (recDressComponent.Component?.ComponentName,
                            recDressComponent.Count))
                    } :
                    null;
            }
        }
        public void Insert(DressBindingModel model)
        {
            using (var context = new DressShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Dress(), context);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(DressBindingModel model)
        {
            using (var context = new DressShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var dress = context.Dresses.FirstOrDefault(rec => rec.Id == model.Id);

                        if (dress == null)
                        {
                            throw new Exception("Подарок не найден");
                        }

                        CreateModel(model, dress, context);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(DressBindingModel model)
        {
            using (var context = new DressShopDatabase())
            {
                var Component = context.Dresses.FirstOrDefault(rec => rec.Id == model.Id);

                if (Component == null)
                {
                    throw new Exception("Материал не найден");
                }

                context.Dresses.Remove(Component);
                context.SaveChanges();
            }
        }
        private Dress CreateModel(DressBindingModel model, Dress dress, DressShopDatabase context)
        {
            dress.DressName = model.DressName;
            dress.Price = model.Price;
            if (dress.Id == 0)
            {
                context.Dresses.Add(dress);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var dressComponent = context.DressComponents
                    .Where(rec => rec.DressId == model.Id.Value)
                    .ToList();

                context.DressComponents.RemoveRange(dressComponent
                    .Where(rec => !model.DressComponents.ContainsKey(rec.DressId))
                    .ToList());
                context.SaveChanges();

                foreach (var updateComponent in dressComponent)
                {
                    updateComponent.Count = model.DressComponents[updateComponent.ComponentId].Item2;
                    model.DressComponents.Remove(updateComponent.DressId);
                }
                context.SaveChanges();
            }
            foreach (var dressComponent in model.DressComponents)
            {
                context.DressComponents.Add(new DressComponent
                {
                    DressId = dress.Id,
                    ComponentId = dressComponent.Key,
                    Count = dressComponent.Value.Item2
                });
                context.SaveChanges();
            }
            return dress;
        }
    }
}