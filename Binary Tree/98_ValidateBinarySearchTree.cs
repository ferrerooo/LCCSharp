// https://leetcode.com/problems/validate-binary-search-tree/

using System;
using System.Collections.Generic;

public class Solution {
    public bool IsValidBST(TreeNode root) {
        
        if (root == null)
            return true;
        
        Stack<TreeNode> nodeStack = new Stack<TreeNode>();
        TreeNode cur = root;
        int? preVal = null;
        
        while (cur != null || nodeStack.Count > 0) {
            
            if (cur != null) {
                nodeStack.Push(cur);
                cur = cur.left;
            } else {
                TreeNode temp = nodeStack.Pop();
                if (preVal != null && temp.val <= preVal)
                    return false;
                else {
                    preVal = temp.val;
                    cur = temp.right;
                }
            }
        }
        
        return true;
        
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