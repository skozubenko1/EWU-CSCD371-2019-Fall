using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShoppingList.ViewModels
{
    public class MainWindowViewModel
        : ObservableCollection<ShoppingListItem>
    {
        ShoppingListDB DB;

        public Command AddNewItemCommand { get; }

        public MainWindowViewModel(string FileName = "ShoppingList.xml")
        {
            DB = ShoppingListDB.Load(FileName);

            DB.Items.ForEach(x => Items.Add(x));

            this.CollectionChanged += MainWindowViewModel_CollectionChanged;

            AddNewItemCommand = new Command(AddNewItem);
        }

        private void MainWindowViewModel_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {

            }
        }

        void AddNewItem()
        {
            var dlg = new AddEditItem();

            var isOK = dlg.ShowDialog();

            if (isOK != null)
            {
                if (isOK.Value)
                {
                    // Changed or new item
                    Add(dlg.Item);
                }
            }
        }

        public void Save()
        {
            DB.Items = new List<ShoppingListItem>(this);
            DB.Save();
        }
    }
}
