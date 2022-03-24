// https://leetcode.com/problems/binary-search-tree-iterator/

using System.Collections.Generic;

public class BSTIterator173 {
    
    private Stack<TreeNode> stack = new Stack<TreeNode>();

    public BSTIterator(TreeNode root) {
        
        while (root != null) {
            stack.Push(root);
            root = root.left;
        }        
    }
    
    public int Next() {
        
        TreeNode node = stack.Pop();
        int result = node.val;
        node = node.right;
        while (node != null) {
            stack.Push(node);
            node = node.left;
        }
        return result;
    }
    
    public bool HasNext() {
        
        return stack.Count > 0;
        
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

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */