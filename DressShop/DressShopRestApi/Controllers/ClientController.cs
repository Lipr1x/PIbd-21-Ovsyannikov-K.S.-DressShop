using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.BusinessLogics;
using AbstractShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DressShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientLogic _logic;
        public ClientController(ClientLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public ClientViewModel Login(string login, string password) => _logic.Read(new ClientBindingModel
        { Email = login, Password = password })?[0];

        [HttpPost]
        public void Register(ClientBindingModel model) => _logic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(ClientBindingModel model) => _logic.CreateOrUpdate(model);
    }
}
