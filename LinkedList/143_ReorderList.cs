// https://leetcode.com/problems/reorder-list/

public class Solution143 {
    public void ReorderList(ListNode head) {
        
        if (head == null || head.next == null || head.next.next == null)
            return;
        
        ListNode dummy = new ListNode();
        dummy.next = head;
        
        ListNode fast = head;
        ListNode mid = head;
        ListNode preMid = dummy;
        
        
        while (fast != null) {
            fast = fast.next;
            mid = mid.next;
            preMid = preMid.next;
            if (fast != null) {
                fast = fast.next;
            } else {
                break;
            }
        }
        
        preMid.next = null;
        
        ListNode revHead = ReverseList(mid);
        ListNode current = head;
        
        while (current != null && revHead != null) {
            
            ListNode temp1 = current.next;
            ListNode temp2 = revHead.next;
            
            current.next = revHead;
            revHead.next = temp1;
            
            current = temp1;
            revHead = temp2;
            
        }
    }
    
    private static ListNode ReverseList(ListNode head) {
        
        ListNode newhead = head;
        head = head.next;
        newhead.next = null;
        
        while (head != null) {
            
            ListNode temp = head.next;
            head.next = newhead;
            newhead = head;
            head = temp;
            
        }
        
        return newhead;
        
    }
    
    
}