using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ShoppingList
{
    public class ShoppingListItem : INotifyPropertyChanged
    {
        string _Name = "";
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        string _Notes = "";
        public string Notes
        {
            get => _Notes;
            set => SetProperty(ref _Notes, value);
        }

        public ShoppingListItem() { }
        public ShoppingListItem(ShoppingListItem Item)
        {
            Name = Item.Name;
            Notes = Item.Notes;
        }
        public ShoppingListItem(string Name, string Notes) {
            this.Name = Name;
            this.Notes = Notes;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            var item = obj as ShoppingListItem;

            // We only care about the name. The notes can be identical for more than one item
            if (item != null && item.Name.ToUpper() == Name.ToUpper())
                return true;

            return base.Equals(obj);
        }
    }
}
