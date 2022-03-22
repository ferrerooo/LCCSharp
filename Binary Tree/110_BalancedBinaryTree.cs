// https://leetcode.com/problems/balanced-binary-tree/

using System;
using System.Collections.Generic;

public class Solution110
{

    private Dictionary<TreeNode, int> nodeMap = new Dictionary<TreeNode, int>();

    public bool IsBalanced(TreeNode root)
    {

        if (root == null)
            return true;

        int leftHeight = GetTreeHeight(root.left);
        int rightHeight = GetTreeHeight(root.right);

        if (Math.Abs(leftHeight - rightHeight) > 1)
            return false;
        else
        {
            return IsBalanced(root.left) && IsBalanced(root.right);
        }

    }

    private int GetTreeHeight(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        if (nodeMap.ContainsKey(node))
        {
            return nodeMap[node];
        }
        else
        {
            int height = Math.Max(GetTreeHeight(node.left),
                        GetTreeHeight(node.right)) + 1;
            nodeMap[node] = height;
            return height;
        }
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