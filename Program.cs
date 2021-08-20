using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UkenTest {
    class Program {

        /*
        creating a function that takes in an int array and length of the array
        then creating a sorted dictionary that counts the occurrences for each int
        and then runs through the dictionary to find the result and lowest number
        */
        static string fewestOccurrences(int []nums, int length) {
            SortedDictionary<int, int> countOccurrences = new SortedDictionary<int, int>();

            for (int i = 0; i < length; i++) {
                int key = nums[i];
                if (countOccurrences.ContainsKey(key)) {
                    int occurrence = countOccurrences[key];
                    occurrence++;
                    countOccurrences[key] = occurrence;
                } else {
                    countOccurrences.Add(key, 1);
                }
            }

            int min = length + 1, result = -1;
            foreach (KeyValuePair<int, int> pair in countOccurrences) {
                if (min > pair.Value) {
                    result = pair.Key;
                    min = pair.Value;
                }
            }
            return "Number: " + result + " Repeated: " + min;
        }

        static void Main(string[] args) {

            string path = @"C:\Users\there\source\repos\UkenTest\testfiles/1.txt";
            for (int i = 1; i < 6; i++) {
                string filepath = Regex.Replace(path, "[0-9]", i.ToString());
                /*
                creating a string array that accesses the test files and reads all lines
                then converts every entry into an int array
                before feeding into the function and writing to the console in the proper format
                */
                string[] fileContent = System.IO.File.ReadAllLines(filepath);
                int[] nums = Array.ConvertAll(fileContent, int.Parse);
                Console.WriteLine("File: {0}.txt " + fewestOccurrences(nums, nums.Length), i);
            }
        }
    }
}
