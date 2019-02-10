using System;
using System.ComponentModel;

namespace Numerology.Model
{
    public class UniversalNumbers
    {

        private DateTimeOffset _calcDate = Convert.ToDateTime("1/1/" + DateTime.Today.Year);
        private string _universalYearNumber;

        private string _januaryNumber;
        private string _februaryNumber;
        private string _marchNumber;
        private string _aprilNumber;
        private string _mayNumber;
        private string _juneNumber;
        private string _julyNumber;
        private string _augustNumber;
        private string _septemberNumber;
        private string _octoberNumber;
        private string _novemberNumber;
        private string _decemberNumber;

        private int _selectedMonth;
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   
        /// <summary>
        /// Дата расчета
        /// </summary>
        public DateTimeOffset CalcDate
        {
            get
            {
                return _calcDate;
            }
            set
            {
                _calcDate = value;
                OnPropertyChanged("CalcDate");
            }
        }

        public string UniversalYearNumber
        {
            get
            {
                return _universalYearNumber;
            }
            set
            {
                _universalYearNumber = value;
                OnPropertyChanged("UniversalYearNumber");
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      

        public string JanuaryNumber
        {
            get
            {
                return _januaryNumber;
            }
            set
            {
                _januaryNumber = value;
                OnPropertyChanged("JanuaryNumber");
            }
        }
        public string FebruaryNumber
        {
            get
            {
                return _februaryNumber;
            }
            set
            {
                _februaryNumber = value;
                OnPropertyChanged("FebruaryNumber");
            }
        }
        public string MarchNumber
        {
            get
            {
                return _marchNumber;
            }
            set
            {
                _marchNumber = value;
                OnPropertyChanged("MarchNumber");
            }
        }
        public string AprilNumber
        {
            get
            {
                return _aprilNumber;
            }
            set
            {
                _aprilNumber = value;
                OnPropertyChanged("AprilNumber");
            }
        }
        public string MayNumber
        {
            get
            {
                return _mayNumber;
            }
            set
            {
                _mayNumber = value;
                OnPropertyChanged("MayNumber");
            }
        }
        public string JuneNumber
        {
            get
            {
                return _juneNumber;
            }
            set
            {
                _juneNumber = value;
                OnPropertyChanged("JuneNumber");
            }
        }
        public string JulyNumber
        {
            get
            {
                return _julyNumber;
            }
            set
            {
                _julyNumber = value;
                OnPropertyChanged("JulyNumber");
            }
        }
        public string AugustNumber
        {
            get
            {
                return _augustNumber;
            }
            set
            {
                _augustNumber = value;
                OnPropertyChanged("AugustNumber");
            }
        }
        public string SeptemberNumber
        {
            get
            {
                return _septemberNumber;
            }
            set
            {
                _septemberNumber = value;
                OnPropertyChanged("SeptemberNumber");
            }
        }
        public string OctoberNumber
        {
            get
            {
                return _octoberNumber;
            }
            set
            {
                _octoberNumber = value;
                OnPropertyChanged("OctoberNumber");
            }
        }
        public string NovemberNumber
        {
            get
            {
                return _novemberNumber;
            }
            set
            {
                _novemberNumber = value;
                OnPropertyChanged("NovemberNumber");
            }
        }
        public string DecemberNumber
        {
            get
            {
                return _decemberNumber;
            }
            set
            {
                _decemberNumber = value;
                OnPropertyChanged("DecemberNumber");
            }
        }


        public int SelectedMonth
        {
            get
            {
                return _selectedMonth;
            }
            set
            {
                _selectedMonth = value;
                OnPropertyChanged("SelectedMonth");
            }
        }
         
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
