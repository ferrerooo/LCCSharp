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
using System.Text;
public class LC_2096_DirectionsFromaBinaryTreeNodetoAnother {
    
    public string GetDirections(TreeNode root, int startValue, int destValue) {
        
        StringBuilder sb = new StringBuilder();
        
        // path format is [ [node1, L], [node2, R], [node3, _]   ]
        Stack<string[]> sPath = new Stack<string[]>();
        Stack<string[]> dPath = new Stack<string[]>();
        
        this.GetPath(root, startValue, sPath);
        this.GetPath(root, destValue, dPath);
        
        string[] sPre = null;
        string[] dPre = null;
        
        while (sPath.Count > 0 && dPath.Count > 0 && (sPath.Peek())[0] == (dPath.Peek())[0]) {
            sPre = sPath.Peek();
            dPre = dPath.Peek();
            sPath.Pop();
            dPath.Pop();
        }

        while (sPath.Count > 0) {
            sb.Append("U");
            sPath.Pop();
        }
        
        sb.Append(dPre[1]);
        
        while (dPath.Count > 0) {
            sb.Append(dPath.Pop()[1]);
        }
        
        return sb.ToString();
    }
    
    private bool GetPath(TreeNode root, int value, Stack<string[]> path) {
        
        if (root == null)
            return false;
        
        if (root.val == value) {
            path.Push(new string[]{root.val.ToString(), ""});
            return true;
        }
        
        if (this.GetPath(root.left, value, path)) {
            path.Push(new string[]{root.val.ToString(), "L"});
            return true;
        }
        
        if (this.GetPath(root.right, value, path)) {
            path.Push(new string[]{root.val.ToString(), "R"});
            return true;
        }
        
        return false;
    }

}