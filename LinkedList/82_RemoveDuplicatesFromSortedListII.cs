// https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/submissions/

using System;
public class Solution82 {
    public ListNode DeleteDuplicates(ListNode head) {
        
        ListNode dummy = new ListNode();
        dummy.next = head;
        ListNode current = dummy;
        
        while (current != null) {
            
            if (IsNextDup(current)) {
                current.next = GetNodeAfterDup(current);
                continue;
            } 
            current = current.next;
        }
        
        return dummy.next;
    }
    
    private static bool IsNextDup(ListNode node) {
        if (node.next != null && node.next.next != null && node.next.val == node.next.next.val)
            return true;
        else
            return false;
    }
    
    private static ListNode GetNodeAfterDup(ListNode node) {
        int dupVal = node.next.val;
        ListNode pointer = node.next;
        while (pointer != null && pointer.val == dupVal)
            pointer = pointer.next;
        return pointer;
    }
}