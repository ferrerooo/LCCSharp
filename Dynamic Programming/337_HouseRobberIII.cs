// https://leetcode.com/problems/house-robber-iii/

/*
Tricky part is - deeper understanding of the specific problem.
*/


using System;
public class Solution337 {
    public int Rob(TreeNode root) {
        
        (int MaxWithHead, int MaxNoHead) = RobRecur(root);
        
        return Math.Max(MaxWithHead, MaxNoHead);
    }
    
    private static (int, int) RobRecur(TreeNode root) {
        
        if (root == null)
            return (0, 0);
        
        (int leftMaxWithHead, int leftMaxNoHead) = RobRecur(root.left);
        (int rightMaxWithHead, int rightMaxNoHead) = RobRecur(root.right);
        
        int withhead = root.val + leftMaxNoHead + rightMaxNoHead;
        int nohead = Math.Max(leftMaxWithHead, leftMaxNoHead) + Math.Max(rightMaxWithHead, rightMaxNoHead);
        
        return (withhead, nohead);
    }
}
