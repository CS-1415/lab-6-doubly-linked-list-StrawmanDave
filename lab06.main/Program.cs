using lab06;

//Test if printing out the list works correctly
DoublyLinkedList<int> Numbers = new DoublyLinkedList<int>();
Numbers.AddLast(1);
Numbers.AddLast(2);
Numbers.AddLast(3);
Numbers.AddLast(4);
Console.WriteLine("List in order");
Numbers.printList();
Console.WriteLine();
//test if removelast works
Numbers.RemoveLast();
Console.WriteLine("Removed the end node");
Numbers.printList();
Console.WriteLine();

//test if reversList works
Numbers.ReverseList();
Console.WriteLine("List reversed");
Numbers.printList();


//test if addFirst works correctly
DoublyLinkedList<int> newNumber = new DoublyLinkedList<int>();
Console.WriteLine();
newNumber.AddFirst(1);
newNumber.AddFirst(2);
newNumber.AddFirst(3);
newNumber.AddFirst(4);
newNumber.printList();

//test if removeFirst wors correctly
newNumber.RemoveFirst();
Console.WriteLine();
Console.WriteLine("Removed the first node");
newNumber.printList();

DoublyLinkedList<string> Words = new DoublyLinkedList<string>();
Words.AddLast("The");
Words.AddLast("Quick");
Words.AddLast("Brown");
Words.AddLast("Fox");

Console.WriteLine();
Words.printList();
Words.ReverseList();
Console.WriteLine();
Words.printList();

DoublyLinkedList<int> SameNumbers = newNumber.Reverse();
SameNumbers.printList();