# Lab-6-Doubly-Linked-List
Lab 06 - Basic Doubly-Linked List
General Learning Objectives

Use a modern operating system and utilities.

Use an integrated development environment to develop a program.

Solve problems and develop programs using the control structures of sequence, selection, and repetition, following a disciplined approach.

Objectives
Understand the idea of creating a singly-linked list and a doubly-linked list 
Gain more practice implementing interfaces and using generics.
Gain more experience working with references.
Gain practice with recursively defined datatypes.
Gain practice with declaring nullable types.
Step 1: Read and Understand This Overview

The C# standard library's System.Collections.Generic.LinkedList implements a data structure known as a circular doubly linked list. The interface is similar to the following which you will implement in this lab:

public interface IDoubleEndedCollection<T>
{

    T First { get; }
    T Last { get; }
    int Length { get; }

    void AddLast(T value);  
    void AddFirst(T value);
    void RemoveFirst();     
    void RemoveLast();                
    void InsertAfter(DNode<T>, T value);
    void RemoveByValue(T value);
    void ReverseList();
}


Rather than having an underlying array reserving a large chunk of contiguous memory, a linked list uses separate Node structures that can be spread across many small chunks of memory and that are linked together using references. Specifically, here is a possible implementation of a LinkedListNode:

public class DNode<T> 
{
    public T Value { get; set; }
    public DNode<T>? Previous { get; set; }
    public DNode<T>? Next { get; set; }
}


The idea is that a node will contain a piece of data as well as a pointer to the next node (if it isn't the last node in the list) and a pointer to the previous node (if it isn't the first node in the list). The list itself, just holds a reference to the first node and the last node (which are both null if the list is empty):

public class DoublyLinkedList<T> : IDoubleEndedCollection<T> 
{
    private DoublyLinkedListNode<T>? _head = null;
    private DoublyLinkedListNode<T>? _tail = null;
    public int Length { get; } = 0;

    // TODO: implement the methods of the interface
}


While an array-list allows fast random access to any position in the list and supports fast insertion and deletion from the back. A doubly-linked list supports fast insertion and deletion from both the front and the back, but doesn't provide fast random access (however, stay-tuned for learning about the idea of iterators and enumerators that can let you efficiently iterate over the values of a linked list).

Here is a brief description of how to add and remove from the end:

Pseudo code to add a value at the end

void AddLast(T value):
   create a new node with the new value
   if the list is empty:
       set head and tail to both point to that new node
   otherwise:
       set tail's next to point to the new node
       set the new node's previous to point to tail
       set tail to point to the new node
   increment the length


Pseudo code to remove a value from the end

void RemoveLast():
   if the list only has one item:
       set head and tail both to null
   otherwise:
       get the second to last node and set its next to null
   decrement the length


Adding to and removing from the beginning are analogous. First and Last should simply return the corresponding values from the head and tail respectively.

We won't require to you write a main method for this project. Instead, you will just make and test a library.

Step 2: Test and Implement
Setup the solution (refer to your last lab if you still need help with these steps):
Accept the GitHub Classroom Assignment.
Clone the repository.
Start a new dotnet solution in the repository.
Create a classlib and an nunit projects within the solution and add to the nunit project a reference to the classlib.
In the classlib project, create .cs files for the interface and the two classes listed above. Add all of the new source files to the git repository and then commit.
Add the minimal amount of code so that the class lib project will compile.
In the test project, incrementally tests for the following scenarios. We recommend doing so via a separate Tests class for each starting condition so that you can leverage the Setup method to setup the initial scenario before each test (look back at the Polymorphic Drawing Lab to see an example of how we did this before for the shapes). Specifically, we recommend having a non-static member variable that is a DoublyLinkedList that is initialized in the Setup method according to each of the scenarios described below. Then, within the class will be a separate test method that starts with the same setup but manipulates and then tests the list in different ways (also described below). You must test each of the following scenarios and conditions:
LinkedListStartingEmptyTests.cs (Setup just initializes to an empty list):
Has correct length.
Single AddLast works.
Single AddFirst works.
LinkedListStartingWithOneAtBackTests.cs (Setup initializes a list with just one item added to the back):
Single AddLast works.
Single AddFirst works.
Single RemoveLast works.
Single RemoveFirst works.
LinkedListStartingWithOneAtFrontTests.cs (Setup initializes a list with just one item added to the front):
Single AddLast works.
Single AddFirst works.
Single RemoveLast works.
Single RemoveFirst works.
LinkedListStartingWithTwoTests.cs (Setup initializes a list with two items):
Removing first from the front, then remove from the back, results in empty list.
LinkedListStartingWithTwoTests.cs (Setup initializes a list with three items):
Reverse successfully reverses the order of the list.
(Double-check that your implementation matches the pseudo-code given about and add additional tests if necessary.)
Commit and push all of your changes.
Grading

Grading must be done in person or via Teams with a TA or instructor.

Getting a TA or instructor to sign-off on your lab before you leave is the easiest and best way to get the best grade possible.
