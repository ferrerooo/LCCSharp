//https://leetcode.com/problems/longest-common-subsequence/submissions/

using System;

public class Solution1143 {
    public int LongestCommonSubsequence(string text1, string text2) {
        
        if (String.IsNullOrWhiteSpace(text1) || String.IsNullOrWhiteSpace(text2))
            return 0;
        
        int t1Len = text1.Length;
        int t2Len = text2.Length;
        
        var dp = new int[t1Len + 1, t2Len + 1];
        
        for (int i = 0; i <= t1Len; i++)
            dp[i, 0] = 0;
        
        for (int i = 0; i <= t2Len; i++)
            dp[0, i] = 0;
        
        for (int i = 1; i <= t1Len; i++) {
            for (int j = 1; j <= t2Len; j++) {
                
                if (text1[i - 1] == text2[j - 1]) 
                    dp[i, j] = Math.Max(dp[i-1, j-1] + 1, Math.Max(dp[i, j-1], dp[i-1, j]));
                else 
                    dp[i, j] = Math.Max(dp[i, j-1], dp[i-1, j]);
                
            }
        }
        
        return dp[t1Len, t2Len];
    }
}