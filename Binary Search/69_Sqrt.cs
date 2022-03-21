// https://leetcode.com/problems/sqrtx/

public class Solution69
{
    public int MySqrt(int x)
    {

        long start = 0;
        long end = x;
        int result = -1;

        while (start <= end)
        {

            long mid = (start + end) / 2;

            if (mid * mid == x)
            {
                result = (int)mid;
                break;
            }
            else if (mid * mid > x)
                end = mid - 1;
            else
            {
                if ((mid + 1) * (mid + 1) < x)
                    start = mid + 1;
                else if ((mid + 1) * (mid + 1) == x)
                {
                    result = (int)(mid + 1);
                    break;
                }
                else
                {
                    result = (int)mid;
                    break;
                }
            }
        }

        return result;
    }
}