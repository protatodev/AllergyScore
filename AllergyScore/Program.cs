/*
 * Here's something a bit trickier and please only attempt this if you have completed the first two projects and had them both checked by an instructor. An allergy score is a single number that tells what someone is allergic to. The scores for each allergen are:

allergen     score
eggs         1
peanuts      2
shellfish    4
strawberries 8
tomatoes     16
chocolate    32
pollen       64
cats         128

So if someone is allergic to eggs and strawberries, they get a score of 9.

Build a website that uses a method that is called on someone's score - i.e. the score is the object, and returns an array listing what they're allergic to. For example, running allergies(3) should print a list of the person's allergies (eggs and peanuts) to the screen.
 * 
 */

using System;
using System.Collections.Generic;

namespace AllergyScore
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.GetUserInput();
        }
    }

    public class Person
    {
        int allergyScore = 0;
        AllergyTracker tracker = new AllergyTracker();

        public void GetUserInput()
        {
            Console.WriteLine("Enter Your Allergy Score");
            allergyScore = int.Parse(Console.ReadLine());
            List<string> allergyList = tracker.GetAllergies(allergyScore);
            printAllergies(allergyList);
        }

        public void printAllergies(List<string> allergyList)
        {
            Console.WriteLine("Your Allergy Score: {0}", allergyScore);
            Console.WriteLine("*** Your Allergies ***");

            foreach (string allergy in allergyList)
            {
                Console.WriteLine("*: {0}", allergy);
            }
        }
    }

    public class AllergyTracker
    {
        Dictionary<string, int> library = new Dictionary<string, int>() { { "eggs", 1}, { "peanuts", 2 }, { "shellfish", 4 }, { "strawberries", 8 }, { "tomatoes", 16 }, { "chocolate", 32 }, { "pollen", 64 }, { "cats", 128 } };

        public List<string> GetAllergies(int score)
        {
            int updatedScore = score;
            List<string> allergyArray = new List<string>() { };

            foreach(KeyValuePair<string, int> allergy in library)
            {
                if(updatedScore >= allergy.Value && !allergyArray.Contains(allergy.Key))
                {
                    allergyArray.Add(allergy.Key);
                    updatedScore -= allergy.Value;
                }
            }

            return allergyArray;
        } 
    }
}
