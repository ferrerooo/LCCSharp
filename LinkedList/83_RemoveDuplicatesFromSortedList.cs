// https://leetcode.com/problems/remove-duplicates-from-sorted-list/submissions/

public class Solution83 {
    public ListNode DeleteDuplicates(ListNode head) {
        
        if (head == null)
            return null;
        
        ListNode current = head;
        
        while (current != null) {
            
            if (current.next == null)
                break;
            
            if (current.val == current.next.val)
                current.next = current.next.next;
            else
                current = current.next;
        }
        
        return head;
    }
}