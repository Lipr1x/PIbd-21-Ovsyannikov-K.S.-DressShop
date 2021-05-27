using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.BusinessLogics;
using AbstractShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DressShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;
        private readonly DressLogic _dress;
        private readonly OrderLogic _main;
        public MainController(OrderLogic order, DressLogic dress, OrderLogic main)
        {
            _order = order;
            _dress = dress;
            _main = main;
        }
        [HttpGet]
        public List<DressViewModel> GetDressList() => _dress.Read(null)?.ToList();

        [HttpGet]
        public DressViewModel GetDress(int dressId) => _dress.Read(new DressBindingModel { Id = dressId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}
