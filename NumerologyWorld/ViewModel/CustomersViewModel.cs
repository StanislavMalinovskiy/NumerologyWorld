using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using Windows.ApplicationModel;
using Windows.Storage;
using Numerology.Common;
using Numerology.Model;

namespace Numerology.ViewModel
{
    public class CustomersViewModel : INotifyPropertyChanged
    {
        #region Declarations

        private Customer FirstPerson;
        private Customer SecondPerson;

        private CompareNumerologicalMap _CompareNumerologicalMap;

        private NumMapCalculator FirstNumMapCalculator;
        private NumMapCalculator SecondNumMapCalculator;

        private ObservableCollection<Customer> _Customers;
        private Customer _SelectedCustomer;
        private ObservableCollection<Customer> _SelectedCustomers = new ObservableCollection<Customer>();
        private StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        public RelayCommand CompareCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        #endregion

        #region Constructor

        public CustomersViewModel()
        {
            CompareCommand = new RelayCommand(ExecuteCompareCommand);
            DeleteCommand = new RelayCommand(ExecuteDeleteCommand);
        }
        #endregion

        #region CommandLogic
        private  void ExecuteCompareCommand()
        {
            //var msgDlg = new Windows.UI.Popups.MessageDialog("Execute Compare Command" + SelectedCustomers.Count) { DefaultCommandIndex = 1 };
            //await msgDlg.ShowAsync();
            CalculateCompareNumerologyMap();
        }

        private  void ExecuteDeleteCommand()
        {
            DeleteCustomer();
        }
        #endregion

        #region Procedures


        /// <summary>
        /// Вычисляет нумерологическую карту для двух человек
        /// </summary>
        private void CalculateCompareNumerologyMap()
        {
            if (CompareNumerologicalMap == null)
            {
                CompareNumerologicalMap = new CompareNumerologicalMap();
            }

            System.Collections.IEnumerator myEnumerator = SelectedCustomers.GetEnumerator();

            while (myEnumerator.MoveNext())
            {
                if (FirstPerson == null)
                {
                    FirstPerson = (Customer)myEnumerator.Current;
                    continue;
                }
                if (SecondPerson == null)
                {
                    SecondPerson = (Customer)myEnumerator.Current;
                }
            }

            FirstNumMapCalculator = new NumMapCalculator(FirstPerson.FirstName, FirstPerson.LastName, FirstPerson.SecondName, FirstPerson.BirthDate, true);
            SecondNumMapCalculator = new NumMapCalculator(SecondPerson.FirstName, SecondPerson.LastName, SecondPerson.SecondName, SecondPerson.BirthDate, true);

            CompareNumerologicalMap.DayOfBirthFirstPerson = GetNaturalNumberIntForCompare(FirstNumMapCalculator.GetDayOfBirth().ToString());
            CompareNumerologicalMap.DayOfBirthSecondPerson = GetNaturalNumberIntForCompare(SecondNumMapCalculator.GetDayOfBirth().ToString());

            CompareNumerologicalMap.SoulNumberFirstPerson = GetNaturalNumberIntForCompare(FirstNumMapCalculator.GetSoulNumber()).ToString();
            CompareNumerologicalMap.SoulNumberSecondPerson = GetNaturalNumberIntForCompare(SecondNumMapCalculator.GetSoulNumber()).ToString();

            CompareNumerologicalMap.IdentityNumberFirstPerson = GetNaturalNumberIntForCompare(FirstNumMapCalculator.GetIdentityNumber()).ToString();
            CompareNumerologicalMap.IdentityNumberSecondPerson = GetNaturalNumberIntForCompare(SecondNumMapCalculator.GetIdentityNumber()).ToString();

            CompareNumerologicalMap.DestinyNumberFirstPerson = GetNaturalNumberIntForCompare(FirstNumMapCalculator.GetDestinyNumber()).ToString();
            CompareNumerologicalMap.DestinyNumberSecondPerson = GetNaturalNumberIntForCompare(SecondNumMapCalculator.GetDestinyNumber()).ToString();

            CompareNumerologicalMap.LifePathNumberFirstPerson = GetNaturalNumberIntForCompare(FirstNumMapCalculator.GetLifePathNumber()).ToString();
            CompareNumerologicalMap.LifePathNumberSecondPerson = GetNaturalNumberIntForCompare(SecondNumMapCalculator.GetLifePathNumber()).ToString();

            CompareNumerologicalMap.MaturityNumberFirstPerson = GetNaturalNumberIntForCompare(FirstNumMapCalculator.GetMaturityNumber()).ToString();
            CompareNumerologicalMap.MaturityNumberSecondPerson = GetNaturalNumberIntForCompare(SecondNumMapCalculator.GetMaturityNumber()).ToString();

            FirstNumMapCalculator.GetFirstCycle();
            FirstNumMapCalculator.GetSecondCycle();
            FirstNumMapCalculator.GetThirdCycle();

            FirstNumMapCalculator.GetFirstPeak();
            FirstNumMapCalculator.GetSecondPeak();
            FirstNumMapCalculator.GetThirdPeak();
            FirstNumMapCalculator.GetFourthPeak();

            SecondNumMapCalculator.GetFirstCycle();
            SecondNumMapCalculator.GetSecondCycle();
            SecondNumMapCalculator.GetThirdCycle();

            SecondNumMapCalculator.GetFirstPeak();
            SecondNumMapCalculator.GetSecondPeak();
            SecondNumMapCalculator.GetThirdPeak();
            SecondNumMapCalculator.GetFourthPeak();

            CompareNumerologicalMap.CurrentCycleFirstPerson = FirstNumMapCalculator.CurrentCycle;
            CompareNumerologicalMap.CurrentCycleSecondPerson = SecondNumMapCalculator.CurrentCycle;

            CompareNumerologicalMap.CurrentPeakFirstPerson = FirstNumMapCalculator.CurrentPeak;
            CompareNumerologicalMap.CurrentPeakSecondPerson = SecondNumMapCalculator.CurrentPeak;

            CompareNumerologicalMap.CurrentProblemFirstPerson = FirstNumMapCalculator.GetCurrentProblem();
            CompareNumerologicalMap.CurrentProblemSecondPerson = SecondNumMapCalculator.GetCurrentProblem();

            CompareNumerologicalMap.DayOfBirthResultPersonal = GetPersonalCompareResult(CompareNumerologicalMap.DayOfBirthFirstPerson, CompareNumerologicalMap.DayOfBirthSecondPerson);
            CompareNumerologicalMap.DayOfBirthResultBusiness = GetBusinessCompareResult(CompareNumerologicalMap.DayOfBirthFirstPerson, CompareNumerologicalMap.DayOfBirthSecondPerson);

            CompareNumerologicalMap.SoulNumberResultPersonal = GetPersonalCompareResult(Convert.ToInt32(CompareNumerologicalMap.SoulNumberFirstPerson), Convert.ToInt32(CompareNumerologicalMap.SoulNumberSecondPerson));
            CompareNumerologicalMap.SoulNumberResultBusiness = GetBusinessCompareResult(Convert.ToInt32(CompareNumerologicalMap.SoulNumberFirstPerson), Convert.ToInt32(CompareNumerologicalMap.SoulNumberSecondPerson));

            CompareNumerologicalMap.IdentityNumberResultPersonal = GetPersonalCompareResult(Convert.ToInt32(CompareNumerologicalMap.IdentityNumberFirstPerson), Convert.ToInt32(CompareNumerologicalMap.IdentityNumberSecondPerson));
            CompareNumerologicalMap.IdentityNumberResultBusiness = GetBusinessCompareResult(Convert.ToInt32(CompareNumerologicalMap.IdentityNumberFirstPerson), Convert.ToInt32(CompareNumerologicalMap.IdentityNumberSecondPerson));

            CompareNumerologicalMap.DestinyNumberResultPersonal = GetPersonalCompareResult(Convert.ToInt32(CompareNumerologicalMap.DestinyNumberFirstPerson), Convert.ToInt32(CompareNumerologicalMap.DestinyNumberSecondPerson));
            CompareNumerologicalMap.DestinyNumberResultBusiness = GetBusinessCompareResult(Convert.ToInt32(CompareNumerologicalMap.DestinyNumberFirstPerson), Convert.ToInt32(CompareNumerologicalMap.DestinyNumberSecondPerson));

            CompareNumerologicalMap.LifePathNumberResultPersonal = GetPersonalCompareResult(Convert.ToInt32(CompareNumerologicalMap.LifePathNumberFirstPerson), Convert.ToInt32(CompareNumerologicalMap.LifePathNumberSecondPerson));
            CompareNumerologicalMap.LifePathNumberResultBusiness = GetBusinessCompareResult(Convert.ToInt32(CompareNumerologicalMap.LifePathNumberFirstPerson), Convert.ToInt32(CompareNumerologicalMap.LifePathNumberSecondPerson));

            CompareNumerologicalMap.MaturityNumberResultPersonal = GetPersonalCompareResult(Convert.ToInt32(CompareNumerologicalMap.MaturityNumberFirstPerson), Convert.ToInt32(CompareNumerologicalMap.MaturityNumberSecondPerson));
            CompareNumerologicalMap.MaturityNumberResultBusiness = GetBusinessCompareResult(Convert.ToInt32(CompareNumerologicalMap.MaturityNumberFirstPerson), Convert.ToInt32(CompareNumerologicalMap.MaturityNumberSecondPerson));

            CompareNumerologicalMap.CurrentCycleResultPersonal = GetPersonalCompareResult(Convert.ToInt32(CompareNumerologicalMap.CurrentCycleFirstPerson), Convert.ToInt32(CompareNumerologicalMap.CurrentCycleSecondPerson));
            CompareNumerologicalMap.CurrentCycleResultBusiness = GetBusinessCompareResult(Convert.ToInt32(CompareNumerologicalMap.CurrentCycleFirstPerson), Convert.ToInt32(CompareNumerologicalMap.CurrentCycleSecondPerson));

            CompareNumerologicalMap.CurrentPeakResultPersonal = GetPersonalCompareResult(Convert.ToInt32(CompareNumerologicalMap.CurrentPeakFirstPerson), Convert.ToInt32(CompareNumerologicalMap.CurrentPeakSecondPerson));
            CompareNumerologicalMap.CurrentPeakResultBusiness = GetBusinessCompareResult(Convert.ToInt32(CompareNumerologicalMap.CurrentPeakFirstPerson), Convert.ToInt32(CompareNumerologicalMap.CurrentPeakSecondPerson));

            CompareNumerologicalMap.CurrentProblemResultPersonal = GetPersonalCompareResult(Convert.ToInt32(CompareNumerologicalMap.CurrentProblemFirstPerson), Convert.ToInt32(CompareNumerologicalMap.CurrentProblemSecondPerson));
            CompareNumerologicalMap.CurrentProblemResultBusiness = GetBusinessCompareResult(Convert.ToInt32(CompareNumerologicalMap.CurrentProblemFirstPerson), Convert.ToInt32(CompareNumerologicalMap.CurrentProblemSecondPerson));


            decimal OverallFirstPerson = CompareNumerologicalMap.DayOfBirthResultPersonal +
                                     CompareNumerologicalMap.SoulNumberResultPersonal +
                                     CompareNumerologicalMap.IdentityNumberResultPersonal +
                                     CompareNumerologicalMap.DestinyNumberResultPersonal +
                                     CompareNumerologicalMap.LifePathNumberResultPersonal +
                                     CompareNumerologicalMap.MaturityNumberResultPersonal +
                                     CompareNumerologicalMap.CurrentCycleResultPersonal +
                                     CompareNumerologicalMap.CurrentPeakResultPersonal +
                                     CompareNumerologicalMap.CurrentProblemResultPersonal;


            decimal OverallSecondPerson = CompareNumerologicalMap.DayOfBirthResultBusiness +
                                      CompareNumerologicalMap.SoulNumberResultBusiness +
                                      CompareNumerologicalMap.IdentityNumberResultBusiness +
                                      CompareNumerologicalMap.DestinyNumberResultBusiness +
                                      CompareNumerologicalMap.LifePathNumberResultBusiness +
                                      CompareNumerologicalMap.MaturityNumberResultBusiness +
                                      CompareNumerologicalMap.CurrentCycleResultBusiness +
                                      CompareNumerologicalMap.CurrentPeakResultBusiness +
                                      CompareNumerologicalMap.CurrentProblemResultBusiness;

            CompareNumerologicalMap.OverallFirstPerson = OverallFirstPerson + " (" + (OverallFirstPerson / 9).ToString("n2") + ")";

            CompareNumerologicalMap.OverallSecondPerson = OverallSecondPerson + " (" + (OverallSecondPerson / 9).ToString("n2") + ")";

            RaisePropertyChanged("CompareNumerologicalMap");
            FirstPerson = null;
            SecondPerson = null;
        }


        private async void DeleteCustomer()
        {
            StorageFile CustomersFile;

            Customers.Remove(SelectedCustomer);
            // Сохраняем в локальное хранилище
            CustomersFile = await localFolder.CreateFileAsync("CustomersFile.txt", CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(CustomersFile, Serialize(Customers));
        }

        async void BindCustomers()
        {
            try
            {
                StorageFile CustomersFile = await localFolder.GetFileAsync("CustomersFile.txt");
                string CustomersTxt = await FileIO.ReadTextAsync(CustomersFile);
                Customers = Deserialize(CustomersTxt);

                //if (CustomersFile != null)
                //{
                //    await CustomersFile.DeleteAsync();
                //}
            }
            catch
            {
                // ignored
            }
        }

        #endregion

        #region Functions

        private int GetPersonalCompareResult(int FirstPersonNum, int SecondPersonNum)
        {
            int Result = 0;

            if (FirstPersonNum == 0 || SecondPersonNum == 0)
            {
                return 5;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 1)
            {
                return 4;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 2)
            {
                return 4;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 3)
            {
                return 2;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 4)
            {
                return 2;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 5)
            {
                return 3;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 6)
            {
                return 4;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 7)
            {
                return 3;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 8)
            {
                return 3;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 9)
            {
                return 5;
            }

            ////2/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 2 && SecondPersonNum == 1)
            {
                return 4;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 2)
            {
                return 5;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 3)
            {
                return 4;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 4)
            {
                return 4;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 5)
            {
                return 2;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 6)
            {
                return 4;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 7)
            {
                return 4;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 8)
            {
                return 4;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 9)
            {
                return 5;
            }

            ////3/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 3 && SecondPersonNum == 1)
            {
                return 2;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 2)
            {
                return 4;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 3)
            {
                return 2;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 4)
            {
                return 3;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 5)
            {
                return 3;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 6)
            {
                return 4;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 7)
            {
                return 4;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 8)
            {
                return 3;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 9)
            {
                return 5;
            }

            ////4/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 4 && SecondPersonNum == 1)
            {
                return 2;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 2)
            {
                return 4;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 3)
            {
                return 3;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 4)
            {
                return 4;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 5)
            {
                return 2;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 6)
            {
                return 3;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 7)
            {
                return 4;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 8)
            {
                return 4;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 9)
            {
                return 4;
            }

            ////5/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 5 && SecondPersonNum == 1)
            {
                return 3;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 2)
            {
                return 2;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 3)
            {
                return 3;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 4)
            {
                return 2;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 5)
            {
                return 2;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 6)
            {
                return 3;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 7)
            {
                return 2;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 8)
            {
                return 4;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 9)
            {
                return 4;
            }

            ////6/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 6 && SecondPersonNum == 1)
            {
                return 4;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 2)
            {
                return 4;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 3)
            {
                return 4;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 4)
            {
                return 3;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 5)
            {
                return 3;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 6)
            {
                return 5;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 7)
            {
                return 2;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 8)
            {
                return 5;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 9)
            {
                return 5;
            }

            ////7/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 7 && SecondPersonNum == 1)
            {
                return 3;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 2)
            {
                return 4;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 3)
            {
                return 4;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 4)
            {
                return 4;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 5)
            {
                return 2;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 6)
            {
                return 2;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 7)
            {
                return 5;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 8)
            {
                return 4;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 9)
            {
                return 5;
            }

            ////8/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 8 && SecondPersonNum == 1)
            {
                return 3;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 2)
            {
                return 4;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 3)
            {
                return 3;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 4)
            {
                return 4;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 5)
            {
                return 4;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 6)
            {
                return 5;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 7)
            {
                return 4;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 8)
            {
                return 3;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 9)
            {
                return 4;
            }

            ////9/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 9 && SecondPersonNum == 1)
            {
                return 5;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 2)
            {
                return 5;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 3)
            {
                return 5;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 4)
            {
                return 4;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 5)
            {
                return 4;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 6)
            {
                return 5;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 7)
            {
                return 5;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 8)
            {
                return 4;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 9)
            {
                return 5;
            }

            return Result;
        }

        private int GetBusinessCompareResult(int FirstPersonNum, int SecondPersonNum)
        {
            int Result = 0;

            if (FirstPersonNum == 0 || SecondPersonNum == 0)
            {
                return 5;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 1)
            {
                return 4;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 2)
            {
                return 5;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 3)
            {
                return 4;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 4)
            {
                return 4;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 5)
            {
                return 5;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 6)
            {
                return 4;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 7)
            {
                return 3;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 8)
            {
                return 5;
            }

            if (FirstPersonNum == 1 && SecondPersonNum == 9)
            {
                return 5;
            }

            ////2/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 2 && SecondPersonNum == 1)
            {
                return 5;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 2)
            {
                return 3;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 3)
            {
                return 3;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 4)
            {
                return 4;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 5)
            {
                return 2;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 6)
            {
                return 2;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 7)
            {
                return 2;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 8)
            {
                return 4;
            }

            if (FirstPersonNum == 2 && SecondPersonNum == 9)
            {
                return 4;
            }

            ////3/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 3 && SecondPersonNum == 1)
            {
                return 4;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 2)
            {
                return 3;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 3)
            {
                return 2;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 4)
            {
                return 3;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 5)
            {
                return 4;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 6)
            {
                return 4;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 7)
            {
                return 4;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 8)
            {
                return 5;
            }

            if (FirstPersonNum == 3 && SecondPersonNum == 9)
            {
                return 2;
            }

            ////4/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 4 && SecondPersonNum == 1)
            {
                return 4;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 2)
            {
                return 4;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 3)
            {
                return 3;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 4)
            {
                return 5;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 5)
            {
                return 2;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 6)
            {
                return 4;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 7)
            {
                return 4;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 8)
            {
                return 5;
            }

            if (FirstPersonNum == 4 && SecondPersonNum == 9)
            {
                return 4;
            }

            ////5/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 5 && SecondPersonNum == 1)
            {
                return 5;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 2)
            {
                return 2;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 3)
            {
                return 4;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 4)
            {
                return 2;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 5)
            {
                return 2;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 6)
            {
                return 3;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 7)
            {
                return 3;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 8)
            {
                return 5;
            }

            if (FirstPersonNum == 5 && SecondPersonNum == 9)
            {
                return 4;
            }

            ////6/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 6 && SecondPersonNum == 1)
            {
                return 4;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 2)
            {
                return 2;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 3)
            {
                return 4;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 4)
            {
                return 4;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 5)
            {
                return 3;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 6)
            {
                return 3;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 7)
            {
                return 2;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 8)
            {
                return 4;
            }

            if (FirstPersonNum == 6 && SecondPersonNum == 9)
            {
                return 5;
            }

            ////7/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 7 && SecondPersonNum == 1)
            {
                return 3;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 2)
            {
                return 2;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 3)
            {
                return 4;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 4)
            {
                return 4;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 5)
            {
                return 3;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 6)
            {
                return 2;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 7)
            {
                return 2;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 8)
            {
                return 5;
            }

            if (FirstPersonNum == 7 && SecondPersonNum == 9)
            {
                return 3;
            }

            ////8/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 8 && SecondPersonNum == 1)
            {
                return 5;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 2)
            {
                return 4;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 3)
            {
                return 5;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 4)
            {
                return 5;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 5)
            {
                return 5;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 6)
            {
                return 4;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 7)
            {
                return 5;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 8)
            {
                return 5;
            }

            if (FirstPersonNum == 8 && SecondPersonNum == 9)
            {
                return 4;
            }

            ////9/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (FirstPersonNum == 9 && SecondPersonNum == 1)
            {
                return 5;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 2)
            {
                return 4;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 3)
            {
                return 2;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 4)
            {
                return 4;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 5)
            {
                return 4;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 6)
            {
                return 5;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 7)
            {
                return 3;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 8)
            {
                return 4;
            }

            if (FirstPersonNum == 9 && SecondPersonNum == 9)
            {
                return 4;
            }

            return Result;
        }

        private int GetNaturalNumberIntForCompare(string num)
        {
            int numVal;

            if (num.Contains("/"))
            {
                //if (num.Contains("1/10"))
                //{
                //    return 1;
                //}
                //if (num.Contains("10/1"))
                //{
                //    return 1;
                //}
                //if (num.Contains("19/10"))
                //{
                //    return 1;
                //}
                //else
                //{
                return Convert.ToInt32(num.Substring(3, 1));
                //}            
            }

            if (num.Length > 1)
            {
                var FirstDigit = num.Substring(0, 1);
                var SecondDigit = num.Substring(1, 1);

                numVal = Convert.ToInt32(FirstDigit) + Convert.ToInt32(SecondDigit);
            }
            else
            {
                numVal = Convert.ToInt32(num);
            }

            // Вторая проверка на двузначное число
            // Приведение числа к однозначному
            if (numVal.ToString().Length == 2)
            {
                var FirstDigit = numVal.ToString().Substring(0, 1);
                var SecondDigit = numVal.ToString().Substring(1, 1);
                numVal = Convert.ToInt32(FirstDigit) + Convert.ToInt32(SecondDigit);
            }

            if (Convert.ToString(numVal).Contains("0") & numVal != 0)
            {
                string numValStr = Convert.ToString(numVal);
                numValStr = numValStr.Replace("0", "");
                numVal = Convert.ToInt16(numValStr);
            }

            return numVal;
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

        #region Properties  (bindings)

        public CompareNumerologicalMap CompareNumerologicalMap
        {
            get
            {
                return _CompareNumerologicalMap;
            }
            set
            {
                if (_CompareNumerologicalMap != value)
                {
                    _CompareNumerologicalMap = value;
                    RaisePropertyChanged("CompareNumerologicalMap");
                }
            }
        }


        public ObservableCollection<Customer> Customers
        {
            get
            {
                if (_Customers == null)
                {
                    if (DesignMode.DesignModeEnabled == false)
                    {
                        BindCustomers();
                    }

                }
                return _Customers;
            }
            set
            {
                _Customers = value;
                RaisePropertyChanged("Customers");
            }
        }

        public Customer SelectedCustomer
        {
            get
            {
                return _SelectedCustomer;
            }
            set
            {
                _SelectedCustomer = value;

                CompareCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged("SelectedCustomer");

            }
        }

        public ObservableCollection<Customer> SelectedCustomers
        {
            get
            {
                return _SelectedCustomers;
            }

            set
            {
                _SelectedCustomers = value;
                RaisePropertyChanged("SelectedCustomers");
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
