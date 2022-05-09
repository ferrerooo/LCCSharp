// https://leetcode.com/problems/linked-list-cycle-ii/

public class Solution142
{
    public ListNode DetectCycle(ListNode head)
    {

        if (head == null)
            return null;

        ListNode fast = head;
        ListNode slow = head;
        ListNode current = head;

        while (fast != null)
        {

            fast = fast.next;
            slow = slow.next;

            if (fast != null)
                fast = fast.next;
            else
                return null;

            if (fast == slow)
                break;

        }

        if (fast == null)
            return null;

        while (current != slow)
        {
            current = current.next;
            slow = slow.next;
        }

        return current;
    }
}