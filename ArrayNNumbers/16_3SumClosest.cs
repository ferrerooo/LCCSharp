// https://leetcode.com/problems/3sum-closest/

using System;
public class Solution16 {
    public int ThreeSumClosest(int[] nums, int target) {
        
        Array.Sort(nums);
        
        int mingap = Int32.MaxValue;
        int result = 0;
        
        for (int i = 0; i < nums.Length-2; i++) {
            
            int start = i + 1;
            int end = nums.Length - 1;
            
            while (start < end) {
                int sum = nums[i] + nums[start] + nums[end];
                
                if (sum == target)
                    return sum;
                else if (sum < target) {
                    if (target - sum < mingap) {
                        mingap = target - sum;
                        result = sum;
                    }
                    start++;
                } else  {
                    if (sum - target < mingap) {
                        mingap = sum - target;
                        result = sum;
                    }
                    end--;
                }
            }
            
        }
        
        return result;
    }
}