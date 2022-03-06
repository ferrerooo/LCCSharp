// https://leetcode.com/problems/binary-tree-preorder-traversal/

using System;
using System.Collections.Generic;

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

public class Solution144 {
    public IList<int> PreorderTraversal(TreeNode root) {
        
        if (root == null) {
            return new List<int>();
        }
        
        IList<int> preorderList = new List<int>();
        preorderList.Add(root.val);
        
        IList<int> leftList = (PreorderTraversal(root.left));
        IList<int> rightList = (PreorderTraversal(root.right));
        
        foreach (var i in leftList)
            preorderList.Add(i);
        
        foreach (var i in rightList)
            preorderList.Add(i);
        
        return preorderList;
    }


    public IList<int> PreorderTraversal_NonRecur(TreeNode root) {
        
        IList<int> preorderList = new List<int>();
        
        TreeNode current = root;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        
        while (current != null || stack.Count > 0) {
            
            if (current != null) {
                preorderList.Add(current.val);
                stack.Push(current);
                current = current.left;
            } else {
                current = stack.Pop().right;                
            }
        }
        
        return preorderList;
    }
}

