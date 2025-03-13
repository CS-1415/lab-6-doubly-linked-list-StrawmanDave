namespace lab06;
public interface IDoubleEndedCollection<T>
{
    T First { get; }
    T Last { get; }
    int Length { get; }

    void AddLast(T value);  
    void AddFirst(T value);
    void RemoveFirst();     
    void RemoveLast();                
    void InsertAfter(DNode<T> dNode, T value);
    void RemoveByValue(T value);
    void ReverseList();
}



public class DNode<T>
{
    public T Value {get; set;}
    public DNode<T>? Previous {get; set;}
    public DNode<T>? Next {get; set;}

    public DNode()
    {

    }

    public DNode(T value)
    {
        Value = value;
    }

    public bool Equals(DNode<T> node)
    {
        if(node.Value.Equals(Value))
        {
            return true;
        }

        return false;
    }
}

public class DoublyLinkedList<T> : IDoubleEndedCollection<T>
{
    private DNode<T>? _head = null;
    private DNode<T>? _tail = null;
    T IDoubleEndedCollection<T>.First => _head.Value;
    T IDoubleEndedCollection<T>.Last => _tail.Value;
    public int Length {get; private set;} = 0;
    
    public void printList()
    {
        DNode<T> Curr = _head;
        for(int i = 0; i<Length; i ++)
        {
            Console.Write($"{Curr.Value} ");
            Curr = Curr.Next;
        }
    }
    public void AddLast(T value)
    {
        //used to add a node with the given value at the end of the list
        //create a new node with value of the parameter
        DNode<T> newNode = new DNode<T>(value);

        if(_tail == null)//checking if tail is null checks if the list is empty or has one because we set the head to the new node. 
        {
            _head = newNode; 
        }else //if the list has one or more
        {
            newNode.Previous = _tail;
            _tail.Next = newNode;
        }
        _tail = newNode;
        Length ++;
    }

    public void AddFirst(T value)
    {
        //used to add a node with the given value at the beggining of the list
        //create a new node with the value of the paramerter
        DNode<T> newNode = new DNode<T>(value);
        newNode.Next = _head;

        if (_head == null)
        {
            _tail = newNode;
        }else
        {
            _head.Previous = newNode;
        }
 
        _head = newNode;
        Length ++;
    }

    public void RemoveFirst()
    {
        if(_head != null)
        {
            _head = _head.Next;

            if(_head == null)
            {
                _tail = null;
            }
            Length --;
        }
    }

    public void RemoveLast()
    {
        if(_tail != null)
        {
            _tail = _tail.Previous;

            if(_tail == null)
            {
                _head = null;
            }
            Length --;
        }
    }

    public void InsertAfter(DNode<T> DN, T value)
    {
        //used to insert after the DN node given
        //will need to set the DN.Value or it will not do anything.
        DNode<T> newNode = new DNode<T>(value);
        DNode<T> curr = _head;

        //travers the list to find the first node Equal to DN
        while(curr != null)
        {
            if(curr.Equals(DN))
            {
                curr.Next = newNode;
                break;
            }
            curr = curr.Next;
        }

        if(curr == null)
        {
            Console.WriteLine("Node not found");
        }
        
    }

    public void RemoveByValue(T value)
    {
        //Will remove any node out of the list with the given value.
        DNode<T> Curr = _head;
        while(Curr != null)
        {
            if(Curr.Value.Equals(value))
            {
                if(Curr.Next == null)
                {
                    _tail = Curr.Previous;
                }
               
            }else
            {
                Curr.Next.Previous = Curr.Previous;
            }

            if(Curr.Previous == null)
            {
                _head = Curr.Next;
            }else
            {
                Curr.Previous.Next = Curr.Next;
            }

            Curr = null;
            Length --;
        }
    }

    public void ReverseList()
    {
        DoublyLinkedList<T> temp = Reverse();
        DNode<T> Curr = temp._head;
        while(Length > 0)
        {
            RemoveFirst();
        }

        for(int i = 0; i<temp.Length; i++)
        {
            AddLast(Curr.Value);
            Curr = Curr.Next;
        }
    }

    public DoublyLinkedList<T> Reverse()
    {
        DoublyLinkedList<T> reversed = new DoublyLinkedList<T>();
        while(_tail != null)
        {
            reversed.AddLast(_tail.Value);
            _tail = _tail.Previous;
        }
        return reversed;
    }
}