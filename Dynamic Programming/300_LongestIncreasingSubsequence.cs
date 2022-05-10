// https://leetcode.com/problems/longest-increasing-subsequence/

/* TODO : think about nlogn solution. */

using System;
public class Solution300 {
    public int LengthOfLIS(int[] nums) {
        
        if (nums == null || nums.Length == 0)
            return 0;
        
        int[] dp = new int[nums.Length];
        
        for (int i = 0; i < nums.Length; i++)
            dp[i] = 1;
        
        for (int i = 1; i < dp.Length; i++) {
            
            for (int j = 0; j < i; j++) {
                
                if (nums[i] > nums[j]) {
                    dp[i] = Math.Max(dp[j] + 1, dp[i]);
                }
            }
        }
        
        return GetMax(dp);
    }
    
    private static int GetMax(int[] dp) {
        
        int max = 0;
        
        foreach (var i in dp) {
            max = Math.Max(max, i);
        }
        
        return max;
    }
}