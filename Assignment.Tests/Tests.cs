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
        //So I can use it for all tests
        SampleData Data = new SampleData();

        [TestMethod]
        public void Test_HardCodedSpokaneValues()
        {
            SampleData Data = new SampleData("Spokane.csv");

            Assert.IsTrue(Data.GetUniqueSortedListOfStatesGivenCsvRows().ToList().Count == 1);
        }

        void Find_And_Check_Email(IPerson p)
        {
            // Find all people with the email address of this person (p).
            var list = Data.FilterByEmailAddress(x => x == p.EmailAddress).ToList();
            
            // Since we assume email is unique, we expect only one record.
            Assert.IsTrue(list.Count == 1);

            // To make sure we check first and last name as well.
            Assert.IsTrue(list[0].FirstName == p.FirstName && list[0].LastName == p.LastName);
        }

        [TestMethod]
        public void Test_FilterByEmailAddress()
        {
            //Assuming that email is unique
            foreach(var p in Data.People)
            {
                Find_And_Check_Email(p);
            }
        }

        [TestMethod]
        public void TestUseLinqtoVerifyDataSortedCorrectly()
        {
            string prev = "";

            Data.GetUniqueSortedListOfStatesGivenCsvRows().ToList().ForEach(x => {
                Assert.IsTrue(prev.CompareTo(x) <= 0);
                prev = x;
            });
        }

        [TestMethod]
        public void GetUniqueSortedListOfStates()
        {
            SampleData _Data = new SampleData();

            string expected_result = "ALAZCADCFLGAINKSLAMDMNMOMTNCNENHNVNYORPASCTNTXUTVAWAWV";

            IEnumerable<string> states = _Data.GetUniqueSortedListOfStatesGivenCsvRows();

            string my_result = "";
            
            foreach(var line in states)
            {
                my_result += line;
            }

            Assert.AreEqual(expected_result, my_result);
        }

        [TestMethod]
        public void TestPeopleProperty()
        {
            // Consider using ISampleData.CsvRows in your test to verify your results.
            var people = Data.People.ToArray();
            var csv = Data.CsvRows.ToArray();

            //Check if the length is the same
            Assert.IsTrue(people.Length == csv.Length);

            //checked if all the address is not null
            foreach(var p in people)
            {
                Assert.IsNotNull(p.Address);
            }

            //Id,FirstName,LastName,Email,StreetAddress,City,State,Zip         
            foreach (var row in csv)
            {
                var parts = row.Split(',');

                //assuming that email address is unique;
                Assert.IsNotNull(people.FirstOrDefault(x => x.EmailAddress == parts[3]));
            }
        }
    }
}

