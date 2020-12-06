using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WPFAutomation.ExcelExtensions;
using WPFAutomation.Models;
using System.Configuration;
using System;
using System.Data.SqlClient;
using System.Windows.Data;
using System.Windows.Media;
using WPFAutomation.DataRepository;

namespace WPFAutomation.ViewModel
{

    public class WorkerViewModel : ViewModelBase
    {

        private ObservableCollection<PersonModel> _personList = new ObservableCollection<PersonModel>();
        private string _selectedFileNamePath = "-- no Excel file opened --";
        private PersonModel _selectedPerson;
        private bool _isEnabled_SaveToDatabase;
        private bool _isEnabled_GetoAllFromDatabase;
        private string _dataSourceConnString;
        private string _InitialDirectioryConnString;
        private string _IntegratedSecurityConnString;
        private CheckConnectionState _gridBackground;
        private SolidColorBrush _connectionStringButtonColor;



        private ExcelLoad excelLoad = new ExcelLoad();
        private ExcelSave excelSave = new ExcelSave();


        public string DataSourceConnString
        {
            get
            {
                return _dataSourceConnString;
            }
            set
            {

                if (string.IsNullOrEmpty(value) || value.Length <= 0)
                {
                    MessageBox.Show("Check your DataSource input!");
                }
                if (_dataSourceConnString != value)
                {
                    _dataSourceConnString = value;
                    OnPropertyChanged();
                }
            }
        }
        public string InitialDirectioryConnString
        {
            get
            {
                return _InitialDirectioryConnString;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length <= 0)
                {
                    MessageBox.Show("Check your Initial Directory input!");
                }
                if (_InitialDirectioryConnString != value)
                {
                    _InitialDirectioryConnString = value;
                    OnPropertyChanged();
                }
            }
        }
        public string IntegratedSecurityConnString
        {
            get
            {
                return _IntegratedSecurityConnString;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length <= 0)
                {
                    MessageBox.Show("Check your Integrated Security input!");
                }
                if (_IntegratedSecurityConnString != value)
                {
                    _IntegratedSecurityConnString = value;
                    OnPropertyChanged();
                }
            }
        }


        public enum CheckConnectionState { Success, Failed }

        public CheckConnectionState GridBackground
        {
            get { return _gridBackground; }
            set
            {
                _gridBackground = value;
                OnPropertyChanged();
            }
        }

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
        public RelayCommand SaveToDbCommand { get; private set; }
        public RelayCommand GetAllFromDbCommand { get; private set; }

        public RelayCommand CheckConnectionStringCommand { get; private set; }



        public bool IsEnabled_SaveToDatabase
        {
            get
            {
                return _isEnabled_SaveToDatabase;
            }
            set
            {
                _isEnabled_SaveToDatabase = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled_GetAllFromDatabase
        {
            get
            {
                return _isEnabled_GetoAllFromDatabase;
            }
            set
            {
                _isEnabled_GetoAllFromDatabase = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush ConnectionStringButtonColor
        {
            get { return _connectionStringButtonColor; }
            set
            {
                _connectionStringButtonColor = value;
                OnPropertyChanged();
            }
        }

        public WorkerViewModel()
        {

            AddPersonCommand = new RelayCommand(OnAddingPerson);
            DeletePersonCommand = new RelayCommand(OnDeletePerson, CanDeletePerson);

            SaveExcelCommand = new RelayCommand(OnSaveExcel);
            ReadExcelCommand = new RelayCommand(OnReadExcel);

            SaveToDbCommand = new RelayCommand(OnSaveToDB);
            GetAllFromDbCommand = new RelayCommand(OnGetAllFromDB);

            CheckConnectionStringCommand = new RelayCommand(OnCheckingConnetionString);

            InitializeDefaultConnString();




            //I understand it's just a test, but when we have working solution for this one - test should be only in unit tests - MD
            //PersonList = new ObservableCollection<PersonModel>(new List<PersonModel>() { new PersonModel() { ID = 1234, FirstName = "TestFirstName", LastName = "TestLastName", DateOfBirth = new DateTime(2020, 08, 16) } });
        }

        private void InitializeDefaultConnString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var connStringInOrder = connectionString.Split(';');

            DataSourceConnString = connStringInOrder[0].Remove(0, 12);
            InitialDirectioryConnString = connStringInOrder[1].Remove(0, 16);
            bool integratedSecurity = connStringInOrder[2] == "Integrated Security=True" ? true : false;
            IntegratedSecurityConnString = integratedSecurity.ToString();

        }

        private void OnCheckingConnetionString()
        {
            GetOpenDataConnection(DataSourceConnString, InitialDirectioryConnString, IntegratedSecurityConnString);
        }
        //this method should to DataAccess project like the GetConnection method too
        private void GetOpenDataConnection(string server, string database, string security)
        {
            string builder = BuildConnectionString(server, database, security);

            try
            {
                var successConnect = OpenDatabaseConnection.GetConnection(builder);
                if (successConnect != null && successConnect.State == System.Data.ConnectionState.Open)
                {
                    ConnectionStringButtonColor = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                }
                else
                {
                    ConnectionStringButtonColor = new SolidColorBrush(Color.FromRgb(250, 0, 0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong connection String" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //throw;
            }


        }

        private string BuildConnectionString(string server, string database, string security)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.InitialCatalog = database;
            builder.IntegratedSecurity = bool.Parse(security);
            return builder.ToString();
        }

        private void OnGetAllFromDB()
        {
            if (!PersonList.Count.Equals(0))
            {
                if (MessageBox.Show("All changes will be lost - do you want to proceed?", "Question",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    PersonList.Clear();
                }
                else
                {
                    return;
                }
            }

            //if (conn == null ? IsEnabled_SaveToDatabase = false : IsEnabled_SaveToDatabase = true)

            var repo = new PeopleRepository(BuildConnectionString(DataSourceConnString, InitialDirectioryConnString, IntegratedSecurityConnString));
            if (repo != null ? IsEnabled_SaveToDatabase = true : IsEnabled_SaveToDatabase = true)
            {
                var peopleFromDB = repo.GetAll();
                //TODO!!!
                //var dbContext = new PeopleRepository(conn)
                //var pulledDataFromDb = dbContext.GetAllFromDb(conn);
                foreach (var person in peopleFromDB)
                {
                    PersonList.Add(person);
                };
            }
        }
        private void OnSaveToDB()
        {
            if (!PersonList.Count.Equals(0))
            {
                if (MessageBox.Show("Do you want to save changes in Datagrid?", "Question",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    var conn = OpenDatabaseConnection.GetConnection("ConnectionString");
                    if (conn == null ? IsEnabled_SaveToDatabase = false : IsEnabled_SaveToDatabase = true)
                    {
                        //TODO
                        //var dbContext = new PersonModelDataContext();
                        //dbContext.InsertToDb(conn, PersonList.ToList());
                    }
                }
                else
                {
                    excelSave.SaveToExcel(PersonList.ToList());
                    return;
                }
            }
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
            PersonList.Add(new PersonModel());
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
