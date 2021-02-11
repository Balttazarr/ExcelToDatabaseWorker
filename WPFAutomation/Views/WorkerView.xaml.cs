using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using WPFAutomation.Models;
using WPFAutomation.ViewModel;

namespace WPFAutomation.Views
{
    /// <summary>
    /// Interaction logic for WorkerView.xaml
    /// </summary>
    public partial class WorkerView
    {

        //public WorkerViewModel viewModelInstance = new WorkerViewModel();
        public WorkerView()
        {
            InitializeComponent();

        }



        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void EditableDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPerson = sender as FrameworkElement;

            ((WorkerViewModel)selectedPerson.DataContext).SelectedPerson = (PersonModel)EditableDataGrid.SelectedItem;

        }
    }
}
