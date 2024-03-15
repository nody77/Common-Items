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
            //if (arr1.Length == 0 || arr2.Length == 0)
            //{
            //    return new int[0];
            //}
            //else if (arr1.Length == 1 && arr2.Length == 1)
            //{
            //    if (arr1[0] == arr2[0])
            //    {
            //        return new int[] { arr1[0] };
            //    }
            //    else
            //    {
            //        return new int[0];
            //    }
            //}
            //else
            //{
            //    int mid1 = arr1.Length / 2;
            //    int mid2 = arr2.Length / 2;

            //    int[] left1 = new int[mid1];
            //    int[] right1 = new int[arr1.Length - mid1];

            //    Array.Copy(arr1, 0, left1, 0, mid1);
            //    Array.Copy(arr1, mid1, right1, 0, arr1.Length - mid1);

            //    int[] left2 = new int[mid2];
            //    int[] right2 = new int[arr2.Length - mid2];

            //    Array.Copy(arr2, 0, left2, 0, mid2);
            //    Array.Copy(arr2, mid2, right2, 0, arr2.Length - mid2);

            //    int[] commonLeft = RequiredFuntion(left1, left2);
            //    int[] commonRight = RequiredFuntion(right1, right2);
            //    int[] commonLeftandRight1 = RequiredFuntion(left1, right2);
            //    int[] commonLeftandRight2 = RequiredFuntion(left2, right1);

            //    int[] merge = commonLeftandRight1.Concat(commonLeftandRight2).ToArray();
            //    int[] merge2 = commonLeft.Concat(commonRight).ToArray();

            //    return merge.Concat(merge2).ToArray();
            //}
            int[] common = commonitems(arr1, 0, arr1.Length - 1, arr2, 0, arr2.Length - 1);
            return common;
        }
        public static int[] commonitems(int[] array1, int start1, int end1, int[] array2, int start2, int end2)
        {
            if (start1 > end1 || start2 > end2)
            {
                return new int[0];
            }
            else if (start1 == end1 && start2 == end2)
            {
                if (array1[start1] == array2[start2])
                {
                    return new int[] { array1[start1] };
                }
                else
                {
                    return new int[0];
                }
            }
            else
            {
                int mid1 = (start1 + end1) / 2;
                int mid2 = (start2 + end2) / 2;


                int[] commonLeft = commonitems(array1, start1, mid1, array2, start2, mid2);
                int[] commonRight = commonitems(array1, mid1 + 1, end1, array2, mid2 + 1, end2);
                int[] commonLeftandRight1 = commonitems(array1, start1, mid1, array2, mid2 + 1, end2);
                int[] commonLeftandRight2 = commonitems(array1, mid1 + 1, end1, array2, start2, mid2);

                int[] merge = new int[commonLeft.Length + commonRight.Length];
                int[] merge2 = new int[commonLeftandRight1.Length + commonLeftandRight2.Length];

                Parallel.Invoke(
                () =>  merge = commonLeftandRight1.Concat(commonLeftandRight2).ToArray(),
                () =>  merge2 = commonLeft.Concat(commonRight).ToArray()
                );

                return merge.Concat(merge2).ToArray();
            }
        }
        #endregion
    }
}
