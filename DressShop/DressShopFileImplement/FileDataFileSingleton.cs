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
	public class FileDataFileSingleton
	{
		private static FileDataFileSingleton instance;

		private readonly string ComponentFileName = "Component.xml";
		private readonly string OrderFileName = "Order.xml";
		private readonly string DressFileName = "Dress.xml";
		private readonly string ClientFileName = "Client.xml";
		private readonly string ImplementerFileName = "Implementer.xml";
		private readonly string MessageFileName = "Message.xml";
		public List<Component> Components { get; set; }
		public List<Order> Orders { get; set; }
		public List<Dress> Dresses { get; set; }
		public List<Client> Clients { get; set; }
		public List<Implementer> Implementers { get; set; }
		public List<MessageInfo> Messages { get; set; }
		private FileDataFileSingleton()
		{
			Components = LoadComponents();
			Orders = LoadOrders();
			Dresses = LoadDresses();
			Clients = LoadClients();
			Implementers = LoadImplementers();
			Messages = LoadMessages();
		}

		public static FileDataFileSingleton GetInstance()
		{
			if (instance == null)
			{
				instance = new FileDataFileSingleton();
			}
			return instance;
		}

		~FileDataFileSingleton()
		{
			SaveComponents();
			SaveOrders();
			SaveDresses();
			SaveClients();
			SaveImplementers();
			SaveMessages();
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
					Order order = new Order
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						DressId = Convert.ToInt32(elem.Element("DressId").Value),
						Count = Convert.ToInt32(elem.Element("Count").Value),
						Sum = Convert.ToDecimal(elem.Element("Sum").Value),
						Status = status,
						DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value)
					};

					if (!string.IsNullOrEmpty(elem.Element("DateImplement").Value))
					{
						order.DateImplement = Convert.ToDateTime(elem.Element("DateImplement").Value);
					}
					if (!string.IsNullOrEmpty(elem.Element("ImplementerId").Value))
					{
						order.ImplementerId = Convert.ToInt32(elem.Element("ImplementerId").Value);
					}
					list.Add(order);
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
					foreach (var materials in
				   elem.Element("DressComponents").Elements("DressComponents").ToList())
					{
						dressComponents.Add(Convert.ToInt32(materials.Element("Key").Value),
					   Convert.ToInt32(materials.Element("Value").Value));
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
		private List<Implementer> LoadImplementers()
		{
			var list = new List<Implementer>();
			if (File.Exists(ImplementerFileName))
			{
				XDocument xDocument = XDocument.Load(ImplementerFileName);
				var xElements = xDocument.Root.Elements("Implementers").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new Implementer
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						Name = elem.Element("Name").Value,
						WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
						PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value)
					});
				}
			}
			return list;
		}

		private List<MessageInfo> LoadMessages()
		{
			var list = new List<MessageInfo>();
			if (File.Exists(MessageFileName))
			{
				XDocument xDocument = XDocument.Load(MessageFileName);
				var xElements = xDocument.Root.Elements("Message").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new MessageInfo
					{
						MessageId = elem.Attribute("MessageId").Value,
						ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
						SenderName = elem.Element("SenderName").Value,
						DateDelivery = Convert.ToDateTime(elem.Element("DateDelivery")?.Value),
						Subject = elem.Element("Subject").Value,
						Body = elem.Element("Body").Value,
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
				foreach (var material in Components)
				{
					xElement.Add(new XElement("Component",
					new XAttribute("Id", material.Id),
					new XElement("ComponentName", material.ComponentName)));
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
					var materialElement = new XElement("DressComponents");
					foreach (var material in dress.DressComponents)
					{
						materialElement.Add(new XElement("DressComponent",
						new XElement("Key", material.Key),
						new XElement("Value", material.Value)));
					}
					xElement.Add(new XElement("Dress",
					 new XAttribute("Id", dress.Id),
					 new XElement("DressName", dress.DressName),
					 new XElement("Price", dress.Price),
					 materialElement));
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

		private void SaveImplementers()
		{
			if (Implementers != null)
			{
				var xElement = new XElement("Implementers");
				foreach (var client in Implementers)
				{
					xElement.Add(new XElement("Implementer",
					new XAttribute("Id", client.Id),
					new XElement("Name", client.Name),
					new XElement("WorkingTime", client.WorkingTime),
					new XElement("PauseTime", client.PauseTime)));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(ImplementerFileName);
			}
		}

		private void SaveMessages()
		{
			if (Messages != null)
			{
				var xElement = new XElement("Messages");
				foreach (var message in Messages)
				{
					xElement.Add(new XElement("Message",
					new XAttribute("MessageId", message.MessageId),
					new XElement("ClientId", message.ClientId),
					new XElement("SenderName", message.SenderName),
					new XElement("DateDelivery", message.DateDelivery),
					new XElement("Subject", message.Subject),
					new XElement("Body", message.Body)
					));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(MessageFileName);
			}
		}
	}
}