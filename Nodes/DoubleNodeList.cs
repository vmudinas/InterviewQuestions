using System;

public class DoubleNodeList
{ 
    public class DNode
    {
        internal int data;
        internal DNode prev;
        internal DNode next;
        public DNode(int d)
        {
            data = d;
            prev = null;
            next = null;
        }
    }

    public class DoubleLinkedList
    {
        public DNode head;
    }

    public void InsertFront(DoubleLinkedList doubleLinkedList, int data)
    {
        DNode newNode = new(data)
        {
            next = doubleLinkedList.head,
            prev = null
        };
        if (doubleLinkedList.head != null)
        {
            doubleLinkedList.head.prev = newNode;
        }
        doubleLinkedList.head = newNode;
    }

    public void InsertLast(DoubleLinkedList doubleLinkedList, int data)
    {
        DNode newNode = new(data);
        if (doubleLinkedList.head == null)
        {
            newNode.prev = null;
            doubleLinkedList.head = newNode;
            return;
        }
        DNode lastNode = GetLastNode(doubleLinkedList);
        lastNode.next = newNode;
        newNode.prev = lastNode;
    }

    public DNode GetLastNode(DoubleLinkedList singlyList)
    {
        DNode temp = singlyList.head;
        while (temp.next != null)
        {
            temp = temp.next;
        }
        return temp;
    }


    /*
     * To perform this operation on doubly linked list we need to follow two extra steps
Set the previous of new node to given node.
Set the previous of the next node of given node to the new node.
So, the method for Doubly Linked List will look like this.
     */

    public void InsertAfter(DNode prev_node, int data)
    {
        if (prev_node == null)
        {
            Console.WriteLine("The given prevoius node cannot be null");
            return;
        }
        DNode newNode = new DNode(data);
        newNode.next = prev_node.next;
        prev_node.next = newNode;
        newNode.prev = prev_node;
        if (newNode.next != null)
        {
            newNode.next.prev = newNode;
        }
    }

    //To perform this operation on doubly linked list we don't need any extra pointer for previous node as Doubly
    /// /linked list already have a pointer to previous node.so the delete method will be,

    public void DeleteNodebyKey(DoubleLinkedList doubleLinkedList, int key)
    {
        DNode temp = doubleLinkedList.head;
        if (temp != null && temp.data == key)
        {
            doubleLinkedList.head = temp.next;
            doubleLinkedList.head.prev = null;
            return;
        }
        while (temp != null && temp.data != key)
        {
            temp = temp.next;
        }
        if (temp == null)
        {
            return;
        }
        if (temp.next != null)
        {
            temp.next.prev = temp.prev;
        }
        if (temp.prev != null)
        {
            temp.prev.next = temp.next;
        }
    }

    // Return 0 for no value
    public int GetNth(DoubleLinkedList doubleLinkedList, int index)
    {
        DNode current = doubleLinkedList.head;
        int count = 0; /* index of Node we are
                        currently looking at */
        while (current != null)
        {
            if (count == index)
                return current.data;
            count++;
            current = current.next;
        }

        /* if we get to this line, the caller was asking
        for a non-existent element so we assert fail */
       // Debug.Assert(false);
        return 0;
    }

    /*
     * This is one of the most famous interview questions. We need to reverse the links of each node to point to its previous node,
     * and the last node should be the head node.This can be achieved by iterative 
     * as well as recursive methods. Here I am explaining the iterative method.
We need two extra pointers to keep track of previous and next node, initialize them to null.
Start traversing the list from head node to last node and reverse the pointer of one node in each iteration.
Once the list is exhausted, set last node as head node.
The method will look like this,
     */
    public void ReverseLinkedList(DoubleLinkedList singlyList)
    {
        DNode prev = null;
        DNode current = singlyList.head;
        DNode temp = null;
        while (current != null)
        {
            temp = current.next;
            current.next = prev;
            prev = current;
            current = temp;
        }
        singlyList.head = prev;
    }
}