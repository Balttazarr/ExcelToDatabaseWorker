using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WPFAutomation.ExcelExtensions;
using WPFAutomation.Models;
using System.Configuration;

namespace WPFAutomation.ViewModel
{

    public class WorkerViewModel : ViewModelBase
    {
        //get rid off innecessary commented code - MD

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

        public PersonModel SelectedPersonModel
        {
            get
            {
                return _selectedPersonModel;
            }
            set
            {
                if (_selectedPersonModel != value)
                {
                    _selectedPersonModel = value;
                    OnPropertyChanged();
                }

            }
        }

        // you dont use it so why is it declared? - MD
        //ExcelSave excelHelperUnitSave = new ExcelSave();

        //make those private - you only use it in here - MD
        private ObservableCollection<PersonModel> _personList = new ObservableCollection<PersonModel>();
        private PersonModel _selectedPersonModel;
        private ExcelLoad excelLoad = new ExcelLoad();
        private ExcelSave excelSave = new ExcelSave();


        private string _selectedFileNamePath;

        public WorkerViewModel()
        {
            //I understand it's just a test, but when we have working solution for this one - test should be only in unit tests - MD
            //PersonList = new ObservableCollection<PersonModel>(new List<PersonModel>() { new PersonModel() { ID = 1234, FirstName = "TestFirstName", LastName = "TestLastName", DateOfBirth = new DateTime(2020, 08, 16) } });
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
