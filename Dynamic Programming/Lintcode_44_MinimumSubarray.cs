// https://www.lintcode.com/problem/44/

using System;
using System.Collections;
using System.Collections.Generic;

namespace lintcode
{
    class Solution44L {
        /**
         * @param nums: a list of integers
         * @return: A integer indicate the sum of minimum subarray
         */
        public int MinSubArray(List<int> nums) {
            // write your code here

            int minCurrent = nums[0];
            int min = minCurrent;

            for (int i = 1; i < nums.Count; i++) {
                minCurrent = Math.Min(nums[i], nums[i] + minCurrent);
                min = Math.Min(min, minCurrent);
            }

            return min;
        }
    }
}