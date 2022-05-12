// https://leetcode.com/problems/reverse-words-in-a-string/

using System.Collections.Generic;
using System.Text;

public class Solution151 {
    public string ReverseWords(string s) {
        
        int start = 0;
        
        var lists = new List<string>();
        
        while(start < s.Length) {
            
            while(start < s.Length && s[start] == ' ')
                start++;
            
            if (start >= s.Length)
                break;
            
            int end = start;
            
            while (end < s.Length && s[end] != ' ')
                end++;
            
            lists.Add(s.Substring(start, end - start));
            
            start = end;
        }
        
        StringBuilder sb = new StringBuilder();
        
        for (int i = lists.Count - 1; i >= 0; i--) {
            sb.Append(lists[i]);
            if (i != 0)
                sb.Append(' ');
        }
        
        return sb.ToString();
    }
}