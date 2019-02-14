using System;
using System.ComponentModel;
using Numerology.Common;
using Numerology.Model;

namespace Numerology.ViewModel
{
    public class PersonalNumbersViewModel : INotifyPropertyChanged
    {
        #region Declarations

        private PersonalNumbers _personalNumbers = new PersonalNumbers();
        private PersonalNumbersCalculator _personalNumbersCalculator;

        private UniversalNumbers _universalNumbers = new UniversalNumbers();
        private UniversalNumbersCalculator _universalNumbersCalculator;

        public RelayCommand CalcPersonalNumbersCommand { get; set; }

        public RelayCommandWithPar SelectMonthCommand { get; set; }

        #endregion

        #region Constructor

        public PersonalNumbersViewModel()
        {
            CalcPersonalNumbersCommand = new RelayCommand(ExecuteCalcPersonalNumbersCommand);
            SelectMonthCommand = new RelayCommandWithPar(ExecuteSelectMonthCommand);
        }

        #endregion

        #region CommandLogic

        private void ExecuteCalcPersonalNumbersCommand()
        {
            //var msgDlg = new Windows.UI.Popups.MessageDialog("Execute Compare Command" + SelectedCustomers.Count) { DefaultCommandIndex = 1 };
            //await msgDlg.ShowAsync();
            CalculatePersonalNumbers();
            CalculateUniversalNumbers();
        }

        private void ExecuteSelectMonthCommand(object monthNumber)
        {
            if (monthNumber != null)
            {
                PersonalNumbers.SelectedMonth = Convert.ToInt16(monthNumber);
            }
            else
            {
                PersonalNumbers.SelectedMonth = 0;
            }
            CalculatePersonalDays(PersonalNumbers.SelectedMonth);

        }

        #endregion

        #region Procedures

        /// <summary>
        /// Вычисляет личные числа по дате
        /// </summary>
        private void CalculatePersonalNumbers()
        {
            //if (PersonalNumbers == null)
            //{
            //    PersonalNumbers = new PersonalNumbers();
            //}

            ClearPersonalDays();

            _personalNumbersCalculator = new PersonalNumbersCalculator(PersonalNumbers.CalcDate.Date, true);

            PersonalNumbers.PersonalYearNumber = _personalNumbersCalculator.GetPersonalYearNumber();

            PersonalNumbers.JanuaryNumber = _personalNumbersCalculator.GetMonthNum(1);
            PersonalNumbers.FebruaryNumber = _personalNumbersCalculator.GetMonthNum(2);
            PersonalNumbers.MarchNumber = _personalNumbersCalculator.GetMonthNum(3);
            PersonalNumbers.AprilNumber = _personalNumbersCalculator.GetMonthNum(4);
            PersonalNumbers.MayNumber = _personalNumbersCalculator.GetMonthNum(5);
            PersonalNumbers.JuneNumber = _personalNumbersCalculator.GetMonthNum(6);
            PersonalNumbers.JulyNumber = _personalNumbersCalculator.GetMonthNum(7);
            PersonalNumbers.AugustNumber = _personalNumbersCalculator.GetMonthNum(8);
            PersonalNumbers.SeptemberNumber = _personalNumbersCalculator.GetMonthNum(9);
            PersonalNumbers.OctoberNumber = _personalNumbersCalculator.GetMonthNum(10);
            PersonalNumbers.NovemberNumber = _personalNumbersCalculator.GetMonthNum(11);
            PersonalNumbers.DecemberNumber = _personalNumbersCalculator.GetMonthNum(12);

            RaisePropertyChanged("PersonalNumbers");
            //FirstPerson = nullCalculateUniversalNumbers
        }

        /// <summary>
        /// Вычисляет универсальные числа по дате
        /// </summary>
        private void CalculateUniversalNumbers()
        {
            _universalNumbersCalculator = new UniversalNumbersCalculator(PersonalNumbers.CalcDate.Date, true);

            UniversalNumbers.UniversalYearNumber = _universalNumbersCalculator.GetUniversalYearNumber();

            UniversalNumbers.JanuaryNumber = _universalNumbersCalculator.GetMonthNum(1);
            UniversalNumbers.FebruaryNumber = _universalNumbersCalculator.GetMonthNum(2);
            UniversalNumbers.MarchNumber = _universalNumbersCalculator.GetMonthNum(3);
            UniversalNumbers.AprilNumber = _universalNumbersCalculator.GetMonthNum(4);
            UniversalNumbers.MayNumber = _universalNumbersCalculator.GetMonthNum(5);
            UniversalNumbers.JuneNumber = _universalNumbersCalculator.GetMonthNum(6);
            UniversalNumbers.JulyNumber = _universalNumbersCalculator.GetMonthNum(7);
            UniversalNumbers.AugustNumber = _universalNumbersCalculator.GetMonthNum(8);
            UniversalNumbers.SeptemberNumber = _universalNumbersCalculator.GetMonthNum(9);
            UniversalNumbers.OctoberNumber = _universalNumbersCalculator.GetMonthNum(10);
            UniversalNumbers.NovemberNumber = _universalNumbersCalculator.GetMonthNum(11);
            UniversalNumbers.DecemberNumber = _universalNumbersCalculator.GetMonthNum(12);

            RaisePropertyChanged("UniversalNumbers");
        }

        private void CalculatePersonalDays(int monthNumber)
        {

            int firstMonthValue = _personalNumbersCalculator.GetFirstValueOfSelectedMonth(monthNumber);

            int daysInMonthCount = DateTime.DaysInMonth(PersonalNumbers.CalcDate.Year, monthNumber);

            if (firstMonthValue == 1)
            {
                PersonalNumbers.Day1 = 1;
                PersonalNumbers.Day2 = 2;
                PersonalNumbers.Day3 = 3;
                PersonalNumbers.Day4 = 4;
                PersonalNumbers.Day5 = 5;
                PersonalNumbers.Day6 = 6;
                PersonalNumbers.Day7 = 7;
                PersonalNumbers.Day8 = 8;
                PersonalNumbers.Day9 = 9;
                PersonalNumbers.Day10 = 10;
                PersonalNumbers.Day11 = 11;
                PersonalNumbers.Day12 = 12;
                PersonalNumbers.Day13 = 13;
                PersonalNumbers.Day14 = 14;
                PersonalNumbers.Day15 = 15;
                PersonalNumbers.Day16 = 16;
                PersonalNumbers.Day17 = 17;
                PersonalNumbers.Day18 = 18;
                PersonalNumbers.Day19 = 19;
                PersonalNumbers.Day20 = 20;
                PersonalNumbers.Day21 = 21;
                PersonalNumbers.Day22 = 22;
                PersonalNumbers.Day23 = 23;
                PersonalNumbers.Day24 = 24;
                PersonalNumbers.Day25 = 25;
                PersonalNumbers.Day26 = 26;
                PersonalNumbers.Day27 = 27;
                PersonalNumbers.Day28 = 28;

                if (daysInMonthCount >= 29)
                {
                    PersonalNumbers.Day29 = 29;
                }
                else
                {
                    PersonalNumbers.Day29 = null;
                }

                if (daysInMonthCount >= 30)
                {
                    PersonalNumbers.Day30 = 30;
                }
                else
                {
                    PersonalNumbers.Day30 = null;
                }

                if (daysInMonthCount == 31)
                {
                    PersonalNumbers.Day31 = 31;
                }
                else
                {
                    PersonalNumbers.Day31 = null;
                }

                PersonalNumbers.Day32 = null;
                PersonalNumbers.Day33 = null;
                PersonalNumbers.Day34 = null;
                PersonalNumbers.Day35 = null;
                PersonalNumbers.Day36 = null;
                PersonalNumbers.Day37 = null;
                PersonalNumbers.Day38 = null;
                PersonalNumbers.Day39 = null;
                PersonalNumbers.Day40 = null;
            }
            else if (firstMonthValue == 2)
            {
                PersonalNumbers.Day1 = null;
                PersonalNumbers.Day2 = 1;
                PersonalNumbers.Day3 = 2;
                PersonalNumbers.Day4 = 3;
                PersonalNumbers.Day5 = 4;
                PersonalNumbers.Day6 = 5;
                PersonalNumbers.Day7 = 6;
                PersonalNumbers.Day8 = 7;
                PersonalNumbers.Day9 = 8;
                PersonalNumbers.Day10 = 9;
                PersonalNumbers.Day11 = 10;
                PersonalNumbers.Day12 = 11;
                PersonalNumbers.Day13 = 12;
                PersonalNumbers.Day14 = 13;
                PersonalNumbers.Day15 = 14;
                PersonalNumbers.Day16 = 15;
                PersonalNumbers.Day17 = 16;
                PersonalNumbers.Day18 = 17;
                PersonalNumbers.Day19 = 18;
                PersonalNumbers.Day20 = 19;
                PersonalNumbers.Day21 = 20;
                PersonalNumbers.Day22 = 21;
                PersonalNumbers.Day23 = 22;
                PersonalNumbers.Day24 = 23;
                PersonalNumbers.Day25 = 24;
                PersonalNumbers.Day26 = 25;
                PersonalNumbers.Day27 = 26;
                PersonalNumbers.Day28 = 27;
                PersonalNumbers.Day29 = 28;

                if (daysInMonthCount >= 29)
                {
                    PersonalNumbers.Day30 = 29;
                }
                else
                {
                    PersonalNumbers.Day30 = null;
                }

                if (daysInMonthCount >= 30)
                {
                    PersonalNumbers.Day31 = 30;
                }
                else
                {
                    PersonalNumbers.Day31 = null;
                }

                if (daysInMonthCount == 31)
                {
                    PersonalNumbers.Day32 = 31;
                }
                else
                {
                    PersonalNumbers.Day32 = null;
                }

                PersonalNumbers.Day33 = null;
                PersonalNumbers.Day34 = null;
                PersonalNumbers.Day35 = null;
                PersonalNumbers.Day36 = null;
                PersonalNumbers.Day37 = null;
                PersonalNumbers.Day38 = null;
                PersonalNumbers.Day39 = null;
                PersonalNumbers.Day40 = null;
            }
            else if (firstMonthValue == 3)
            {
                PersonalNumbers.Day1 = null;
                PersonalNumbers.Day2 = null;
                PersonalNumbers.Day3 = 1;
                PersonalNumbers.Day4 = 2;
                PersonalNumbers.Day5 = 3;
                PersonalNumbers.Day6 = 4;
                PersonalNumbers.Day7 = 5;
                PersonalNumbers.Day8 = 6;
                PersonalNumbers.Day9 = 7;
                PersonalNumbers.Day10 = 8;
                PersonalNumbers.Day11 = 9;
                PersonalNumbers.Day12 = 10;
                PersonalNumbers.Day13 = 11;
                PersonalNumbers.Day14 = 12;
                PersonalNumbers.Day15 = 13;
                PersonalNumbers.Day16 = 14;
                PersonalNumbers.Day17 = 15;
                PersonalNumbers.Day18 = 16;
                PersonalNumbers.Day19 = 17;
                PersonalNumbers.Day20 = 18;
                PersonalNumbers.Day21 = 19;
                PersonalNumbers.Day22 = 20;
                PersonalNumbers.Day23 = 21;
                PersonalNumbers.Day24 = 22;
                PersonalNumbers.Day25 = 23;
                PersonalNumbers.Day26 = 24;
                PersonalNumbers.Day27 = 25;
                PersonalNumbers.Day28 = 26;
                PersonalNumbers.Day29 = 27;
                PersonalNumbers.Day30 = 28;

                if (daysInMonthCount >= 29)
                {
                    PersonalNumbers.Day31 = 29;
                }
                else
                {
                    PersonalNumbers.Day31 = null;
                }

                if (daysInMonthCount >= 30)
                {
                    PersonalNumbers.Day32 = 30;
                }
                else
                {
                    PersonalNumbers.Day32 = null;
                }

                if (daysInMonthCount == 31)
                {
                    PersonalNumbers.Day33 = 31;
                }
                else
                {
                    PersonalNumbers.Day33 = null;
                }

                PersonalNumbers.Day34 = null;
                PersonalNumbers.Day35 = null;
                PersonalNumbers.Day36 = null;
                PersonalNumbers.Day37 = null;
                PersonalNumbers.Day38 = null;
                PersonalNumbers.Day39 = null;
                PersonalNumbers.Day40 = null;
            }
            else if (firstMonthValue == 4)
            {
                PersonalNumbers.Day1 = null;
                PersonalNumbers.Day2 = null;
                PersonalNumbers.Day3 = null;
                PersonalNumbers.Day4 = 1;
                PersonalNumbers.Day5 = 2;
                PersonalNumbers.Day6 = 3;
                PersonalNumbers.Day7 = 4;
                PersonalNumbers.Day8 = 5;
                PersonalNumbers.Day9 = 6;
                PersonalNumbers.Day10 = 7;
                PersonalNumbers.Day11 = 8;
                PersonalNumbers.Day12 = 9;
                PersonalNumbers.Day13 = 10;
                PersonalNumbers.Day14 = 11;
                PersonalNumbers.Day15 = 12;
                PersonalNumbers.Day16 = 13;
                PersonalNumbers.Day17 = 14;
                PersonalNumbers.Day18 = 15;
                PersonalNumbers.Day19 = 16;
                PersonalNumbers.Day20 = 17;
                PersonalNumbers.Day21 = 18;
                PersonalNumbers.Day22 = 19;
                PersonalNumbers.Day23 = 20;
                PersonalNumbers.Day24 = 21;
                PersonalNumbers.Day25 = 22;
                PersonalNumbers.Day26 = 23;
                PersonalNumbers.Day27 = 24;
                PersonalNumbers.Day28 = 25;
                PersonalNumbers.Day29 = 26;
                PersonalNumbers.Day30 = 27;
                PersonalNumbers.Day31 = 28;

                if (daysInMonthCount >= 29)
                {
                    PersonalNumbers.Day32 = 29;
                }
                else
                {
                    PersonalNumbers.Day32 = null;
                }

                if (daysInMonthCount >= 30)
                {
                    PersonalNumbers.Day33 = 30;
                }
                else
                {
                    PersonalNumbers.Day33 = null;
                }

                if (daysInMonthCount == 31)
                {
                    PersonalNumbers.Day34 = 31;
                }
                else
                {
                    PersonalNumbers.Day34 = null;
                }

                PersonalNumbers.Day35 = null;
                PersonalNumbers.Day36 = null;
                PersonalNumbers.Day37 = null;
                PersonalNumbers.Day38 = null;
                PersonalNumbers.Day39 = null;
                PersonalNumbers.Day40 = null;
            }
            else if (firstMonthValue == 5)
            {
                PersonalNumbers.Day1 = null;
                PersonalNumbers.Day2 = null;
                PersonalNumbers.Day3 = null;
                PersonalNumbers.Day4 = null;
                PersonalNumbers.Day5 = 1;
                PersonalNumbers.Day6 = 2;
                PersonalNumbers.Day7 = 3;
                PersonalNumbers.Day8 = 4;
                PersonalNumbers.Day9 = 5;
                PersonalNumbers.Day10 = 6;
                PersonalNumbers.Day11 = 7;
                PersonalNumbers.Day12 = 8;
                PersonalNumbers.Day13 = 9;
                PersonalNumbers.Day14 = 10;
                PersonalNumbers.Day15 = 11;
                PersonalNumbers.Day16 = 12;
                PersonalNumbers.Day17 = 13;
                PersonalNumbers.Day18 = 14;
                PersonalNumbers.Day19 = 15;
                PersonalNumbers.Day20 = 16;
                PersonalNumbers.Day21 = 17;
                PersonalNumbers.Day22 = 18;
                PersonalNumbers.Day23 = 19;
                PersonalNumbers.Day24 = 20;
                PersonalNumbers.Day25 = 21;
                PersonalNumbers.Day26 = 22;
                PersonalNumbers.Day27 = 23;
                PersonalNumbers.Day28 = 24;
                PersonalNumbers.Day29 = 25;
                PersonalNumbers.Day30 = 26;
                PersonalNumbers.Day31 = 27;
                PersonalNumbers.Day32 = 28;

                if (daysInMonthCount >= 29)
                {
                    PersonalNumbers.Day33 = 29;
                }
                else
                {
                    PersonalNumbers.Day33 = null;
                }

                if (daysInMonthCount >= 30)
                {
                    PersonalNumbers.Day34 = 30;
                }
                else
                {
                    PersonalNumbers.Day34 = null;
                }

                if (daysInMonthCount == 31)
                {
                    PersonalNumbers.Day35 = 31;
                }
                else
                {
                    PersonalNumbers.Day35 = null;
                }

                PersonalNumbers.Day36 = null;
                PersonalNumbers.Day37 = null;
                PersonalNumbers.Day38 = null;
                PersonalNumbers.Day39 = null;
                PersonalNumbers.Day40 = null;
            }
            else if (firstMonthValue == 6)
            {
                PersonalNumbers.Day1 = null;
                PersonalNumbers.Day2 = null;
                PersonalNumbers.Day3 = null;
                PersonalNumbers.Day4 = null;
                PersonalNumbers.Day5 = null;
                PersonalNumbers.Day6 = 1;
                PersonalNumbers.Day7 = 2;
                PersonalNumbers.Day8 = 3;
                PersonalNumbers.Day9 = 4;
                PersonalNumbers.Day10 = 5;
                PersonalNumbers.Day11 = 6;
                PersonalNumbers.Day12 = 7;
                PersonalNumbers.Day13 = 8;
                PersonalNumbers.Day14 = 9;
                PersonalNumbers.Day15 = 10;
                PersonalNumbers.Day16 = 11;
                PersonalNumbers.Day17 = 12;
                PersonalNumbers.Day18 = 13;
                PersonalNumbers.Day19 = 14;
                PersonalNumbers.Day20 = 15;
                PersonalNumbers.Day21 = 16;
                PersonalNumbers.Day22 = 17;
                PersonalNumbers.Day23 = 18;
                PersonalNumbers.Day24 = 19;
                PersonalNumbers.Day25 = 20;
                PersonalNumbers.Day26 = 21;
                PersonalNumbers.Day27 = 22;
                PersonalNumbers.Day28 = 23;
                PersonalNumbers.Day29 = 24;
                PersonalNumbers.Day30 = 25;
                PersonalNumbers.Day31 = 26;
                PersonalNumbers.Day32 = 27;
                PersonalNumbers.Day33 = 28;

                if (daysInMonthCount >= 29)
                {
                    PersonalNumbers.Day34 = 29;
                }
                else
                {
                    PersonalNumbers.Day34 = null;
                }

                if (daysInMonthCount >= 30)
                {
                    PersonalNumbers.Day35 = 30;
                }
                else
                {
                    PersonalNumbers.Day35 = null;
                }

                if (daysInMonthCount == 31)
                {
                    PersonalNumbers.Day36 = 31;
                }
                else
                {
                    PersonalNumbers.Day36 = null;
                }

                PersonalNumbers.Day37 = null;
                PersonalNumbers.Day38 = null;
                PersonalNumbers.Day39 = null;
                PersonalNumbers.Day40 = null;
            }
            else if (firstMonthValue == 7)
            {
                PersonalNumbers.Day1 = null;
                PersonalNumbers.Day2 = null;
                PersonalNumbers.Day3 = null;
                PersonalNumbers.Day4 = null;
                PersonalNumbers.Day5 = null;
                PersonalNumbers.Day6 = null;
                PersonalNumbers.Day7 = 1;
                PersonalNumbers.Day8 = 2;
                PersonalNumbers.Day9 = 3;
                PersonalNumbers.Day10 = 4;
                PersonalNumbers.Day11 = 5;
                PersonalNumbers.Day12 = 6;
                PersonalNumbers.Day13 = 7;
                PersonalNumbers.Day14 = 8;
                PersonalNumbers.Day15 = 9;
                PersonalNumbers.Day16 = 10;
                PersonalNumbers.Day17 = 11;
                PersonalNumbers.Day18 = 12;
                PersonalNumbers.Day19 = 13;
                PersonalNumbers.Day20 = 14;
                PersonalNumbers.Day21 = 15;
                PersonalNumbers.Day22 = 16;
                PersonalNumbers.Day23 = 17;
                PersonalNumbers.Day24 = 18;
                PersonalNumbers.Day25 = 19;
                PersonalNumbers.Day26 = 20;
                PersonalNumbers.Day27 = 21;
                PersonalNumbers.Day28 = 22;
                PersonalNumbers.Day29 = 23;
                PersonalNumbers.Day30 = 24;
                PersonalNumbers.Day31 = 25;
                PersonalNumbers.Day32 = 26;
                PersonalNumbers.Day33 = 27;
                PersonalNumbers.Day34 = 28;

                if (daysInMonthCount >= 29)
                {
                    PersonalNumbers.Day35 = 29;
                }
                else
                {
                    PersonalNumbers.Day35 = null;
                }

                if (daysInMonthCount >= 30)
                {
                    PersonalNumbers.Day36 = 30;
                }
                else
                {
                    PersonalNumbers.Day36 = null;
                }

                if (daysInMonthCount == 31)
                {
                    PersonalNumbers.Day37 = 31;
                }
                else
                {
                    PersonalNumbers.Day37 = null;
                }

                PersonalNumbers.Day38 = null;
                PersonalNumbers.Day39 = null;
                PersonalNumbers.Day40 = null;
            }
            else if (firstMonthValue == 8)
            {
                PersonalNumbers.Day1 = null;
                PersonalNumbers.Day2 = null;
                PersonalNumbers.Day3 = null;
                PersonalNumbers.Day4 = null;
                PersonalNumbers.Day5 = null;
                PersonalNumbers.Day6 = null;
                PersonalNumbers.Day7 = null;
                PersonalNumbers.Day8 = 1;
                PersonalNumbers.Day9 = 2;
                PersonalNumbers.Day10 = 3;
                PersonalNumbers.Day11 = 4;
                PersonalNumbers.Day12 = 5;
                PersonalNumbers.Day13 = 6;
                PersonalNumbers.Day14 = 7;
                PersonalNumbers.Day15 = 8;
                PersonalNumbers.Day16 = 9;
                PersonalNumbers.Day17 = 10;
                PersonalNumbers.Day18 = 11;
                PersonalNumbers.Day19 = 12;
                PersonalNumbers.Day20 = 13;
                PersonalNumbers.Day21 = 14;
                PersonalNumbers.Day22 = 15;
                PersonalNumbers.Day23 = 16;
                PersonalNumbers.Day24 = 17;
                PersonalNumbers.Day25 = 18;
                PersonalNumbers.Day26 = 19;
                PersonalNumbers.Day27 = 20;
                PersonalNumbers.Day28 = 21;
                PersonalNumbers.Day29 = 22;
                PersonalNumbers.Day30 = 23;
                PersonalNumbers.Day31 = 24;
                PersonalNumbers.Day32 = 25;
                PersonalNumbers.Day33 = 26;
                PersonalNumbers.Day34 = 27;
                PersonalNumbers.Day35 = 28;

                if (daysInMonthCount >= 29)
                {
                    PersonalNumbers.Day36 = 29;
                }
                else
                {
                    PersonalNumbers.Day36 = null;
                }

                if (daysInMonthCount >= 30)
                {
                    PersonalNumbers.Day37 = 30;
                }
                else
                {
                    PersonalNumbers.Day37 = null;
                }

                if (daysInMonthCount == 31)
                {
                    PersonalNumbers.Day38 = 31;
                }
                else
                {
                    PersonalNumbers.Day38 = null;
                }

                PersonalNumbers.Day39 = null;
                PersonalNumbers.Day40 = null;
            }
            else if (firstMonthValue == 9)
            {
                PersonalNumbers.Day1 = null;
                PersonalNumbers.Day2 = null;
                PersonalNumbers.Day3 = null;
                PersonalNumbers.Day4 = null;
                PersonalNumbers.Day5 = null;
                PersonalNumbers.Day6 = null;
                PersonalNumbers.Day7 = null;
                PersonalNumbers.Day8 = null;
                PersonalNumbers.Day9 = 1;
                PersonalNumbers.Day10 = 2;
                PersonalNumbers.Day11 = 3;
                PersonalNumbers.Day12 = 4;
                PersonalNumbers.Day13 = 5;
                PersonalNumbers.Day14 = 6;
                PersonalNumbers.Day15 = 7;
                PersonalNumbers.Day16 = 8;
                PersonalNumbers.Day17 = 9;
                PersonalNumbers.Day18 = 10;
                PersonalNumbers.Day19 = 11;
                PersonalNumbers.Day20 = 12;
                PersonalNumbers.Day21 = 13;
                PersonalNumbers.Day22 = 14;
                PersonalNumbers.Day23 = 15;
                PersonalNumbers.Day24 = 16;
                PersonalNumbers.Day25 = 17;
                PersonalNumbers.Day26 = 18;
                PersonalNumbers.Day27 = 19;
                PersonalNumbers.Day28 = 20;
                PersonalNumbers.Day29 = 21;
                PersonalNumbers.Day30 = 22;
                PersonalNumbers.Day31 = 23;
                PersonalNumbers.Day32 = 24;
                PersonalNumbers.Day33 = 25;
                PersonalNumbers.Day34 = 26;
                PersonalNumbers.Day35 = 27;
                PersonalNumbers.Day36 = 28;

                if (daysInMonthCount >= 29)
                {
                    PersonalNumbers.Day37 = 29;
                }
                else
                {
                    PersonalNumbers.Day37 = null;
                }

                if (daysInMonthCount >= 30)
                {
                    PersonalNumbers.Day38 = 30;
                }
                else
                {
                    PersonalNumbers.Day38 = null;
                }

                if (daysInMonthCount == 31)
                {
                    PersonalNumbers.Day39 = 31;
                }
                else
                {
                    PersonalNumbers.Day39 = null;
                }

                PersonalNumbers.Day40 = null;
            }
            RaisePropertyChanged("PersonalNumbers");
        }

        private void ClearPersonalDays()
        {
            PersonalNumbers.Day1 = null;
            PersonalNumbers.Day2 = null;
            PersonalNumbers.Day3 = null;
            PersonalNumbers.Day4 = null;
            PersonalNumbers.Day5 = null;
            PersonalNumbers.Day6 = null;
            PersonalNumbers.Day7 = null;
            PersonalNumbers.Day8 = null;
            PersonalNumbers.Day9 = null;
            PersonalNumbers.Day10 = null;
            PersonalNumbers.Day11 = null;
            PersonalNumbers.Day12 = null;
            PersonalNumbers.Day13 = null;
            PersonalNumbers.Day14 = null;
            PersonalNumbers.Day15 = null;
            PersonalNumbers.Day16 = null;
            PersonalNumbers.Day17 = null;
            PersonalNumbers.Day18 = null;
            PersonalNumbers.Day19 = null;
            PersonalNumbers.Day20 = null;
            PersonalNumbers.Day21 = null;
            PersonalNumbers.Day22 = null;
            PersonalNumbers.Day23 = null;
            PersonalNumbers.Day24 = null;
            PersonalNumbers.Day25 = null;
            PersonalNumbers.Day26 = null;
            PersonalNumbers.Day27 = null;
            PersonalNumbers.Day28 = null;
            PersonalNumbers.Day29 = null;
            PersonalNumbers.Day30 = null;
            PersonalNumbers.Day31 = null;
            PersonalNumbers.Day32 = null;
            PersonalNumbers.Day33 = null;
            PersonalNumbers.Day34 = null;
            PersonalNumbers.Day35 = null;
            PersonalNumbers.Day36 = null;
            PersonalNumbers.Day37 = null;
            PersonalNumbers.Day38 = null;
            PersonalNumbers.Day39 = null;
            PersonalNumbers.Day40 = null;
        }



        #endregion

        #region Functions

        #endregion

        #region Properties (bindings)

        public PersonalNumbers PersonalNumbers
        {
            get
            {
                return _personalNumbers;
            }
            set
            {
                if (_personalNumbers != value)
                {
                    _personalNumbers = value;
                    RaisePropertyChanged("PersonalNumbers");
                }
            }
        }

        public UniversalNumbers UniversalNumbers
        {
            get
            {
                return _universalNumbers;
            }
            set
            {
                if (_universalNumbers != value)
                {
                    _universalNumbers = value;
                    RaisePropertyChanged("UniversalNumbers");
                }
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
