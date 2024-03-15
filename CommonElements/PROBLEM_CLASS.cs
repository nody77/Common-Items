using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
            int n = arr1.Length;
            int count = 0;
            int[]temp = new int[n];
            int[] commonitems;
            for (int i = 0; i < n; i++)
            {
                bool flag = BinarySearch(0, arr2.Length-1, arr1[i], arr2);
                if (flag)
                {
                    
                    temp[count] = arr1[i];
                    count++;
                }
            }
            commonitems = new int[count];
            Array.Copy(temp, 0, commonitems, 0, count);
            return commonitems;
        }
        public static bool BinarySearch(int start , int end , int item , int[] array)
        {
            if(start > end)
            {
                return false;
            }
            else
            {
                int middle = (start + end) / 2;
                if (item == array[middle])
                {
                    return true;
                }
                else if (item > array[middle])
                {
                    return BinarySearch(middle + 1, end, item, array);
                }
                else
                {
                    return BinarySearch(start, middle - 1, item, array);
                }
            }
        }
        #endregion
    }
}
