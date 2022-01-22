using System;

namespace MyCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> myList = new MyLinkedList<int>() {10,20,30};

            MyLinkedList<int>.MyLinkedListNode<int> node;
            myList.AddFirst(1);
            myList.AddFirst(2);
            myList.AddFirst(3);

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(myList.Find(2).Value);

            myList.Clear();
            Console.Read();
        }
    }
}
