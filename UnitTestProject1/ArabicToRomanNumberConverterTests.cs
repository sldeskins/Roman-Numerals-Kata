using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArabicRomaNumerialCalculatorClasses;

namespace ArabicRomaNumerialCalculatorClassesTests
    {
    [TestClass]
    public class ArabicToRomanNumberConverterTests
        {
        [TestMethod]
        public void TestMethod_AllowsUserRoleAccessToConverter ()
            {
            String userRole = "games designer";

            ArabicToRomanNumberConverter arabicToRomanNumberConverter = new ArabicToRomanNumberConverter();
            bool result = arabicToRomanNumberConverter.UserRoleHasAccess(userRole);
            Assert.IsTrue(result);

            //
            userRole = "some other role";
            result = arabicToRomanNumberConverter.UserRoleHasAccess(userRole);
            Assert.IsFalse(result);


            }
        [TestMethod]
        public void TestMethod_AllowsUserRoleAccessToConverter_ctor ()
            {
            String userRole = "games designer";

            ArabicToRomanNumberConverter arabicToRomanNumberConverter = new ArabicToRomanNumberConverter(userRole);
            bool result = arabicToRomanNumberConverter.UserRoleHasAccess();
            Assert.IsTrue(result);

            //
            userRole = "some other role";
            arabicToRomanNumberConverter = new ArabicToRomanNumberConverter(userRole);

            result = arabicToRomanNumberConverter.UserRoleHasAccess();
            Assert.IsFalse(result);


            }


        [TestMethod]
        public void TestMethod_ConvertArabicNumber_ValidUser ()
            {
            var testDataCollection = new[] { 
//invalid inputs
new { testInput = (Int16) 0, expectedRomanNumber = "invalid -- out of range" },
new { testInput = (Int16) (-10), expectedRomanNumber = "invalid -- out of range" },
new { testInput = (Int16) 3001, expectedRomanNumber = "invalid -- out of range" },

//valid inputs
new { testInput = (Int16) 1, expectedRomanNumber = "I" },
new { testInput = (Int16) 2, expectedRomanNumber = "II" },
new { testInput = (Int16) 3, expectedRomanNumber = "III" },
new { testInput = (Int16) 5, expectedRomanNumber = "V" },


new { testInput = (Int16) 4, expectedRomanNumber = "IV" },
new { testInput = (Int16) 9, expectedRomanNumber = "IX" },
new { testInput = (Int16) 40, expectedRomanNumber = "XL" },
new { testInput = (Int16) 90, expectedRomanNumber = "XC" },
new { testInput = (Int16) 400, expectedRomanNumber = "CD" },
new { testInput = (Int16) 900, expectedRomanNumber = "CM" },

new { testInput = (Int16) 100, expectedRomanNumber = "C" },
new { testInput = (Int16) 200, expectedRomanNumber = "CC" },
new { testInput = (Int16) 300, expectedRomanNumber = "CCC" },

new { testInput = (Int16) 1000, expectedRomanNumber = "M" },
new { testInput = (Int16) 2000, expectedRomanNumber = "MM" },

new { testInput = (Int16) 30, expectedRomanNumber = "XXX" },

new { testInput = (Int16) 3000, expectedRomanNumber = "MMM" },
    };

            String userRole = "games designer";
            ArabicToRomanNumberConverter arabicToRomanNumberConverter = new ArabicToRomanNumberConverter(userRole);

            foreach (var testData in testDataCollection)
                {

                string romanNumber = arabicToRomanNumberConverter.ConvertArabic(testData.testInput);
                Assert.AreEqual(testData.expectedRomanNumber, romanNumber, testData.testInput.ToString());
                }
            }

        [TestMethod]
        public void TestMethod_ConvertArabicNumber_NotValidUser ()
            {
            var testDataCollection = new[] { 
//invalid inputs
new { testInput = (Int16) 1, expectedRomanNumber = "Not a Valid User" },
new { testInput = (Int16) 5, expectedRomanNumber = "Not a Valid User" },
    };


            String userRole = "invalid user";
            ArabicToRomanNumberConverter arabicToRomanNumberConverter = new ArabicToRomanNumberConverter(userRole);

            foreach (var testData in testDataCollection)
                {

                string romanNumber = arabicToRomanNumberConverter.ConvertArabic(testData.testInput);
                Assert.AreEqual(testData.expectedRomanNumber, romanNumber, testData.testInput.ToString());
                }
            }
        }
    }