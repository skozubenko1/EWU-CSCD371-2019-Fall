using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShoppingList
{
    /// <summary>
    /// Interaction logic for AddEditItem.xaml
    /// </summary>
    public partial class AddEditItem : Window
    {
        public AddEditItem(Window Owner = null)
        {
            InitializeComponent();

            Title = "New Item";
        }

        ShoppingListItem _Item = new ShoppingListItem();
        bool UpdateMode;

        public ShoppingListItem Item
        {
            get { return _Item; }
            set
            {
                // Indicate that we are updating the item.
                UpdateMode = true;
                _Item = value;

                textBoxItemName.Text = Item.Name;
                textBoxNotes.Text = Item.Notes;
                addButton.Content = "Update";
                Title = "Update Item";
            }
        }

        private void textBoxItemName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UpdateMode)
                Item.OnPropertyChanged(nameof(Item.Name));

            Item.Name = textBoxItemName.Text;
        }

        private void textBoxNotes_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UpdateMode)
                Item.OnPropertyChanged(nameof(Item.Notes));

            Item.Notes = textBoxNotes.Text;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (Item.Name.Length < 5)
            {
                MessageBox.Show("Name must be at least 5 characters");
                return;
            }
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
