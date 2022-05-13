// https://leetcode.com/problems/maximum-subarray/

using System;
 public class Solution53 {
    public int MaxSubArray(int[] nums) {
        
        int[] dp = new int[nums.Length];
        
        dp[0] = nums[0];
        
        for (int i = 1; i< nums.Length; i++) {
            
            if (dp[i-1] <= 0)
                dp[i] = nums[i];
            else
                dp[i] = nums[i] + dp[i-1];
        }
        
        return GetMax(dp);
    }
    
    private static int GetMax(int[] dp) {
        
        int max = Int32.MinValue;
        
        foreach (var i in dp)
            max = Math.Max(max, i);
        
        return max;
    }
}