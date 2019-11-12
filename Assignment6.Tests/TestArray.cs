using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment6.Tests
{
    [TestClass]
    public class TestArray
    {
        [TestMethod]
        public void TestIterable()
        {
            Array<Object> array = new Array<Object>(500);

            string str = "";

            for(int i = 0; i < 5; i++)
            {
                array.Add(i);
                str += i.ToString();
            }

            var iterator = array.GetEnumerator();
            string str2 = "";

            while(iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
                str2 += iterator.Current.ToString();
            }

            foreach(var o in array)
            {
                Console.WriteLine(o);
            }

            Assert.AreEqual(str, str2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNull()
        {
            Array<Object> array = new Array<Object>(500);

            array.Add(null);
        }

        [TestMethod]
        public void TestRemoveContainsClear()
        {
            int test = 1;

            Array<int> array = new Array<int>(500);
            array.Add(test);

            Assert.IsTrue(array.Contains(1));

            array.Remove(test);

            Assert.IsFalse(array.Contains(1));

            array.Add(test);
            array.Add(2);
            array.Clear();

            Assert.AreEqual(0, array.Count);
        }
    }
}
