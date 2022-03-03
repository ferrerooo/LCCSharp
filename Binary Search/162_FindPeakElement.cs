// https://leetcode.com/problems/find-peak-element/

public class Solution {
    public int FindPeakElement(int[] nums) {
        
        int start = 0;
        int end = nums.Length - 1;
        
        while (start <= end) {
            
            int mid = start + (end - start) / 2;
            
            if (mid == start || nums[mid] > nums[mid - 1]) {
                if ((mid == end) || nums[mid] > nums[mid + 1])
                    return mid;
                else {
                    start = mid + 1;
                }
            } else {
                end = mid - 1;
            }
            
            /*
            
            if (mid > start && mid < end) {
                
                if (nums[mid] > nums[mid + 1] && nums[mid] > nums[mid - 1]) {
                    return mid;
                } else if (nums[mid] < nums[mid + 1] && nums[mid] < nums[mid - 1]) {
                    end = mid - 1;
                    continue;
                } else if (nums[mid] < nums[mid + 1] && nums[mid] > nums[mid - 1]) {
                    start = mid + 1;
                    continue;
                } else {
                    // when trending down
                    end = mid - 1;
                    continue;
                }   
            }
            
            if (mid == start && mid == end) {
                return mid;
            }
            
            if (mid == start) {
                if (nums[mid] > nums[mid + 1])
                    return mid;
                else {
                    start = mid + 1;
                    continue;
                }
            }
            
            if (nums[mid] > nums[mid - 1])
                return mid;
            else {
                end = mid - 1;
                continue;
            }
            */
        }
        
        return -1;
    }
}