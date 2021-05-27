using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.HelperModels;
using AbstractShopBusinessLogic.Interfaces;
using AbstractShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractShopBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly IDressStorage _dressStorage;
        private readonly IOrderStorage _orderStorage;
        public ReportLogic(IDressStorage dressStorage, IComponentStorage
       componentStorage, IOrderStorage orderStorage)
        {
            _dressStorage = dressStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
        }
        public List<ReportDressComponentViewModel> GetDressComponent()
        {
            var components = _componentStorage.GetFullList();
            var dresses = _dressStorage.GetFullList();
            var list = new List<ReportDressComponentViewModel>();
            foreach (var dress in dresses)
            {
                var record = new ReportDressComponentViewModel
                {
                    DressName = dress.DressName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in components)
                {
                    if (dress.DressComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(component.ComponentName,
                       dress.DressComponents[component.Id].Item2));
                        record.TotalCount +=
                       dress.DressComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                DressName = x.DressName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }

        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Dresses = _dressStorage.GetFullList()
            });
        }

        public void SaveDressComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Dresses = GetDressComponent()
            });
        }

        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }

    }
}
