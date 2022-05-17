// https://www.lintcode.com/problem/42/

using System;
using System.Collections;
using System.Collections.Generic;

namespace lintcode
{
    class Solution42L {
        /**
         * @param nums: A list of integers
         * @return: An integer denotes the sum of max two non-overlapping subarrays
         */
        public int MaxTwoSubArrays(List<int> nums) {
            // write your code here

            int[] left = new int[nums.Count];
            int[] right = new int[nums.Count];

            left[0] = nums[0];
            for (int i = 1; i < nums.Count; i++) {
                if (left[i-1] > 0) {
                    left[i] = left[i-1] + nums[i];
                } else {
                    left[i] = nums[i];
                }
            }

            right[nums.Count-1] = nums[nums.Count-1];
            for (int i = nums.Count - 2; i>=0; i--) {
                if (right[i+1] > 0)
                    right[i] = right[i+1] + nums[i];
                else
                    right[i] = nums[i];
            }

            // left to right, till index i, what is the max sum
            int[] dpleft = new int[nums.Count];
            dpleft[0] = left[0];
            for (int i = 1; i<nums.Count; i++) {
                dpleft[i] = Math.Max(left[i], dpleft[i-1]);
            }

            // right to left, till index i, what is the max sum
            int[] dpright = new int[nums.Count];
            dpright[nums.Count-1] = right[nums.Count-1];
            for (int i = nums.Count-2; i>=0; i--) {
                dpright[i] = Math.Max(right[i], dpright[i+1]);
            }

            int max = Int32.MinValue;

            for (int i = 0;i<nums.Count-1; i++) {
                max = Math.Max(max, dpleft[i] + dpright[i+1]);
            }

            return max;

        }
    }
}