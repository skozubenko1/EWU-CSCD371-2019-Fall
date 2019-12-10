using ShoppingList.Models;
using ShoppingList.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ShoppingList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel ViewModel;

        public MainWindow()
        {
            DataContext = ViewModel = new MainWindowViewModel();

            InitializeComponent();

            grid.ItemsSource = ViewModel;

            grid.CanUserAddRows = false;
            grid.SelectionChanged += Grid_SelectionChanged;
        }

        private void Grid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            buttonRemove.IsEnabled = grid.SelectedItems.Count > 0;
        }

        private void buttonClose(object sender, RoutedEventArgs e)
        {

        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Remove(grid.SelectedItem as ShoppingListItem);
        }

        private void testButton_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModel.Save();
        }
    }
}
