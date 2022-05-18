// https://leetcode.com/problems/3sum/

using System.Collections.Generic;
using System;
public class Solution15 {
    public IList<IList<int>> ThreeSum(int[] nums) {
        
        Array.Sort(nums);
        var result = new List<IList<int>>();
        
        for (int i = 0; i < nums.Length-2; i++) {
            
            int start = i + 1; 
            int end = nums.Length-1;
            
            if (i > 0 && nums[i-1] == nums[i])
                continue;
            
            while (start < end) {
                
                if (nums[i] + nums[start] + nums[end] == 0) {
                    
                    var list = new List<int>(){nums[i], nums[start], nums[end]};
                    if (start <= i + 1 || nums[start] != nums[start-1])
                        result.Add(list);
                    end--;
                    start++;
                } else if (nums[i] + nums[start] + nums[end] > 0) {
                    end--;
                } else {
                    start++;
                }
                
            }
        }
        
        return result;
        
    }
}