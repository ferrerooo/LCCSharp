// https://leetcode.com/problems/linked-list-cycle/

public class Solution141
{
    public bool HasCycle(ListNode head)
    {

        if (head == null)
            return false;

        ListNode fast = head;
        ListNode slow = head;

        while (fast != null)
        {
            fast = fast.next;
            slow = slow.next;
            if (fast != null)
                fast = fast.next;
            else
                break;

            if (fast == slow)
                return true;
        }


        return false;
    }
}