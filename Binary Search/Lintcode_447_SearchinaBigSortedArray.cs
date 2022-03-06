// https://www.lintcode.com/problem/447/

/*

public class Solution {
    
    public int searchBigSortedArray(ArrayReader reader, int target) {
        // write your code here

        int inaccessibleIndexValue = Integer.MAX_VALUE;
        int start = 0;
        int end = 0;
        boolean bFoundRange = false;
        // find the index range for target
        while (!bFoundRange) {
            int current = reader.get(end);
            if (current < target) {
                start = end;
                if (end == 0)
                    end = 1;
                else
                    end = end * 2;
            } else {
                bFoundRange = true;
            }
        }

        int result = -1;
        // binary search to find the target index
        while (start <= end) {
            int mid = start + (end - start) / 2;
            if (reader.get(mid) < target) {
                start = mid + 1;
            } else if (reader.get(mid) > target){
                end = mid - 1;
            } else {
                if (mid == start || reader.get(mid-1) < target) {
                    result = mid;
                    break;
                } else {
                    end = mid - 1;
                }
            }
        }

        return result;
    }
}

*/