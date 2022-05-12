// https://www.lintcode.com/problem/39/

using System;
using System.Collections;
using System.Collections.Generic;

namespace lintcode
{
    class Solution39L {
        /**
         * @param nums: An integer array
         * @return: nothing
         */
        public void RecoverRotatedSortedArray(List<int> nums) {

            if (nums == null)
                return;

            int start = 0;

            for (int i = 0; i < nums.Count - 1; i++) {

                if (nums[i] > nums[i+1]) {
                    start = i + 1;
                    break;
                }
            }

            if (start == 0)
                return;

            Reverse(nums, 0, start - 1);
            Reverse(nums, start, nums.Count - 1);
            Reverse(nums, 0, nums.Count - 1);

            return;
        }

        private static void Reverse(List<int> nums, int a, int b) {
            
            while (a < b) {
                int temp = nums[a];
                nums[a] = nums[b];
                nums[b] = temp;
                a++;
                b--;
            }

            return;
        }

        private static string PrintIt(List<int> nums) {
            string str = "";

            foreach (var i in nums)
                str = str + i + ",";
            
            return str;
        }
    }
}