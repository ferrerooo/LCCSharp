// https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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
public class Solution109 {
    public TreeNode SortedListToBST(ListNode head) {
        
        if (head == null)
            return null;
        
        if (head.next == null)
            return new TreeNode(head.val);
        
        if (head.next.next == null) {
            var n1 = new TreeNode(head.val);
            var n2 = new TreeNode(head.next.val);
            n1.right = n2;
            return n1;
        }
        
        ListNode dummy = new ListNode();
        dummy.next = head;
        ListNode preSlow = dummy;
        ListNode fast = head;
        ListNode slow = head;
        
        while (fast.next != null) {
            
            fast = fast.next;
            slow = slow.next;
            preSlow = preSlow.next;
            
            if (fast.next != null)
                fast = fast.next;
            else
                break;
        }
        
        preSlow.next = null;
        
        TreeNode root = new TreeNode(slow.val);
        root.left = SortedListToBST(dummy.next);
        root.right = SortedListToBST(slow.next);
        
        return root;
    }
}