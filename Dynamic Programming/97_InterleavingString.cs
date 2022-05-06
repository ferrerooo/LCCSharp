// https://leetcode.com/problems/interleaving-string/submissions/

public class Solution97 {
    public bool IsInterleave(string s1, string s2, string s3) {
        
        //if (String.IsNullOrWhiteSpace(s1) || String.IsNullOrWhiteSpace(s2) || String.IsNullOrWhiteSpace(s3) || s1.Length + s2.Length != s3.Length)
        //    return false;
        
        if (s1.Length + s2.Length != s3.Length)
            return false;
        
        int len1 = s1.Length;
        int len2 = s2.Length;
        int len3 = s3.Length;

        var dp = new  bool[len1 + 1, len2 + 1];
        dp[0, 0] = true;
        
        for (int col = 1; col <= len2; col++) {
            dp[0, col] = (s2[col - 1] == s3[col - 1]) ? dp[0, col - 1] : false;
        }
        
        for (int row = 1; row <= len1; row++) {
            dp[row, 0] = (s1[row - 1] == s3[row - 1]) ? dp[row - 1, 0] : false;
        }
        
        for (int row = 1; row <= len1; row++) {
            for (int col = 1; col <= len2; col++) {
                
                if (s3[row + col -1] == s1[row -1] && s3[row + col - 1] == s2[col - 1])
                    dp[row, col] = (dp[row - 1, col] || dp[row, col - 1]) ? true : false;
                else if (s3[row + col -1] == s1[row -1])
                    dp[row, col] = dp[row - 1, col];
                else if (s3[row + col - 1] == s2[col - 1])
                    dp[row, col] = dp[row, col - 1];
                else
                    dp[row, col] = false;
            }
        }
        
        return dp[len1, len2];
    }
}