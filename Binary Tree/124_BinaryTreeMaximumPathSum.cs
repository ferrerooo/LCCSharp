// https://leetcode.com/problems/binary-tree-maximum-path-sum/

using System;

public class Solution124 {
    public int MaxPathSum(TreeNode root) {
        
        long maxSum = (long)Int32.MinValue;
        
        MaxPathFromRootRecur(root, ref maxSum);
        
        return (int)maxSum;
    }
    
    private long MaxPathFromRootRecur(TreeNode root, ref long maxSum) {        
        
        if (root == null)
            return (long)Int32.MinValue;
        
        long leftMax = MaxPathFromRootRecur(root.left, ref maxSum);
        long rightMax = MaxPathFromRootRecur(root.right, ref maxSum);
        
        long currentMaxPath = Math.Max(
                                    Math.Max((long)root.val + leftMax, (long)root.val + rightMax),
                                    Math.Max((long)root.val, (long)root.val + leftMax + rightMax)
                                );
        
        maxSum = Math.Max(currentMaxPath, maxSum);
        
        return Math.Max(  Math.Max((long)root.val + leftMax, (long)root.val + rightMax), 
                           (long)root.val
                       );
    }

        public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}