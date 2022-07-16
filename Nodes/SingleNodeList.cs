using System;

public class SingleNodeList
{
    public class Node
    {
        internal int data;
        internal Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }

    public class SingleLinkedList
    {
        public Node head;
    }

    public void InsertFront(SingleLinkedList singlyList, int new_data)
    {
        Node new_node = new Node(new_data);
        new_node.next = singlyList.head;
        singlyList.head = new_node;
    }

    public void InsertLast(SingleLinkedList singlyList, int new_data)
    {
        Node new_node = new Node(new_data);
        if (singlyList.head == null)
        {
            singlyList.head = new_node;
            return;
        }
        Node lastNode = GetLastNode(singlyList);
        lastNode.next = new_node;
    }

    // function to create and return a Node 
    public Node GetNode(int data) => new Node(data);

    //int data = 12, pos = 3;
    //head = InsertPos(head, pos, data);
    //Console.WriteLine("Linked list after" +
    //                        " insertion of 12 at position 3: ");
    public Node InsertAtIndex(Node headNode,
                     int position, int data)
    {
        var head = headNode;
        if (position < 1)
            Console.WriteLine("Invalid position");

        //if position is 1 then new node is 
        // set infornt of head node
        //head node is changing.
        if (position == 1)
        {
            var newNode = new Node(data);
            newNode.next = headNode;
            head = newNode;
        }
        else
        {
            while (position-- != 0)
            {
                if (position == 1)
                {
                    // adding Node at required position
                    Node newNode = GetNode(data);

                    // Making the new Node to point to 
                    // the old Node at the same position 
                    newNode.next = headNode.next;

                    // Replacing current with new Node 
                    // to the old Node to point to the new Node 
                    headNode.next = newNode;
                    break;
                }
                headNode = headNode.next;
            }
            if (position != 1)
                Console.WriteLine("Position out of range");
        }
        return head;
    }


    // Return 0 for no value
    public int GetNth(SingleLinkedList doubleLinkedList, int index)
    {
        Node current = doubleLinkedList.head;
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

    public Node GetLastNode(SingleLinkedList singlyList)
    {
        Node temp = singlyList.head;
        while (temp.next != null)
        {
            temp = temp.next;
        }
        return temp;
    }


    public void InsertAfter(Node prev_node, int new_data)
    {
        if (prev_node == null)
        {
            Console.WriteLine("The given previous node Cannot be null");
            return;
        }
        Node new_node = new Node(new_data);
        new_node.next = prev_node.next;
        prev_node.next = new_node;
    }


    /*
     Delete a node from Linked List using a given key value
First step is to find the node having the key value.
We will traverse through the Linked list, and use one extra pointer to keep track of the previous node while traversing the linked list.
If the node to be deleted is the first node, then simply set the Next pointer of the Head to point to the next element from the Node to be deleted.
If the node is in the middle somewhere, then find the node before it, and make the Node before it point to the Node next to it.
If the node to be deleted is last node, then find the node before it, and set it to point to null.
So, the method for singly linked list will look like this,
     */
    public void DeleteNodebyKey(SingleLinkedList singlyList, int key)
    {
        Node temp = singlyList.head;
        Node prev = null;
        if (temp != null && temp.data == key)
        {
            singlyList.head = temp.next;
            return;
        }
        while (temp != null && temp.data != key)
        {
            prev = temp;
            temp = temp.next;
        }
        if (temp == null)
        {
            return;
        }
        prev.next = temp.next;
    }

    /*
     * This is one of the most famous interview questions. We need to reverse the links of each node to point to its previous node, and the last node should be the head node.This can be achieved by iterative as well as recursive methods. Here I am explaining the iterative method.
We need two extra pointers to keep track of previous and next node, initialize them to null.
Start traversing the list from head node to last node and reverse the pointer of one node in each iteration.
Once the list is exhausted, set last node as head node.
The method will look like this,
     */
    public void ReverseLinkedList(SingleLinkedList singlyList)
    {
        Node prev = null;
        Node current = singlyList.head;
        Node temp = null;
        while (current != null)
        {
            temp = current.next;
            current.next = prev;
            prev = current;
            current = temp;
        }
        singlyList.head = prev;
    }


    // Given a reference (pointer to pointer)
    // to the head of a list and a position,
    // deletes the node at the given position
    public void deleteNode(SingleLinkedList singlyList, int position)
    {

        // If linked list is empty
        if (singlyList.head == null)
            return;

        // Store head node
        Node temp = singlyList.head;

        // If head needs to be removed
        if (position == 0)
        {

            // Change head
            singlyList.head = temp.next;
            return;
        }

        // Find previous node of the node to be deleted
        for (int i = 0; temp != null && i < position - 1;
             i++)
            temp = temp.next;

        // If position is more than number of nodes
        if (temp == null || temp.next == null)
            return;

        // Node temp->next is the node to be deleted
        // Store pointer to the next of node to be deleted
        Node next = temp.next.next;

        // Unlink the deleted node from list
        temp.next = next;
    }

    public SingleLinkedList ClearList(SingleLinkedList singlyList)
    {


        //2. if the head is not null make temp as head and 
        //   move head to head next, then delete the temp,
        //   continue the process till head becomes null
        while (singlyList.head != null)
        {
          //  Node  temp = singlyList.head;
            singlyList.head = singlyList.head.next;
            //temp = null;
        }

        return singlyList;
       // Console.WriteLine("All nodes are deleted successfully.");
    }
}
