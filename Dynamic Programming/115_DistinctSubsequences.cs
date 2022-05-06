// https://leetcode.com/problems/distinct-subsequences/submissions/

public class Solution115 {
    public int NumDistinct(string s, string t) {
        
        if (s == null || t == null || s.Length < t.Length || s.Length == 0 || t.Length == 0)
            return 0;
        
        int len1 = s.Length;
        int len2 = t.Length;
        
        var dp = new int[len1, len2];
        
        for (int i = 1; i < len2; i++)
            dp[0, i] = 0;
        
        for (int i = 0; i < len1; i++) {
            
            if (i == 0) {
                dp[0, 0] = s[0] == t[0] ? 1 : 0;
                continue;
            }
            
            dp[i, 0] = s[i] == t[0] ? (dp[i - 1, 0] + 1) : dp[i - 1, 0];
        }
        
        for (int col = 1; col < len2; col++) {
            for (int row = 1; row < len1; row++) {
                
                if (s[row] == t[col]) {
                    dp[row, col] = dp[row - 1, col - 1] + dp[row - 1, col];
                } else {
                    dp[row, col] = dp[row - 1, col];
                }
                
            }
        }
        
        return dp[len1 - 1, len2 - 1];
    }
}