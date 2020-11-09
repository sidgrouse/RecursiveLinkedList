using System;
using System.Collections.Generic;

namespace RecursiveLinkedList
{
    public static class RecursiveLinkedListExtensions
    {
        public static RecursiveLinkedList<T> AddElementToPresortedList<T>(this RecursiveLinkedList<T> list, T newElement, IComparer<T> comparer = null) 
        {
            comparer ??= Comparer<T>.Default;

            var newList = Copy(list);

            var pointer = newList;
            while (!pointer.IsEmpty)
            {
                var isNewElementLess = comparer.Compare(newElement, pointer.Head) < 0;
                if (isNewElementLess)
                {
                    pointer.AddHead(newElement);
                    break;
                }

                pointer = pointer.Tail;
            }

            if (pointer.IsEmpty)
            {
                pointer.AddHead(newElement);
            }

            return newList;
        }

        private static RecursiveLinkedList<T> Copy<T>(RecursiveLinkedList<T> list)
        {
            if (list.IsEmpty)
            {
                return new RecursiveLinkedList<T>();
            }

            return new RecursiveLinkedList<T>(list.Head, Copy(list.Tail));
        }
    }
}
