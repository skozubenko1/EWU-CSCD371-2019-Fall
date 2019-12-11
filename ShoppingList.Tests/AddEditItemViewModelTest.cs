using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingList.ViewModels;

namespace ShoppingList.Tests
{
	[TestClass]
	public class AddEditItemViewModelTest 
		: ShoppingListTestBase
	{
		[TestMethod]
		public void Title_Test()
		{
			Assert.IsTrue(new AddEditItemViewModel().Title == "New Item");
			Assert.IsTrue(new AddEditItemViewModel(DummyItem).Title == "Update Item");
		}
		[TestMethod]
		public void AddUpdateButtonText_Test()
		{
			Assert.IsTrue(new AddEditItemViewModel().AddUpdateButtonText == "Add");
			Assert.IsTrue(new AddEditItemViewModel(DummyItem).AddUpdateButtonText == "Update");
		}

		[TestMethod]
		public void ItemName_Test()
		{
			bool isChanged = false;

			var item = DummyItem;
			item.PropertyChanged += (x, e) =>
			{
				if( e.PropertyName == nameof(item.Name) )
					isChanged = true;
			};

			var vm = new AddEditItemViewModel(item);

			Assert.IsTrue(vm.ItemName == item.Name);

			vm.ItemName = "New Item Name";

			Assert.IsTrue(isChanged);
		}
		
		[TestMethod]
		public void ItemNotes_Test()
		{
			bool isChanged = false;

			var item = DummyItem;
			item.PropertyChanged += (x, e) =>
			{
				if( e.PropertyName == nameof(item.Notes) )
					isChanged = true;
			};

			var vm = new AddEditItemViewModel(item);

			Assert.IsTrue(vm.ItemNotes == item.Notes);

			vm.ItemNotes = "New Item Notes";

			Assert.IsTrue(isChanged);
		}

		[TestMethod]
		public void Error_Test()
		{
			// New Items
			var vm = new AddEditItemViewModel();

			// Never null
			Assert.IsTrue(vm.ItemName == "");

			// Error - not enough char in the name
			Assert.IsTrue(vm.Error != null);

			vm.ItemName = "1234";

			// Error - still not enough, needs at least 5
			Assert.IsTrue(vm.Error != null);

			vm.ItemName = "12345";

			// Enough - no error
			Assert.IsTrue(vm.Error == null);
		}

	}
}
