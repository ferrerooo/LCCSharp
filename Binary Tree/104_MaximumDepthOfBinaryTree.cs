// https://leetcode.com/problems/maximum-depth-of-binary-tree/

using System;

public class Solution104 {
    public int MaxDepth(TreeNode root) {
        
        if (root == null)
        {
            return 0;
        }
        
        return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        
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