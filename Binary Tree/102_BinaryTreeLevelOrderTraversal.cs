// https://leetcode.com/problems/binary-tree-level-order-traversal/

using System.Collections.Generic;

public class Solution102
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {

        IList<IList<int>> results = new List<IList<int>>();

        if (root == null)
            return results;

        Queue<TreeNode> curLevelQueue = new Queue<TreeNode>();
        Queue<TreeNode> nextLevelQueue = new Queue<TreeNode>();

        curLevelQueue.Enqueue(root);

        while (curLevelQueue.Count > 0)
        {

            IList<int> levelOrder = new List<int>();

            while (curLevelQueue.Count > 0)
            {
                TreeNode node = curLevelQueue.Dequeue();
                levelOrder.Add(node.val);
                if (node.left != null)
                    nextLevelQueue.Enqueue(node.left);
                if (node.right != null)
                    nextLevelQueue.Enqueue(node.right);
            }

            results.Add(levelOrder);
            var temp = curLevelQueue;
            curLevelQueue = nextLevelQueue;
            nextLevelQueue = temp;
            nextLevelQueue.Clear();
        }

        return results;
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