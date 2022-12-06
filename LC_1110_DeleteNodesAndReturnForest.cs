/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

 using System.Collections.Generic;
public class LC_1110_DeleteNodesAndReturnForest {
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {

        IDictionary<int, int> inboundMap = new Dictionary<int, int>();
        IDictionary<int, TreeNode> valNodeMap = new Dictionary<int, TreeNode>();
        IDictionary<int, TreeNode> parentMap = new Dictionary<int, TreeNode>();

        this.FillInMaps(root, inboundMap, valNodeMap, parentMap);

        foreach (var i in to_delete) {

            TreeNode dNode = valNodeMap[i];

            if (inboundMap.ContainsKey(dNode.val)) {
                inboundMap.Remove(dNode.val);
                if (parentMap[dNode.val] != null && parentMap[dNode.val].left == dNode)
                    parentMap[dNode.val].left = null;
                if (parentMap[dNode.val] != null && parentMap[dNode.val].right == dNode)
                    parentMap[dNode.val].right = null;
            }
            
            if (dNode.left != null 
                    && inboundMap.ContainsKey(dNode.left.val)) {
                inboundMap[dNode.left.val] = 0;
                dNode.left = null;
            }

            if (dNode.right != null 
                    && inboundMap.ContainsKey(dNode.right.val)) {
                inboundMap[dNode.right.val] = 0;
                dNode.right = null;
            }
        }

        IList<TreeNode> result = new List<TreeNode>();
        foreach(KeyValuePair<int, int> pair in inboundMap) {
            if (pair.Value == 0) {
                result.Add(valNodeMap[pair.Key]);
            }
        }

        return result;
    }

    private void FillInMaps(TreeNode root, 
                            IDictionary<int, int> inboundMap, 
                            IDictionary<int, TreeNode> valNodeMap,
                            IDictionary<int, TreeNode> parentMap) {
        
        if (root == null)
            return;

        if (!inboundMap.ContainsKey(root.val)) {
            inboundMap[root.val] = 0;
            parentMap[root.val] = null;
        }
        
        if (!valNodeMap.ContainsKey(root.val))
            valNodeMap[root.val] = root;

        if (root.left != null) {
            inboundMap[root.left.val] = 1;
            parentMap[root.left.val] = root;
        }
        
        if (root.right != null) {
            inboundMap[root.right.val] = 1;
            parentMap[root.right.val] = root;
        }
        
        this.FillInMaps(root.left, inboundMap, valNodeMap, parentMap);
        this.FillInMaps(root.right, inboundMap, valNodeMap, parentMap);
    }
}