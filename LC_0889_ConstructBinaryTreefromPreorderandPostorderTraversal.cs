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
public class LC_0889_ConstructBinaryTreefromPreorderandPostorderTraversal {
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder) {

        return this.Recur(preorder, 0, preorder.Length-1, postorder, 0, postorder.Length-1);
    }

    private TreeNode Recur(int[] pre, int s1, int e1, int[] post, int s2, int e2) {
        
        if (s1 > e1)
            return null;

        TreeNode node = new TreeNode(pre[s1]);
        int len = this.GetChildNodeCount(pre, s1, e1, post, s2, e2);

        node.left = this.Recur(pre, s1+1, s1+len, post, s2, s2+len-1);
        node.right = this.Recur(pre, s1+len+1, e1, post, s2+len, e2-1);
        
        return node;
    }

    private int GetChildNodeCount(int[] pre, int s1, int e1, int[] post, int s2, int e2) {

        int p1 = s1+1;
        int p2 = s2;

        int result = 0;
        IDictionary<int, int> dict = new Dictionary<int, int>();

        for (int i=p1; i<=e1; i++) {
            if (!dict.ContainsKey(pre[i]))
                dict[pre[i]] = 1;
            else {
                dict[pre[i]] = dict[pre[i]] + 1;
                if (dict[pre[i]] == 0)
                    dict.Remove(pre[i]);
            }


            if (!dict.ContainsKey(post[p2]))
                dict[post[p2]] = -1;
            else {
                dict[post[p2]] = dict[post[p2]] - 1;
                if (dict[post[p2]] == 0)
                    dict.Remove(post[p2]);
            }

            if (dict.Count == 0) {
                result = i - p1 + 1;
                break;
            }
            p2++;
        }

        return result;
    }
}