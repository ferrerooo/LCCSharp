// https://www.lintcode.com/problem/45/

using System;
using System.Collections;
using System.Collections.Generic;

namespace lintcode
{
    class Solution45L {
        /**
         * @param nums: A list of integers
         * @return: An integer indicate the value of maximum difference between two substrings
         */
        public int MaxDiffSubArrays(int[] nums) {
            // write your code here

            return Math.Max(GetMaxDiff1(nums), GetMaxDiff2(nums));
        }

        private static int GetMaxDiff1(int[] nums) {
            int[] left = new int[nums.Length];
            int[] right = new int[nums.Length];

            left[0] = nums[0];
            int maxCurrent = nums[0];
            for (int i = 1; i<nums.Length; i++) {
                maxCurrent = Math.Max(nums[i], nums[i] + maxCurrent);
                left[i] = Math.Max(left[i-1], maxCurrent);
            }

            right[nums.Length-1] = nums[nums.Length-1];
            int minCurrent = nums[nums.Length-1];
            for (int i = nums.Length-2; i>=0; i--) {
                minCurrent = Math.Min(nums[i], nums[i] + minCurrent);
                right[i] = Math.Min(right[i+1], minCurrent);
            }

            int globalMax = Int32.MinValue;
            for (int i=0;i<nums.Length-1; i++) {
                globalMax = Math.Max(Math.Abs(left[i]-right[i+1]), globalMax);
            }

            return globalMax;
        }

        private static int GetMaxDiff2(int[] nums) {
            int[] left = new int[nums.Length];
            int[] right = new int[nums.Length];

            left[0] = nums[0];
            int minCurrent = nums[0];
            for (int i = 1; i<nums.Length; i++) {
                minCurrent = Math.Min(nums[i], nums[i] + minCurrent);
                left[i] = Math.Min(left[i-1], minCurrent);
            }

            right[nums.Length-1] = nums[nums.Length-1];
            int maxCurrent = nums[nums.Length-1];
            for (int i = nums.Length-2; i>=0; i--) {
                maxCurrent = Math.Max(nums[i], nums[i] + maxCurrent);
                right[i] = Math.Max(right[i+1], maxCurrent);
            }

            int globalMax = Int32.MinValue;
            for (int i=0;i<nums.Length-1; i++) {
                globalMax = Math.Max(Math.Abs(right[i+1]-left[i]), globalMax);
            }
            
            return globalMax;
        }
    }
}

