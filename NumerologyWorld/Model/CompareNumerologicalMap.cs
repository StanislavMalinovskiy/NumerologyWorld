using System.ComponentModel;

namespace Numerology.Model
{
    public class CompareNumerologicalMap
    {
        private int _DayOfBirthFirstPerson;
        private int _DayOfBirthSecondPerson;

        private string _LifePathNumberFirstPerson;
        private string _LifePathNumberSecondPerson;

        private string _SoulNumberFirstPerson;
        private string _SoulNumberSecondPerson;

        private string _IdentityNumberFirstPerson;
        private string _IdentityNumberSecondPerson;

        private string _DestinyNumberFirstPerson;
        private string _DestinyNumberSecondPerson;

        private string _MaturityNumberFirstPerson;
        private string _MaturityNumberSecondPerson;

        private string _CurrentCycleFirstPerson;
        private string _CurrentCycleSecondPerson;

        private string _CurrentPeakFirstPerson;
        private string _CurrentPeakSecondPerson;

        private string _CurrentProblemFirstPerson;
        private string _CurrentProblemSecondPerson;

        private string _OverallFirstPerson;
        private string _OverallSecondPerson;
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private int _DayOfBirthResultPersonal;
        private int _DayOfBirthResultBusiness;

        private int _LifePathNumberResultPersonal;
        private int _LifePathNumberResultBusiness;

        private int _SoulNumberResultPersonal;
        private int _SoulNumberResultBusiness;

        private int _IdentityNumberResultPersonal;
        private int _IdentityNumberResultBusiness;

        private int _DestinyNumberResultPersonal;
        private int _DestinyNumberResultBusiness;

        private int _MaturityNumberResultPersonal;
        private int _MaturityNumberResultBusiness;

        private int _CurrentCycleResultPersonal;
        private int _CurrentCycleResultBusiness;

        private int _CurrentPeakResultPersonal;
        private int _CurrentPeakResultBusiness;

        private int _CurrentProblemResultPersonal;
        private int _CurrentProblemResultBusiness;

        /// <summary>
        /// Число жизненного пути
        /// </summary>
        public string LifePathNumberFirstPerson
        {
            get
            {
                return _LifePathNumberFirstPerson;
            }
            set
            {
                _LifePathNumberFirstPerson = value;
                OnPropertyChanged("LifePathNumberFirstPerson");
            }
        }

        /// <summary>
        /// Число жизненного пути
        /// </summary>
        public string LifePathNumberSecondPerson
        {
            get
            {
                return _LifePathNumberSecondPerson;
            }
            set
            {
                _LifePathNumberSecondPerson = value;
                OnPropertyChanged("LifePathNumberSecondPerson");
            }
        }


        /// <summary>
        /// Число души
        /// </summary>
        public string SoulNumberFirstPerson
        {
            get
            {
                return _SoulNumberFirstPerson;
            }
            set
            {
                _SoulNumberFirstPerson = value;
                OnPropertyChanged("SoulNumberFirstPerson");
            }
        }

        /// <summary>
        /// Число души
        /// </summary>
        public string SoulNumberSecondPerson
        {
            get
            {
                return _SoulNumberSecondPerson;
            }
            set
            {
                _SoulNumberSecondPerson = value;
                OnPropertyChanged("SoulNumberSecondPerson");
            }
        }



        /// <summary>
        /// Число личности
        /// </summary>
        public string IdentityNumberFirstPerson
        {
            get
            {
                return _IdentityNumberFirstPerson;
            }
            set
            {
                _IdentityNumberFirstPerson = value;
                OnPropertyChanged("IdentityNumberFirstPerson");
            }
        }

        /// <summary>
        /// Число личности
        /// </summary>
        public string IdentityNumberSecondPerson
        {
            get
            {
                return _IdentityNumberSecondPerson;
            }
            set
            {
                _IdentityNumberSecondPerson = value;
                OnPropertyChanged("IdentityNumberSecondPerson");
            }
        }


        /// <summary>
        /// Число судьбы
        /// </summary>
        public string DestinyNumberFirstPerson
        {
            get
            {
                return _DestinyNumberFirstPerson;
            }
            set
            {
                _DestinyNumberFirstPerson = value;
                OnPropertyChanged("DestinyNumberFirstPerson");
            }
        }

        /// <summary>
        /// Число судьбы
        /// </summary>
        public string DestinyNumberSecondPerson
        {
            get
            {
                return _DestinyNumberSecondPerson;
            }
            set
            {
                _DestinyNumberSecondPerson = value;
                OnPropertyChanged("DestinyNumberSecondPerson");
            }
        }


        /// <summary>
        /// Число зрелости
        /// </summary>
        public string MaturityNumberFirstPerson
        {
            get
            {
                return _MaturityNumberFirstPerson;
            }
            set
            {
                _MaturityNumberFirstPerson = value;
                OnPropertyChanged("MaturityNumberFirstPerson");
            }
        }

        /// <summary>
        /// Число зрелости
        /// </summary>
        public string MaturityNumberSecondPerson
        {
            get
            {
                return _MaturityNumberSecondPerson;
            }
            set
            {
                _MaturityNumberSecondPerson = value;
                OnPropertyChanged("MaturityNumberSecondPerson");
            }
        }

        /// <summary>
        /// Текущий цикл
        /// </summary>
        public string CurrentCycleFirstPerson
        {
            get
            {
                return _CurrentCycleFirstPerson;
            }
            set
            {
                _CurrentCycleFirstPerson = value;
                OnPropertyChanged("CurrentCycleFirstPerson");
            }
        }

        /// <summary>
        /// Текущий цикл
        /// </summary>
        public string CurrentCycleSecondPerson
        {
            get
            {
                return _CurrentCycleSecondPerson;
            }
            set
            {
                _CurrentCycleSecondPerson = value;
                OnPropertyChanged("CurrentCycleSecondPerson");
            }
        }

        /// <summary>
        /// Текущий пик
        /// </summary>
        public string CurrentPeakFirstPerson
        {
            get
            {
                return _CurrentPeakFirstPerson;
            }
            set
            {
                _CurrentPeakFirstPerson = value;
                OnPropertyChanged("CurrentPeakFirstPerson");
            }
        }

        /// <summary>
        /// Текущий пик
        /// </summary>
        public string CurrentPeakSecondPerson
        {
            get
            {
                return _CurrentPeakSecondPerson;
            }
            set
            {
                _CurrentPeakSecondPerson = value;
                OnPropertyChanged("CurrentPeakSecondPerson");
            }
        }

        /// <summary>
        /// Текущая проблема
        /// </summary>
        public string CurrentProblemFirstPerson
        {
            get
            {
                return _CurrentProblemFirstPerson;
            }
            set
            {
                _CurrentProblemFirstPerson = value;
                OnPropertyChanged("CurrentProblemFirstPerson");
            }
        }

        /// <summary>
        /// Текущая проблема
        /// </summary>
        public string CurrentProblemSecondPerson
        {
            get
            {
                return _CurrentProblemSecondPerson;
            }
            set
            {
                _CurrentProblemSecondPerson = value;
                OnPropertyChanged("CurrentProblemSecondPerson");
            }
        }



        /// <summary>
        /// Дата рождения
        /// </summary>
        public int DayOfBirthFirstPerson
        {
            get
            {
                return _DayOfBirthFirstPerson;
            }
            set
            {
                _DayOfBirthFirstPerson = value;
                OnPropertyChanged("DayOfBirthFirstPerson");
            }
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public int DayOfBirthSecondPerson
        {
            get
            {
                return _DayOfBirthSecondPerson;
            }
            set
            {
                _DayOfBirthSecondPerson = value;
                OnPropertyChanged("DayOfBirthSecondPerson");
            }
        }

        /// <summary>
        /// Сумма чисел по первому сравниваемому человеку
        /// </summary>
        public string OverallFirstPerson
        {
            get
            {
                return _OverallFirstPerson;
            }
            set
            {
                _OverallFirstPerson = value;
                OnPropertyChanged("OverallFirstPerson");
            }
        }

        /// <summary>
        /// Сумма чисел по второму сравниваемому человеку
        /// </summary>
        public string OverallSecondPerson
        {
            get
            {
                return _OverallSecondPerson;
            }
            set
            {
                _OverallSecondPerson = value;
                OnPropertyChanged("OverallSecondPerson");
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DayOfBirthResultPersonal
        {
            get
            {
                return _DayOfBirthResultPersonal;
            }
            set
            {
                _DayOfBirthResultPersonal = value;
                OnPropertyChanged("DayOfBirthResultPersonal");
            }
        }

        public int DayOfBirthResultBusiness
        {
            get
            {
                return _DayOfBirthResultBusiness;
            }
            set
            {
                _DayOfBirthResultBusiness = value;
                OnPropertyChanged("DayOfBirthResultBusiness");
            }
        }

        public int LifePathNumberResultPersonal
        {
            get
            {
                return _LifePathNumberResultPersonal;
            }
            set
            {
                _LifePathNumberResultPersonal = value;
                OnPropertyChanged("LifePathNumberResultPersonal");
            }
        }

        public int LifePathNumberResultBusiness
        {
            get
            {
                return _LifePathNumberResultBusiness;
            }
            set
            {
                _LifePathNumberResultBusiness = value;
                OnPropertyChanged("LifePathNumberResultBusiness");
            }
        }


        public int SoulNumberResultPersonal
        {
            get
            {
                return _SoulNumberResultPersonal;
            }
            set
            {
                _SoulNumberResultPersonal = value;
                OnPropertyChanged("SoulNumberResultPersonal");
            }
        }

        public int SoulNumberResultBusiness
        {
            get
            {
                return _SoulNumberResultBusiness;
            }
            set
            {
                _SoulNumberResultBusiness = value;
                OnPropertyChanged("SoulNumberResultBusiness");
            }
        }

        public int IdentityNumberResultPersonal
        {
            get
            {
                return _IdentityNumberResultPersonal;
            }
            set
            {
                _IdentityNumberResultPersonal = value;
                OnPropertyChanged("IdentityNumberResultPersonal");
            }
        }

        public int IdentityNumberResultBusiness
        {
            get
            {
                return _IdentityNumberResultBusiness;
            }
            set
            {
                _IdentityNumberResultBusiness = value;
                OnPropertyChanged("IdentityNumberResultBusiness");
            }
        }


        public int DestinyNumberResultPersonal
        {
            get
            {
                return _DestinyNumberResultPersonal;
            }
            set
            {
                _DestinyNumberResultPersonal = value;
                OnPropertyChanged("DestinyNumberResultPersonal");
            }
        }

        public int DestinyNumberResultBusiness
        {
            get
            {
                return _DestinyNumberResultBusiness;
            }
            set
            {
                _DestinyNumberResultBusiness = value;
                OnPropertyChanged("DestinyNumberResultBusiness");
            }
        }
        public int MaturityNumberResultPersonal
        {
            get
            {
                return _MaturityNumberResultPersonal;
            }
            set
            {
                _MaturityNumberResultPersonal = value;
                OnPropertyChanged("MaturityNumberResultPersonal");
            }
        }


        public int MaturityNumberResultBusiness
        {
            get
            {
                return _MaturityNumberResultBusiness;
            }
            set
            {
                _MaturityNumberResultBusiness = value;
                OnPropertyChanged("MaturityNumberResultBusiness");
            }
        }

        public int CurrentCycleResultPersonal
        {
            get
            {
                return _CurrentCycleResultPersonal;
            }
            set
            {
                _CurrentCycleResultPersonal = value;
                OnPropertyChanged("CurrentCycleResultPersonal");
            }
        }


        public int CurrentCycleResultBusiness
        {
            get
            {
                return _CurrentCycleResultBusiness;
            }
            set
            {
                _CurrentCycleResultBusiness = value;
                OnPropertyChanged("CurrentCycleResultBusiness");
            }
        }


        public int CurrentPeakResultPersonal
        {
            get
            {
                return _CurrentPeakResultPersonal;
            }
            set
            {
                _CurrentPeakResultPersonal = value;
                OnPropertyChanged("CurrentPeakResultPersonal");
            }
        }

        public int CurrentPeakResultBusiness
        {
            get
            {
                return _CurrentPeakResultBusiness;
            }
            set
            {
                _CurrentPeakResultBusiness = value;
                OnPropertyChanged("CurrentPeakResultBusiness");
            }
        }

        public int CurrentProblemResultPersonal
        {
            get
            {
                return _CurrentProblemResultPersonal;
            }
            set
            {
                _CurrentProblemResultPersonal = value;
                OnPropertyChanged("CurrentProblemResultPersonal");
            }
        }

        public int CurrentProblemResultBusiness
        {
            get
            {
                return _CurrentProblemResultBusiness;
            }
            set
            {
                _CurrentProblemResultBusiness = value;
                OnPropertyChanged("CurrentProblemResultBusiness");
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
