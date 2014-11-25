using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArabicRomaNumerialCalculatorClasses;

namespace ArabicRomaNumerialCalculatorClassesTests
    {
    [TestClass]
    public class RomanToArabicConverterTest
        {
        [TestMethod]
        public void TestValidUserRole ()
            {

            var testDataCollection = new[] { 
               //Role access   
               //valid inputs
                new { userRole="customer", RomanNumber = "A", expectedArabicNumber = 0, expectedMessage = "A is not a valid roman numeral." },
               //invalid inputs
                new { userRole="another", RomanNumber = "A", expectedArabicNumber = 0, expectedMessage = "Role 'another' can not use the Roman to Arabic Converter." },
   
                //valid single inputs         
                //The Romans wrote their numbers using letters; specifically the letters "I, V, X, L, C, D, and M."
                new { userRole="customer", RomanNumber ="I", expectedArabicNumber = 1, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="V", expectedArabicNumber = 5, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="X", expectedArabicNumber = 10, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="L", expectedArabicNumber = 50, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="C", expectedArabicNumber = 100, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="D", expectedArabicNumber = 500, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="M", expectedArabicNumber = 1000, expectedMessage = "ok" },
                      
                new { userRole="customer", RomanNumber ="VI", expectedArabicNumber = 6, expectedMessage = "ok" },
              
                //invalid single inputs            
                new { userRole="customer", RomanNumber ="i", expectedArabicNumber = 0, expectedMessage = "i is not a valid roman numeral. Lower case roman numerals are not valid." },
                new { userRole="customer", RomanNumber ="v", expectedArabicNumber = 0, expectedMessage = "v is not a valid roman numeral. Lower case roman numerals are not valid." },
                new { userRole="customer", RomanNumber ="x", expectedArabicNumber = 0, expectedMessage = "x is not a valid roman numeral. Lower case roman numerals are not valid." },
                new { userRole="customer", RomanNumber ="l", expectedArabicNumber = 0, expectedMessage = "l is not a valid roman numeral. Lower case roman numerals are not valid." },
                new { userRole="customer", RomanNumber ="c", expectedArabicNumber = 0, expectedMessage = "c is not a valid roman numeral. Lower case roman numerals are not valid." },
                new { userRole="customer", RomanNumber ="d", expectedArabicNumber = 0, expectedMessage = "d is not a valid roman numeral. Lower case roman numerals are not valid." },
                new { userRole="customer", RomanNumber ="m", expectedArabicNumber = 0, expectedMessage = "m is not a valid roman numeral. Lower case roman numerals are not valid." },

                //invalid can not be repeated more than three time     
                //The symbols 'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row.
                new { userRole="customer", RomanNumber ="II", expectedArabicNumber = 2, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="III", expectedArabicNumber = 3, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="IIII", expectedArabicNumber = 0, expectedMessage = "'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row."},
                //new { userRole="customer", RomanNumber ="IIIXI", expectedArabicNumber = 0, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="IIIIIIII", expectedArabicNumber = 0, expectedMessage = "'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row."},
                new { userRole="customer", RomanNumber ="MMMMM", expectedArabicNumber = 0, expectedMessage = "'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row."},
                new { userRole="customer", RomanNumber ="CCCCCCCC", expectedArabicNumber = 0, expectedMessage = "'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row."},
                new { userRole="customer", RomanNumber ="XXXXXX", expectedArabicNumber = 0, expectedMessage = "'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row."},

                //from chart http://literacy.kent.edu/Minigrants/Cinci/romanchart.htm
                new { userRole="customer", RomanNumber ="I", expectedArabicNumber = 1, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="II", expectedArabicNumber = 2, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="III", expectedArabicNumber = 3, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="IV", expectedArabicNumber = 4, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="V", expectedArabicNumber = 5, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="VI", expectedArabicNumber = 6, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="VII", expectedArabicNumber = 7, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="VIII", expectedArabicNumber = 8, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="IX", expectedArabicNumber = 9, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="X", expectedArabicNumber = 10, expectedMessage = "ok" },
                
                new { userRole="customer", RomanNumber ="XI", expectedArabicNumber = 11, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="XII", expectedArabicNumber = 12, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="XIII", expectedArabicNumber = 13, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="XIV", expectedArabicNumber = 14, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="XV", expectedArabicNumber = 15, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="XVI", expectedArabicNumber = 16, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="XVII", expectedArabicNumber = 17, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="XVIII", expectedArabicNumber = 18, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="XIX", expectedArabicNumber = 19, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="XX", expectedArabicNumber = 20, expectedMessage = "ok" },


                new { userRole="customer", RomanNumber ="DI", expectedArabicNumber = 501, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="DL", expectedArabicNumber = 550, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="DXXX", expectedArabicNumber = 530, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="DCCVII", expectedArabicNumber = 707, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="DCCCXC", expectedArabicNumber = 890, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="MD", expectedArabicNumber = 1500, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="MDCCC", expectedArabicNumber = 1800, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="CM", expectedArabicNumber = 900, expectedMessage = "ok" },

                //http://romannumerals.babuo.com/roman-numerals-1-5000
                new { userRole="customer", RomanNumber ="MDCCCLXXXI", expectedArabicNumber = 1881, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="MCMXXI", expectedArabicNumber = 1921, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="CM", expectedArabicNumber = 900, expectedMessage = "ok" },

                //range
                new { userRole="customer", RomanNumber ="", expectedArabicNumber = 0, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="MMM", expectedArabicNumber = 3000, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="MMMI", expectedArabicNumber = 0, expectedMessage = "out of range" },

                //invalid can not be repeated more than three time     
                //'V', 'L', and 'D' can never be repeated. 
                new { userRole="customer", RomanNumber ="VXV", expectedArabicNumber = 10, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="DXD", expectedArabicNumber = 990, expectedMessage = "ok" },
                new { userRole="customer", RomanNumber ="LXL", expectedArabicNumber = 90, expectedMessage = "ok" },

                new { userRole="customer", RomanNumber ="XLL", expectedArabicNumber = 0, expectedMessage = "'V', 'L', and 'D' can never be repeated." },
                new { userRole="customer", RomanNumber ="XVVX", expectedArabicNumber = 0, expectedMessage = "'V', 'L', and 'D' can never be repeated." },
                new { userRole="customer", RomanNumber ="DDX", expectedArabicNumber = 0, expectedMessage = "'V', 'L', and 'D' can never be repeated." },

           };


            foreach (var testData in testDataCollection)
                {
                RomanToArabicConverter RomanToArabicConverter = new RomanToArabicConverter(testData.userRole);

                Int16 result = RomanToArabicConverter.RomanToArabic(testData.RomanNumber);
                Assert.AreEqual(testData.expectedArabicNumber, result, testData.RomanNumber + " " + testData.userRole);

                string message = RomanToArabicConverter.getCommandMessage();
                Assert.AreEqual(testData.expectedMessage, message, testData.RomanNumber, testData.RomanNumber + " " + testData.userRole);
                }
            }
        [TestMethod]
        public void TestMethod1 ()
            {

            var testDataCollection = new[] { 
                //invalid inputs
                new { RomanNumber = "A", expectedArabicNumber = 0, expectedMessage = "A is not a valid roman numeral." },
                new { RomanNumber = "a", expectedArabicNumber = 0, expectedMessage = "a is not a valid roman numeral." },
               
                 };
            string userRole = "customer";
            RomanToArabicConverter RomanToArabicConverter = new RomanToArabicConverter(userRole);

            foreach (var testData in testDataCollection)
                {
                Int16 result = RomanToArabicConverter.RomanToArabic(testData.RomanNumber);
                Assert.AreEqual(testData.expectedArabicNumber, result);

                string message = RomanToArabicConverter.getCommandMessage();
                Assert.AreEqual(testData.expectedMessage, message, testData.RomanNumber);
                }
            }
        }
    }