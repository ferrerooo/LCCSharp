// https://www.lintcode.com/problem/43/description

using System;
using System.Collections;
using System.Collections.Generic;

namespace lintcode
{
    class Solution43L {
        /**
         * @param nums: A list of integers
         * @param k: An integer denote to find k non-overlapping subarrays
         * @return: An integer denote the sum of max k non-overlapping subarrays
         */
        public int MaxSubArray(int[] nums, int k) {
            // write your code here

            int[,] dp = new int[k, nums.Length];

            for (int i = 0; i < nums.Length; i++) {
                dp[0, i] = nums[i];
            }

            int maxCurrent = nums[0];
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++) {
                maxCurrent = Math.Max(nums[i], nums[i] + maxCurrent);
                max = Math.Max(max, maxCurrent);
                dp[0, i] = max;
            }

            for (int i = 1; i < k; i++) {

                for (int j = i; j < nums.Length; j++) {

                    if (i == j)
                        dp[i, j] = dp[i-1, j-1] + nums[j];

                    maxCurrent = nums[j];
                    max = nums[j];
                    dp[i, j] = dp[i-1, j-1] + nums[j];
                    for (int m = j - 1; m >= i; m--) {

                        maxCurrent = Math.Max(nums[m], nums[m] + maxCurrent);
                        max = Math.Max(max, maxCurrent);
                        dp[i, j] = Math.Max(dp[i-1, m-1] + max, dp[i, j]);
                    }

                }

            }

            return dp[k-1, nums.Length-1];
        }
    }
}