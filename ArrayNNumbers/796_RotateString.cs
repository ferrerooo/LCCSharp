// https://leetcode.com/problems/rotate-string/

public class Solution796 {
    public bool RotateString(string s, string goal) {
        
        if (s == null || goal == null || s.Length != goal.Length)
            return false;
        
        return (goal + goal).Contains(s);
    }
}