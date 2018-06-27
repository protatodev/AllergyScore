using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllergyScore;
using System;
using System.Collections.Generic;

namespace AllergyScoreTest
{
    [TestClass]
    public class AllergyScoreTest
    {
        Dictionary<string, int> library = new Dictionary<string, int>() { { "eggs", 1 }, { "peanuts", 2 }, { "shellfish", 4 }, { "strawberries", 8 }, { "tomatoes", 16 }, { "chocolate", 32 }, { "pollen", 64 }, { "cats", 128 } };

        [TestMethod]
        public bool GetAllergies_ReturnTrue(int score)
        {
            bool isEmpty = true;
            List<string> allergyArray = new List<string>() { };

            foreach (KeyValuePair<string, int> allergy in library)
            {
                if (score > allergy.Value)
                {
                    allergyArray.Add(allergy.Key);
                    score--;
                }
            }

            if(allergyArray.Count > 0)
            {
                isEmpty = false;
            }

            return isEmpty;
        }

        [TestMethod]
        public void isGetAllergies_True()
        {
            Assert.AreEqual(false, GetAllergies_ReturnTrue(3));
        }
    }
}
