// https://leetcode.com/problems/median-of-two-sorted-arrays/

/*
Great that got a first try accept, used 50 mins.
*/

using System;
public class Solution4 {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        
        if ((nums1.Length + nums2.Length) % 2 == 1) {
            
            var result = FindMedianOnNums1(nums1, nums2, (nums1.Length + nums2.Length) / 2, (nums1.Length + nums2.Length) / 2);
            
            if (result == Double.MinValue)
                return FindMedianOnNums1(nums2, nums1, (nums1.Length + nums2.Length) / 2, (nums1.Length + nums2.Length) / 2);
            else
                return result;
            
        } else {
            
            var res11 = FindMedianOnNums1(nums1, nums2, (nums1.Length + nums2.Length) / 2 - 1, (nums1.Length + nums2.Length) / 2);
            var res12 = FindMedianOnNums1(nums1, nums2, (nums1.Length + nums2.Length) / 2, (nums1.Length + nums2.Length) / 2 - 1);
            
            var res21 = FindMedianOnNums1(nums2, nums1, (nums1.Length + nums2.Length) / 2 - 1, (nums1.Length + nums2.Length) / 2);
            var res22 = FindMedianOnNums1(nums2, nums1, (nums1.Length + nums2.Length) / 2, (nums1.Length + nums2.Length) / 2 - 1);
            
            var mid1 = res11 != Double.MinValue ? res11 : res21;
            var mid2 = res12 != Double.MinValue ? res12 : res22;
            
            return (mid1 + mid2) / 2.0;
            
        }
        
    }
    
    private static double FindMedianOnNums1(int[] nums1, int[] nums2, int leftCnt, int rightCnt) {
        
        int a = 0;
        int b = nums1.Length - 1;
        
        while (a <= b) {
            
            int current = (b + a + 1) / 2;
            int nums1Left = current;
            int nums1Right = nums1.Length - current - 1;
            
            if (nums2 == null || nums2.Length == 0) {
                
                if (nums1Left == leftCnt && nums1Right == rightCnt)
                    return (double)nums1[current];
                if (nums1Left < leftCnt) {
                    a = current + 1;
                    continue;
                }
                b = current - 1;
                continue;
            }
            
            if (leftCnt < nums1Left) {
                b = current - 1;
                continue;
            }
            
            if (rightCnt < nums1Right) {
                a = current + 1;
                continue;
            }
            
            int direction = GetDirection(nums2, nums1[current], leftCnt - nums1Left, rightCnt - nums1Right);
            
            if (direction == 0)
                return (double)nums1[current];
            
            if (direction == 1) {
                a = current + 1;
                continue;
            }
                
            b = current - 1;
            continue;
        }
        
        return Double.MinValue;
    }
    
    private static int GetDirection (int[] nums, int val, int count1, int count2) {
        
        if (count1 == 0) {
            
            if (val <= nums[0])
                return 0;
            return -1;
        }
        
        if (count2 == 0) {
            if (val >= nums[nums.Length - 1])
                return 0;
            return 1;
        }
        
        if (nums[count1-1] <= val && nums[nums.Length-count2] >= val)
            return 0;
        
        if (nums[count1-1] > val)
            return 1; // means move right
        
        return -1; // move left
        
    }
}