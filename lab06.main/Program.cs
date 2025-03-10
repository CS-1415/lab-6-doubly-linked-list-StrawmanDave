using lab06;
using Microsoft.VisualBasic;
using System.Diagnostics;

DoublyLinkedList<string> stringTest = new DoublyLinkedList<string>();
stringTest.AddFirst(new DNode<string>("One"), "One");

stringTest.ForwardTraversal();