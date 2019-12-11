using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
	[TestClass]
	public class MainWindowViewModelTest : ShoppingListTestBase
	{
		[TestMethod]
		public void EditItem_Test()
		{
			// Related to the View - Not required this time around.
			// The functionality to be tested in the AddEditItemViewModelTest
		}

		[TestMethod]
		public void Save_Test()
		{
			// Create, make sure empty and save
			var vm = OpenOrCreateMainWindowViewModel();
			vm.Clear();
			vm.Save();

			vm = OpenOrCreateMainWindowViewModel();

			Assert.IsTrue(vm.Count == 0);

			vm.Add(DummyItem);
			vm.Save();

			// Create vm and ensure it has one item that equals to the item above
			vm = OpenOrCreateMainWindowViewModel();

			Assert.IsTrue(vm.Count == 1);
			Assert.IsTrue(vm[0].Equals(DummyItem));
		}

		[TestMethod]
		public void ToString_Test()
		{
			var vm = EmptyMainWindowViewModel;
			vm.Add(DummyItem);
			Assert.IsTrue(vm.Count == 1);
			Assert.IsTrue(vm.ToString() == "Items:1");
		}
	}
}
