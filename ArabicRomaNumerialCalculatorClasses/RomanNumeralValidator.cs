using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//http://agilekatas.co.uk/katas/romannumerals-kata.html
namespace ArabicRomaNumerialCalculatorClasses
    {

    public class RomanNumeralValidator
        {
        protected String message = null;
        public List<char> VALID_ROMMAN_LETTERS = null;
        protected List<char> VALID_ROMMAN_LETTERS_LOWERCASE = null;

        public RomanNumeralValidator ()
            {

            VALID_ROMMAN_LETTERS = new List<char>() { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            VALID_ROMMAN_LETTERS_LOWERCASE = new List<char>() { 'i', 'v', 'x', 'l', 'c', 'd', 'm' };
            }

        public bool RomanNumeralStringIsValid ( string testRomanCharacterString )
            {

            bool isValid = false;

            bool isValidRomanNumeralCharacters = true;
            bool hasLowercaseRomanNumerals = false;
            string hasLowercaseRomanNumeralsMeaasge = "Lower case roman numerals are not valid.";


            bool hasMoreThanThreeRomanNumeralsRepeatsIsOk = true;
            string hasMoreThanThreeRomanNumeralsRepeatsMessage = "'I', 'X', 'C', and 'M' can be repeated at most 3 times in a row.";

            bool canNeverBeRepeatedIsOk = true;
            string canNeverBeRepeatedMessage = "'V', 'L', and 'D' can never be repeated.";


            List<String> InValidCharacters = new List<string>();

            List<char> testRomanCharList = testRomanCharacterString.ToList();
            testRomanCharList.ForEach(delegate( char romanChar )
            {
                if (!VALID_ROMMAN_LETTERS.Contains(romanChar))
                    {
                    isValidRomanNumeralCharacters = false;
                    InValidCharacters.Add(romanChar.ToString());

                    if (VALID_ROMMAN_LETTERS_LOWERCASE.Contains(romanChar))
                        {
                        hasLowercaseRomanNumerals = true;
                        }
                    }

            });

         


            if (isValidRomanNumeralCharacters)
                {
                string patternCanBeRepeatedAtMostThreeTimes = @"([I]{4,}|[X]{4,}|[C]{4,}|[M]{4,})+";
                Regex regex = new Regex(patternCanBeRepeatedAtMostThreeTimes);
                if (regex.IsMatch(testRomanCharacterString))
                    {
                    hasMoreThanThreeRomanNumeralsRepeatsIsOk = false;
                    }

                string patternCanNeverBeRepeated = @"([V]{2,}|[L]{2,}|[D]{2,})+";
                regex = new Regex(patternCanNeverBeRepeated);
                if (regex.IsMatch(testRomanCharacterString))
                    {
                    canNeverBeRepeatedIsOk = false;
                    }

                }


            isValid = isValidRomanNumeralCharacters && hasMoreThanThreeRomanNumeralsRepeatsIsOk && canNeverBeRepeatedIsOk;
            if (!isValid)
                {
                List<string> messageList = new List<string>();
                if (!isValidRomanNumeralCharacters)
                    {
                    messageList.Add(String.Join(null, InValidCharacters) + " is not a valid roman numeral.");
                    }
                if (hasLowercaseRomanNumerals)
                    {
                    messageList.Add(hasLowercaseRomanNumeralsMeaasge);
                    }
                if (!hasMoreThanThreeRomanNumeralsRepeatsIsOk)
                    {
                    messageList.Add(hasMoreThanThreeRomanNumeralsRepeatsMessage);
                    }
                if (!canNeverBeRepeatedIsOk)
                    {
                    messageList.Add(canNeverBeRepeatedMessage);
                    }

                message = string.Join(" ", messageList);

                }
            else
                {
                message = "ok";
                }
            return isValid;
            }

        public string getCommandMessage ()
            {
            return message;
            }
        }

    }