// https://leetcode.com/problems/house-robber/

using System;
public class Solution198 {
    public int Rob(int[] nums) {
        
        if (nums == null || nums.Length == 0)
            return 0;
        
        if (nums.Length == 1)
            return nums[0];
        
        int[] dp = new int[nums.Length];
        
        for (int i = 0; i < nums.Length; i++) {
            
            if (i == 0 || i == 1) {
                dp[i] = nums[i];
                continue;
            }
            
            if (i == 2) {
                dp[i] = dp[i-2] + nums[i];
                continue;
            }
            
            // do not need to look back more than i-3.
            dp[i] = Math.Max((dp[i-2] + nums[i]), (dp[i-3] + nums[i]));
        }
        
        return Math.Max(dp[nums.Length-1], dp[nums.Length-2]);
    }
}