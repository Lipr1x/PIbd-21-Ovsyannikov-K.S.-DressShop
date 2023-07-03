using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.ViewModels;
using AbstractShopBusinessLogic.Interfaces;
using DressShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DressShopDatabaseImplement.Implements
{
    public class ImplementerStorage : IImplementerStorage
    {
        public List<ImplementerViewModel> GetFullList()
        {
            using (var context = new DressShopDatabase())
            {
                return context.Implementers
                .Select(CreateModel).ToList();
            }
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DressShopDatabase())
            {
                return context.Implementers
                    .Where(rec =>
                    rec.Name.Contains(model.Name))
                    .Select(CreateModel).ToList();
            }
        }

        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DressShopDatabase())
            {
                var implementer = context.Implementers
                .FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
                return implementer != null ?
                CreateModel(implementer) : null;
            }
        }

        public void Insert(ImplementerBindingModel model)
        {
            using (var context = new DressShopDatabase())
            {
                context.Implementers.Add(CreateModel(model, new Implementer()));
                context.SaveChanges();
            }
        }

        public void Update(ImplementerBindingModel model)
        {
            using (var context = new DressShopDatabase())
            {
                var element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Исполнитель не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            using (var context = new DressShopDatabase())
            {
                Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Implementers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Исполнитель не найден");
                }
            }
        }

        private Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.Name = model.Name;
            implementer.WorkingTime = model.WorkingTime;
            implementer.PauseTime = model.PauseTime;
            return implementer;
        }

        private ImplementerViewModel CreateModel(Implementer implementer)
        {
            return new ImplementerViewModel
            {
                Id = implementer.Id,
                Name = implementer.Name,
                WorkingTime = implementer.WorkingTime,
                PauseTime = implementer.PauseTime
            };
        }
    }
}
