// https://leetcode.com/problems/palindrome-partitioning/

using System;
using System.Collections.Generic;
public class Solution131 {
    
    public IList<IList<string>> Partition(string s) {
    
        var cache = new Dictionary<int, IList<IList<string>>>();
        
        return PartitionRecur(s, 0, cache);
        
    }
    
    private IList<IList<string>> PartitionRecur(string s, int index, Dictionary<int, IList<IList<string>>> cache) {
        
        var results = new List<IList<string>>();
        
        if (index >= s.Length) {
            return new List<IList<string>>();
        }
        
        for (int i = index; i < s.Length; i ++) {
            
            if (IsPalindrome(s, index, i)) {
                
                var headPalinStr = s.Substring(index, i + 1 - index);
                
                IList<IList<string>> lists = null;
                
                if (cache.ContainsKey(i + 1)) {
                    lists = cache[i + 1];
                } else {
                    lists = PartitionRecur(s, i + 1, cache);   
                    cache[i + 1] = lists;
                }
                
                if (lists.Count == 0) {
                    var headList = new List<string>{headPalinStr};
                    results.Add(headList);
                    continue;
                }
                
                foreach (var list in lists) {
                    var headList = new List<string> {headPalinStr};
                    headList.AddRange(list);
                    results.Add(headList);
                }
            }
            
        }
        
        return results;
    } 
    
    private bool IsPalindrome(string s, int start, int end) {
        
        while (start < end) {
            if (s[start] != s[end])
                return false;
            start ++;
            end --;
        }
        return true;
    }
    
}