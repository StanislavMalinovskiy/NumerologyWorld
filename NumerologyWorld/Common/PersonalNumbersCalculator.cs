using System;
using Numerology.Model;

namespace Numerology.Common
{

    public class PersonalNumbersCalculator
    {
        #region Declarations

        int PersonalYearNum;

        //public bool CalcLifePathSeparately { get; set; }
        private DateTime? BirthDate { get; set; }
        private int DayOfBirthNum { get; set; }


        #endregion

        #region Constructor
        public PersonalNumbersCalculator(DateTime? _birthDate, bool _calcLifePathSeparately)
        {
            //CalcLifePathSeparately = _calcLifePathSeparately;

            BirthDate = _birthDate;

            DayOfBirthNum = GetDayOfBirth /*Возвращает день рождения*/();
            //Age = GetAge();
        }
        #endregion

        #region Procedures

        /// <summary>
        /// Очищает данные
        /// </summary>
        private void ClearValues()
        {
            PersonalYearNum = 0;
        }

        #endregion

        #region Functions

        public string GetPersonalYearNumber()
        {
            //var BirthDateStrClear = "";

            if (BirthDate != null && BirthDate.Value != null)
            {
                //var BirthDateStr = BirthDate.Value.ToString().Substring(0, 10);

                //*Получить число души по фамилии*/
                //foreach (var achar in BirthDateStr)
                //{
                //    if (!char.IsPunctuation(achar))
                //    {
                //        BirthDateStrClear += achar;
                //    }
                //}

                //if (CalcLifePathSeparately)
                //{
                var dayOfBirthInt = GetNaturalNumberInt(BirthDate.Value.Day);
                var monthOfBirthInt = GetNaturalNumberInt(BirthDate.Value.Month);
                var yearInt = GetNaturalNumberInt(BirthDate.Value.Year);

                var dayOfBirthNatural = GetNaturalNumberInt(dayOfBirthInt);
                var monthOfBirthNatural = GetNaturalNumberInt(monthOfBirthInt);
                var yearIntNatural = GetNaturalNumberInt(yearInt);

                PersonalYearNum = dayOfBirthNatural + monthOfBirthNatural + yearIntNatural;
                //}
                //else
                //{
                //    int Digit1 = Convert.ToInt16(BirthDateStrClear.Substring(0, 1));
                //    int Digit2 = Convert.ToInt16(BirthDateStrClear.Substring(1, 1));
                //    int Digit3 = Convert.ToInt16(BirthDateStrClear.Substring(2, 1));
                //    int Digit4 = Convert.ToInt16(BirthDateStrClear.Substring(3, 1));
                //    int Digit5 = Convert.ToInt16(BirthDateStrClear.Substring(4, 1));
                //    int Digit6 = Convert.ToInt16(BirthDateStrClear.Substring(5, 1));
                //    int Digit7 = Convert.ToInt16(BirthDateStrClear.Substring(6, 1));
                //    int Digit8 = Convert.ToInt16(BirthDateStrClear.Substring(7, 1));

                //    LifePathNum = Digit1 + Digit2 + Digit3 + Digit4 + Digit5 + Digit6 + Digit7 + Digit8;
                //}

                return GetNaturalNumberString(PersonalYearNum);
            }
            else
            {
                return "";
            }
        }

        public string GetMonthNum(int monthNumber)
        {
            int monthNum = GetPersonalYearNumberNatural() + monthNumber;

            return GetNaturalNumberString(monthNum);
        }


        public int GetFirstValueOfSelectedMonth(int monthNumber)
        {
            int monthNum = GetPersonalYearNumberNatural() + monthNumber;

            int monthNumInt = GetNaturalNumberInt(monthNum);

            int val = monthNumInt + 1;

            if (val == 10)
            {
                val = 1;
            }

            return val;
        }

        private int GetPersonalYearNumberNatural()
        {
            int personalYearNumNatural;
            if (PersonalYearNum.ToString().Length > 3)
            {
                personalYearNumNatural = Convert.ToInt16(PersonalYearNum.ToString().Substring(3, 1));
            }
            else
            {
                personalYearNumNatural = Convert.ToInt16(PersonalYearNum);
            }
            return personalYearNumNatural;
        }

        private int GetDayOfBirth()
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


        private string GetNaturalNumberString(int num)
        {

            if (num.ToString().Length > 1)
            {
                var FirstLetter = num.ToString().Substring(0, 1);
                var SecondLetter = num.ToString().Substring(1, 1);

                var numVal2 = Convert.ToInt32(FirstLetter) + Convert.ToInt32(SecondLetter);

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
                        FirstLetter = numVal2.ToString().Substring(0, 1);
                        SecondLetter = numVal2.ToString().Substring(1, 1);

                        var numVal3 = Convert.ToInt32(FirstLetter) + Convert.ToInt32(SecondLetter);

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
                var FirstDigit = num.ToString().Substring(0, 1);
                var SecondDigit = num.ToString().Substring(1, 1);

                int ThirdDigit = 0;
                if (num.ToString().Length > 2)
                {
                    ThirdDigit = Convert.ToInt16(num.ToString().Substring(2, 1));
                }

                int ForthDigit = 0;
                if (num.ToString().Length > 3)
                {
                    ForthDigit = Convert.ToInt16(num.ToString().Substring(3, 1));
                }

                numVal = Convert.ToInt32(FirstDigit) + Convert.ToInt32(SecondDigit) + Convert.ToInt32(ThirdDigit) + Convert.ToInt32(ForthDigit);
            }
            else
            {
                numVal = num;
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

        #endregion

    }

}
