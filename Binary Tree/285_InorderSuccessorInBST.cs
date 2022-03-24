// https://leetcode.com/problems/inorder-successor-in-bst/

public class Solution285 {
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        
        if (root == null || p == null)
            return null;
                     
        return InorderSuccessorRecur(root, p, null);
    }
    
    private TreeNode InorderSuccessorRecur(TreeNode root, TreeNode p, TreeNode previousNode) {
        
        if (root == null)
            return null;
        
        if (root.val == p.val) {
            
            TreeNode s = getSuccessorInRightChildren(root);
            
            if (s != null)
                return s;
            else
                return previousNode;
            
        } else if (root.val < p.val) {
            
            return InorderSuccessorRecur(root.right, p, previousNode);
        
        } else {
            
            return InorderSuccessorRecur(root.left, p, root);
        
        }
    }
    
    private TreeNode getSuccessorInRightChildren (TreeNode node) {
        
        if (node == null || node.right == null)
            return null;
        
        TreeNode s = node.right;
        
        while(s.left != null)
            s = s.left;
        
        return s;
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