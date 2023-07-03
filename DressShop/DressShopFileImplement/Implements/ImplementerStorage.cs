using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.Interfaces;
using AbstractShopBusinessLogic.ViewModels;
using DressShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DressShopFileImplement.Implements
{
    class ImplementerStorage : IImplementerStorage
    {
        private readonly FileDataFileSingleton source;

        public ImplementerStorage()
        {
            source = FileDataFileSingleton.GetInstance();
        }

        public List<ImplementerViewModel> GetFullList()
        {
            return source.Implementers
            .Select(CreateModel).ToList();
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return source.Implementers
                .Where(rec =>
                rec.Name.Contains(model.Name))
                .Select(CreateModel).ToList();

        }

        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var implementer = source.Implementers
            .FirstOrDefault(rec => rec.Id == model.Id);
            return implementer != null ?
            CreateModel(implementer) : null;

        }

        public void Insert(ImplementerBindingModel model)
        {

            int maxId = source.Implementers.Count > 0 ? source.Clients.Max(rec => rec.Id) : 0;
            var element = new Implementer { Id = maxId + 1 };
            source.Implementers.Add(CreateModel(model, element));

        }

        public void Update(ImplementerBindingModel model)
        {
            var element = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Исполнитель не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(ImplementerBindingModel model)
        {
            Implementer element = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {

                source.Implementers.Remove(element);
            }
            else
            {
                throw new Exception("Исполнитель не найден");
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