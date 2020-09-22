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

        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {

        }
        //Adds one object from EditableDataGrid
        private void AddPersonButton(object sender, RoutedEventArgs e)
        {
            FrameworkElement addPerson = sender as FrameworkElement;
            ((WorkerViewModel)addPerson.DataContext).PersonList.Add(new PersonModel());

        }

        //Deletes one object from EditableDataGrid
        private void DeletePersonButton(object sender, RoutedEventArgs e)
        {
            FrameworkElement removePerson = sender as FrameworkElement;
            var dataContextPerson = ((WorkerViewModel)removePerson.DataContext);

            dataContextPerson.PersonList.Remove(dataContextPerson.SelectedPersonModel);
        }

        //Saves the EditableDataGrid to .xlsx file
        private void SaveExcelButton_Click(object sender, RoutedEventArgs e)
        { 
            FrameworkElement saveButton = sender as FrameworkElement;
            var personList = ((WorkerViewModel)saveButton.DataContext).PersonList;

            if (personList.Count != 0)
            {
                ((WorkerViewModel)saveButton.DataContext).SaveExcelFile(personList);
            }
            else
            {
                if (MessageBox.Show("There are no people added to the grid. Please add at least one person before saving to a spreadsheet", "Saving error",
                MessageBoxButton.OK,
                MessageBoxImage.Error) == MessageBoxResult.OK)
                {
                    return;
                }
            }
        }

        private void ReadExcelButton_Click(object sender, RoutedEventArgs e)
        {

            FrameworkElement executeButton = sender as FrameworkElement;

            var personList = ((WorkerViewModel)executeButton.DataContext).PersonList;

            //example of choice before clearing list
            if (!personList.Count.Equals(0))
            {
                if (MessageBox.Show("Do you want to load new excel file and clear current list?", "Question",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    // Clears list after loading excel and then loads new list from file 
                    personList.Clear();
                    ((WorkerViewModel)executeButton.DataContext).ReadExcelFile();
                    return;
                }
                else return;
            }

            // Clears list after loading excel and then loads new list from file 
            personList.Clear();
            ((WorkerViewModel)executeButton.DataContext).ReadExcelFile();
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

            ((WorkerViewModel)selectedPerson.DataContext).SelectedPersonModel = (PersonModel)EditableDataGrid.SelectedItem;
        }
    }
}
