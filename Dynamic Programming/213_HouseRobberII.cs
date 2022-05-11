// https://leetcode.com/problems/house-robber-ii/

using System;
public class Solution213 {
    public int Rob(int[] nums) {
        
        if (nums == null || nums.Length == 0)
            return 0;
        
        if (nums.Length == 1)
            return nums[0];
        
        if (nums.Length == 2)
            return Math.Max(nums[0], nums[1]);
        
        int[] dpRob1st = new int[nums.Length];
        int[] dpNotRob1st = new int[nums.Length];
        
        for (int i = 0; i < nums.Length; i++) {
            
            if (i == 0) {
                dpRob1st[i] = nums[0];
                dpNotRob1st[i] = 0;
                continue;
            }
            
            if (i == 1) {
                dpRob1st[1] = 0;
                dpNotRob1st[1] = nums[1];
                continue;
            }
            
            if (i == 2) {
                dpRob1st[i] = dpRob1st[0] + nums[2];
                dpNotRob1st[i] = nums[2];
                continue;
            }
            
            dpRob1st[i] = Math.Max((nums[i] + dpRob1st[i-2]), (nums[i] + dpRob1st[i-3]));
            dpNotRob1st[i] = Math.Max((nums[i] + dpNotRob1st[i-2]), (nums[i] + dpNotRob1st[i-3]));
            
        }
        
        int Rob1stMax = Math.Max(dpRob1st[nums.Length-2], dpRob1st[nums.Length-3]);
        int NotRob1stMax = Math.Max(dpNotRob1st[nums.Length-1], dpNotRob1st[nums.Length-2]);
        
        return Math.Max(Rob1stMax, NotRob1stMax);
    }
}