
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArabicRomaNumerialCalculatorClasses;
using System.Collections.Generic;

namespace ArabicRomaNumerialCalculatorClassesTests
    {
    [TestClass]
    public class UnitTest1
        {


        [TestMethod]
        public void Test_RomanNumeralStringIsValid ()
            {
            var testDataCollection = new[] { 
//invalid inputs
new { testInput = "A", expectedIsValid = false, expectedMessage = "A is not a valid roman numeral." },
new { testInput = "a", expectedIsValid = false, expectedMessage = "a is not a valid roman numeral." },
               
//valid single inputs         
//The Romans wrote their numbers using letters; specifically the letters "I, V, X, L, C, D, and M."
new { testInput = "I", expectedIsValid = true, expectedMessage = "ok" },
new { testInput = "V", expectedIsValid = true, expectedMessage = "ok" },
new { testInput = "X", expectedIsValid = true, expectedMessage = "ok" },
new { testInput = "L", expectedIsValid = true, expectedMessage = "ok" },
new { testInput = "C", expectedIsValid = true, expectedMessage = "ok" },
new { testInput = "D", expectedIsValid = true, expectedMessage = "ok" },
new { testInput = "M", expectedIsValid = true, expectedMessage = "ok" },
                      
new { testInput = "VI", expectedIsValid = true, expectedMessage = "ok" },
              
//invalid single inputs            
new { testInput = "i", expectedIsValid = false, expectedMessage = "i is not a valid roman numeral. Lower case roman numerals are not valid." },
new { testInput = "v", expectedIsValid = false, expectedMessage = "v is not a valid roman numeral. Lower case roman numerals are not valid." },
new { testInput = "x", expectedIsValid = false, expectedMessage = "x is not a valid roman numeral. Lower case roman numerals are not valid." },
new { testInput = "l", expectedIsValid = false, expectedMessage = "l is not a valid roman numeral. Lower case roman numerals are not valid." },
new { testInput = "c", expectedIsValid = false, expectedMessage = "c is not a valid roman numeral. Lower case roman numerals are not valid." },
new { testInput = "d", expectedIsValid = false, expectedMessage = "d is not a valid roman numeral. Lower case roman numerals are not valid." },
new { testInput = "m", expectedIsValid = false, expectedMessage = "m is not a valid roman numeral. Lower case roman numerals are not valid." },

//invalid can not be repeated more than three time     
//The symbols 'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row.
new { testInput = "II", expectedIsValid = true, expectedMessage = "ok" },
new { testInput = "III", expectedIsValid = true, expectedMessage = "ok" },
new { testInput = "IIII", expectedIsValid = false, expectedMessage = "'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row."},
new { testInput = "IIIXI", expectedIsValid = true, expectedMessage = "ok" },
new { testInput = "IIIIIIII", expectedIsValid = false, expectedMessage = "'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row."},
new { testInput = "MMMMM", expectedIsValid = false, expectedMessage = "'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row."},
new { testInput = "CCCCCCCC", expectedIsValid = false, expectedMessage = "'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row."},
new { testInput = "XXXXXX", expectedIsValid = false, expectedMessage = "'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row."},

//invalid can not be repeated more than three time     
//'V', 'L', and 'D' can never be repeated. 
new { testInput = "VXV", expectedIsValid = true, expectedMessage = "ok" },
new { testInput = "DXD", expectedIsValid = true, expectedMessage = "ok" },
new { testInput = "LXL", expectedIsValid = true, expectedMessage = "ok" },

new { testInput = "XLL", expectedIsValid = false, expectedMessage = "'V', 'L', and 'D' can never be repeated." },
new { testInput = "XVVX", expectedIsValid = false, expectedMessage = "'V', 'L', and 'D' can never be repeated." },
new { testInput = "DDX", expectedIsValid = false, expectedMessage = "'V', 'L', and 'D' can never be repeated." },
            };


            RomanNumeralValidator testClass = new RomanNumeralValidator();

            foreach (var testData in testDataCollection)
                {

                bool result = testClass.RomanNumeralStringIsValid(testData.testInput);
                Assert.AreEqual(testData.expectedIsValid, result, testData.testInput);

                string message = testClass.getCommandMessage();
                Assert.AreEqual(testData.expectedMessage, message, testData.testInput);
                }
            }

        }
    }
