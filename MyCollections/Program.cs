using System;

namespace MyCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> myList = new MyLinkedList<int>();

            MyLinkedList<int>.MyLinkedListNode<int> node;
            myList.AddFirst(1);
            myList.AddFirst(2);
            myList.AddFirst(3);
        }
    }
}
