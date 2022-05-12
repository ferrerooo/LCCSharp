// https://leetcode.com/problems/reverse-words-in-a-string-ii/

public class Solution186 {
    public void ReverseWords(char[] s) {
        
        Reverse(s, 0, s.Length - 1);
        
        int start = 0;
        
        while (start < s.Length) {
            
            while (start < s.Length && s[start] == ' ')
                start++;
            
            if (start >= s.Length)
                break;
            
            int end = start;
            
            while (end < s.Length && s[end] != ' ')
                end++;
            
            Reverse(s, start, end - 1);
            
            start = end;
        }
        
        return;
        
    }
    
    private static void Reverse(char[] s, int a, int b) {
        
        if (a >= b)
            return;
        
        while (a < b) {
            char temp = s[a];
            s[a] = s[b];
            s[b] = temp;
            a++;
            b--;
        }
        
    }
}