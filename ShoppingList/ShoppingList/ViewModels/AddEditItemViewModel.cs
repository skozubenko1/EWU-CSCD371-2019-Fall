using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.ViewModels
{
	public class AddEditItemViewModel
	{
        ShoppingListItem Item = new ShoppingListItem();
        bool UpdateMode;

        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="ItemToEdit">If this parameter is null, this dialog box is used for adding new item</param>
        public AddEditItemViewModel(ShoppingListItem ItemToEdit = null)
        {
            if(ItemToEdit != null)
            {
                Item = ItemToEdit;
                UpdateMode = true;
            }
        }

        public string Title
        {
            get { return UpdateMode ? "Update Item" : "New Item"; }
        }

        public string AddUpdateButtonText
        {
            get { return UpdateMode ? "Update" : "Add"; }
        }
        
        public string ItemName
        {
            get
            {
                return Item.Name;
            }
            set
            {
                Item.Name = value;

                if (UpdateMode)
                    Item.OnPropertyChanged(nameof(Item.Name));
            }
        }
        
        public string ItemNotes
        {
            get
            {
                return Item.Notes;
            }
            set
            {
                Item.Notes = value;

                if (UpdateMode)
                    Item.OnPropertyChanged(nameof(Item.Notes));

            }
        }
        
        public string Error
        {
            get
            {
                if (Item.Name.Length < 5)
                    return "Name must be at least 5 characters";

                return null;
            }
        }
    }
}
