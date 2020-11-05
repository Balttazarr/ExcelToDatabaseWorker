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
        public WorkerViewModel workerViewInstance = new WorkerViewModel();

        //public WorkerViewModel viewModelModel = new WorkerViewModel();
        public WorkerView()
        {

            //OpenDatabaseConnection.GetConnection("ConnectionString");
            InitializeComponent();
            // var dataAccess = new PersonModelDataContext();
            // dataAccess.InsertToDb("456", "ABC", "XYZ", Convert.ToDateTime("05-06-2010"));

        }

       

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void UpdateDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void EditableDataGrid_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void EditableDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPerson = sender as FrameworkElement;

            ((WorkerViewModel)selectedPerson.DataContext).SelectedPerson = (PersonModel)EditableDataGrid.SelectedItem;
        }

        private void SaveToDatabaseButton_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            WorkerViewModel theViewModel = (WorkerViewModel)FindResource("WorkerViewModel");
            theViewModel.IsEnabled_SaveToDatabase = !theViewModel.IsEnabled_SaveToDatabase;
        }

        private void GetFromDatabaseButton_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            WorkerViewModel theViewModel = (WorkerViewModel)FindResource("WorkerViewModel");
            theViewModel.IsEnabled_GetAllFromDatabase = !theViewModel.IsEnabled_GetAllFromDatabase;
        }

        private void DataSourceText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
