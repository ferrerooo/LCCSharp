// https://www.lintcode.com/problem/96/

using System;
using System.Collections;
using System.Collections.Generic;

class SolutionL96
{

    public ListNode Partition(ListNode head, int x)
    {
        // write your code here

        ListNode smallHead = new ListNode(0);
        ListNode bigHead = new ListNode(0);

        ListNode smallTail = smallHead;
        ListNode bigTail = bigHead;

        ListNode current = head;

        while (current != null)
        {
            if (current.val < x)
            {
                smallTail.next = current;
                smallTail = smallTail.next;
                current = current.next;
            }
            else
            {
                bigTail.next = current;
                bigTail = bigTail.next;
                current = current.next;
                bigTail.next = null;
            }

        }

        smallTail.next = bigHead.next;
        return smallHead.next;
    }
}
