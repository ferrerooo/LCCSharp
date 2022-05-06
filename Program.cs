using System;

namespace LC
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution82 sol = new Solution82();
            ListNode head = new ListNode(1);
            sol.DeleteDuplicates(head);
            Console.WriteLine("aab");
        }
    }
}
