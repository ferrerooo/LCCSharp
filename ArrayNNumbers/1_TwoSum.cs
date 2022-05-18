// https://leetcode.com/problems/two-sum/


using System.Collections.Generic;

public class Solution1 {
    public int[] TwoSum1(int[] nums, int target) {
        
        var dict = new Dictionary<int, int>();
        var results = new int[2];
        
        for (int i = 0; i < nums.Length; i++) {
            
            var num1 = nums[i];
            var num2 = target - num1;
            
            if (dict.ContainsKey(num2)) {
                results[0] = dict[num2];
                results[1] = i;
                break;
            } else {
                dict[num1] = i;
            }
            
        }
        
        return results;
    }
}