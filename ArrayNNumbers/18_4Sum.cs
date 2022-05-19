// https://leetcode.com/problems/4sum/

using System.Collections.Generic;
public class Solution18 {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        
        var results = new List<IList<int>>();
        
        Array.Sort(nums);
        
        for (int i = 0; i < nums.Length - 3; i++) {
            
            if (i > 0 && nums[i] == nums[i-1])
                continue;
            
            for (int j = i + 1; j < nums.Length - 2; j++) {
                
                if (j > i + 1 && nums[j] == nums[j-1])
                    continue;
                
                int a = j + 1; 
                int b = nums.Length - 1;
                
                while (a < b) {
                    
                    int sum = nums[i] + nums[j] + nums[a] + nums[b];
                    
                    if (sum == target) {
                        var list = new List<int>(){nums[i], nums[j], nums[a], nums[b]};
                        results.Add(list);
                        a++;
                        while (a < nums.Length && nums[a] == nums[a-1])
                            a++;
                        b--;
                        while (b > 0 && nums[b] == nums[b+1])
                            b--;
                    } else if (sum > target) {
                        b--;
                    } else {
                        a++;
                    }
                }
                
            }
            
        }
        
        return results;
    }
}