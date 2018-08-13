/*
Text To Number Converter from Coding Challenges
by Silvio Duka

Last modified date: 2018-03-12

Write a program that will convert a decimal number into its text equivalent. 

For Example: 
11: eleven 
193: one hundred ninety three 
1996: one thousand nine hundred ninety six 
*/

using System;
using System.Collections.Generic;

namespace NumberToTextConverter
{
    class Program
    {
        static Dictionary<string, long> dict = new Dictionary<string, long>();

        static void Main(string[] args)
        {
            //some examples
            //string text = "ninety-nine million, nine hundred and nine thousand, nine hundred and ninety-nine"; // Insert a text to convert to number (max. 999999999)
            //string text = "one thousand, nine hundred and ninety-nine ";
            //string text = "twenty five thousand eight hundred sixty three"; // It's OK also in this way
            //string text = "twenty - five thousand, eight hundred and sixty-three";
            //string text = "thousand";

            string text = "nine hundred and ninety-nine million, nine hundred and ninety-nine thousand, nine hundred and ninety-nine ";

            InitDictionary();

            Console.WriteLine($"Input: {text}");
            Console.WriteLine($"Result: {ConvertTextToNumber(text)}");
        }

        static long ConvertTextToNumber(string text)
        {
            if (text == String.Empty) return 0;

            text = text.Replace(',', ' ');
            text = text.Replace('-', ' ');
            text = text.Replace(" and", " ");

            string[] numbers = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long result = 0;
            long tmp = 0;
            int i = 1;
            string old = String.Empty;

            foreach (string number in numbers)
            {
                long t = GetText(number);

                if (number == "thousand" || number == "million")
                {
                    if (old == String.Empty) tmp = 1;
                    result += tmp * t;
                    tmp = 0;
                }
                else if (number == "hundred")
                {
                    if (old == String.Empty) tmp = 1;
                    tmp *= t;
                }
                else
                {
                    tmp += t;
                }

                if (i == numbers.Length) result += tmp;

                i++;
                old += number;
            }

            return result;
        }

        static long GetText(string key)
        {
            long s;

            dict.TryGetValue(key, out s);

            return s;
        }

        static void InitDictionary()
        {
            dict.Add("zero", 0);
            dict.Add("one", 1);
            dict.Add("two", 2);
            dict.Add("three", 3);
            dict.Add("four", 4);
            dict.Add("five", 5);
            dict.Add("six", 6);
            dict.Add("seven", 7);
            dict.Add("eight", 8);
            dict.Add("nine", 9);
            dict.Add("ten", 10);
            dict.Add("eleven", 11);
            dict.Add("twelve", 12);
            dict.Add("thirteen", 13);
            dict.Add("fourteen", 14);
            dict.Add("fifteen", 15);
            dict.Add("sixteen", 16);
            dict.Add("seventeen", 17);
            dict.Add("eighteen", 18);
            dict.Add("nineteen", 19);
            dict.Add("twenty", 20);
            dict.Add("thirty", 30);
            dict.Add("forty", 40);
            dict.Add("fifty", 50);
            dict.Add("sixty", 60);
            dict.Add("seventy", 70);
            dict.Add("eighty", 80);
            dict.Add("ninety", 90);
            dict.Add("hundred", 100);
            dict.Add("thousand", 1000);
            dict.Add("million", 1000000);
        }
    }
}