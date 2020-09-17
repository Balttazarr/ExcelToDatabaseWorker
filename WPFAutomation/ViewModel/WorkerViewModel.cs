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

namespace WPFAutomation.ViewModel
{

    public class WorkerViewModel : ViewModelBase
    {
        ExcelSave excelHelperUnitSave = new ExcelSave();
        ExcelLoad excelLoad = new ExcelLoad();


        //private List<PersonModel> _listOfPeople = new List<PersonModel>();
        //public List<PersonModel> ListOfPeople
        //{
        //    get => _listOfPeople;
        //    set
        //    {
        //        _listOfPeople = new List<PersonModel>(value);
        //        OnPropertyChanged();
        //    }
        //}

        private string _selectedFileNamePath;
        public string SelectedFileNamePath
        {
            get
            { return _selectedFileNamePath; }
            set
            {
                _selectedFileNamePath = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PersonModel> _personList = new ObservableCollection<PersonModel>();

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

        PersonModel _selectedPersonModel;
        public PersonModel SelectedPersonModel
        {
            get
            { return _selectedPersonModel; }
            set
            {
                if (_selectedPersonModel != value )
                {
                    _selectedPersonModel = value;
                    OnPropertyChanged();
                }

            }
        }


        public WorkerViewModel()
        {
            PersonList = new ObservableCollection<PersonModel>(new List<PersonModel>() { new PersonModel() { ID = 1234, FirstName = "TestFirstName", LastName = "TestLastName", DateOfBirth = new DateTime(2020, 08, 16) } });
        }





        public void ReadExcelFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\CzarnyPotwor\Desktop",
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FilterIndex = 0,
                RestoreDirectory = true
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





        public void LoadPersonModel()
        {

            //ListOfPeople.Add(new PersonModel { });

            //excelHelperUnitSave.SaveToExcel(peopleList);
        }


    }
}
