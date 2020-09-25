using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WPFAutomation.ViewModel;

namespace WPFAutomation.Models
{
    [Table("People")]
    public class PersonModel : ViewModelBase
    {
        [Required]
        public int ID
        {
            get { return _ID; }
            set
            {
                if (value != _ID)
                    { 
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }
        [Required]
        [StringLength(30)]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }
        [StringLength(30)]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (value != _dateOfBirth)
                {
                    _dateOfBirth = value;
                    OnPropertyChanged();
                }
            }
        }
        //public int Height { get; set; } // in centimeters [cm]
        //public float Weight { get; set; } //  in kilograms [kg]
        //public Sex Sex { get; set; }
        //public Race Race { get; set; }
        //public Nationality Nationality { get; set; }
        //public Profession Profession { get; set; }
        // public List<Belonging> ThingsOwned { get; set; }
        // public List<Language> LanguagesSpoken { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////
        static int uniqueID = 1;
        public PersonModel()
        {
            ID = GetUniqueID();
            FirstName = "Test";
            LastName = "Name";
            DateOfBirth = GetRandomBirthDate();
        //    Height = 170;
        //    Weight = 70;
        //    Sex = Sex.Male;
        //    Race = Race.White;
        //    Nationality = Nationality.American;
        //    Profession = Profession.Astronaut;
        }

        public int GetUniqueID()
        {
            return uniqueID++;
        }

        public DateTime GetRandomBirthDate()
        {
            //maybe create minDateValue instead of random? - MD
            DateTime start = new DateTime(1970, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_gen.Next(range));
        }

        //imho all declared variables should be on the top of the class - MD
        private Random _gen = new Random();

        private int _ID;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;

    }
}
