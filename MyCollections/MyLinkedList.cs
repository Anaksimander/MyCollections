using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    class MyLinkedList<T> : IEnumerable<T>
    {
        public int Count { get; set; }
        public MyLinkedListNode<T> First { get; set; }
        public MyLinkedListNode<T> Last { get; set; }
        public MyLinkedList()
        {
            Count = 0;
            First = null;
            Last = null;
        }
        public MyLinkedList<T>? AddAfter(MyLinkedListNode<T> node, T value)
        {

            return this;
        }
        public MyLinkedList<T> AddLast(T value)
        {
            if (Count == 0)
            {
                First = new MyLinkedListNode<T>(value);
                Last = First;
            }
            else if (Count == 1)
            {
                Last = new MyLinkedListNode<T>(value, First, Last);
                First.Next = Last;
                First.Previous = Last;
            }
            else
            {
                Last.Next = new MyLinkedListNode<T>(value, First, Last);
                Last = Last.Next;
                First.Previous = Last;
            }
            Count++;
            return this;
        }
        public MyLinkedList<T> AddLast(MyLinkedListNode<T> node)
        {
            if (Count == 0)
            {
                First = new MyLinkedListNode<T>(node);
                Last = First;
            }
            else if (Count == 1)
            {
                Last = new MyLinkedListNode<T>(node);
                First.Next = Last;
                First.Previous = Last;
            }
            else
            {
                Last.Next = new MyLinkedListNode<T>(node);
                Last = Last.Next;
                First.Previous = Last;
            }
            Count++;
            return this;
        }
        public MyLinkedList<T> AddFirst(T value)
        {
            if (Count == 0)
            {
                First = new MyLinkedListNode<T>(value);
                Last = First;
            }
            else if (Count == 1)
            {
                First = new MyLinkedListNode<T>(value, First, Last);
                Last.Previous = First;
                Last.Next = First;
            }
            else
            {
                First.Previous = new MyLinkedListNode<T>(value, First, Last);
                First = First.Previous;
                Last.Next = First;
            }
            Count++;
            return this;
        }
        public MyLinkedList<T> AddFirst(MyLinkedListNode<T> node)
        {
            if (Count == 0)
            {
                First = new MyLinkedListNode<T>(node);
                Last = First;
            }
            else if (Count == 1)
            {
                First = new MyLinkedListNode<T>(node);
                Last.Previous = First;
                Last.Next = First;
            }
            else
            {
                First.Previous = new MyLinkedListNode<T>(node);
                First = First.Previous;
                Last.Next = First;
            }
            Count++;
            return this;
        }
        public MyLinkedList<T> RemoveFirst()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Last.Next = First.Next;
                First = First.Next;
                First.Previous = Last;
            }
            Count--;
            return this;
        }
        public MyLinkedList<T> RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                First.Previous = Last.Previous;
                Last = Last.Previous;
                Last.Next = First;
            }
            Count--;
            return this;
        }
        public MyLinkedListNode<T>? Find(T value)
        {

            return null;
        }

        public IEnumerator<T> GetEnumerator(){
            return new MyLinkedListEnumeratorGeneral(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyLinkedListEnumerator(this);
        }

        class MyLinkedListEnumeratorGeneral : IEnumerator<T>
        {
            private MyLinkedList<T> list;
            private MyLinkedListNode<T> ENode;
            int position = -1;
            public MyLinkedListEnumeratorGeneral(MyLinkedList<T> list)
            {
                this.list = list;
            }
            public T Current
            {
                get
                {
                    if (position == -1 || position >= list.Count)
                        throw new ArgumentException();
                    return ENode.Value;
                }
            }
            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                
                if (position == -1)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    position--;
                    ENode = ENode.Previous;
                }
            }

            public bool MoveNext()
            {
                if (position == -1)
                {
                    position++;
                    ENode = list.First;
                    return true;
                }
                else
                if (position < list.Count-1)
                {
                    position++;
                    ENode = ENode.Next;
                    return true;
                }
                else
                    return false;
            }
            public void Reset()
            {
                ENode = null;
                position = -1;
            }
        }

        class MyLinkedListEnumerator : IEnumerator
        {
            private MyLinkedList<T> list;
            private MyLinkedListNode<T> ENode;
            int position = -1;
            public MyLinkedListEnumerator(MyLinkedList<T> list) {
                this.list = list;
            }
            
            public object Current
            {
                get
                {
                    if (position == -1 || position > list.Count)
                        throw new ArgumentException();
                    return ENode.Value;
                }
            }
            public bool MoveNext()
            {
                if(position == -1)
                {
                    ENode = list.First;
                    return true;
                }
                else
                if (position <= list.Count)
                {
                    position++;
                    ENode = ENode.Next;
                    return true;
                }
                else
                    return false;
            }
            public void Reset()
            {
                ENode = null;
                position = -1;
            }
        }

        public class MyLinkedListNode<L>
        {
            public MyLinkedListNode<L> Next { get; set; }
            public L Value { get; private set; }
            public MyLinkedListNode<L> Previous { get; set; }
            public MyLinkedListNode(L value)
            {
                Value = value;
                Next = this;
                Previous = this;
            }
            public MyLinkedListNode(MyLinkedListNode<L> value)
            {
                Value = value.Value;
                Next = value.Next;
                Previous = value.Previous;
            }
            public MyLinkedListNode(L value, MyLinkedListNode<L> next, MyLinkedListNode<L> previous)
            {
                Value = value;
                Next = next;
                Previous = previous;
            }
        }
    }
}
