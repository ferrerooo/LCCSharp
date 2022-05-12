// https://leetcode.com/problems/reverse-words-in-a-string-iii/

using System;
using System.Text;
public class Solution557 {
    public string ReverseWords(string s) {
        
        char[] ch = new char[s.Length];
        for (int i = 0; i < s.Length; i++)
            ch[i] = s[i];
        
        int start = 0;
        
        while (start < s.Length) {
            
            while (start < s.Length && ch[start] == ' ')
                start++;
            
            if (start >= s.Length)
                break;
            
            int end = start;
            
            while (end < s.Length && ch[end] != ' ')
                end++;
            
            Reverse(ch, start, end - 1);
            start = end;
        }
        
        return new String(ch);
        
    }
    
    private static void Reverse(char[] ch, int a , int b) {
        
        while (a < b) {
            char temp = ch[a];
            ch[a] = ch[b];
            ch[b] = temp;
            a++;
            b--;
        }
    }
}