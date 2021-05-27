using System;
using AbstractShopBusinessLogic.BindingModels;
using System.Collections.Generic;
using AbstractShopBusinessLogic.ViewModels;
using System.Diagnostics;
using AbstractShopBusinessLogic.Enums;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DressShowClientApp.Models;

namespace DressShowClientApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={Program.Client.Id}"));
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(Program.Client);
        }

        [HttpPost]
        public void Privacy(string login, string password, string fio)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(fio))
            {
                //прописать запрос
                APIClient.PostRequest("api/client/updatedata", new ClientBindingModel
                {
                    Id = Program.Client.Id,
                    ClientFIO = fio,
                    Email = login,
                    Password = password
                });
                Program.Client.ClientFIO = fio;
                Program.Client.Email = login;
                Program.Client.Password = password;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Enter login, password and full name");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string login, string password)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                Program.Client = APIClient.GetRequest<ClientViewModel>($"api/client/login?login={login}&password={password}");
                if (Program.Client == null)
                {
                    throw new Exception("Invalid username / password");
                }
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Enter login, password");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public void Register(string login, string password, string fio)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(fio))
            {
                APIClient.PostRequest("api/client/register", new ClientBindingModel
                {
                    ClientFIO = fio,
                    Email = login,
                    Password = password
                });
                Response.Redirect("Enter");
                return;
            }
            throw new Exception("Enter login, password and full name");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Dresses = APIClient.GetRequest<List<DressViewModel>>("api/main/getdresslist");
            return View();
        }

        [HttpPost]
        public void Create(int dress, int count, decimal sum)
        {
            if (count == 0 || sum == 0)
            {
                return;
            }
            var str = Program.Client.Id;
            //прописать запрос
            APIClient.PostRequest("api/main/createorder", new CreateOrderBindingModel
            {
                DressId = dress,
                ClientId = Program.Client.Id.Value,
                Sum = sum,
                Count = count
            });
            Response.Redirect("Index");
        }

        [HttpPost]
        public decimal Calc(decimal count, int dress)
        {
            DressViewModel prod = APIClient.GetRequest<DressViewModel>($"api/main/getdress?dressId={dress}");
            return count * prod.Price;
        }
    }
}