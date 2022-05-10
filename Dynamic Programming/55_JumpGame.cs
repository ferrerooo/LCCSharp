// https://leetcode.com/problems/jump-game/

using System;

public class Solution55 {
    public bool CanJump(int[] nums) {
        
        int lastIndex = nums.Length-1;
        int currentIndex = 0;
        int maxIndex = 0;
        
        while (currentIndex <= maxIndex) {
            
            if (maxIndex >= lastIndex)
                return true;
            
            maxIndex = Math.Max(maxIndex, currentIndex + nums[currentIndex]);
            currentIndex ++;
        }
        
        return false;
    }
}

/*
// another time do this problem. different from above solution.

public class Solution {
    public bool CanJump(int[] nums) {
        
        if (nums == null || nums.Length == 0)
            return false;
        
        bool[] dp = new bool[nums.Length];
        
        dp[0] = true;
        
        for (int i = 1; i < nums.Length; i++) {
            
            for (int j = i - 1; j >= 0; j--) {
                
                if (j + nums[j] >= i) {
                    dp[i] = true;
                    break;
                }
            }
            
            if (dp[i] == false)
                return false;
        }
        
        return true;
    }
}

*/

