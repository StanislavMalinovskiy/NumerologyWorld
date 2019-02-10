using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerology.Model
{
    public class NumerologicalMap
    {

        private string _SoulNumber;
        private string _IdentityNumber;
        private string _LifePathNumber;
        private string _DestinyNumber;
        private string _MaturityNumber;
        private string _GrowthNumber;
        private string _CashNumber;
        private string _NumerologyCode;

        private string _FirstCycle;
        private string _SecondCycle;
        private string _ThirdCycle;

        private string _FirstPeak;
        private string _SecondPeak;
        private string _ThirdPeak;
        private string _FourthPeak;

        private string _FirstProblemNumber;
        private string _SecondProblemNumber;
        private string _ThirdProblemNumber;
        private string _FourthProblemNumber;

        private string _FirstRowPsychomatrix;
        private string _SecondRowPsychomatrix;

        private string _TopLeftPsychoNumber;
        private string _TopCenterPsychoNumber;
        private string _TopRightPsychoNumber;

        private string _CenterLeftPsychoNumber;
        private string _CenterPsychoNumber;
        private string _CenterRightPsychoNumber;

        private string _BottomLeftPsychoNumber;
        private string _BottomCenterPsychoNumber;
        private string _BottomRightPsychoNumber;


        private int _DayOfBirth;

        /// <summary>
        /// Число души
        /// </summary>
        public string SoulNumber
        {
            get
            {
                return _SoulNumber;
            }
            set
            {
                _SoulNumber = value;
                OnPropertyChanged("SoulNumber");
            }
        }

        /// <summary>
        /// Число личности
        /// </summary>
        public string IdentityNumber
        {
            get
            {
                return _IdentityNumber;
            }
            set
            {
                _IdentityNumber = value;
                OnPropertyChanged("IdentityNumber");
            }
        }


        /// <summary>
        /// Число судьбы
        /// </summary>
        public string DestinyNumber
        {
            get
            {
                return _DestinyNumber;
            }
            set
            {
                _DestinyNumber = value;
                OnPropertyChanged("DestinyNumber");
            }
        }

        /// <summary>
        /// Число жизненного пути
        /// </summary>
        public string LifePathNumber
        {
            get
            {
                return _LifePathNumber;
            }
            set
            {
                _LifePathNumber = value;
                OnPropertyChanged("LifePathNumber");
            }
        }


        /// <summary>
        /// Число зрелости
        /// </summary>
        public string MaturityNumber
        {
            get
            {
                return _MaturityNumber;
            }
            set
            {
                _MaturityNumber = value;
                OnPropertyChanged("MaturityNumber");
            }
        }

        /// <summary>
        /// Число роста
        /// </summary>
        public string GrowthNumber
        {
            get
            {
                return _GrowthNumber;
            }
            set
            {
                _GrowthNumber = value;
                OnPropertyChanged("GrowthNumber");
            }
        }

        /// <summary>
        /// Денежное число
        /// </summary>
        public string CashNumber
        {
            get
            {
                return _CashNumber;
            }
            set
            {
                _CashNumber = value;
                OnPropertyChanged("CashNumber");
            }
        }

        /// <summary>
        /// Нумерологический код
        /// </summary>
        public string NumerologyCode
        {
            get
            {
                return _NumerologyCode;
            }
            set
            {
                _NumerologyCode = value;
                OnPropertyChanged("NumerologyCode");
            }
        }

        /// <summary>
        /// Формирующий цикл (первый цикл)
        /// </summary>
        public string FirstCycle
        {
            get
            {
                return _FirstCycle;
            }
            set
            {
                _FirstCycle = value;
                OnPropertyChanged("FirstCycle");
            }
        }

        /// <summary>
        /// Цикл продуктивности (второй цикл)
        /// </summary>
        public string SecondCycle
        {
            get
            {
                return _SecondCycle;
            }
            set
            {
                _SecondCycle = value;
                OnPropertyChanged("SecondCycle");
            }
        }


        /// <summary>
        /// Итоговый цикл  (третий цикл)
        /// </summary>
        public string ThirdCycle
        {
            get
            {
                return _ThirdCycle;
            }
            set
            {
                _ThirdCycle = value;
                OnPropertyChanged("ThirdCycle");
            }
        }


        /// <summary>
        /// Первый пик
        /// </summary>
        public string FirstPeak
        {
            get
            {
                return _FirstPeak;
            }
            set
            {
                _FirstPeak = value;
                OnPropertyChanged("FirstPeak");
            }
        }

        /// <summary>
        /// Второй пик
        /// </summary>
        public string SecondPeak
        {
            get
            {
                return _SecondPeak;
            }
            set
            {
                _SecondPeak = value;
                OnPropertyChanged("SecondPeak");
            }
        }

        /// <summary>
        /// Третий пик
        /// </summary>
        public string ThirdPeak
        {
            get
            {
                return _ThirdPeak;
            }
            set
            {
                _ThirdPeak = value;
                OnPropertyChanged("ThirdPeak");
            }
        }

        /// <summary>
        /// Четвертый пик
        /// </summary>
        public string FourthPeak
        {
            get
            {
                return _FourthPeak;
            }
            set
            {
                _FourthPeak = value;
                OnPropertyChanged("FourthPeak");
            }
        }

        /// <summary>
        /// Первая проблема
        /// </summary>
        public string FirstProblemNumber
        {
            get
            {
                return _FirstProblemNumber;
            }
            set
            {
                _FirstProblemNumber = value;
                OnPropertyChanged("FirstProblemNumber");
            }
        }

        /// <summary>
        /// Вторая проблема
        /// </summary>
        public string SecondProblemNumber
        {
            get
            {
                return _SecondProblemNumber;
            }
            set
            {
                _SecondProblemNumber = value;
                OnPropertyChanged("SecondProblemNumber");
            }
        }

        /// <summary>
        /// Третяя проблема
        /// </summary>
        public string ThirdProblemNumber
        {
            get
            {
                return _ThirdProblemNumber;
            }
            set
            {
                _ThirdProblemNumber = value;
                OnPropertyChanged("ThirdProblemNumber");
            }
        }

        /// <summary>
        /// Четвертая проблема
        /// </summary>
        public string FourthProblemNumber
        {
            get
            {
                return _FourthProblemNumber;
            }
            set
            {
                _FourthProblemNumber = value;
                OnPropertyChanged("FourthProblemNumber");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////      

        public string FirstRowPsychomatrix
        {
            get
            {
                return _FirstRowPsychomatrix;
            }
            set
            {
                _FirstRowPsychomatrix = value;
                OnPropertyChanged("_FirstRowPsychomatrix");
            }
        }

        public string SecondRowPsychomatrix
        {
            get
            {
                return _SecondRowPsychomatrix;
            }
            set
            {
                _SecondRowPsychomatrix = value;
                OnPropertyChanged("SecondRowPsychomatrix");
            }
        }

        public string TopLeftPsychoNumber
        {
            get
            {
                return _TopLeftPsychoNumber;
            }
            set
            {
                _TopLeftPsychoNumber = value;
                OnPropertyChanged("TopLeftPsychoNumber");
            }
        }

        public string TopCenterPsychoNumber
        {
            get
            {
                return _TopCenterPsychoNumber;
            }
            set
            {
                _TopCenterPsychoNumber = value;
                OnPropertyChanged("TopCenterPsychoNumber");
            }
        }

        public string TopRightPsychoNumber
        {
            get
            {
                return _TopRightPsychoNumber;
            }
            set
            {
                _TopRightPsychoNumber = value;
                OnPropertyChanged("TopRightPsychoNumber");
            }
        }

        public string CenterLeftPsychoNumber
        {
            get
            {
                return _CenterLeftPsychoNumber;
            }
            set
            {
                _CenterLeftPsychoNumber = value;
                OnPropertyChanged("CenterLeftPsychoNumber");
            }
        }

        public string CenterPsychoNumber
        {
            get
            {
                return _CenterPsychoNumber;
            }
            set
            {
                _CenterPsychoNumber = value;
                OnPropertyChanged("CenterPsychoNumber");
            }
        }

        public string CenterRightPsychoNumber
        {
            get
            {
                return _CenterRightPsychoNumber;
            }
            set
            {
                _CenterRightPsychoNumber = value;
                OnPropertyChanged("CenterRightPsychoNumber");
            }
        }

        public string BottomLeftPsychoNumber
        {
            get
            {
                return _BottomLeftPsychoNumber;
            }
            set
            {
                _BottomLeftPsychoNumber = value;
                OnPropertyChanged("BottomLeftPsychoNumber");
            }
        }

        public string BottomCenterPsychoNumber
        {
            get
            {
                return _BottomCenterPsychoNumber;
            }
            set
            {
                _BottomCenterPsychoNumber = value;
                OnPropertyChanged("BottomCenterPsychoNumber");
            }
        }

        public string BottomRightPsychoNumber
        {
            get
            {
                return _BottomRightPsychoNumber;
            }
            set
            {
                _BottomRightPsychoNumber = value;
                OnPropertyChanged("BottomRightPsychoNumber");
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private int _SoulNumberNatural;
        public int SoulNumberNatural
        {
            get
            {
                return _SoulNumberNatural;
            }
            set
            {
                _SoulNumberNatural = value;
                OnPropertyChanged("SoulNumberNatural");
            }
        }

        private int _IdentityNumberNatural;
        public int IdentityNumberNatural
        {
            get
            {
                return _IdentityNumberNatural;
            }
            set
            {
                _IdentityNumberNatural = value;
                OnPropertyChanged("IdentityNumberNatural");
            }
        }

        private int _DestinyNumberNatural;
        public int DestinyNumberNatural
        {
            get
            {
                return _DestinyNumberNatural;
            }
            set
            {
                _DestinyNumberNatural = value;
                OnPropertyChanged("DestinyNumberNatural");
            }
        }

        private int _LifePathNumberNatural;

        public int LifePathNumberNatural
        {
            get
            {
                return _LifePathNumberNatural;
            }
            set
            {
                _LifePathNumberNatural = value;
                OnPropertyChanged("LifePathNumberNatural");
            }
        }


        /// <summary>
        /// Отчество
        /// </summary>
        public int DayOfBirth
        {
            get
            {
                return _DayOfBirth;
            }
            set
            {
                _DayOfBirth = value;
                OnPropertyChanged("DayOfBirth");
            }
        }

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
