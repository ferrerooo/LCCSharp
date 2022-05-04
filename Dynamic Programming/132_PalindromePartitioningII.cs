// https://leetcode.com/problems/palindrome-partitioning-ii/

/* 
I think the most straightforward DP idea is as below. Time complexity is not good. O(n3) ?
There are some room to make IsPalindrome faster
*/

using System;
using System.Collections.Generic;

public class Solution132 {
    /*public int MinCut(string s) {
        
        if (string.IsNullOrEmpty(s))
            return -1;
        
        var dpMinCut = new int[s.Length];
        dpMinCut[0] = 0;
        
        for (int i = 1; i < s.Length; i++) {
            
            dpMinCut[i] = dpMinCut[i - 1] + 1;
            
            for (int j = 0; j <= i; j++) {
                if (IsPalindrome(s, j, i)) {
                    
                    
                    dpMinCut[i] = j == 0 ? 0 : Math.Min(dpMinCut[j - 1] + 1, dpMinCut[i]);
                }
            }
        }
        
        return dpMinCut[s.Length - 1];
    }
    
    private bool IsPalindrome(string s, int start, int end) {
        
        while (start < end) {
            if (s[start] != s[end])
                return false;
            start ++;
            end --;
        }
        return true;
    }*/

/* 
The 2nd try makes IsPalindrome faster. Cached some temporary resutls
*/

    private static bool?[,] IsPalindromeMatrix = null;
    
    public int MinCut(string s) {
        
        if (string.IsNullOrEmpty(s))
            return -1;
        
        var dpMinCut = new int[s.Length];
        dpMinCut[0] = 0;
        
        for (int i = 1; i < s.Length; i++) {
            
            dpMinCut[i] = dpMinCut[i - 1] + 1;
            
            for (int j = 0; j <= i; j++) {
                if (IsPalindromeFast(s, j, i)) {
                    
                    
                    dpMinCut[i] = j == 0 ? 0 : Math.Min(dpMinCut[j - 1] + 1, dpMinCut[i]);
                }
            }
        }
        
        return dpMinCut[s.Length - 1];
    }
    
    private static bool IsPalindromeFast(string s, int start, int end) {
        
        if (IsPalindromeMatrix == null)
            IsPalindromeMatrix = new bool?[s.Length, s.Length];
        
        if (IsPalindromeMatrix[start, end].HasValue) {
            return IsPalindromeMatrix[start, end].Value;
        }
        
        var i = start;
        var j = end;
        var result = false;
        
        while (i < j) {
            if (s[i] != s[j]) {
                IsPalindromeMatrix[i, j] = false;
                return false;
            }
            
            i ++;
            j --;
            
            if (IsPalindromeMatrix[i, j].HasValue) {
                result = IsPalindromeMatrix[i, j].Value;
                break;
            }
        }
        
        if (i >= j)
            result = true;
        
        IsPalindromeMatrix[start, end] = result;
        return result;
    }
}