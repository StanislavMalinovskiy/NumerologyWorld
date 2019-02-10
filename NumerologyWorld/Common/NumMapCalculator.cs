using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Numerology.Model;

namespace Numerology.Common
{
    public class NumMapCalculator
    {
        #region Declarations

        private int _identityNum;
        private int _soulNum;
        private int _destinyNum;
        private int _lifePathNum;
        private int _maturityNum;
        private int _growthNum;
        private int _cashNum;

        private string _firstPeakSimple;
        private string _secondPeakSimple;

        private string _firstProblemSimple;
        private string _secondProblemSimple;

        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string SecondName { get; set; }
        public bool CalcLifePathSeparately { get; set; }
        private DateTime? BirthDate { get; set; }
        private int DayOfBirthNum { get; set; }
        private int Age { get; set; }
        public string CurrentCycle { get; private set; }
        public string CurrentPeak { get; private set; }
        //public string CurrentProblem { get; private set; }

        private int? _currentProblemNumber;

        public string FirstRowPsychomatrix;
        public string SecondRowPsychomatrix;

        public string TopLeftPsychoNumber;
        public string TopCenterPsychoNumber;
        public string TopRightPsychoNumber;

        public string CenterLeftPsychoNumber;
        public string CenterPsychoNumber;
        public string CenterRightPsychoNumber;

        public string BottomLeftPsychoNumber;
        public string BottomCenterPsychoNumber;
        public string BottomRightPsychoNumber;

        #endregion

        #region Constructor

        public NumMapCalculator(string firstName, string lastName, string secondName, DateTime? birthDate,
            bool calcLifePathSeparately)
        {
            CalcLifePathSeparately = calcLifePathSeparately;

            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;
            BirthDate = birthDate;

            DayOfBirthNum = GetDayOfBirth /*Возвращает день рождения*/();
            Age = GetAge();
        }

        #endregion

        #region Procedures

        /// <summary>
        /// Вычисляет психоматрицу
        /// </summary>
        public void CalculatePsychomatrix()
        {
            string fullDateString = null;
            string secondRowPsychomatrix = null;
            string firstAndSecondRowPsychomatrix = null;
            int firstDigit = 0;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (BirthDate != null)
            {
                fullDateString = DayOfBirthNum.ToString() + BirthDate.Value.Month.ToString() +
                                 BirthDate.Value.Year.ToString();
                firstDigit = Convert.ToInt16(fullDateString.Substring(0, 1));
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (fullDateString != null)
            {
                int digit1 = Convert.ToInt16(fullDateString.Substring(0, 1));
                int digit2 = Convert.ToInt16(fullDateString.Substring(1, 1));
                int digit3 = Convert.ToInt16(fullDateString.Substring(2, 1));
                int digit4 = Convert.ToInt16(fullDateString.Substring(3, 1));
                int digit5 = Convert.ToInt16(fullDateString.Substring(4, 1));
                int digit6 = Convert.ToInt16(fullDateString.Substring(5, 1));
                int digit7 = 0;
                int digit8 = 0;

                if (fullDateString.Length > 6)
                {
                    digit7 = Convert.ToInt16(fullDateString.Substring(6, 1));
                }
                if (fullDateString.Length > 7)
                {
                    digit8 = Convert.ToInt16(fullDateString.Substring(7, 1));
                }


                int lpNum = digit1 + digit2 + digit3 + digit4 + digit5 + digit6 + digit7 + digit8;

                var lpString = Convert.ToString(lpNum).Replace("0", "");

                secondRowPsychomatrix = lpString + GetNaturalNumberIntForPsichomatrix(lpNum);

                var firstDigitx2 = firstDigit * 2;

                if (lpNum >= firstDigitx2)
                {
                    var lpNumMinusFirstDigitx2 = lpNum - firstDigitx2;
                    secondRowPsychomatrix += lpNumMinusFirstDigitx2;
                    secondRowPsychomatrix += GetNaturalNumberIntForPsichomatrix(lpNumMinusFirstDigitx2);
                }

                firstAndSecondRowPsychomatrix = fullDateString + secondRowPsychomatrix;
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (fullDateString != null) FirstRowPsychomatrix = fullDateString.Replace("0", "");

            SecondRowPsychomatrix = secondRowPsychomatrix;

            if (firstAndSecondRowPsychomatrix != null && firstAndSecondRowPsychomatrix.Count(c => c == '3') == 0)
            {
                TopLeftPsychoNumber = '\u2013'.ToString();
            }
            else
            {
                if (firstAndSecondRowPsychomatrix != null)
                    TopLeftPsychoNumber = new string('3', firstAndSecondRowPsychomatrix.Count(c => c == '3'));
            }

            if (firstAndSecondRowPsychomatrix != null && firstAndSecondRowPsychomatrix.Count(c => c == '6') == 0)
            {
                TopCenterPsychoNumber = '\u2013'.ToString();
            }
            else
            {
                if (firstAndSecondRowPsychomatrix != null)
                    TopCenterPsychoNumber = new string('6', firstAndSecondRowPsychomatrix.Count(c => c == '6'));
            }

            if (firstAndSecondRowPsychomatrix != null && firstAndSecondRowPsychomatrix.Count(c => c == '9') == 0)
            {
                TopRightPsychoNumber = '\u2013'.ToString();
            }
            else
            {
                if (firstAndSecondRowPsychomatrix != null)
                    TopRightPsychoNumber = new string('9', firstAndSecondRowPsychomatrix.Count(c => c == '9'));
            }

            if (firstAndSecondRowPsychomatrix != null && firstAndSecondRowPsychomatrix.Count(c => c == '2') == 0)
            {
                CenterLeftPsychoNumber = '\u2013'.ToString();
            }
            else
            {
                if (firstAndSecondRowPsychomatrix != null)
                    CenterLeftPsychoNumber = new string('2', firstAndSecondRowPsychomatrix.Count(c => c == '2'));
            }

            if (firstAndSecondRowPsychomatrix != null && firstAndSecondRowPsychomatrix.Count(c => c == '5') == 0)
            {
                CenterPsychoNumber = '\u2013'.ToString();
            }
            else
            {
                if (firstAndSecondRowPsychomatrix != null)
                    CenterPsychoNumber = new string('5', firstAndSecondRowPsychomatrix.Count(c => c == '5'));
            }

            if (firstAndSecondRowPsychomatrix != null && firstAndSecondRowPsychomatrix.Count(c => c == '8') == 0)
            {
                CenterRightPsychoNumber = '\u2013'.ToString();
            }
            else
            {
                if (firstAndSecondRowPsychomatrix != null)
                    CenterRightPsychoNumber = new string('8', firstAndSecondRowPsychomatrix.Count(c => c == '8'));
            }

            if (firstAndSecondRowPsychomatrix != null && firstAndSecondRowPsychomatrix.Count(c => c == '1') == 0)
            {
                BottomLeftPsychoNumber = '\u2013'.ToString();
            }
            else
            {
                if (firstAndSecondRowPsychomatrix != null)
                    BottomLeftPsychoNumber = new string('1', firstAndSecondRowPsychomatrix.Count(c => c == '1'));
            }

            if (firstAndSecondRowPsychomatrix != null && firstAndSecondRowPsychomatrix.Count(c => c == '4') == 0)
            {
                BottomCenterPsychoNumber = '\u2013'.ToString();
            }
            else
            {
                if (firstAndSecondRowPsychomatrix != null)
                    BottomCenterPsychoNumber = new string('4', firstAndSecondRowPsychomatrix.Count(c => c == '4'));
            }

            if (firstAndSecondRowPsychomatrix != null && firstAndSecondRowPsychomatrix.Count(c => c == '7') == 0)
            {
                BottomRightPsychoNumber = '\u2013'.ToString();
            }
            else
            {
                if (firstAndSecondRowPsychomatrix != null)
                    BottomRightPsychoNumber = new string('7', firstAndSecondRowPsychomatrix.Count(c => c == '7'));
            }
        }

        //private void ClearValues()
        //{
        //    _lifePathNum = 0;
        //    _maturityNum = 0;
        //    _cashNum = 0;

        //    _firstPeakSimple = null;
        //    _secondPeakSimple = null;

        //    _firstProblemSimple = null;
        //    _secondProblemSimple = null;
        //}

        #endregion

        #region Functions

        /// <summary>
        /// Возвращает число души
        /// </summary>
        /// <returns></returns>
        public string GetSoulNumber()
        {
            int lastNameSoulNumber = 0;
            int firstNameSoulNumber = 0;
            int secondNameSoulNumber = 0;

            /*---------------------------------------------------------------------------------------------------------------------*/
            /*Получить число души по фамилии*/
            foreach (var achar in LastName.ToLower())
            {
                if (char.IsLetter(achar))
                {
                    if (CharCodes.vowelLellers.Contains(achar))
                    {
                        lastNameSoulNumber += CharCodes.GetCharCode(achar);
                    }
                }
            }

            lastNameSoulNumber = GetNaturalNumberInt(lastNameSoulNumber);

            /*---------------------------------------------------------------------------------------------------------------------*/
            /*Получить число души по имени*/
            foreach (var achar in FirstName.ToLower())
            {
                if (char.IsLetter(achar))
                {
                    if (CharCodes.vowelLellers.Contains(achar))
                    {
                        firstNameSoulNumber += CharCodes.GetCharCode(achar);
                    }
                }
            }

            firstNameSoulNumber = GetNaturalNumberInt(firstNameSoulNumber);

            /*---------------------------------------------------------------------------------------------------------------------*/

            if (SecondName != null)
            {
                /*Получить число души по отчеству*/
                foreach (var achar in SecondName.ToLower())
                {
                    if (char.IsLetter(achar))
                    {
                        if (CharCodes.vowelLellers.Contains(achar))
                        {
                            secondNameSoulNumber += CharCodes.GetCharCode(achar);
                        }
                    }
                }

                secondNameSoulNumber = GetNaturalNumberInt(secondNameSoulNumber);
            }

            _soulNum = lastNameSoulNumber + firstNameSoulNumber + secondNameSoulNumber;


            return GetNaturalNumberString(_soulNum);
        }

        /// <summary>
        /// Возвращает число личности
        /// </summary>
        /// <returns></returns>
        public string GetIdentityNumber()
        {
            int lastNameIdentityNumber = 0;
            int firstNameIdentityNumber = 0;
            int secondNameIdentityNumber = 0;

            /*---------------------------------------------------------------------------------------------------------------------*/
            /*Получить число души по фамилии*/
            foreach (var achar in LastName.ToLower())
            {
                if (char.IsLetter(achar))
                {
                    if (CharCodes.consonantLellers.Contains(achar))
                    {
                        lastNameIdentityNumber += CharCodes.GetCharCode(achar);
                    }
                }
            }

            lastNameIdentityNumber = GetNaturalNumberInt(lastNameIdentityNumber);

            /*---------------------------------------------------------------------------------------------------------------------*/
            /*Получить число души по имени*/
            foreach (var achar in FirstName.ToLower())
            {
                if (char.IsLetter(achar))
                {
                    if (CharCodes.consonantLellers.Contains(achar))
                    {
                        firstNameIdentityNumber += CharCodes.GetCharCode(achar);
                    }
                }
            }

            firstNameIdentityNumber = GetNaturalNumberInt(firstNameIdentityNumber);

            /*---------------------------------------------------------------------------------------------------------------------*/
            if (SecondName != null)
            {
                /*Получить число души по отчеству*/
                foreach (var achar in SecondName.ToLower())
                {
                    if (char.IsLetter(achar))
                    {
                        if (CharCodes.consonantLellers.Contains(achar))
                        {
                            secondNameIdentityNumber += CharCodes.GetCharCode(achar);
                        }
                    }
                }

                secondNameIdentityNumber = GetNaturalNumberInt(secondNameIdentityNumber);
            }

            _identityNum = lastNameIdentityNumber + firstNameIdentityNumber + secondNameIdentityNumber;

            return GetNaturalNumberString(_identityNum);
        }

        public string GetDestinyNumber()
        {
            _destinyNum = GetNaturalNumberInt(_soulNum) + GetNaturalNumberInt(_identityNum);

            return GetNaturalNumberString(_destinyNum);
        }

        public string GetLifePathNumber()
        {
            var birthDateStrClear = "";

            if (BirthDate != null && BirthDate.Value != null)
            {
                var birthDateStr = BirthDate.Value.ToString().Substring(0, 10);

                /*Получить число души по фамилии*/
                foreach (var achar in birthDateStr)
                {
                    if (!char.IsPunctuation(achar))
                    {
                        birthDateStrClear += achar;
                    }
                }

                if (CalcLifePathSeparately)
                {
                    var dayOfBirthInt = GetNaturalNumberInt(BirthDate.Value.Day);
                    var monthOfBirthInt = GetNaturalNumberInt(BirthDate.Value.Month);
                    var yearOfBirthInt = GetNaturalNumberInt(BirthDate.Value.Year);

                    var dayOfBirthNatural = GetNaturalNumberInt(dayOfBirthInt);
                    var monthOfBirthNatural = GetNaturalNumberInt(monthOfBirthInt);
                    var yearOfBirthNatural = GetNaturalNumberInt(yearOfBirthInt);

                    _lifePathNum = dayOfBirthNatural + monthOfBirthNatural + yearOfBirthNatural;
                }
                else
                {
                    int digit1 = Convert.ToInt16(birthDateStrClear.Substring(0, 1));
                    int digit2 = Convert.ToInt16(birthDateStrClear.Substring(1, 1));
                    int digit3 = Convert.ToInt16(birthDateStrClear.Substring(2, 1));
                    int digit4 = Convert.ToInt16(birthDateStrClear.Substring(3, 1));
                    int digit5 = Convert.ToInt16(birthDateStrClear.Substring(4, 1));
                    int digit6 = Convert.ToInt16(birthDateStrClear.Substring(5, 1));
                    int digit7 = Convert.ToInt16(birthDateStrClear.Substring(6, 1));
                    int digit8 = Convert.ToInt16(birthDateStrClear.Substring(7, 1));

                    _lifePathNum = digit1 + digit2 + digit3 + digit4 + digit5 + digit6 + digit7 + digit8;
                }

                return GetNaturalNumberString(_lifePathNum);
            }
            else
            {
                return "";
            }
        }

        public string GetMaturityNumber()
        {
            if (_destinyNum == 0)
            {
                _destinyNum = 1;
            }
            _maturityNum = GetNaturalNumberInt(_lifePathNum) + GetNaturalNumberInt(_destinyNum);

            return GetNaturalNumberString(_maturityNum);
        }

        public string GetGrowthNumber()
        {
            int firstNameVowelNumber = 0;
            int firstNameConsonantNumber = 0;

            /*---------------------------------------------------------------------------------------------------------------------*/
            /*Получить число по гласным*/
            foreach (var achar in FirstName.ToLower())
            {
                if (char.IsLetter(achar))
                {
                    if (CharCodes.vowelLellers.Contains(achar))
                    {
                        firstNameVowelNumber += CharCodes.GetCharCode(achar);
                    }
                }
            }

            /*---------------------------------------------------------------------------------------------------------------------*/
            /*Получить число по согласным*/
            foreach (var achar in FirstName.ToLower())
            {
                if (char.IsLetter(achar))
                {
                    if (CharCodes.consonantLellers.Contains(achar))
                    {
                        firstNameConsonantNumber += CharCodes.GetCharCode(achar);
                    }
                }
            }

            firstNameVowelNumber = GetNaturalNumberInt(firstNameVowelNumber);
            firstNameConsonantNumber = GetNaturalNumberInt(firstNameConsonantNumber);

            _growthNum = firstNameVowelNumber + firstNameConsonantNumber;

            return GetNaturalNumberString(_growthNum);
        }


        public string GetCashNumber()
        {
            if (BirthDate != null)
            {
                string dayOfBirthNumbers = BirthDate.Value.Day.ToString() + BirthDate.Value.Month.ToString() +
                                           BirthDate.Value.Year.ToString();


                int birthDateNumbers = 0;
                foreach (var val in dayOfBirthNumbers)
                {
                    var strVal = val.ToString();
                    birthDateNumbers += Convert.ToInt16(strVal);
                }

                birthDateNumbers = GetNaturalNumberInt(birthDateNumbers);
                _cashNum = birthDateNumbers + GetNaturalNumberInt(_growthNum);
            }

            return GetNaturalNumberString(_cashNum);
        }

        public string GetNumerologyCode()
        {
            int resultValue = 0;

            if (BirthDate != null)
            {
                resultValue = 55 - ((BirthDate.Value.Month * 2) + BirthDate.Value.Day);
            }

            return resultValue.ToString();
        }

        public string GetFirstCycle()
        {
            int monthNum = 0;
            int endOfFirstCycle;

            if (BirthDate != null)
            {
                monthNum = BirthDate.Value.Month;
            }

            endOfFirstCycle = 36 - GetNaturalNumberInt(GetLifePathNumberNatural());

            var firstCycle = GetNaturalNumberString(monthNum) + " " + "(0 " + '\u2192' + " " + endOfFirstCycle + ")";


            if (Age >= 0 && Age <= endOfFirstCycle)
            {
                CurrentCycle = GetNaturalNumberInt(monthNum).ToString();
            }

            return firstCycle;
        }


        public string GetSecondCycle()
        {
            int endOfSecondCycle;

            int endOfFirstCycle = 36 - GetNaturalNumberInt(GetLifePathNumberNatural()) + 1;

            endOfSecondCycle = endOfFirstCycle + 26;

            var firstCycle = GetNaturalNumberString(DayOfBirthNum) + " " + "(" + endOfFirstCycle + " " + '\u2192' + " " +
                             endOfSecondCycle + ")";

            if (Age >= endOfFirstCycle && Age <= endOfSecondCycle)
            {
                CurrentCycle = GetNaturalNumberInt(DayOfBirthNum).ToString();
            }

            return firstCycle;
        }

        public string GetThirdCycle()
        {
            int endOfFirstCycle = 36 - GetNaturalNumberInt(GetLifePathNumberNatural()) + 1;

            int endOfSecondCycle = endOfFirstCycle + 27;

            int yearOfBirthInt = 0;
            if (BirthDate != null)
            {
                yearOfBirthInt = GetNaturalNumberInt(BirthDate.Value.Year);
            }

            var thirdCycle = GetNaturalNumberString(yearOfBirthInt) + " " + "(" + endOfSecondCycle + " " + '\u2192' +
                             "  )";

            if (Age >= endOfSecondCycle)
            {
                CurrentCycle = GetNaturalNumberInt(yearOfBirthInt).ToString();
            }

            return thirdCycle;
        }

        public string GetFirstPeak()
        {
            int monthNum = 0;
            int dayAndMonthNum;
            int endOfFirstPeak;

            if (BirthDate != null)
            {
                monthNum = BirthDate.Value.Month;
            }

            endOfFirstPeak = 36 - GetNaturalNumberInt(GetLifePathNumberNatural());

            dayAndMonthNum = GetNaturalNumberInt(DayOfBirthNum) + GetNaturalNumberInt(monthNum);
            _firstPeakSimple = GetNaturalNumberString(dayAndMonthNum);

            if (_firstPeakSimple.Length > 3)
            {
                _firstPeakSimple = _firstPeakSimple.Substring(3, 1);
            }

            var firstPeak = GetNaturalNumberString(dayAndMonthNum) + " " + "(0 " + '\u2192' + " " + endOfFirstPeak + ")";

            if (Age >= 0 && Age <= endOfFirstPeak)
            {
                CurrentPeak = GetNaturalNumberInt(dayAndMonthNum).ToString();
                _currentProblemNumber = 1;
            }

            return firstPeak;
        }


        public string GetSecondPeak()
        {
            int dayAndYearNum;

            int endOfFirstPeak;
            int endOfSecondPeak;

            endOfFirstPeak = 36 - GetNaturalNumberInt(GetLifePathNumberNatural());
            endOfSecondPeak = endOfFirstPeak + 9;

            int yearOfBirthInt = 0;
            if (BirthDate != null)
            {
                yearOfBirthInt = GetNaturalNumberInt(BirthDate.Value.Year);
            }

            dayAndYearNum = GetNaturalNumberInt(DayOfBirthNum) + GetNaturalNumberInt(yearOfBirthInt);
            _secondPeakSimple = GetNaturalNumberString(dayAndYearNum);

            if (_secondPeakSimple.Length > 3)
            {
                _secondPeakSimple = _secondPeakSimple.Substring(3, 1);
            }

            var secondPeak = GetNaturalNumberString(dayAndYearNum) + " " + "(" + endOfFirstPeak + " " + '\u2192' + " " +
                             endOfSecondPeak + ")";

            if (Age >= endOfFirstPeak && Age <= endOfSecondPeak)
            {
                CurrentPeak = GetNaturalNumberInt(dayAndYearNum).ToString();
                _currentProblemNumber = 2;
            }

            return secondPeak;
        }

        public string GetThirdPeak()
        {
            int firstPeakAndSecondPeakNum;

            int endOfSecondPeak;
            int endOfThirdPeak;

            endOfSecondPeak = 36 - GetNaturalNumberInt(GetLifePathNumberNatural()) + 9;
            endOfThirdPeak = endOfSecondPeak + 9;

            firstPeakAndSecondPeakNum = GetNaturalNumberInt(Convert.ToInt16(_firstPeakSimple)) +
                                        GetNaturalNumberInt(Convert.ToInt16(_secondPeakSimple));

            var thirdPeak = GetNaturalNumberString(firstPeakAndSecondPeakNum) + " " + "(" + endOfSecondPeak + " " +
                            '\u2192' + " " + endOfThirdPeak + ")";

            if (Age >= endOfSecondPeak && Age <= endOfThirdPeak)
            {
                CurrentPeak = GetNaturalNumberInt(firstPeakAndSecondPeakNum).ToString();
                _currentProblemNumber = 3;
            }

            return thirdPeak;
        }

        public string GetFourthPeak()
        {
            int yearOfBirthInt = 0;
            int monthNum = 0;
            int monthAndYearNum;

            int endOfSecondPeak;
            int endOfThirdPeak;

            endOfSecondPeak = 36 - GetNaturalNumberInt(GetLifePathNumberNatural()) + 9;
            endOfThirdPeak = endOfSecondPeak + 9;


            if (BirthDate != null)
            {
                monthNum = BirthDate.Value.Month;
                yearOfBirthInt = GetNaturalNumberInt(BirthDate.Value.Year);
            }

            monthAndYearNum = GetNaturalNumberInt(monthNum) + GetNaturalNumberInt(yearOfBirthInt);

            var thirdPeak = GetNaturalNumberString(monthAndYearNum) + " " + "(" + endOfThirdPeak + " " + '\u2192' + " " +
                            "  )";

            if (Age >= endOfThirdPeak)
            {
                CurrentPeak = GetNaturalNumberInt(monthAndYearNum).ToString();
                _currentProblemNumber = 4;
            }

            return thirdPeak;
        }

        public string GetFirstProblemNumber()
        {
            int monthNum = 0;
            int dayAndMonthNum;

            if (BirthDate != null)
            {
                monthNum = BirthDate.Value.Month;
            }

            dayAndMonthNum = GetNaturalNumberInt(DayOfBirthNum) - GetNaturalNumberInt(monthNum);
            dayAndMonthNum = Math.Abs(dayAndMonthNum);

            _firstProblemSimple = GetNaturalNumberString(dayAndMonthNum);

            if (_firstProblemSimple.Length > 3)
            {
                _firstProblemSimple = _firstProblemSimple.Substring(3, 1);
            }

            return GetNaturalNumberString(dayAndMonthNum);
        }

        public string GetSecondProblemNumber()
        {
            int yearOfBirthInt = 0;
            int dayAndYearNum;

            if (BirthDate != null)
            {
                yearOfBirthInt = GetNaturalNumberInt(BirthDate.Value.Year);
            }

            dayAndYearNum = GetNaturalNumberInt(DayOfBirthNum) - GetNaturalNumberInt(yearOfBirthInt);
            dayAndYearNum = Math.Abs(dayAndYearNum);

            _secondProblemSimple = GetNaturalNumberString(dayAndYearNum);

            if (_secondProblemSimple.Length > 3)
            {
                _secondProblemSimple = _secondProblemSimple.Substring(3, 1);
            }

            return GetNaturalNumberString(dayAndYearNum);
        }

        public string GetThirdProblemNumber()
        {
            int firstAndSecondProblemNum;

            firstAndSecondProblemNum = GetNaturalNumberInt(Convert.ToInt16(_firstProblemSimple)) -
                                       GetNaturalNumberInt(Convert.ToInt16(_secondProblemSimple));
            firstAndSecondProblemNum = Math.Abs(firstAndSecondProblemNum);

            return GetNaturalNumberString(firstAndSecondProblemNum);
        }

        public string GetFourthProblemNumber()
        {
            int monthAndYearNum;

            int yearOfBirthInt = 0;
            int monthNum = 0;

            if (BirthDate != null)
            {
                monthNum = BirthDate.Value.Month;
                yearOfBirthInt = GetNaturalNumberInt(BirthDate.Value.Year);
            }

            monthAndYearNum = GetNaturalNumberInt(monthNum) - GetNaturalNumberInt(yearOfBirthInt);
            monthAndYearNum = Math.Abs(monthAndYearNum);

            return GetNaturalNumberString(monthAndYearNum);
        }

        public string GetCurrentProblem()
        {
            string prNum = null;
            if (_currentProblemNumber != null)
            {
                if (_currentProblemNumber == 1)
                {
                    prNum = GetFirstProblemNumber();
                }
                if (_currentProblemNumber == 2)
                {
                    prNum = GetSecondProblemNumber();
                }
                if (_currentProblemNumber == 3)
                {
                    prNum = GetThirdProblemNumber();
                }
                if (_currentProblemNumber == 4)
                {
                    prNum = GetFourthProblemNumber();
                }
            }

            return prNum;
        }

        private int GetLifePathNumberNatural()
        {
            int lifePathNumberNatural;
            if (_lifePathNum.ToString().Length > 3)
            {
                lifePathNumberNatural = Convert.ToInt16(_lifePathNum.ToString().Substring(3, 1));
            }
            else
            {
                lifePathNumberNatural = Convert.ToInt16(_lifePathNum);
            }
            return lifePathNumberNatural;
        }

        public int GetDayOfBirth()
        {
            if (BirthDate != null && BirthDate.Value != null)
            {
                return Convert.ToInt16(BirthDate.Value.Day);
            }
            else
            {
                return 0;
            }
        }

        private int GetAge()
        {
            int age = 0;
            DateTime nowDate = DateTime.Today;
            if (BirthDate != null)
            {
                age = nowDate.Year - BirthDate.Value.Year;
                if (BirthDate > nowDate.AddYears(-age))
                {
                    return age - 1;
                }
            }
            return age;
        }

        private string GetNaturalNumberString(int num)
        {
            if (num.ToString().Length > 1)
            {
                var firstLetter = num.ToString().Substring(0, 1);
                var secondLetter = num.ToString().Substring(1, 1);

                var numVal2 = Convert.ToInt32(firstLetter) + Convert.ToInt32(secondLetter);

                if (CharCodes.controlNumbers.Contains(Convert.ToChar(num)))
                {
                    if (num == 10)
                    {
                        var numValOriginal = 10 + "/" + 1;
                        return numValOriginal;
                    }
                    if (num == 19)
                    {
                        var numValOriginal = num + "/" + 1;
                        return numValOriginal;
                    }
                    else
                    {
                        var numValOriginal = num + "/" + numVal2;
                        return numValOriginal;
                    }
                }
                else
                {
                    if (numVal2.ToString().Length > 1)
                    {
                        firstLetter = numVal2.ToString().Substring(0, 1);
                        secondLetter = numVal2.ToString().Substring(1, 1);

                        var numVal3 = Convert.ToInt32(firstLetter) + Convert.ToInt32(secondLetter);

                        if (CharCodes.controlNumbers.Contains(Convert.ToChar(numVal2)))
                        {
                            if (numVal2 == 10)
                            {
                                var numValOriginal = 10 + "/" + 1;
                                return numValOriginal;
                            }
                            if (numVal2 == 19)
                            {
                                var numValOriginal = numVal2 + "/" + 1;
                                return numValOriginal;
                            }
                            else
                            {
                                var numValOriginal = numVal2 + "/" + numVal3;
                                return numValOriginal;
                            }
                        }
                        return numVal3.ToString();
                    }
                    else
                    {
                        return numVal2.ToString();
                    }
                }
            }
            else
            {
                return num.ToString();
            }
        }

        public int GetNaturalNumberInt(int num)
        {
            int numVal;

            if (num.ToString().Length > 1)
            {
                var firstDigit = num.ToString().Substring(0, 1);
                var secondDigit = num.ToString().Substring(1, 1);

                int thirdDigit = 0;
                if (num.ToString().Length > 2)
                {
                    thirdDigit = Convert.ToInt16(num.ToString().Substring(2, 1));
                }

                int forthDigit = 0;
                if (num.ToString().Length > 3)
                {
                    forthDigit = Convert.ToInt16(num.ToString().Substring(3, 1));
                }

                numVal = Convert.ToInt32(firstDigit) + Convert.ToInt32(secondDigit) + Convert.ToInt32(thirdDigit) +
                         Convert.ToInt32(forthDigit);
            }
            else
            {
                numVal = num;
            }

            // Вторая проверка на двузначное число
            // Приведение числа к однозначному
            if (numVal.ToString().Length == 2)
            {
                var firstDigit = numVal.ToString().Substring(0, 1);
                var secondDigit = numVal.ToString().Substring(1, 1);
                numVal = Convert.ToInt32(firstDigit) + Convert.ToInt32(secondDigit);
            }


            if (Convert.ToString(numVal).Contains("0") & numVal != 0)
            {
                string numValStr = Convert.ToString(numVal);
                numValStr = numValStr.Replace("0", "");
                numVal = Convert.ToInt16(numValStr);
            }

            return numVal;
        }


        public int GetLongNaturalNumberInt(int num)
        {
            int numVal = 0;

            if (num.ToString().Length > 1)
            {
                foreach (var val in num.ToString())
                {
                    var strVal = val.ToString();
                    numVal += Convert.ToInt16(strVal);
                }

            }
            else
            {
                numVal = num;
            }


            if (Convert.ToString(numVal).Contains("0") & numVal != 0)
            {
                string numValStr = Convert.ToString(numVal);
                numValStr = numValStr.Replace("0", "");
                numVal = Convert.ToInt16(numValStr);
            }

            return numVal;
        }

        private int GetNaturalNumberIntForPsichomatrix(int num)
        {
            int numVal;

            if (num.ToString().Length > 1)
            {
                var firstDigit = num.ToString().Substring(0, 1);
                var secondDigit = num.ToString().Substring(1, 1);

                int thirdDigit = 0;
                if (num.ToString().Length > 2)
                {
                    thirdDigit = Convert.ToInt16(num.ToString().Substring(2, 1));
                }

                int forthDigit = 0;
                if (num.ToString().Length > 3)
                {
                    forthDigit = Convert.ToInt16(num.ToString().Substring(3, 1));
                }

                numVal = Convert.ToInt32(firstDigit) + Convert.ToInt32(secondDigit) + Convert.ToInt32(thirdDigit) +
                         Convert.ToInt32(forthDigit);
            }
            else
            {
                numVal = num;
            }
            return numVal;
        }

        public string GetBirthDayDescriptionSource()
        {
            var source = "ms-appx-web:///Common/DaysDescription/Day" + DayOfBirthNum + ".html";
            return source;
        }

        public string GetKarmicKnotsDescriptionSource()
        {
            int month = 1;
            int result;

            if (BirthDate != null)
            {
                month = BirthDate.Value.Month;
            }


            if (DayOfBirthNum > 0 && month > 0)
            {
                if (DayOfBirthNum == 30 && month == 2)
                {
                    return "Нет данных";
                }

                if (DayOfBirthNum == 31 && month == 2)
                {
                    return "Нет данных";
                }

                if (DayOfBirthNum == 31 && month == 4)
                {
                    return "Нет данных";
                }

                if (DayOfBirthNum == 31 && month == 6)
                {
                    return "Нет данных";
                }

                if (DayOfBirthNum == 31 && month == 9)
                {
                    return "Нет данных";
                }

                if (DayOfBirthNum == 31 && month == 11)
                {
                    return "Нет данных";
                }

                if (DayOfBirthNum >=24)
                {
                    DayOfBirthNum = DayOfBirthNum - 22;
                }
                 

                result = Math.Abs(DayOfBirthNum - month);
            }
            else
            {
                return "";
            }

            if (result == 0)
            {
                result = 22;
            }
             
            var source = "ms-appx-web:///Common/KarmicKnotsDescription/num_" + result + ".html";
            return source;
        }

        private static readonly List<int> LsArgumentNumbers = new List<int> { 12, 24, 36, 48, 60, 72, 84, 96 };
        public IEnumerable GetLsItemsSource()
        {
            var points = new List<ChartsDataPoint>();

            int lsNumber = 0;
            int i = 0;

            if (BirthDate != null)
            {
                lsNumber = DayOfBirthNum * BirthDate.Value.Month * BirthDate.Value.Year;
            }

            points.Add(new ChartsDataPoint() { PointArgument = 0, PointValue = GetFirstValueForLsChart(lsNumber) });

            foreach (var arg in LsArgumentNumbers)
            {
                string value = Convert.ToString(lsNumber).Substring(i, 1);
                points.Add(new ChartsDataPoint() { PointArgument = arg, PointValue = Convert.ToInt16(value) });
                i += 1;

                if (Convert.ToString(lsNumber).Length == i)
                {
                    points.Add(new ChartsDataPoint() { PointArgument = arg + 12 });
                    break;
                }
            }
            return points;
        }


        private static readonly List<int> SyArgumentNumbers = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80 };

        public IEnumerable GetSyItemsSource()
        {
            var points = new List<ChartsDataPoint>();

            int lsNumber = 0;
            int i = 0;

            if (BirthDate != null)
            {
                var dayNumStr = Convert.ToString(DayOfBirthNum);
                string monthNumStr = BirthDate.Value.Month.ToString();

                if (monthNumStr.Length == 1)
                {
                    monthNumStr = 0 + monthNumStr;
                }

                var dayAndMonthNumStr = dayNumStr + monthNumStr;

                lsNumber = Convert.ToInt16(dayAndMonthNumStr) * BirthDate.Value.Year;
            }

            points.Add(new ChartsDataPoint() { PointArgument = 0 });

            foreach (var arg in SyArgumentNumbers)
            {
                string value = Convert.ToString(lsNumber).Substring(i, 1);
                points.Add(new ChartsDataPoint() { PointArgument = arg, PointValue = Convert.ToInt16(value) });

                i += 1;

                if (Convert.ToString(lsNumber).Length == i)
                {
                    points.Add(new ChartsDataPoint() { PointArgument = arg + 10 });
                    break;
                }
            }
            return points;
        }

        public IEnumerable GetDemandLevelChartItemsSource()
        {
            var points = new List<ChartsDataPoint>();

            int lsNumber = 0;
            int i = 0;

            if (BirthDate != null)
            {
                var dayNumStr = Convert.ToString(DayOfBirthNum);
                string monthNumStr = BirthDate.Value.Month.ToString();

                if (monthNumStr.Length == 1)
                {
                    monthNumStr = 0 + monthNumStr;
                }

                var dayAndMonthNumStr = dayNumStr + monthNumStr;

                lsNumber = Convert.ToInt16(dayAndMonthNumStr) * BirthDate.Value.Year;
            }

            Double t1 = GetLongNaturalNumberInt(lsNumber);
            Double t2 = lsNumber.ToString().Length;

            Double demandLevel = t1 / t2; // 01.09.2019 add new chartArgument
            demandLevel = Math.Round(demandLevel, 2);
            points.Add(new ChartsDataPoint() { PointArgument = 0, PointValue = demandLevel });

            foreach (var arg in SyArgumentNumbers)
            {
                points.Add(new ChartsDataPoint() { PointArgument = arg, PointValue = demandLevel });

                i += 1;

                if (Convert.ToString(lsNumber).Length == i)
                {
                    points.Add(new ChartsDataPoint() { PointArgument = arg + 10 });
                    break;
                }
            }


            return points;
        }

        private int GetFirstValueForLsChart(int lsNumber)
        {
            int firstValue = 0;
            foreach (var achar in Convert.ToString(lsNumber))
            {
                var strNumber = achar.ToString();
                firstValue += Convert.ToInt16(strNumber);
            }

            firstValue = GetNaturalNumberInt(firstValue);

            return firstValue;
        }



        #endregion

        #region Properties

        #endregion
    }
}