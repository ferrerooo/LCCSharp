// https://leetcode.com/problems/palindrome-linked-list/

public class Solution234 {
    public bool IsPalindrome(ListNode head) {
        
        if (head == null)
            return false;
        
        ListNode dummy = new ListNode();
        dummy.next = head;
        ListNode preMid = dummy;
        ListNode fast = head;
        ListNode slow = head;
        
        while (fast != null) {
            
            fast = fast.next;
            slow = slow.next;
            preMid = preMid.next;
            if (fast != null)
                fast = fast.next;
            
        }
        
        preMid.next = null;
        ListNode head2 = Reverse(slow);
        
        while (head2 != null) {
            if (head.val == head2.val) {
                head = head.next;
                head2 = head2.next;
            } else {
                return false;
            }
                
        }
        
        return true;
    }
    
    private static ListNode Reverse(ListNode head) {
        
        if (head == null)
            return null;
        
        ListNode current = head;
        ListNode rev = new ListNode();
        
        while (current != null) {
            ListNode temp = current.next;
            current.next = rev.next;
            rev.next = current;
            current = temp;
        }
        
        return rev.next;
    }
}