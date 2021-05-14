using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractShopBusinessLogic.BusinessLogics;
using AbstractShopBusinessLogic.Interfaces;
using DressShopDatabaseImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace AbstractShopView
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var container = BuildUnityContainer();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(container.Resolve<FormMain>());
		}
		private static IUnityContainer BuildUnityContainer()
		{
			var currentContainer = new UnityContainer();
			currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new
		   HierarchicalLifetimeManager());
			currentContainer.RegisterType<IOrderStorage, OrderStorage>(new
		   HierarchicalLifetimeManager());
			currentContainer.RegisterType<IDressStorage, DressStorage>(new
		   HierarchicalLifetimeManager());
			currentContainer.RegisterType<ComponentLogic>(new
		   HierarchicalLifetimeManager());
			currentContainer.RegisterType<OrderLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<DressLogic>(new
		   HierarchicalLifetimeManager());
			return currentContainer;
		}
	}
}
