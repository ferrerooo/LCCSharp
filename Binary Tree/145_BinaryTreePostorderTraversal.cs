// https://leetcode.com/problems/binary-tree-postorder-traversal/

using System;
using System.Collections.Generic;

public class Solution145
{

    public IList<int> PostorderTraversal(TreeNode root)
    {

        IList<int> results = new List<int>();

        PostorderRecur(root, results);

        return results;
    }

    private static void PostorderRecur(TreeNode node, IList<int> results)
    {

        if (node == null)
            return;

        PostorderRecur(node.left, results);
        PostorderRecur(node.right, results);
        results.Add(node.val);
    }

    public IList<int> PostorderTraversal_NonRecur(TreeNode root)
    {

        IList<int> postOrderList = new List<int>();

        TreeNode current = root;

        Stack<TreeNode> nodeStack = new Stack<TreeNode>();
        HashSet<TreeNode> rightVisited = new HashSet<TreeNode>();

        while (current != null || nodeStack.Count > 0)
        {

            if (current != null)
            {
                nodeStack.Push(current);
                current = current.left;
            }
            else
            {
                current = nodeStack.Peek();
                if (rightVisited.Contains(current))
                {
                    postOrderList.Add(current.val);
                    nodeStack.Pop();
                    current = null;
                }
                else
                {
                    rightVisited.Add(current);
                    current = current.right;
                }
            }
        }

        return postOrderList;
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
