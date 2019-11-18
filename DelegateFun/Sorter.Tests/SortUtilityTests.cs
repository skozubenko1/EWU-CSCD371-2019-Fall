using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void passNullTest()
        {
            SortUtility arr = new SortUtility();

            arr.Sorter(null, (left, right) => left > right);


        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            SortUtility arr = new SortUtility();

            ComparatorDel ascending = (left, right) => { return left < right; };
            //ComparatorDel descending = (left, right) => { return left < right; };

           int[] array = createRandom(4);

            arr.Sorter(array, ascending);


            Assert.IsTrue(isAscending(array));
        }


        [TestMethod]
        public void SortUtility_ShouldSortDescending()
        {
            SortUtility arr = new SortUtility();

            ComparatorDel descending = (left, right) =>  left > right;

            int[] array = createRandom(4);

            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine(array[i]);
            }

            arr.Sorter(array, descending);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(array[i]);
            }

            Assert.IsTrue(isDescending(array));
        }

        [TestMethod]
        public void TestWithStatement()
        {
            SortUtility arr = new SortUtility();

            int[] array = { 1, 2, 3, 4 };

            arr.Sorter(array, (left, right) => {
                if (left > 2 && right > 2) { return left < right; }
                return left > right;
            });

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(array[i]);
            }
            Assert.IsTrue(isAsAndDes(array));

        }

        static Random random = new Random();
        public int[] createRandom(int length)
        {
            int[] array = new int[length];

            for(int i = 0; i < length; i++)
            {
                array[i] = random.Next(0, 100);
            }

            return array;
        }

        public bool isDescending(int[] array)
        {
            int prev = int.MaxValue;
            
            for(int i = 0; i < array.Length; i++)
            {
                if(prev < array[i])
                {
                    return false;    
                }

                prev = array[i];
            }

            return true;
        }

        public bool isAscending(int[] array)
        {
            int prev = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (prev > array[i])
                {
                    return false;
                }

                prev = array[i];
            }

            return true;
        }

        public bool isAsAndDes(int[] array)
        {
            int prev = int.MinValue;

            for (int i = 0; i < 2; i++)
            {
                if (prev > array[i])
                {
                    return false;
                }

                prev = array[i];
            }

            int prev2 = int.MaxValue;

            for (int i = 2; i < array.Length; i++)
            {
                if (prev2 < array[i])
                {
                    return false;
                }

                prev2 = array[i];
            }

            return true;
        }
    }
}
