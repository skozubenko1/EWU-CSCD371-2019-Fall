using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingList.ViewModels;

namespace ShoppingList.Tests
{
	public class ShoppingListTestBase
	{
		public ShoppingListItem DummyItem
		{
			get
			{ 
				return new ShoppingListItem("name", "notes");
			}
		}

		public List<ShoppingListItem> CreateDummyItems(int NumItems = 5)
		{
			var list = new List<ShoppingListItem>();

			for (int i = 0; i < 5; i++)
				list.Add(new ShoppingListItem($"Item_{i}", $"Notes for item {i}"));

			return list;
		}

		public MainWindowViewModel OpenOrCreateMainWindowViewModel(int NumItems = 0)
		{
			var view = new MainWindowViewModel();

			if(NumItems > 0)
			{
				if (view.Count > 0)
					view.Clear();

				CreateDummyItems(5).ForEach(x => view.Add(x));
			}

			return view;
		}

		public MainWindowViewModel EmptyMainWindowViewModel
		{
			get
			{
				var view = new MainWindowViewModel("dummy.xml");
				view.Clear();
				return view;
			}
		}
	}
}
