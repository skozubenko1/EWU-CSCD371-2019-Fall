using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



namespace Assignment.Tests
{
    [TestClass]
    public class Tests
    {
        /// D. Include a test that leverages a hard coded list of Spokane based addresses.
        [TestMethod]
        public void Test_HardCodedSpokaneValues()
        {

        }



        [TestMethod]
        public void Test_FilterByEmailAddress()
        {
            //not yet fully implemented..
            SampleData data = new SampleData();

            string csvRows = "1, Priscilla, Jenyns, pjenyns0@state.gov,7884 Corry Wa y, Helena, MT,70577\n" +
                "2,Karin,Joder,kjoder1 @quantcast.com,03594 Florence Park, Tampa, FL,71961\n" +
                "3,Chadd,Stennine,cstennine2 @wired.com,94148 Kings Terrace, Long Beach,CA,59721";
            
            //IEnumerable<string> emails = 
        }

        /// E. Include a test that uses LINQ to verify the data is sorted correctly (do not use a hard coded list).
        [TestMethod]
        public void GetUniqueSortedListOfStates_Linq_ReturnsCorrectlySortedList()
        {
            SampleData _Data = new SampleData();

            string expected_result = "ALAZCADCFLGAINKSLAMDMNMOMTNCNENHNVNYORPASCTNTXUTVAWAWV";

            IEnumerable<string> states = _Data.GetUniqueSortedListOfStatesGivenCsvRows();

            string my_result = "";

            foreach(var line in states)
            {
                my_result += line;
            }

            //Console.Write(my_result);
            Assert.AreEqual(expected_result, my_result);

        }



    }
}

