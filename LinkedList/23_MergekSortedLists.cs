// https://leetcode.com/problems/merge-k-sorted-lists/

using System.Collections.Generic;
using System.Linq;

public class Solution23 {
    public ListNode MergeKLists(ListNode[] lists) {
        
        if (lists == null || lists.Length == 0)
            return null;
        
        var tmpLists = lists.ToList();
        
        while (tmpLists.Count > 1) {
            
            var newLists = new List<ListNode>();
            
            for (int i = 0; i < tmpLists.Count; i = i + 2) {
                
                if (i  >= tmpLists.Count)
                    break;
                
                if (i + 1 == tmpLists.Count) {
                    newLists.Add(tmpLists[i]);
                    break;
                }
                
                newLists.Add(MergeTwoLists(tmpLists[i], tmpLists[i + 1]));
            }
            
            tmpLists = newLists;
            
        }
        
        return tmpLists[0];
        
    }
    
    
    private static ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        
        ListNode dummy = new ListNode();
        ListNode current = dummy;
        
        while (list1 != null && list2 != null) {
            
            if (list1.val <= list2.val) {
                current.next = list1;
                list1 = list1.next;
            } else {
                current.next = list2;
                list2 = list2.next;
            }
            current = current.next;
        }
        
        if (list1 != null)
            current.next = list1;
        
        if (list2 != null)
            current.next = list2;
        
        return dummy.next;
        
    }
}