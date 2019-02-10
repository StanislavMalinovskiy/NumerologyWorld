using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml.Serialization;
using Windows.Storage;
using Numerology.Common;
using Numerology.Model;

namespace Numerology.ViewModel
{
    public class NumerologicalMapViewModel : INotifyPropertyChanged
    {

        #region Declarations

        private NumerologicalMap _NumerologicalMap;
        private NumMapCalculator NumMapCalculator;

        private ObservableCollection<Customer> Customers;
        private Customer NewCustomer;

        public RelayCommand CalculateCommand { get; set; }

        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        #endregion

        #region Constructor
        public NumerologicalMapViewModel()
        {
            CalculateCommand = new RelayCommand(ExecuteCalculateCommand, CanExucuteCalculateCommand);
        }

        #endregion

        #region CommandLogic
        private void ExecuteCalculateCommand()
        {
            if (HasValidationErrors() == false)
            {
                CalculateNumerologyMap();
                CalcIsComplete = true;
                SaveCustomer();
            }

            //var msgDlg = new Windows.UI.Popups.MessageDialog(NewCustomer.FirstName) { DefaultCommandIndex = 1 };
            //await msgDlg.ShowAsync();        
        }
        private bool CanExucuteCalculateCommand()
        {
            if (HasValidationErrors())
            {
                return false;
            }

            if (LastName == null || FirstName == null)
            {
                return false;
            }
            else if (LastName != null && FirstName != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Procedures

        /// <summary>
        /// Вычисляет нумерологическую карту
        /// </summary>
        private void CalculateNumerologyMap()
        {

            if (NumerologicalMap == null)
            {
                NumerologicalMap = new NumerologicalMap();
            }

            NumMapCalculator = new NumMapCalculator(FirstName, LastName, SecondName, BirthDate.Date, CalcLifePathSeparately);

            BirthDayDescriptionSource = NumMapCalculator.GetBirthDayDescriptionSource();
            KarmicKnotsDescriptionSource = NumMapCalculator.GetKarmicKnotsDescriptionSource();

            NumerologicalMap.DayOfBirth = NumMapCalculator.GetDayOfBirth();

            NumerologicalMap.SoulNumber = NumMapCalculator.GetSoulNumber();
            NumerologicalMap.IdentityNumber = NumMapCalculator.GetIdentityNumber();
            NumerologicalMap.DestinyNumber = NumMapCalculator.GetDestinyNumber();
            NumerologicalMap.GrowthNumber = NumMapCalculator.GetGrowthNumber();

            NumerologicalMap.LifePathNumber = NumMapCalculator.GetLifePathNumber();
            NumerologicalMap.MaturityNumber = NumMapCalculator.GetMaturityNumber();
            NumerologicalMap.CashNumber = NumMapCalculator.GetCashNumber();
            NumerologicalMap.NumerologyCode = NumMapCalculator.GetNumerologyCode();

            NumerologicalMap.FirstCycle = NumMapCalculator.GetFirstCycle();
            NumerologicalMap.SecondCycle = NumMapCalculator.GetSecondCycle();
            NumerologicalMap.ThirdCycle = NumMapCalculator.GetThirdCycle();

            NumerologicalMap.FirstPeak = NumMapCalculator.GetFirstPeak();
            NumerologicalMap.SecondPeak = NumMapCalculator.GetSecondPeak();
            NumerologicalMap.ThirdPeak = NumMapCalculator.GetThirdPeak();
            NumerologicalMap.FourthPeak = NumMapCalculator.GetFourthPeak();

            NumerologicalMap.FirstProblemNumber = NumMapCalculator.GetFirstProblemNumber();
            NumerologicalMap.SecondProblemNumber = NumMapCalculator.GetSecondProblemNumber();
            NumerologicalMap.ThirdProblemNumber = NumMapCalculator.GetThirdProblemNumber();
            NumerologicalMap.FourthProblemNumber = NumMapCalculator.GetFourthProblemNumber();

            LifeStraightChartItemsSource = NumMapCalculator.GetLsItemsSource();

            SuccessfulYearsChartItemsSource = NumMapCalculator.GetSyItemsSource();
            DemandLevelChartItemsSource = NumMapCalculator.GetDemandLevelChartItemsSource();

            NumMapCalculator.CalculatePsychomatrix();

            NumerologicalMap.FirstRowPsychomatrix = NumMapCalculator.FirstRowPsychomatrix;
            NumerologicalMap.SecondRowPsychomatrix = NumMapCalculator.SecondRowPsychomatrix;

            NumerologicalMap.TopLeftPsychoNumber = NumMapCalculator.TopLeftPsychoNumber;
            NumerologicalMap.TopCenterPsychoNumber = NumMapCalculator.TopCenterPsychoNumber;
            NumerologicalMap.TopRightPsychoNumber = NumMapCalculator.TopRightPsychoNumber;

            NumerologicalMap.CenterLeftPsychoNumber = NumMapCalculator.CenterLeftPsychoNumber;
            NumerologicalMap.CenterPsychoNumber = NumMapCalculator.CenterPsychoNumber;
            NumerologicalMap.CenterRightPsychoNumber = NumMapCalculator.CenterRightPsychoNumber;

            NumerologicalMap.BottomLeftPsychoNumber = NumMapCalculator.BottomLeftPsychoNumber;
            NumerologicalMap.BottomCenterPsychoNumber = NumMapCalculator.BottomCenterPsychoNumber;
            NumerologicalMap.BottomRightPsychoNumber = NumMapCalculator.BottomRightPsychoNumber;

            RaisePropertyChanged("NumerologicalMap");
            CalculateCommand.RaiseCanExecuteChanged();
        }


        [SuppressMessage("ReSharper", "ConvertIfStatementToNullCoalescingExpression")]
        private async void SaveCustomer()
        {
            NewCustomer = new Customer
            {
                FirstName = FirstName,
                LastName = LastName,
                SecondName = SecondName,
                BirthDate = BirthDate.Date,
                CalculateDate = DateTime.Now,
                MobilePhone = MobilePhone,
                HomePhone = HomePhone,
                Email = Email
            };


            bool fileExists = true;
            StorageFile CustomersFile;


            // Получаем сохранненый локальный файл с персональными данными
            try
            {
                var OldCustomerFile = await localFolder.GetFileAsync("CustomersFile.txt");
                string OldCustomersTxt = await FileIO.ReadTextAsync(OldCustomerFile);
                Customers = Deserialize(OldCustomersTxt);

                if (Customers == null)
                // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                {
                    Customers = new ObservableCollection<Customer>();
                }

                bool IsNewCustomer = true;
          
                foreach (Customer cust in Customers)
                {
                    if (cust.FirstName == NewCustomer.FirstName && cust.LastName == NewCustomer.LastName &&
                        cust.SecondName == NewCustomer.SecondName && cust.BirthDate == NewCustomer.BirthDate)
                    {
                        cust.MobilePhone = NewCustomer.MobilePhone;
                        cust.HomePhone = NewCustomer.HomePhone;
                        cust.Email = NewCustomer.Email;
                        IsNewCustomer = false;
                    }
                }

                if (IsNewCustomer == true)
                {
                    Customers.Add(NewCustomer);
                }
                

                // Сохраняем в локальное хранилище
                CustomersFile = await localFolder.CreateFileAsync("CustomersFile.txt", CreationCollisionOption.OpenIfExists);
                await FileIO.WriteTextAsync(CustomersFile, Serialize(Customers));

            }
            catch
            {
                fileExists = false;
            }

            if (fileExists == false)
            {
                if (Customers == null)
                // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                {
                    Customers = new ObservableCollection<Customer>();
                }
                Customers.Add(NewCustomer);

                CustomersFile = await localFolder.CreateFileAsync("CustomersFile.txt", CreationCollisionOption.OpenIfExists);
                await FileIO.WriteTextAsync(CustomersFile, Serialize(Customers));
            }

        }

        private static string Serialize(object obj)
        {
            using (var sw = new StringWriter())
            {
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj);
                return sw.ToString();
            }
        }

        ObservableCollection<Customer> Deserialize(string obj)
        {
            using (var sw = new StringReader(obj))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<Customer>));
                return (ObservableCollection<Customer>)serializer.Deserialize(sw);
            }
        }

 
        #endregion

        #region Functions

        bool HasValidationErrors()
        {
            if (MobileNumHasError || HomeNumHasError || EmailHasError)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region Properties (bindings)
        //private string _LastName = "Малиновский";
        //private string _FirstName = "Станислав";
        //private string _SecondName = "Вячеславович";
        private string _LastName;
        private string _FirstName;
        private string _SecondName;
        private DateTimeOffset _BirthDate = Convert.ToDateTime("01/01/1980");

        private string _MobilePhone;
        private string _HomePhone;
        private string _Email;

        private bool _MobileNumHasError;
        private bool _HomeNumHasError;
        private bool _EmailHasError;

        private bool _CalcLifePathSeparately;
        private bool _CalcIsComplete;
        private string _BirthDayDescriptionSource;
        private string _KarmicKnotsDescriptionSource;
        
        /// <summary>
        /// Описание дня рождения
        /// </summary>
        public string BirthDayDescriptionSource
        {
            get
            {
                return _BirthDayDescriptionSource;
            }
            private set
            {
                _BirthDayDescriptionSource = value;
                RaisePropertyChanged("BirthDayDescriptionSource");
            }
        }

        /// <summary>
        /// Описание кармического узла
        /// </summary>
        public string KarmicKnotsDescriptionSource
        {
            get
            {
                return _KarmicKnotsDescriptionSource;
            }
            private set
            {
                _KarmicKnotsDescriptionSource = value;
                RaisePropertyChanged("KarmicKnotsDescriptionSource");
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
                RaisePropertyChanged("LastName");
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
                RaisePropertyChanged("FirstName");
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Отчество
        /// </summary>
        public string SecondName
        {
            get
            {
                return _SecondName;
            }
            set
            {
                _SecondName = value;
                RaisePropertyChanged("SecondName");
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTimeOffset BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                _BirthDate = value;
                RaisePropertyChanged("BirthDate");
            }
        }

        public string MobilePhone
        {
            get
            {
                return _MobilePhone;
            }
            set
            {
                _MobilePhone = value;
                RaisePropertyChanged("MobilePhone");
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }

        public string HomePhone
        {
            get
            {
                return _HomePhone;
            }
            set
            {
                _HomePhone = value;
                RaisePropertyChanged("HomePhone");
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                RaisePropertyChanged("Email");
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }

        public bool MobileNumHasError
        {
            get
            {
                return _MobileNumHasError;
            }
            set
            {
                _MobileNumHasError = value;
                RaisePropertyChanged("MobileNumHasError");
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }

        public bool HomeNumHasError
        {
            get
            {
                return _HomeNumHasError;
            }
            set
            {
                _HomeNumHasError = value;
                RaisePropertyChanged("HomeNumHasError");
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }

        public bool EmailHasError
        {
            get
            {
                return _EmailHasError;
            }
            set
            {
                _EmailHasError = value;
                RaisePropertyChanged("EmailHasError");
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }



        /// <summary>
        /// Вычислять жизненный путь по раздельности
        /// </summary>
        public bool CalcLifePathSeparately
        {
            get
            {
                return _CalcLifePathSeparately;
            }
            set
            {
                _CalcLifePathSeparately = value;
                NumMapCalculator.CalcLifePathSeparately = _CalcLifePathSeparately;
                NumerologicalMap.LifePathNumber = NumMapCalculator.GetLifePathNumber();

                RaisePropertyChanged("NumerologicalMap");
                RaisePropertyChanged("CalcLifePathSeparately");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CalcIsComplete
        {
            get
            {
                return _CalcIsComplete;
            }
            private set
            {
                _CalcIsComplete = value;
                RaisePropertyChanged("CalcIsComplete");
            }
        }

        public NumerologicalMap NumerologicalMap
        {
            get
            {
                return _NumerologicalMap;
            }
            set
            {
                if (_NumerologicalMap != value)
                {
                    _NumerologicalMap = value;
                    RaisePropertyChanged("NumerologicalMap");
                }
            }
        }

        IEnumerable _LifeStraightChartItemsSource;
        public IEnumerable LifeStraightChartItemsSource
        {
            get
            {
                return _LifeStraightChartItemsSource;
            }
            set
            {
                _LifeStraightChartItemsSource = value;
                RaisePropertyChanged("LifeStraightChartItemsSource");
            }
        }

        IEnumerable _SuccessfulYearsChartItemsSource;
        public IEnumerable SuccessfulYearsChartItemsSource
        {
            get
            {
                return _SuccessfulYearsChartItemsSource;
            }
            set
            {
                _SuccessfulYearsChartItemsSource = value;
                RaisePropertyChanged("SuccessfulYearsChartItemsSource");
            }
        }

        IEnumerable _DemandLevelChartItemsSource;
        public IEnumerable DemandLevelChartItemsSource
        {
            get
            {
                return _DemandLevelChartItemsSource;
            }
            set
            {
                _DemandLevelChartItemsSource = value;
                RaisePropertyChanged("DemandLevelChartItemsSource");
            }
        }

        private ObservableCollection<string> _LastNames;
        public ObservableCollection<string> LastNames
        {
            get
            {

                return _LastNames;
            }
            set
            {
                _LastNames = value;
                RaisePropertyChanged("LastNames");
            }
        }

        private ObservableCollection<string> _FirstNames;
        public ObservableCollection<string> FirstNames
        {
            get
            {

                return _FirstNames;
            }
            set
            {
                _FirstNames = value;
                RaisePropertyChanged("FirstNames");
            }
        }

        private ObservableCollection<string> _SecondNames;
        public ObservableCollection<string> SecondNames
        {
            get
            {

                return _SecondNames;
            }
            set
            {
                _SecondNames = value;
                RaisePropertyChanged("SecondNames");
            }
        }
        #endregion

        #region INotifyPropertyChanged Realization

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}

