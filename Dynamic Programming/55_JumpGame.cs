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

