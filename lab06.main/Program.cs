using lab06;
using System.Diagnostics;
using System.Net;

//hardcoad a new LinkedList with nothing in it
DoublyLinkedList<int> intTest = new DoublyLinkedList<int>();
//has correct length
Debug.Assert(intTest.Length == 0);
//Single AddLast works
intTest.AddLast(new DNode<int>(1), 1);
//Single AddFirst works
intTest.AddFirst(new DNode<int>(2), new DNode<int>(2).Value);

intTest.ForwardTraversal();