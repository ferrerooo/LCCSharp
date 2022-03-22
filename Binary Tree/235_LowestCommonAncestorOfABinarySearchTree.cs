// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/

public class Solution235 {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        
        if (root == null || root == p || root == q) {
            return root;
        }
        
        TreeNode leftLCA = LowestCommonAncestor(root.left, p, q);
        TreeNode rightLCA = LowestCommonAncestor(root.right, p, q);
        
        if (leftLCA != null && rightLCA != null)
            return root;
        
        if (leftLCA != null)
            return leftLCA;
        
        if (rightLCA != null)
            return rightLCA;
        
        return null;
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