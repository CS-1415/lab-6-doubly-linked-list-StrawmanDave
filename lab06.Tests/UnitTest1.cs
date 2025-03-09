namespace lab06.Tests;

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using lab06;
using NUnit.Framework.Internal;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestForwardTraversal()
    {

        DNode<int> head = new DNode<int>(1);
        DNode<int> second = new DNode<int>(2);
        DNode<int> third = new DNode<int>(3);

        head.Next = second;
        second.Previous = head;
        second.Next = third;
        third.Previous = second;

        Console.WriteLine("Forward Traversal");
        DoublyLinkedList<int>.ForwardTraversal(head);
    }

    public void linkedListStartingEmptyTest()
    {
        //hardcode a new LinkedList with nothing in it
        DoublyLinkedList<int> intTest = new DoublyLinkedList<int>();
        //has correct length
        Debug.Assert(intTest.Length == 0);
        //Single AddLast works
        intTest.AddLast(new DNode<int>(1), 1);
        //Single AddFirst works
        intTest.AddFirst(new DNode<int>(2), new DNode<int>(2).Value);
    }

    public void LinkedListStartingWithOneAtBackTest()
    {
        //hardcode a new DoublyLinked list with one item in it at the back
        DoublyLinkedList<string> oneBack = new DoublyLinkedList<string>(null, "One");
        //Single AddLast works
        oneBack.AddLast(new DNode<string>("Two"), "Two");
        //Single AddFirst works
        oneBack.AddFirst(new DNode<string>("Three"),"Three");
        //Single RemoveLast works
        oneBack.RemoveLast(new DNode<string>("One"));
        //Sigle RemoveFirst works
        oneBack.RemoveFirst(new DNode<string>("Three"));
    }

    public void LinkedListStartingWithOneAtFrontTest()
    {
        //hardcode a new DoublyLinked list with one item in it at the front
        DoublyLinkedList<string> oneFront = new DoublyLinkedList<string>("One",null);
        //Single AddFirs works
        oneFront.AddFirst(new DNode<string>("Two"),"Two");
        //Single AddLast works
        oneFront.AddLast(new DNode<string>("Three"), "Three");
        //Single RemoveLast works
        oneFront.RemoveLast(new DNode<string>("Three"));
        //Single RemoveFirst works
        oneFront.RemoveFirst(new DNode<string>("Two"));
    }

    public void LinkedListStaringWithTwoTests()
    {
        //hardcode a new DoublyLinked list with one item in it at the front and one item at the back
        DoublyLinkedList<int> twoItems = new DoublyLinkedList<int>(1,2);
        twoItems.RemoveFirst(new DNode<int>(1));
        twoItems.RemoveFirst(new DNode<int>(1));
        //results in empty list
        Debug.Assert(twoItems.Length == 0);

        //seconded LinkedListStartingWithTwoTest
        DoublyLinkedList<int> threeItems = new DoublyLinkedList<int>(1,2);
        threeItems.AddLast(new DNode<int>(3),3);
        threeItems.ReverseList();
        threeItems.ForwardTraversal();
    }
}