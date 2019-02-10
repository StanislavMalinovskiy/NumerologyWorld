using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerology.Model
{
    public static class CharCodes
    {


        public static List<char> vowelLellers = new List<char> { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я', 'й', 'a', 'u', 'e', 'o', 'i', 'y' };
        public static List<char> consonantLellers = new List<char> { 'б', 'в', 'г', 'д', 'ж', 'з', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'j', 's', 'b', 'k', 't', 'c', 'l', 'd', 'm', 'v', 'n', 'w', 'f', 'x', 'g', 'p', 'h', 'q' , 'z' , 'r'};
       public static List<int> controlNumbers = new List<int> {10, 11, 13, 14, 16, 19, 22, 33};

        public static int GetCharCode(char achar)
        {
            int Code=1;
            switch (achar)
            {
                case 'а':
                case 'к':
                case 'у':
                case 'a':
                case 'j':
                case 's':
                    Code = 1;
                    break;
                case 'б':
                case 'л':
                case 'ф':
                case 'b':
                case 'k':
                case 't':
                    Code = 2;
                    break;
                case 'в':
                case 'м':
                case 'х':
                case 'c':
                case 'l':
                case 'u':
                    Code = 3;
                    break;
                case 'г':
                case 'н':
                case 'ц':
                case 'd':
                case 'm':
                case 'v':
                    Code = 4;
                    break;
                case 'д':
                case 'о':
                case 'ч':
                case 'e':
                case 'n':
                case 'w':
                    Code = 5;
                    break;
                case 'е':
                case 'ё':
                case 'п':
                case 'ш':
                case 'f':
                case 'o':
                case 'x':
                    Code = 6;
                    break;
                case 'ж':
                case 'р':
                case 'щ':
                case 'g':
                case 'p':
                case 'y':
                    Code = 7;
                    break;
                case 'з':
                case 'с':
                case 'ю':
                case 'h':
                case 'q':
                case 'z':
                    Code = 8;
                    break;
                case 'и':
                case 'й':
                case 'т':
                case 'я':
                case 'э':
                case 'ы':
                case 'i':
                case 'r':
                    Code = 9;
                    break;
            }

            return Code;
        }

    }
}
