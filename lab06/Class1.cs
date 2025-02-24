namespace lab06;

public interface IDoubleEndedCollection<T>
{
    T First {get;}
    T Last {get;}
    int Length {get;}

    void AddLast(T value);
    void AddFirst(T value);
    void RemoveFirst();
    void RemoveLast();
    void InsertAfter(DNode<T>, T value);
    void RemoveByValue(T value);
    void ReverseList();

}

public class DNode<T>
{
    public T Value {get; set;}
    public DNode<T>? Previous {get; set;}
    public DNode<T>? Next {get; set;}
}

public class DoublyLinkedList<T> : IDoubleEndedCollection<T>
{
    private DoubleLinkedListNode<T>? _head = null;
    private DoublyLinkedListNode<T>? _tail = null;
    public int Lenght {get;} = 0;

    //TODO: implement the methods of the interface
}