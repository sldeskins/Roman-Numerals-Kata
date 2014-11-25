using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabicRomaNumerialCalculatorClasses
    {
    public class ArabicToRomanNumberConverter
        {
        private string validUserRoleForArabicToRoman = "games designer";
        private bool isValidUser = false;
        private string userRole;

        Int16[] romanpowers = new Int16[] { 1, 5, 10, 50, 100, 500, 1000 };
        Dictionary<Int16, String> romanpowersDictionary =
             new Dictionary<short, string>()
            {
                {(Int16) 1, "I"},
                {(Int16) 5, "V"},
                {(Int16) 10, "X"},
                {(Int16) 50, "L"},
                {(Int16) 100, "C"},
                {(Int16) 500, "D"},
                {(Int16) 1000, "M"},
            };


        Int16[] romanpowersTriple = new Int16[] { 1, 10, 100, 1000 };
        Dictionary<Int16, String> romanpowersTripleNextDictionary =
                   new Dictionary<short, string>()
            {
                {(Int16) 1, "V"},
                {(Int16) 10, "L"},
                {(Int16) 100, "D"},
            };


        public ArabicToRomanNumberConverter ()
            {

            }

        public ArabicToRomanNumberConverter ( string userRole )
            {
            this.userRole = userRole;
            this.UserRoleHasAccess(userRole);
            }
        public bool UserRoleHasAccess ()
            {
            return this.UserRoleHasAccess(this.userRole);
            }
        public bool UserRoleHasAccess ( string userRole )
            {

            if (userRole == this.validUserRoleForArabicToRoman)
                {
                this.isValidUser = true;
                }
            else
                {
                this.isValidUser = false;
                }
            return isValidUser;
            }


        public string ConvertArabic ( Int16 arabicNumber )
            {

            IEnumerable<Int16> query = from romanpower in romanpowers
                                       orderby romanpower descending
                                       select romanpower;

            string result;
            Int16 workingArabicNumber = arabicNumber;
            string romanString = "";

            if (this.isValidUser)
                {
                if (arabicNumber >= 1 && arabicNumber <= 3000)
                    {
                    foreach (Int16 romanpower in query)
                        {
                        if (workingArabicNumber >= romanpower)
                            {
                            bool flagAdd = true;
                            bool flagNextHigher = false;
                            if (romanpowersTriple.Contains(romanpower))
                                {
                                if (romanpower * 3 < workingArabicNumber)
                                    {
                                    flagAdd = false;
                                    }

                                }
                            else
                                {
                                if (((romanpower * 2) - workingArabicNumber) < romanpower)
                                    {
                                    flagAdd = false;
                                    flagNextHigher = true;
                                    }
                                }

                            if (flagAdd)
                                {

                                String romanLetter;
                                romanpowersDictionary.TryGetValue(romanpower, out romanLetter);
                                romanString = romanString + romanLetter;

                                workingArabicNumber -= romanpower;
                                }
                            else
                                {
                                String romanLetter;
                                String romanLetterForHigherPower;
                               

                                if (flagNextHigher)
                                    {
                                    romanpowersDictionary.TryGetValue((Int16)(romanpower / 5), out romanLetter);
                                    romanpowersDictionary.TryGetValue((Int16)(romanpower*2), out romanLetterForHigherPower);
                                    romanString  = romanLetter+romanLetterForHigherPower + romanString;
                                    workingArabicNumber = (Int16)(workingArabicNumber-((romanpower*2)+romanpower));
                                    }
                                else
                                    {
                                    romanpowersDictionary.TryGetValue(romanpower, out romanLetter);
                                    romanpowersTripleNextDictionary.TryGetValue(romanpower, out romanLetterForHigherPower);
                                    romanString = romanLetter + romanLetterForHigherPower + romanString;
                                    workingArabicNumber -= (Int16)(romanpower * 4);
                                    }
                                }

                            if (workingArabicNumber > 0)
                                {
                                romanString += ConvertArabic(workingArabicNumber);
                                break;
                                }
                            else
                                {
                                break;
                                }
                          
                            }

                        }

                    result = romanString;
                    }
                else
                    {
                    result = "invalid -- out of range";
                    }
                }
            else
                {
                result = "Not a Valid User";
                }
            return result;
            }
        }
    }
