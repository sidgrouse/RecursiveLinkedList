using System;
using System.Linq;

namespace RecursiveLinkedList.Demo
{
    class Program
    {
        static void Main()
        {
            var list = new RecursiveLinkedList<int>();
            foreach (var newElement in Enumerable.Range(0, 5))
            {
                list.AddHead(newElement);
            }
        }
    }
}
