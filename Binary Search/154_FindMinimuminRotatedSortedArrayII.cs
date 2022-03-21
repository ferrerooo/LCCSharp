// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/submissions/

using System;
public class Solution154
{
    public int FindMin(int[] nums)
    {

        return FindMin(nums, 0, nums.Length - 1);

    }

    private static int FindMin(int[] nums, int start, int end)
    {

        if (end - start <= 1)
        {
            return Math.Min(nums[start], nums[end]);
        }

        int mid = start + (end - start) / 2;

        if (nums[start] <= nums[mid] && nums[mid] < nums[end])
        {
            return nums[start];
        }
        else if (nums[start] < nums[mid] && nums[mid] <= nums[end])
        {
            return nums[start];
        }
        else if (nums[mid] > nums[end])
        {
            start = mid + 1;
            return FindMin(nums, start, end);
        }
        else if (nums[start] > nums[mid])
        {
            end = mid;
            return FindMin(nums, start, end);
        }
        else
        {
            return Math.Min(FindMin(nums, start, mid), FindMin(nums, mid + 1, end));
        }
    }
}