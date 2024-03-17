using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class PROBLEM_CLASS
    {
        #region YOUR CODE IS HERE 

        enum SOLUTION_TYPE { NAIVE, EFFICIENT };
        static SOLUTION_TYPE solType = SOLUTION_TYPE.EFFICIENT;


        static Semaphore semaphore = new Semaphore(1,1);

        //Your Code is Here:
        //==================
        /// <summary>
        /// Find common elements between the given arrays (if any) 
        /// If not found, return an empty array (i.e. new int[] { })
        /// </summary>
        /// <param name="arr1">1st array </param>
        /// <param name="arr2">2nd array </param>
        /// <returns>array of common element (if any) or empty array if no common elements. </returns>
        static public int[] RequiredFuntion(int[] arr1, int[] arr2)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            Array.Sort(arr2);
            int size_of_array1 = arr1.Length;
            int number_of_common_item_found = 0;
            int[]temp = new int[size_of_array1];
            int[] commonitems;
            Parallel.For(0, size_of_array1, i =>
            {
                bool flag = BinarySearch(0, arr2.Length - 1, arr1[i], arr2);
                if (flag)
                {
                    semaphore.WaitOne();
                    temp[number_of_common_item_found] = arr1[i];
                    number_of_common_item_found++;
                    semaphore.Release();
                }
            });
            commonitems = new int[number_of_common_item_found];
            Array.Copy(temp, 0, commonitems, 0, number_of_common_item_found);
            return commonitems;
        }
        public static bool BinarySearch(int start_n , int end_a , int item_d , int[] array_a)
        {
            if(start_n > end_a)
            {
                return false;
            }
            else
            {
                int middle_of_array = (start_n + end_a) / 2;
                if (item_d == array_a[middle_of_array])
                {
                    return true;
                }
                else if (item_d > array_a[middle_of_array])
                {
                    return BinarySearch(middle_of_array + 1, end_a, item_d, array_a);
                }
                else
                {
                    return BinarySearch(start_n, middle_of_array - 1, item_d, array_a);
                }
            }
        }
        #endregion
    }
}
