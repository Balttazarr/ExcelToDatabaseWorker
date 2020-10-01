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
        public WorkerViewModel loadedExcel = new WorkerViewModel();

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
    }
}
