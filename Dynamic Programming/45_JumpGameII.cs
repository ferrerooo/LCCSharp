// https://leetcode.com/problems/jump-game-ii/

using System;

public class Solution45 {
    public int Jump(int[] nums) {
        
        int len = nums.Length;
        
        if (len == 1)
            return 0;
            
        int[] minJumps = new int[len];
        minJumps[0] = 0;
        int curIndex = 0;
        
        while (minJumps[len-1] == 0) {
            
            for (int i = curIndex+1; i<=nums[curIndex] + curIndex && i<len; i++) {
                if (minJumps[i] == 0)
                    minJumps[i] = minJumps[curIndex] + 1;
                else
                    minJumps[i] = Math.Min(minJumps[i], minJumps[curIndex] + 1);
            }
            
            curIndex ++;
        }
        
        return minJumps[len-1];
        
    }
}