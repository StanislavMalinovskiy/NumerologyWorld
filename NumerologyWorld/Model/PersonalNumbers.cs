using System;
using System.ComponentModel;

namespace Numerology.Model
{
    public class PersonalNumbers
    {

        private DateTimeOffset _calcDate = Convert.ToDateTime("1/1/" + DateTime.Today.Year);
        private string _personalYearNumber;

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

        public string PersonalYearNumber
        {
            get
            {
                return _personalYearNumber;
            }
            set
            {
                _personalYearNumber = value;
                OnPropertyChanged("PersonalYearNumber");
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

        private int? _day1;
        private int? _day2;
        private int? _day3;
        private int? _day4;
        private int? _day5;
        private int? _day6;
        private int? _day7;
        private int? _day8;
        private int? _day9;
        private int? _day10;
        private int? _day11;
        private int? _day12;
        private int? _day13;
        private int? _day14;
        private int? _day15;
        private int? _day16;
        private int? _day17;
        private int? _day18;
        private int? _day19;
        private int? _day20;
        private int? _day21;
        private int? _day22;
        private int? _day23;
        private int? _day24;
        private int? _day25;
        private int? _day26;
        private int? _day27;
        private int? _day28;
        private int? _day29;
        private int? _day30;
        private int? _day31;
        private int? _day32;
        private int? _day33;
        private int? _day34;
        private int? _day35;
        private int? _day36;
        private int? _day37;
        private int? _day38;
        private int? _day39;
        private int? _day40;

        public int? Day1
        {
            get
            {
                return _day1;
            }
            set
            {
                _day1 = value;
                OnPropertyChanged("Day1");
            }
        }

        public int? Day2
        {
            get
            {
                return _day2;
            }
            set
            {
                _day2 = value;
                OnPropertyChanged("Day2");
            }
        }

        public int? Day3
        {
            get
            {
                return _day3;
            }
            set
            {
                _day3 = value;
                OnPropertyChanged("Day3");
            }
        }

        public int? Day4
        {
            get
            {
                return _day4;
            }
            set
            {
                _day4 = value;
                OnPropertyChanged("Day4");
            }
        }

        public int? Day5
        {
            get
            {
                return _day5;
            }
            set
            {
                _day5 = value;
                OnPropertyChanged("Day5");
            }
        }

        public int? Day6
        {
            get
            {
                return _day6;
            }
            set
            {
                _day6 = value;
                OnPropertyChanged("Day6");
            }
        }

        public int? Day7
        {
            get
            {
                return _day7;
            }
            set
            {
                _day7 = value;
                OnPropertyChanged("Day7");
            }
        }

        public int? Day8
        {
            get
            {
                return _day8;
            }
            set
            {
                _day8 = value;
                OnPropertyChanged("Day8");
            }
        }

        public int? Day9
        {
            get
            {
                return _day9;
            }
            set
            {
                _day9 = value;
                OnPropertyChanged("Day9");
            }
        }

        public int? Day10
        {
            get
            {
                return _day10;
            }
            set
            {
                _day10 = value;
                OnPropertyChanged("Day10");
            }
        }

        public int? Day11
        {
            get
            {
                return _day11;
            }
            set
            {
                _day11 = value;
                OnPropertyChanged("Day11");
            }
        }

        public int? Day12
        {
            get
            {
                return _day12;
            }
            set
            {
                _day12 = value;
                OnPropertyChanged("Day12");
            }
        }

        public int? Day13
        {
            get
            {
                return _day13;
            }
            set
            {
                _day13 = value;
                OnPropertyChanged("Day13");
            }
        }

        public int? Day14
        {
            get
            {
                return _day14;
            }
            set
            {
                _day14 = value;
                OnPropertyChanged("Day14");
            }
        }

        public int? Day15
        {
            get
            {
                return _day15;
            }
            set
            {
                _day15 = value;
                OnPropertyChanged("Day15");
            }
        }

        public int? Day16
        {
            get
            {
                return _day16;
            }
            set
            {
                _day16 = value;
                OnPropertyChanged("Day16");
            }
        }

        public int? Day17
        {
            get
            {
                return _day17;
            }
            set
            {
                _day17 = value;
                OnPropertyChanged("Day17");
            }
        }

        public int? Day18
        {
            get
            {
                return _day18;
            }
            set
            {
                _day18 = value;
                OnPropertyChanged("Day18");
            }
        }

        public int? Day19
        {
            get
            {
                return _day19;
            }
            set
            {
                _day19 = value;
                OnPropertyChanged("Day19");
            }
        }

        public int? Day20
        {
            get
            {
                return _day20;
            }
            set
            {
                _day20 = value;
                OnPropertyChanged("Day20");
            }
        }

        public int? Day21
        {
            get
            {
                return _day21;
            }
            set
            {
                _day21 = value;
                OnPropertyChanged("Day21");
            }
        }

        public int? Day22
        {
            get
            {
                return _day22;
            }
            set
            {
                _day22 = value;
                OnPropertyChanged("Day22");
            }
        }

        public int? Day23
        {
            get
            {
                return _day23;
            }
            set
            {
                _day23 = value;
                OnPropertyChanged("Day23");
            }
        }

        public int? Day24
        {
            get
            {
                return _day24;
            }
            set
            {
                _day24 = value;
                OnPropertyChanged("Day24");
            }
        }

        public int? Day25
        {
            get
            {
                return _day25;
            }
            set
            {
                _day25 = value;
                OnPropertyChanged("Day25");
            }
        }

        public int? Day26
        {
            get
            {
                return _day26;
            }
            set
            {
                _day26 = value;
                OnPropertyChanged("Day26");
            }
        }

        public int? Day27
        {
            get
            {
                return _day27;
            }
            set
            {
                _day27 = value;
                OnPropertyChanged("Day27");
            }
        }

        public int? Day28
        {
            get
            {
                return _day28;
            }
            set
            {
                _day28 = value;
                OnPropertyChanged("Day28");
            }
        }

        public int? Day29
        {
            get
            {
                return _day29;
            }
            set
            {
                _day29 = value;
                OnPropertyChanged("Day29");
            }
        }

        public int? Day30
        {
            get
            {
                return _day30;
            }
            set
            {
                _day30 = value;
                OnPropertyChanged("Day30");
            }
        }

        public int? Day31
        {
            get
            {
                return _day31;
            }
            set
            {
                _day31 = value;
                OnPropertyChanged("Day31");
            }
        }

        public int? Day32
        {
            get
            {
                return _day32;
            }
            set
            {
                _day32 = value;
                OnPropertyChanged("Day32");
            }
        }

        public int? Day33
        {
            get
            {
                return _day33;
            }
            set
            {
                _day33 = value;
                OnPropertyChanged("Day33");
            }
        }

        public int? Day34
        {
            get
            {
                return _day34;
            }
            set
            {
                _day34 = value;
                OnPropertyChanged("Day34");
            }
        }

        public int? Day35
        {
            get
            {
                return _day35;
            }
            set
            {
                _day35 = value;
                OnPropertyChanged("Day35");
            }
        }

        public int? Day36
        {
            get
            {
                return _day36;
            }
            set
            {
                _day36 = value;
                OnPropertyChanged("Day36");
            }
        }

        public int? Day37
        {
            get
            {
                return _day37;
            }
            set
            {
                _day37 = value;
                OnPropertyChanged("Day37");
            }
        }

        public int? Day38
        {
            get
            {
                return _day38;
            }
            set
            {
                _day38 = value;
                OnPropertyChanged("Day38");
            }
        }

        public int? Day39
        {
            get
            {
                return _day39;
            }
            set
            {
                _day39 = value;
                OnPropertyChanged("Day39");
            }
        }

        public int? Day40
        {
            get
            {
                return _day40;
            }
            set
            {
                _day40 = value;
                OnPropertyChanged("Day40");
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
