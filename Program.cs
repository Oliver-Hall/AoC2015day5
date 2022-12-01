using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
internal class Program
{
    private static void Main(string[] args)
    {
       
        // Create a variable for the file path
        string textFilePath = @"C:\Users\omh\OneDrive - The Kings School Chester\C SHarp\AoC2015day5\AoC2015Day5.txt";

        // Read a text file into an array of strings called lines
        string[] lines = File.ReadAllLines(textFilePath);

        int part1NiceCount = 0;
        int part2NiceCount = 0;
        // loop through each line
        foreach (string line in lines)
        {
            if (Day5.threeVowels(line) && Day5.twiceInARow(line) && Day5.doesNotInclude(line))
            {
                part1NiceCount++;
                Console.WriteLine($"{line} is Nice for part 1");
            }
            Console.WriteLine($"{line} is Naughty for part 1");
            
            if (Day5.twoLetterPair(line) && Day5.repeatsLetter(line))
            {
                part2NiceCount++;
                Console.WriteLine($"{line} is Nice for part 2");
            }
            Console.WriteLine($"{line} is Naughty for part 2");
        }
        Console.WriteLine($"Part 1 Total is {part1NiceCount}");
        Console.WriteLine($"Part 2 Total is {part2NiceCount}");
    }
    public class Day5
    {
        //part 1
        public static bool threeVowels(string inp)
        {
            // match if string contains three vowels
            //feels like a job for regex

            // regex
            // [aeiou] character is a vowel
            // .* any character 0 or more times
            string regex3Vowels = "[aeiou].*[aeiou].*[aeiou]";
            MatchCollection matches = Regex.Matches(inp, regex3Vowels);
            
            //if there are more than 1 match then 
            if (matches.Count > 0)
            { 
                return true; 
            }
            else 
            { 
                return false; 
            }

        }
        public static bool twiceInARow(string inp)
        {
            // check if character appears twice in a row in string
            // can't start with empty string so space will do.
            char prevLetter = ' ';
            // loop through each letter and see if it matches prev letter
            foreach (char letter in inp)
            {
                // if matches return true as don't need to check the rest
                if (letter == prevLetter) 
                {
                    return true;
                }
                else //need to update the prev letter to current letter.
                { 
                    prevLetter = letter; 
                }
            }
            return false;
        }
        public static bool doesNotInclude(string inp)
        {
            // check if string does not include specified bad strings

            bool containsBad = false;
            //create list of bad strings to compare against
            string[] listOfBad = new string[] { "ab", "cd", "pq", "xy" };
            foreach (string s in listOfBad)
            {
                if (inp.Contains(s))
                {
                    containsBad = true;
                }
            }
            // wants to know if NOT containing.
            return !containsBad;
        }

        //part 2
        public static bool twoLetterPair(string inp)
        {
            //check if string contains two letter pair

            //loop up to penultimate pair
            for (int letterIndex = 0; letterIndex < inp.Length-2; letterIndex++)
            {
                //create pair 
                string letterPair = inp.Substring(letterIndex, 2);
                //check if remaining substring contains pair
                if (inp.Substring(letterIndex+2).Contains(letterPair))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool repeatsLetter(string inp)
        {
            // see if letter appears twice spaced apart by 1. eg. **a*a****
            // loop through each letter avoiding going out of bounds.
            for (int letterIndex = 0; letterIndex < inp.Length - 2; letterIndex++)
            {
                // compare letter with letter further on.
                if (inp[letterIndex] == inp[letterIndex+2])
                {
                    return true;
                }
            }
            // got to end without a match.
            return false;
        }
    }
    
}