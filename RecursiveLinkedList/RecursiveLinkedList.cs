using System;
using System.Collections;
using System.Collections.Generic;

namespace RecursiveLinkedList
{
    /// <summary>
    /// Linked list implemented in recursive manner.
    /// </summary>
    /// <typeparam name="T">The type of stored elemetns.</typeparam>
    public class RecursiveLinkedList<T>
    {
        internal bool IsEmpty => Tail == null;

        private T _head;

        public RecursiveLinkedList()
        {
        }

        public RecursiveLinkedList(T head, RecursiveLinkedList<T> tail)
        {
            _head = head;
            Tail = tail;
        }

        public T Head => IsEmpty ? throw new InvalidOperationException("The list is empty") : _head;

        public RecursiveLinkedList<T> Tail { get; private set; }

        public void AddHead(T newHead)
        {
            Tail = new RecursiveLinkedList<T>(_head, Tail);
            _head = newHead;
        }

        public void RemoveHead()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("There is no head to be removed. The list is empty");
            }

            _head = Tail._head;
            Tail = Tail.Tail;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var pointerHead = this;
            while (!pointerHead.IsEmpty)
            {
                yield return pointerHead.Head;
                pointerHead = pointerHead.Tail;
            }
        }

        public override string ToString()
        {
            return IsEmpty ? "---" : Head.ToString();
        }
    }
}
