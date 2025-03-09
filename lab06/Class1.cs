using System.Transactions;

namespace lab06;


// A doublylinked nodeDNode
public class DNode<T>
{
    public T Value {get; set;}
    public DNode<T>? Previous {get; set;}
    public DNode<T>? Next {get; set;}

    public DNode(T value)
    {
        Value = value;
        Previous = Next = null;
    }
}

public class DoublyLinkedList<T>
{
    private DNode<T>? _head = null;
    private DNode<T>? _tail = null;
    public int Length {get; set;} = 0;

    public DoublyLinkedList()
    {

    }
    public DoublyLinkedList(T one, T two)
    {
        _head = AddFirst(_head, one);
        _tail = AddLast(_tail, two);
        Length = findSize(_head);
    }

    public void ForwardTraversal()
    {
        DoublyLinkedList<T>.ForwardTraversal(_head);
    }

    public static void ForwardTraversal(DNode<T> head)
    {
        DNode<T> curr = head;

        while(curr != null)
        {
            //output the data
            Console.Write(curr.Value + " ");

            //Move to the next node
            curr = curr.Next;
        }
        Console.WriteLine();
    }

    static void BackwardTraversal(DNode<T> tail)
    {
        DNode<T> curr = tail;

        while(curr != null)
        {
            Console.Write(curr.Value + " ");

            curr = curr.Previous;
        }
        Console.WriteLine();
    }

    static int findSize(DNode<T> head)
    {
        if(head == null)
        {
            return 0;
        }
        return 1 + findSize(head.Next);
    }

    public DNode<T> AddFirst(DNode<T> head, T value)
    {
        //create a new node
        DNode<T> newNode = new DNode<T>(value);
        
        //change previous pointer of head node to new node
        if(head != null)
        {
            head.Previous = newNode;
        }
        
        //return the new node as the head of the doubly
        //linked list
        return newNode;
    }

    public DNode<T> AddLast(DNode<T> head, T value)
    {
        //create a new node
        DNode<T> newNode = new DNode<T>(value);

        // if the linked list is empty, set hte new node as head
        if(head == null)
        {
            head = newNode;
        }else
        {
            DNode<T> curr = head;
            while(curr.Next != null)
            {
                curr = curr.Next;
            }

            //set the next of the last node to the new node
            curr.Next = newNode;

            //set the previous of the new node to the last node
            newNode.Previous = curr;
        }

        return head;
    }

    public DNode<T> RemoveFirst(DNode<T> head)
    {
        //check if the list is empty
        if(head == null)
        {
            return null;
        }
        
        // move the head pointer to the next node
        head = head.Next;

        return head;
    }

    public DNode<T> RemoveLast(DNode<T> head)
    {
        //deals with the corner cases
        if(head == null)
        {
            return null;
        }
        if(head.Next == null)
        {
            return null;
        }

        //travers to the last node
        DNode<T> curr = head;
        while(curr.Next != null)
        {
            curr = curr.Next;
        }

        //update the previous node's next pointer
        if(curr.Previous != null)
        {
            curr.Previous.Next = null;
        }

        //delete the last node
        curr = null;

        //return the updated head
        return head;
    }

    public static DNode<T> InsertAfter(DNode<T> head, T value, int pos)
    {
        //create a new node with the given value from the paramater
        DNode<T> newNode = new DNode<T>(value);
        
        // insertion at the beginning
        if(pos == 1)
        {
            newNode.Next = head;
            if(head != null)
            {
                head.Previous= newNode;
            }
            head = newNode;
            return head; 
        }
        
        DNode<T> curr = head;

        // traverse the list to find the node before the insertion point
        for(int i = 1; curr != null && i<pos; i++)
        {
            curr = curr.Next;
        }

        // if the postion is out of bounds
        if(curr == null)
        {
            Console.WriteLine("postion is out of bounds");
            return head;
        }

        //set the previous of new node to the next curr
        newNode.Previous = curr;
        //set the previous of new node to the next ov curr
        newNode.Next = curr.Next;
        // update the next of current node to the new node
        curr.Next = newNode;

        //if the next node is not the last node, update previous of the new node to then next node
        if(newNode.Next != null)
        {
            newNode.Next.Previous = newNode;
        }

        return head;
    }

    static DNode<T> RemoveByValue(DNode<T> head, int pos)
    {
        //if the list is empty
        if(head == null)
        {
            return head;
        }

        DNode<T> curr = head;

        //travers to the node at the given postions
        for(int i = 1; curr != null && i <pos; i++)
        {
            curr = curr.Next;
        }

        //if the postion is out of range
        if(curr.Previous != null)
        {
            curr.Previous.Next = curr.Next;
        }

        //update the previous node's next pointer
        if(curr.Previous != null)
        {
            curr.Previous.Next = curr.Next;
        }

        //update the next node's previous pointer
        if(curr.Next != null)
        {
            curr.Next.Previous = curr.Previous;
        }

        //if the node to be deleted is the head node
        if( head == curr)
        {
            head = curr.Next;
        }

        // Deallocate memory for the deleted node
        // in C#, the garbe collector handles this automatically
        return head;
    }

    public void ReverseList()
    {
        _head = _tail;
    }
}