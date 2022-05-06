// https://leetcode.com/problems/reverse-linked-list/

public class Solution206 {
    public ListNode ReverseList(ListNode head) {
        
        ListNode tail = null;
        ListNode current = null;
        
        while (head != null) {
            
            current = head;
            head = head.next;
            current.next = tail;
            tail = current;
        }
        
        return tail;
    }
}