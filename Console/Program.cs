using System;
using DoubleLinkedLists;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //DoubleLinkedList aa = new DoubleLinkedList(1);
            //aa.WriteToConsole();
            //aa.Add(2);
            //aa.WriteToConsole();
            //aa.AddFirst(0);
            //aa.WriteToConsole();
           
           
            //aa.RemoveLast();
            //aa.WriteToConsole();
            //aa.RemoveFirst();
            //aa.WriteToConsole();
            //aa.Add(3);
            //aa.Add(4);
            //aa.Add(5);
            //aa.Add(6);
            //aa.Add(7);
            //aa.Add(8);
            //aa.Add(9);
            //aa.WriteToConsole();
            //aa.RemoveTheLastFew(3);
            //aa.WriteToConsole();
            //aa.RemoveFirstFew(2);
            //aa.WriteToConsole();
            //aa.RemoveOneByIndex(1);
            //aa.WriteToConsole();
            //aa.Add(3);
            //aa.Add(4);
            //aa.Add(5);
            //aa.Add(6);
            //aa.Add(7);
            //aa.Add(8);
            //aa.Add(9);
            //aa.WriteToConsole();
            //aa.RemoveSeveralByIndex(3, 3);
            //aa.WriteToConsole();
            // int a = aa.Lenght;
            //aa.Add(a);
            //aa.WriteToConsole();
            int[] arr = new int[] { 1, 1, 1, 1 };
            int[] arr2 = new int[] { 1, 1, 1, 1 };

            DoubleLinkedList arra = new DoubleLinkedList(arr);
            DoubleLinkedList arra2 = new DoubleLinkedList(arr2);

            arra.WriteToConsole();
            arra.AddDoubleLinkedListToBeginning(arra2);
            arra.WriteToConsole();





        }
    }
}
