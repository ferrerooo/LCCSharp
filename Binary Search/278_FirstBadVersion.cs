// https://leetcode.com/problems/first-bad-version/

/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution278 : VersionControl {
    public int FirstBadVersion(int n) {
        
        int badVersion = 0; // default value, no bad version
        
        int start = 1;
        int end = n;
        
        while (start <= end) {
            int mid = start + (end - start)/2;
            if (!IsBadVersion(mid)) {
                start = mid + 1;
            } else if (mid == start || !IsBadVersion(mid - 1)) {
                badVersion = mid;
                break;
            } else {
                end = mid - 1;
            }
        }
        
        return badVersion;
    }
}