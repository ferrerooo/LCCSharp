// https://leetcode.com/problems/search-in-rotated-sorted-array-ii/

public class Solution81
{
    public bool Search(int[] nums, int target)
    {

        return Search(nums, 0, nums.Length - 1, target);

    }

    private static bool Search(int[] nums, int start, int end, int target)
    {

        if (end - start <= 1)
        {
            return nums[start] == target || nums[end] == target;
        }

        int mid = start + (end - start) / 2;

        if (nums[mid] < nums[end])
        {

            if (nums[mid] <= target && target <= nums[end])
            {
                return Search(nums, mid, end, target);
            }
            else
            {
                return Search(nums, start, mid, target);
            }
        }

        if (nums[start] < nums[mid])
        {

            if (nums[start] <= target && target <= nums[mid])
            {
                return Search(nums, start, mid, target);
            }
            else
            {
                return Search(nums, mid, end, target);
            }
        }

        return Search(nums, start, mid, target) || Search(nums, mid, end, target);
    }
}