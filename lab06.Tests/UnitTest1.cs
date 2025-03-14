namespace lab06.Tests;

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

    public void TestPrintList()
    {
        //Test if printing out the list works correctly
        DoublyLinkedList<int> Numbers = new DoublyLinkedList<int>();
        Numbers.AddLast(1);
        Numbers.AddLast(2);
        Numbers.AddLast(3);
        Numbers.AddLast(4);
        Console.WriteLine("List in order");
        Numbers.printList(); // should print 1 2 3 4
    }

    public void TestRemoveLast()
    {
        //test if removelast works
        DoublyLinkedList<int> Numbers = new DoublyLinkedList<int>();
        Numbers.AddLast(1);
        Numbers.AddLast(2);
        Numbers.AddLast(3);
        Numbers.AddLast(4);
        Numbers.RemoveLast();
        Console.WriteLine("Removed the end node");
        Numbers.printList();
        Console.WriteLine();
    }

    public void TestReverseList()
    {
        //test if reversList works
        DoublyLinkedList<int> Numbers = new DoublyLinkedList<int>();
        Numbers.AddLast(1);
        Numbers.AddLast(2);
        Numbers.AddLast(3);
        Numbers.AddLast(4);
        Numbers.ReverseList();
        Console.WriteLine("List reversed");
        Numbers.printList(); // should print 4 3 2 1


        DoublyLinkedList<string> Words = new DoublyLinkedList<string>();
        Words.AddLast("The");
        Words.AddLast("Quick");
        Words.AddLast("Brown");
        Words.AddLast("Fox");

        //second test with words for reverse list
        Words.printList(); // should print The Quick Brown Fox
        Words.ReverseList();
        Console.WriteLine();
        Words.printList();// should print Fox Brown Quick The
    }

    public void TestAddFirst()
    {
        //test if addFirst works correctly
        DoublyLinkedList<int> newNumber = new DoublyLinkedList<int>();
        newNumber.AddFirst(1);
        newNumber.AddFirst(2);
        newNumber.AddFirst(3);
        newNumber.AddFirst(4);
        newNumber.printList(); // should pritn 4 3 2 1
    }

    public void TestRemovefirst()
    {
        //test if removeFirst wors correctly
        DoublyLinkedList<int> newNumber = new DoublyLinkedList<int>();
        newNumber.AddFirst(1);
        newNumber.AddFirst(2);
        newNumber.AddFirst(3);
        newNumber.AddFirst(4);
        newNumber.RemoveFirst();
        Console.WriteLine();
        Console.WriteLine("Removed the first node");
        newNumber.printList();
    }

    public void TestReverse()
    {
        //test if Reverse method really returns the list reversed.
        DoublyLinkedList<int> newNumber = new DoublyLinkedList<int>();
        newNumber.AddFirst(1);
        newNumber.AddFirst(2);
        newNumber.AddFirst(3);
        newNumber.AddFirst(4);
        DoublyLinkedList<int> SameNumbers = newNumber.Reverse();
        Console.WriteLine();
        SameNumbers.printList();// prints 1 2 3 4
        Console.WriteLine();
    }

    public void TestDNodeEquals()
    {
        //test if DNodes equals works
        DNode<int> Node1 = new DNode<int>(3);
        DNode<int> Node2 = new DNode<int>(3);
        DNode<int> number2 = new DNode<int>(2);
        DNode<string> Node3 = new DNode<string>("Three");
        Console.WriteLine(Node1.Equals(Node2)); // should be true
        Console.WriteLine(Node1.Equals(Node3)); // should be false not even the same type
        DNode<string> Node4 = new DNode<string>("Three");
        Console.WriteLine(Node3.Equals(Node4)); // should be true;
        Console.WriteLine(Node1.Equals(number2)); // should be false different numbers 
        DNode<string> word2 = new DNode<string>("Two");
        Console.WriteLine(Node3.Equals(word2)); // should be false both strings but not the same string
    }

    public void TestContainsValue()
    {
        //test if remove by value works
        DoublyLinkedList<int> Numbers = new DoublyLinkedList<int>();
        Numbers.AddLast(1);
        Numbers.AddLast(2);
        Numbers.AddLast(3);
        Numbers.AddLast(4);
        Console.WriteLine(Numbers.ContainsValue(6)); // should be false because it does not contain that value
        Console.WriteLine(Numbers.ContainsValue(3)); // should be true it does contain a values
    }

    public void TestRemoveByValue()
    {
        //test if remove by value works
        DoublyLinkedList<int> Numbers = new DoublyLinkedList<int>();
        Numbers.AddLast(1);
        Numbers.AddLast(2);
        Numbers.AddLast(3);
        Numbers.AddLast(4);
        Numbers.RemoveByValue(3);
        Console.WriteLine("List without 3 in it");
        Numbers.printList();

        //second test for RemoveByValue
        DoublyLinkedList<string> Words = new DoublyLinkedList<string>();
        Words.AddLast("The");
        Words.AddLast("quick");
        Words.AddLast("brown");
        Words.AddLast("fox");
        Words.RemoveByValue("quick");
        Console.WriteLine("List without quick in it");
        Words.printList();

    }

    public void TestInsertAfter()
    {
        //test if InsertAfter method works
        DoublyLinkedList<int> Numbers = new DoublyLinkedList<int>();
        Numbers.AddLast(1);
        Numbers.AddLast(2);
        Numbers.AddLast(3);
        Numbers.AddLast(4);
        Numbers.AddLast(7);
        Numbers.printList(); //1 2 3 4 7
        Console.WriteLine();
        Numbers.InsertAfter(new DNode<int>(4), 5);
        Numbers.InsertAfter(new DNode<int>(5), 6);
        Numbers.printList(); //1 2 3 4 5 6 7
        Console.WriteLine();

        //Second test if InsertAfter method works
        DoublyLinkedList<string> words = new DoublyLinkedList<string>();
        words.AddLast("The");
        words.AddLast("quick");
        words.AddLast("brown");
        words.AddLast("fox");
        words.AddLast("jumps");
        words.printList(); // The quick brown fox jumps
        Console.WriteLine();
        words.InsertAfter(new DNode<string>("quick"), "agile");
        words.printList();// The quick agile brown fox jumps
        Console.WriteLine();
    }

    public void linkedListStartingEmptyTest()
    {
        DoublyLinkedList<int> Numbers = new DoublyLinkedList<int>();
        Debug.Assert(Numbers.Length == 0); // Has correct length it was barrely created so it should be 0
        Numbers.AddLast(1);
        Debug.Assert(Numbers.Length == 1); // now has 1
        Numbers.printList(); // should print 1;
        Console.WriteLine();
        Numbers.AddFirst(2);
        Numbers.printList();// should print 2 1
        Console.WriteLine(); 
    }

    public void LinkedListStartingWithOneAtBackTest()
    {
        //initated list with one at back
        DoublyLinkedList<int> Numbers = new DoublyLinkedList<int>();
        Numbers.AddLast(1);
        Debug.Assert(Numbers.Length == 1); // Has correct length it was barrely created so it should be 1
        Numbers.AddLast(2);
        Numbers.printList(); // should print 1 2
        Console.WriteLine();
        Numbers.AddFirst(2);
        Numbers.printList();// should print 2 1 2
        Console.WriteLine();
        Numbers.RemoveLast();
        Numbers.printList(); // should print 2 1
        Console.WriteLine();
        Numbers.RemoveFirst();
        Numbers.printList();// should print 1
        Console.WriteLine();
    }

    public void LinkedListStartingWithOneAtFrontTest()
    {
        //initated list with one at back
        DoublyLinkedList<int> Numbers = new DoublyLinkedList<int>();
        Numbers.AddFirst(1);
        Debug.Assert(Numbers.Length == 1); // Has correct length it was barrely created so it should be 1
        Numbers.AddLast(2);
        Numbers.printList(); // should print 1 2
        Console.WriteLine();
        Numbers.AddFirst(2);
        Numbers.printList();// should print 2 1 2
        Console.WriteLine();
        Numbers.RemoveLast();
        Numbers.printList(); // should print 2 1
        Console.WriteLine();
        Numbers.RemoveFirst();
        Numbers.printList();// should print 1
        Console.WriteLine();
    }

    public void LinkedListStaringWithTwoTests()
    {
        //initated list with one at back and one at the front
        DoublyLinkedList<int> Numbers = new DoublyLinkedList<int>();
        Numbers.AddLast(1);
        Numbers.AddFirst(2);
        Debug.Assert(Numbers.Length == 2); // Has correct length it was barrely created so it should be 2
        Numbers.RemoveFirst(); 
        Numbers.printList();// should print 1
        Console.WriteLine();
        Numbers.RemoveLast();
        Numbers.printList(); // should print 0
        Console.WriteLine();
        Debug.Assert(Numbers.Length == 0); //Should have 0 in it because we removed all the items
        
        //initated list with one at back and one at the front
        DoublyLinkedList<int> newNumbers = new DoublyLinkedList<int>();
        newNumbers.AddLast(1);
        newNumbers.AddFirst(2);
        Debug.Assert(newNumbers.Length == 2); // Has correct length it was barely created so it should be 2
        newNumbers.printList(); // should print 2 1
        Console.WriteLine();
        newNumbers.ReverseList(); // should print out 1 2
        newNumbers.printList(); 
        Console.WriteLine(); // should print 1 2
    }
}