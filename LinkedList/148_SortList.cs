// https://leetcode.com/problems/sort-list/
using System;
public class Solution148 {
    public ListNode SortList(ListNode head) {
        
        if (head == null)
            return null;
        
        (ListNode h, ListNode t) = SortListRecur(head);
        return h;
    }
    
    private static (ListNode, ListNode) SortListRecur(ListNode head) {
        
        if (head == null || head.next == null)
            return (head, head);
        
        ListNode parNode = GetPartition(head);
        
        (ListNode h1, ListNode h2, ListNode mid) = PartitionList(head, parNode);
        
        (ListNode sortedH1, ListNode sortedT1) = SortListRecur(h1);
        (ListNode sortedH2, ListNode sortedT2) = SortListRecur(h2);
        
        if (sortedH1 == null && sortedH2 == null) {
            Console.WriteLine(mid.val);
            return(mid, mid);
        }
        
        if (sortedH1 == null) {
            mid.next = sortedH2;
            Console.WriteLine($" {mid.val}  - {sortedT2.val}");
            return (mid, sortedT2);
        }
        
        if (sortedH2 == null) {
            sortedT1.next = mid;
            Console.WriteLine($" {sortedH1.val}  -- {mid.val}");
            return (sortedH1, mid);
        }
        
        sortedT1.next = mid;
        mid.next = sortedH2;
        Console.WriteLine($" {sortedH1.val}  --- {sortedT2.val}");
        return (sortedH1, sortedT2);
    }
    
    private static ListNode GetPartition(ListNode head) {
        ListNode slow = head;
        ListNode fast = head;
        
        while (fast != null) {
            
            fast = fast.next;
            if (fast != null)
                fast = fast.next;
            else
                break;
            
            slow = slow.next;
        }
        
        return slow;
    }
    
    private static (ListNode, ListNode, ListNode) PartitionList(ListNode head, ListNode parNode) {
        
        ListNode smallHead = new ListNode();
        ListNode bigHead = new ListNode();
        
        ListNode smallTail = smallHead;
        ListNode bigTail = bigHead;

        bigTail.next = parNode;
        bigTail = bigTail.next;
        
        ListNode current = head;
        
        while (current != null) {
            
            if (current == parNode) {
                current = current.next;
                continue;
            }
            
            if (current.val < parNode.val) {
                smallTail.next = current;
                smallTail = smallTail.next;
                current = current.next;
                smallTail.next = null;
            } else {
                bigTail.next = current;
                bigTail = bigTail.next;
                current = current.next;
                bigTail.next = null;
            }
        }
        Console.WriteLine($"bigHead.next is {bigHead.next.val}");
        return (smallHead.next, bigHead.next.next, bigHead.next);
    }
}