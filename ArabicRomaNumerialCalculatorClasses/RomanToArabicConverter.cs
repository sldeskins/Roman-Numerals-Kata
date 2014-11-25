using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabicRomaNumerialCalculatorClasses
    {
    public class RomanToArabicConverter
        {
        private bool isValidUser = false;
        private string userRole;
        private string message;
        private Int16 UPPER_RANGE_OF_CALCULATOR = 3000;

        private Dictionary<Char, Int16> RomanDigitToArabicValuesDictionary =
       new Dictionary<Char, Int16>()
            {
                {'I',(Int16) 1},
                {'V',(Int16) 5},
                {'X',(Int16) 10},
                {'L',(Int16) 50},
                {'C',(Int16) 100},
                {'D',(Int16) 500},
                {'M',(Int16) 1000}
            };
        public RomanToArabicConverter ( string userRole )
            {
            this.userRole = userRole;
            if ("customer" == userRole)
                {
                this.isValidUser = true;
                }
            else
                {
                this.isValidUser = false;
                }
            }

        public short RomanToArabic ( string RomanNumber )
            {
            Int16 arabicNumber = 0;
            RomanNumeralValidator romanNumeralValidator = new RomanNumeralValidator();
            if (this.isValidUser)
                {
                if (romanNumeralValidator.RomanNumeralStringIsValid(RomanNumber))
                    {
                    char[] RomanNumberArray = RomanNumber.ToCharArray();
                    Int16 previousLookup = 0;
                    Int16 lookup = 0;

                    for (int i = 0; i < RomanNumberArray.Length; i++)
                        {
                        char romanNumberChar = RomanNumberArray[i];

                        RomanDigitToArabicValuesDictionary.TryGetValue(romanNumberChar, out lookup);
                        if (lookup == previousLookup)
                            {
                            arabicNumber = (Int16)(arabicNumber + previousLookup);
                            }
                        else if (previousLookup > lookup)
                            {
                            arabicNumber = (Int16)(arabicNumber + previousLookup);
                            }
                        else
                            {
                            arabicNumber = (Int16)(arabicNumber - previousLookup);
                            }
                        previousLookup = lookup;
                        }
                    arabicNumber = (Int16)(arabicNumber + lookup);
                    message = "ok";

                    if (arabicNumber > UPPER_RANGE_OF_CALCULATOR)
                        {
                        arabicNumber = 0;
                        message = "out of range";
                        }
                    }

                else
                    {
                    message = romanNumeralValidator.getCommandMessage();
                    }
                }
            else
                {
                message = "Role '" + this.userRole + "' can not use the Roman to Arabic Converter.";
                }
            return arabicNumber;
            }

        public string getCommandMessage ()
            {
            return this.message;
            }
        }
    }
