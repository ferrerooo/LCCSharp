namespace DataStructure 
{
    using System.Collections.Generic;
    public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        
        int[] result = new int[2];
        Dictionary<int, int> dict = new Dictionary<int, int>();
        
        for (int i = 0 ;  i <nums.Length; i++) {
            
            int x2 = target - nums[i];
            if (dict.ContainsKey(x2)) {
                result[0] = dict[x2];
                result[1] = i;
                break;
            } else {
                dict[nums[i]] = i;
            }
        }
        
        return result;
    }
}

}