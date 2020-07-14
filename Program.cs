using System;
using System.Collections.Generic;
using System.Collections;

namespace AllAnagrams
{
/*8. Given an array of strings, group all anagrams and return an array of array of strings
Eg: Given [ "act", "rat", "cat", "tar", "hello", "art" ] 
Return [ [ "act", "cat" ], [ "rat", "art", "tar" ] , [ "hello" ] ] 
Note: order doesn't matter
*/

// Create a dictionary using ASCII value addition of each string as the key
// and a list of strings as the value
// Iterate through the given array
// For each string, calculate the sum of ASCII value of each char
// If this value is present in the dictionary as key, add the string to the value list
// Or, create a key using the sum value and add the string as value in the list

    static class GroupAnagrams
    {

        static List<List<String>> GetGroupsOfAnagrams(List<String> array) {
            if (array.Count == 0) {
                return null;
            }

            Dictionary<int, List<String>> anagrams = new Dictionary<int, List<string>>();

            foreach (String str in array) {
                int sum = CalculateSumOfAscii(str);
                if (anagrams.ContainsKey(sum)) {
                    anagrams[sum].Add(str);
                }
                else {
                    anagrams.Add(sum, new List<string>() {str});
                }
            }

            List<List<String>> anagramGroups = new List<List<string>>();
            foreach (var anagram in anagrams) {
                anagramGroups.Add(anagram.Value);
            }

            return anagramGroups;
        }

        static int CalculateSumOfAscii(String str) {
            if (String.IsNullOrEmpty(str)) {
                return 0;
            }

            int sum = 0;
            for(int i = 0; i < str.Length; i++) {
                sum = sum + (int)(str[i]);
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = GroupAnagrams.GetGroupsOfAnagrams(new List<String>() {"act", "rat", "cat", "tar", "hello", "art" });
            foreach (var anagram in result) {
                Console.WriteLine(String.Join("\n", anagram));
            }
        }
    }
}
