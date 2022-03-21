// https://leetcode.com/problems/binary-tree-inorder-traversal/

using System;
using System.Collections.Generic;

 public class Solution94 {
    public IList<int> InorderTraversal(TreeNode root) {
        
        IList<int> results = new List<int>();        
        InorderRecursion(root, results);        
        return results;
    }
    
    private static void InorderRecursion(TreeNode node, IList<int> results) {
        
        if (node == null)
            return;
        
        InorderRecursion(node.left, results);
        results.Add(node.val);
        InorderRecursion(node.right, results);        
    }

    public IList<int> InorderTraversal_NonRecur(TreeNode root) {
        
        IList<int> results = new List<int>();
        
        Stack<TreeNode> stack = new Stack<TreeNode>();
        
        TreeNode current = root;
        
        while(current != null || stack.Count > 0) {
            
            if (current != null) {
                stack.Push(current);
                current = current.left;
            } else {
                current = stack.Pop();
                results.Add(current.val);
                current = current.right;
            }            
        }
        
        return results;
        
    }

    public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         this.val = val;
         this.left = left;
         this.right = right;
     }
 }
}