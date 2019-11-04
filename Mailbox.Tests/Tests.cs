using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
     class Tests
    {
        [TestMethod]
        public void TestPersonEquals()
        {
            string lname = "Kozubenko";
            Person p1 = new Person("Alla", lname);
            Person p2_same = new Person("Alla", lname);
            Person p3_difFname = new Person("Sveta", lname);
            Person p4_diflname = new Person("Alla", "Jacobs");

            Assert.AreEqual(p1.Equals(p2_same), true);
            Assert.AreEqual(p1.Equals(p3_difFname), false);
            Assert.AreEqual(p1.Equals(p4_diflname), false);
        }

        [TestMethod]
        public void TestSaveAndLoad()
        {
            var FileName = "test.json";

            var mailboxes = CreateTestMailboxes();
             

            using (var dataLoader = new DataLoader(File.Open(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
            {
                dataLoader.Save(mailboxes);
            }


            string jsonData = JsonConvert.SerializeObject(mailboxes);

            string fileData = File.ReadAllText(FileName);


            Assert.AreEqual(jsonData == fileData, true);

            //trying
            using var dataLoad = new DataLoader(File.Open("test.json", FileMode.OpenOrCreate, FileAccess.ReadWrite));

            Mailboxes boxes = new Mailboxes(dataLoad.Load() ?? new List<Mailbox>(), 30, 10);

            Assert.AreEqual(boxes.Equals(mailboxes), true);

        }

        [TestMethod]
        public Mailboxes CreateTestMailboxes()
        {
            Mailboxes mailboxes = new Mailboxes(new List<Mailbox>(), 30, 10);

            for (int i = 0; i < 30; i++)
            {
                if (Mailboxes.AddNewMailbox(mailboxes, "12345" + i, "54321" + i, Size.Small) is Mailbox mailbox)
                {
                    mailboxes.Add(mailbox);
                }
            }

            return mailboxes;
        }

        [TestMethod]
        public void TestMailInfoAndToString()
        {
            Mailbox mb = new Mailbox(Size.Large, (0, 0), new Person("Alla", "Kozubenko"));
            Mailboxes boxes = CreateTestMailboxes();

            string s1 = boxes[0].Location.ToString();
            string s2 = boxes[1].Location.ToString();
            string o1 = boxes[0].Owner.ToString();
            string o2 = boxes[1].Owner.ToString();

            string str = mb.Location.ToString();

            Assert.AreEqual("(0, 0)" == str, true);
            Assert.AreEqual(s1 == s2, false);
            Assert.AreEqual("Alla, Kozubenko" == mb.Owner.ToString(), true);
            Assert.AreEqual(o1 == o2, false);
        }
    }
}
