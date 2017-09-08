using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_152
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tt = new int[2] { 0, 2 };
            Solution1 solution = new Solution1();
            solution.MaxProduct( tt);
        }
    }

    public class Solution
    {
        public int MaxProduct(int[] nums)
        {
            bool NegativePair = true;
            int FirstNegativeIndex = -1, LastNegativeIndex = -1;
            int answer = 1;
            int a1, a2, a3, a4;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    NegativePair = !NegativePair;

                    if (FirstNegativeIndex == -1)
                        FirstNegativeIndex = i;
                    else
                        LastNegativeIndex = i;
                }
            }

            if (NegativePair)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    answer = answer * nums[i];
                }
            }
            else
            {
                a1 = Prodcut(nums, 0, FirstNegativeIndex);
                a2 = Prodcut(nums, FirstNegativeIndex, nums.Length);
                a3 = Prodcut(nums, 0, LastNegativeIndex);
                a4 = Prodcut(nums, LastNegativeIndex, nums.Length);

                answer = a1;

                if (a2 > answer)
                    answer = a2;
                if (a3 > answer)
                    answer = a3;
                if (a4 > answer)
                    answer = a4;

            }


            return answer;

        }

        public int Prodcut(int[] nums, int FirstIndex, int LastIndex)
        {
            if (LastIndex == -1 || FirstIndex == -1 || (FirstIndex == 0 && LastIndex == 0)) return -1000;

            int ReturnValue = 1;

            for (int i = FirstIndex; i < LastIndex; i++)
            {
                ReturnValue = ReturnValue * nums[i];
            }

            return ReturnValue;

        }
    }

    public class Solution1
    {
        public int MaxProduct(int [] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int max_p = -10000;
            int p = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                p *= nums[i];
                max_p = Math.Max(max_p, p);
                if (nums[i] == 0)
                    p = 1;

            }
            p = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                p *= nums[i];
                max_p = Math.Max(max_p, p);
                if (nums[i] == 0)
                    p = 1;
            }
            return max_p;

        }
    }
}
