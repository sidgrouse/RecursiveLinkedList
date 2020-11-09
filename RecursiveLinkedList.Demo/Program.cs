using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursiveLinkedList.Demo
{
    class Program
    {
        static void Main()
        {
            DemonstrateExtensionMetod();
            Console.WriteLine("=============");

            DemonstrateIntList();
            Console.WriteLine("=============");

            DemonstrateRemoveHeadWithStringList();
            Console.WriteLine("=============");

            DemonstrateExceptions();
            Console.WriteLine("=============");
            Console.WriteLine("done. press any key");
            Console.ReadKey();
        }

        private static void DemonstrateRemoveHeadWithStringList()
        {
            var miniList = new RecursiveLinkedList<string>();
            miniList.AddHead("three");
            miniList.AddHead("two");
            miniList.AddHead("one");
            miniList.AddHead("head");

            ShowList(miniList, "string list members");

            miniList.RemoveHead();
            ShowList(miniList, "headless string list");
        }

        private static void DemonstrateIntList()
        {
            var list = new RecursiveLinkedList<int>();
            ShowList(list, "the list is empty");

            foreach (var newElement in Enumerable.Range(0, 5))
            {
                list.AddHead(newElement);
            }

            ShowList(list, "int list members");
        }

        private static void DemonstrateExtensionMetod()
        {
            var list = new RecursiveLinkedList<int>();

            list = list.AddElementToPresortedList(1)
                .AddElementToPresortedList(7)
                .AddElementToPresortedList(3)
                .AddElementToPresortedList(5);
            var newList = list.AddElementToPresortedList(0);

            ShowList(list, "list without zero");
            ShowList(newList, "list with zero");
        }

        private static void ShowList<T>(RecursiveLinkedList<T> list, string comment)
        {
            Console.WriteLine($"{comment}:");
            foreach (var element in list)
            {
                Console.WriteLine($" -{element}");
            }
            Console.WriteLine();
        }

        private static void DemonstrateExceptions()
        {
            Console.WriteLine("--Consider the similarity between the two implimentations behaviour:");
            Console.WriteLine("-LINQ Sort:");
            try 
            {
                var libList = new List<ExampleClass> { new ExampleClass { Foo = 6 }, new ExampleClass { Foo = 4 } };
                libList.Sort(); 
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }

            Console.WriteLine("-Custom sort inside AddElementToPresortedList():");
            try 
            {
                var customList = new RecursiveLinkedList<ExampleClass>();
                customList.AddElementToPresortedList(new ExampleClass { Foo = 4 })
                    .AddElementToPresortedList(new ExampleClass { Foo = 5 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private class ExampleClass
        {
            public int Foo { get; set; }
            public override string ToString()
            {
                return Foo.ToString();
            }
        }
    }
}
