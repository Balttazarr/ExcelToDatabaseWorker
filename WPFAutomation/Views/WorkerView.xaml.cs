using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
            InitializeComponent();
            //EditableDataGrid.ItemsSource = viewModelModel.GetPersonModels();

            //viewModelModel = new WorkerViewModel();
            //DataContext = viewModelModel;
            ///var loadedExcel = new WorkerViewModel();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            //EditableDataGrid.ItemsSource = viewModelModel.ListOfPeople;
            //EditableDataGrid.ItemsSource = viewModelModel.GetPersonModels();
        }
        //Dodaje jedną osobę do DataGrid
        private void AddPersonButton(object sender, RoutedEventArgs e)
        {
            FrameworkElement addPerson = sender as FrameworkElement;
            ((WorkerViewModel)addPerson.DataContext).PersonList.Add(new PersonModel());

        }
        //Usuwa jedną osobę z DataGrid
        private void DeletePersonButton(object sender, RoutedEventArgs e)
        {
            FrameworkElement removePerson = sender as FrameworkElement;

            //you try to remove something from empty model list - MD
            ((WorkerViewModel)removePerson.DataContext).PersonList.Remove(loadedExcel.SelectedPersonModel);
        }

        private void SaveExcelButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            //loadedExcel.LoadPersonModel();
 
        }

        private void ReadExcelButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement executeButton = sender as FrameworkElement;
            ((WorkerViewModel)executeButton.DataContext).ReadExcelFile();

        }

        private void UpdateDatabaseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditableDataGrid_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
