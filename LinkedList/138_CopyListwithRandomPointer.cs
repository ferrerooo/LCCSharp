// https://leetcode.com/problems/copy-list-with-random-pointer/

using System.Collections.Generic;


// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}


public class Solution138 {
    public Node CopyRandomList(Node head) {
        
        if (head == null)
            return null;
        
        var dict = new Dictionary<Node, Node>();
        
        var current = head;
        
        while (current != null) {
            var newNode = new Node(current.val);
            dict[current] = newNode;
            current = current.next;
        }
        
        current = head;
        
        while (current != null) {
            
            if (current.next == null)
                dict[current].next = null;
            else
                dict[current].next = dict[current.next];
            
            if (current.random == null)
                dict[current].random = null;
            else
                dict[current].random = dict[current.random];
            
            current = current.next;
        }
        
        return dict[head];
    }
}