using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using AbstractShopBusinessLogic.Enums;
using DressShopFileImplement.Models;

namespace DressShopFileImplement
{
	public class FileDataListSingleton
	{
		private static FileDataListSingleton instance;
		private readonly string ComponentFileName = "Component.xml";
		private readonly string OrderFileName = "Order.xml";
		private readonly string DressFileName = "Dress.xml";
		private readonly string ClientFileName = "Client.xml";
		public List<Component> Components { get; set; }
		public List<Order> Orders { get; set; }
		public List<Dress> Dresses { get; set; }
		public List<Client> Clients { get; set; }

		private FileDataListSingleton()
		{
			Components = LoadComponents();
			Orders = LoadOrders();
			Dresses = LoadDresses();
			Clients = LoadClients();
		}

		public static FileDataListSingleton GetInstance()
		{
			if (instance == null)
			{
				instance = new FileDataListSingleton();
			}
			return instance;
		}

		~FileDataListSingleton()
		{
			SaveComponents();
			SaveOrders();
			SaveDresses();
			SaveClients();
		}

		private List<Component> LoadComponents()
		{
			var list = new List<Component>();
			if (File.Exists(ComponentFileName))
			{
				XDocument xDocument = XDocument.Load(ComponentFileName);
				var xElements = xDocument.Root.Elements("Component").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new Component
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						ComponentName = elem.Element("ComponentName").Value
					});
				}
			}
			return list;
		}

		private List<Order> LoadOrders()
		{
			var list = new List<Order>();
			if (File.Exists(OrderFileName))
			{
				XDocument xDocument = XDocument.Load(OrderFileName);
				var xElements = xDocument.Root.Elements("Order").ToList();
				foreach (var elem in xElements)
				{
					OrderStatus status = (OrderStatus)0;
					switch ((elem.Element("Status").Value))
					{
						case "Принят":
							status = (OrderStatus)0;
							break;
						case "Выполняется":
							status = (OrderStatus)1;
							break;
						case "Готов":
							status = (OrderStatus)2;
							break;
						case "Оплачен":
							status = (OrderStatus)3;
							break;

					}
					if (string.IsNullOrEmpty(elem.Element("DateImplement").Value))
					{
						list.Add(new Order
						{
							Id = Convert.ToInt32(elem.Attribute("Id").Value),
							DressId = Convert.ToInt32(elem.Element("DressId").Value),
							DressName = elem.Element("DressName").Value,
							Count = Convert.ToInt32(elem.Element("Count").Value),
							Sum = Convert.ToDecimal(elem.Element("Sum").Value),
							Status = status,
							DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value)
						});
					}
					else
					{
						list.Add(new Order
						{
							Id = Convert.ToInt32(elem.Attribute("Id").Value),
							DressId = Convert.ToInt32(elem.Element("DressId").Value),
							DressName = elem.Element("DressName").Value,
							Count = Convert.ToInt32(elem.Element("Count").Value),
							Sum = Convert.ToDecimal(elem.Element("Sum").Value),
							Status = status,
							DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
							DateImplement = Convert.ToDateTime(elem.Element("DateImplement").Value)
						});
					}

				}
			}
			return list;
		}

		private List<Dress> LoadDresses()
		{
			var list = new List<Dress>();
			if (File.Exists(DressFileName))
			{
				XDocument xDocument = XDocument.Load(DressFileName);
				var xElements = xDocument.Root.Elements("Dress").ToList();
				foreach (var elem in xElements)
				{
					var dressComponents = new Dictionary<int, int>();
					foreach (var components in
				   elem.Element("DressComponents").Elements("DressComponents").ToList())
					{
						dressComponents.Add(Convert.ToInt32(components.Element("Key").Value),
					   Convert.ToInt32(components.Element("Value").Value));
					}
					list.Add(new Dress
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						DressName = elem.Element("DressName").Value,
						Price = Convert.ToDecimal(elem.Element("Price").Value),
						DressComponents = dressComponents
					});
				}
			}
			return list;
		}

		private List<Client> LoadClients()
		{
			var list = new List<Client>();
			if (File.Exists(ClientFileName))
			{
				XDocument xDocument = XDocument.Load(ClientFileName);
				var xElements = xDocument.Root.Elements("Clients").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new Client
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						ClientFIO = elem.Element("ClientFIO").Value,
						Email = elem.Element("Email").Value,
						Password = elem.Element("Password").Value
					});
				}
			}
			return list;
		}

		private void SaveComponents()
		{
			if (Components != null)
			{
				var xElement = new XElement("Components");
				foreach (var component in Components)
				{
					xElement.Add(new XElement("Component",
					new XAttribute("Id", component.Id),
					new XElement("ComponentName", component.ComponentName)));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(ComponentFileName);
			}
		}

		private void SaveOrders()
		{
			if (Orders != null)
			{
				var xElement = new XElement("Orders");
				foreach (var order in Orders)
				{
					xElement.Add(new XElement("Order",
				 new XAttribute("Id", order.Id),
				 new XElement("DressId", order.DressId),
				 new XElement("DressName", order.DressName),
				 new XElement("Count", order.Count),
				 new XElement("Sum", order.Sum),
				 new XElement("Status", order.Status),
				 new XElement("DateCreate", order.DateCreate),
				 new XElement("DateImplement", order.DateImplement)
				 ));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(OrderFileName);
			}
		}

		private void SaveDresses()
		{
			if (Dresses != null)
			{
				var xElement = new XElement("Dresses");
				foreach (var dress in Dresses)
				{
					var componentElement = new XElement("DressComponents");
					foreach (var component in dress.DressComponents)
					{
						componentElement.Add(new XElement("DressComponents",
						new XElement("Key", component.Key),
						new XElement("Value", component.Value)));
					}
					xElement.Add(new XElement("Dress",
					 new XAttribute("Id", dress.Id),
					 new XElement("DressName", dress.DressName),
					 new XElement("Price", dress.Price),
					 componentElement));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(DressFileName);
			}
		}

		private void SaveClients()
		{
			if (Clients != null)
			{
				var xElement = new XElement("Clients");
				foreach (var client in Clients)
				{
					xElement.Add(new XElement("Client",
					new XAttribute("Id", client.Id),
					new XElement("ClientFIO", client.ClientFIO),
					new XElement("Email", client.Email),
					new XElement("Password", client.Password)));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(ClientFileName);
			}
		}
	}
}