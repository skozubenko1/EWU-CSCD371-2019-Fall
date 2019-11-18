using System;

namespace Sorter
{
    public delegate bool ComparatorDel(int left, int right);

    public class SortUtility
    {

        public void Sorter(int[] array, ComparatorDel comp)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comp(array[j], array[min]))
                    {
                        min = j;
                    }
                }

                int temp = array[min];
                array[min] = array[i];
                array[i] = temp;
            }
        }
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison
    }
}
