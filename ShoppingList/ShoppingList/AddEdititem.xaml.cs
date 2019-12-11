using ShoppingList.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ShoppingList
{
    /// <summary>
    /// Interaction logic for AddEditItem.xaml
    /// </summary>
    public partial class AddEditItem : Window
    {
        AddEditItemViewModel ViewModel;
        public AddEditItem(ShoppingListItem ItemToEdit = null)
        {
            DataContext = ViewModel = new AddEditItemViewModel(ItemToEdit);

            InitializeComponent();

            Title = ViewModel.Title;
            addButton.Content = ViewModel.AddUpdateButtonText;
        }

        public ShoppingListItem Item
        {
            get
            {
                return new ShoppingListItem
                {
                    Name = ViewModel.ItemName,
                    Notes = ViewModel.ItemNotes
                };
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if(ViewModel.Error != null)
            {
                MessageBox.Show(ViewModel.Error);
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
