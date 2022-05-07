using System;

namespace LC
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution148 sol = new Solution148();
            ListNode n1 = new ListNode(4);
            ListNode n2 = new ListNode(1);
            //ListNode n3 = new ListNode(2);
            //ListNode n4 = new ListNode(3);

            n1.next = n2;
            //n2.next = n3;
            //n3.next = n4;

            var result = sol.SortList(n1);

            while (result != null) {
                Console.WriteLine(result.val);
                result = result.next;
            }
        }
    }
}
