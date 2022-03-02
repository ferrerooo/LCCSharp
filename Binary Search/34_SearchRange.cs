//https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/

public class Solution34 {
    
    public static int[] SearchRange(int[] nums, int target) {
        
        int[] results = new int[2] {-1, -1};
        
        results[0] = SearchFirst(nums, target);
        results[1] = SearchLast(nums, target);
        
        return results;        
    }
    
    private static int SearchFirst(int[] nums, int target) {
        
        if (nums == null)
            return -1;
        
        int start = 0;
        int end = nums.Length - 1;
        
        while (start <= end) {
            
            int mid = start + (end - start) / 2;
            
            if (nums[mid] < target) {
                start = mid + 1;
            } else if (nums[mid] > target) {
                end = mid - 1;
            } else {
                if (mid == start || nums[mid - 1] < target)
                    return mid;
                
                if (mid > start && nums[mid - 1] == target) {
                    end = mid - 1;
                    continue;
                }
            }
        }
        
        return -1;
        
    }
    
    private static int SearchLast(int[] nums, int target) {
        
        if (nums == null)
            return -1;
        
        int start = 0;
        int end = nums.Length - 1;
        
        while (start <= end) {
            
            int mid = start + (end - start) / 2;
            
            if (nums[mid] < target) {
                start = mid + 1;
            } else if (nums[mid] > target) {
                end = mid - 1;
            } else {
                if (mid == end || nums[mid + 1] > target)
                    return mid;
                
                if (end > mid && nums[mid + 1] == target) {
                    start = mid + 1;
                    continue;
                }
            }
        }
        
        return -1;
    }
}