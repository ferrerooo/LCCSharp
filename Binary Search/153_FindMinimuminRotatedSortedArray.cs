// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/

public class Solution153 {
    public int FindMin(int[] nums) {
        
        int start = 0;
        int end = nums.Length - 1;
        int result = 0;        
        
        while (start <= end) {
            
            int mid = (start + end) / 2;
            
            if (nums[start] <= nums[mid] && nums[mid] <= nums[end]) {
                result = nums[start];
                break;
            } else if (nums[start] >= nums[mid] && nums[mid] <= nums[end]) {
                end = mid;
                continue;
            } else {
                start = mid + 1;
            }            
        }
        
        return result;
    }
}