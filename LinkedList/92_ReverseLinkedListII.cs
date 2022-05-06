// https://leetcode.com/problems/reverse-linked-list-ii/

public class Solution92 {
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        
        ListNode dummy = new ListNode();
        dummy.next = head;
        ListNode p1 = dummy;
        
        for (int i = 1; i < left; i++) {
            p1 = p1.next;
        }
        
        ListNode subTail = p1.next;
        
        for (int i = left; i < right; i++) {
            
            ListNode p2 = subTail.next;
            subTail.next = p2.next;
            p2.next = p1.next;
            p1.next = p2;
        }
        
        return dummy.next;
    }
}