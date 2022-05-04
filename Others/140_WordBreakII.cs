// https://leetcode.com/problems/word-break-ii/submissions/

using System.Collections.Generic;

public class Solution140 {
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        
        var wordSet = new HashSet<string>();
        foreach (var word in wordDict)
            wordSet.Add(word);
        
        return WordBreakRecur(s, 0, wordSet);
    }
    
    private IList<string> WordBreakRecur(string s, int index, ISet<string> wordSet) {
        
        if (index >= s.Length)
            return new List<string>();
        
        var results = new List<string>();
        
        for (int i = index; i < s.Length; i ++) {
            
            var substr = s.Substring(index, i - index + 1);
            
            if (wordSet.Contains(substr)) {
                var sentenceList = WordBreakRecur(s, i + 1, wordSet);
                
                if (sentenceList.Count != 0) {
                    
                    foreach (var sentence in sentenceList) {
                        results.Add(substr + " " + sentence);
                    }
                } else if (i + 1 == s.Length){
                    results.Add(substr);
                }
            }
        }
        
        return results;
    }
}