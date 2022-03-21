// https://leetcode.com/problems/search-in-rotated-sorted-array/submissions/

public class Solution33
{
    public int Search(int[] nums, int target)
    {

        int start = 0;
        int end = nums.Length - 1;

        while (end - start > 1)
        {

            int mid = start + (end - start) / 2;

            if (nums[start] < nums[mid])
            {
                if (target >= nums[start] && target <= nums[mid])
                {
                    end = mid;
                    continue;
                }
                else
                {
                    start = mid;
                    continue;
                }
            }
            else
            {
                if (target >= nums[mid] && target <= nums[end])
                {
                    start = mid;
                    continue;
                }
                else
                {
                    end = mid;
                    continue;
                }
            }
        }

        if (nums[start] == target)
            return start;
        else if (nums[end] == target)
            return end;
        else
            return -1;
    }
}