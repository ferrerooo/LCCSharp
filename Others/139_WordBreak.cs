// https://leetcode.com/problems/word-break/submissions/

using System.Collections.Generic; 

public class Solution139 {
    public bool WordBreak(string s, IList<string> wordDict) {
        
        var wordSet = new HashSet<string>();
        foreach (var word in wordDict)
            wordSet.Add(word);
        
        var cache = new Dictionary<int, bool>();
        
        return WordBreakRecur(s, 0, wordSet, cache);
    }
    
    private bool WordBreakRecur(string s, int index, ISet<string> wordSet, IDictionary<int, bool> cache) {
        
        if (index >= s.Length)
            return true;
        
        for (int i = index; i < s.Length; i ++) {
            
            var substr = s.Substring(index, i - index + 1);
            
            if (wordSet.Contains(substr)) {
                
                bool rst = false;
                
                if (cache.ContainsKey(i + 1)) {
                    rst = cache[i + 1];    
                } else {
                    rst = WordBreakRecur(s, i + 1, wordSet, cache);
                    cache[i + 1] = rst;
                }
                
                if (rst == true)
                    return true;
                else
                    continue;
            }
        }
        
        return false;
    }
}