using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WPFAutomation.ExcelExtensions;
using WPFAutomation.Models;
using System.Configuration;

namespace WPFAutomation.ViewModel
{

    public class WorkerViewModel : ViewModelBase
    {
        private ObservableCollection<PersonModel> _personList = new ObservableCollection<PersonModel>();
        private string _selectedFileNamePath = "-- no Excel file opened --";
        private PersonModel _selectedPerson;
        private ExcelLoad excelLoad = new ExcelLoad();
        private ExcelSave excelSave = new ExcelSave();


        public string SelectedFileNamePath
        {
            get
            {
                return _selectedFileNamePath;
            }
            set
            {
                _selectedFileNamePath = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PersonModel> PersonList
        {
            get
            { return _personList; }
            set
            {
                _personList = value;
                OnPropertyChanged();
            }
        }

        public PersonModel SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                if (_selectedPerson != value)
                {
                    _selectedPerson = value;
                    DeletePersonCommand.RaiseCanExecuteChanged();
                    OnPropertyChanged();
                }

            }
        }

        
        public RelayCommand AddPersonCommand { get; private set; }
        public RelayCommand DeletePersonCommand { get; private set; } // private setter, because it should only be set once inside the ViewModel itself on construction

        public RelayCommand SaveExcelCommand { get; private set; }
        public RelayCommand ReadExcelCommand { get; private set; }

        public WorkerViewModel()
        {
            AddPersonCommand = new RelayCommand(OnAddingPerson);
            DeletePersonCommand = new RelayCommand(OnDeletePerson, CanDeletePerson);
            SaveExcelCommand = new RelayCommand(OnSaveExcel);
            ReadExcelCommand = new RelayCommand(OnReadExcel);

            //I understand it's just a test, but when we have working solution for this one - test should be only in unit tests - MD
            //PersonList = new ObservableCollection<PersonModel>(new List<PersonModel>() { new PersonModel() { ID = 1234, FirstName = "TestFirstName", LastName = "TestLastName", DateOfBirth = new DateTime(2020, 08, 16) } });
        }

        private void OnReadExcel()
        {

            //example of choice before clearing list
            if (!PersonList.Count.Equals(0))
            {
                if (MessageBox.Show("Do you want to load new excel file and clear current list?", "Question",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    // Clears list after loading excel and then loads new list from file 
                    PersonList.Clear();
                    ReadExcelFile();
                    return;
                }
                else return;
            }

            // Clears list after loading excel and then loads new list from file 
            PersonList.Clear();
            ReadExcelFile();
        }



        private void OnSaveExcel()
        {

            if (PersonList.Count != 0)
            {
                SaveExcelFile(PersonList);
            }
            else
            {
                if (MessageBox.Show("There are no people added to the grid. Please add at least one person before saving to a spreadsheet.", "Saving error",
                MessageBoxButton.OK,
                MessageBoxImage.Error) == MessageBoxResult.OK)
                {
                    return;
                }
            }
        }

        private void OnAddingPerson()
        {
            PersonList.Add( new PersonModel());
        }

        private void OnDeletePerson()
        {
            PersonList.Remove(SelectedPerson);
        }

        private bool CanDeletePerson()
        {
            return SelectedPerson != null;
        }

        public void ReadExcelFile()
        {
            //use var if we clearly know what variable type we create - MD
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = ConfigurationManager.AppSettings["InitialDirectory"],
                Filter = ConfigurationManager.AppSettings["Filter"],
                FilterIndex = int.Parse(ConfigurationManager.AppSettings["FilterIndex"]),
                RestoreDirectory = bool.Parse(ConfigurationManager.AppSettings["RestoreDirectory"])
            };

            if (openFileDialog.ShowDialog() == true)
            {
                SelectedFileNamePath = openFileDialog.FileName;
                var fromExcelList = excelLoad.LoadExcelFile(SelectedFileNamePath).ToList();
                
                foreach (var person in fromExcelList)
                {
                    PersonList.Add(person);
                }
            }
        }

        public void SaveExcelFile(ObservableCollection<PersonModel> personModels)
        {

            excelSave.SaveToExcel(personModels.ToList());
        }



    }
}
