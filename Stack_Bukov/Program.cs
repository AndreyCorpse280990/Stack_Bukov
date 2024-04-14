global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
using System.Threading.Channels;

namespace Stack_Bukov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // создание обычного стека
            Stack stack = new Stack();
            Console.WriteLine($"Изначальный стек: {stack.ToString()}");
            
            // добавление элементов в стек
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine($"Стек, после добавления элементов: {stack.ToString()}");
            
            // Создание расширяемого стека
            ExpandableStack expandableStack = new ExpandableStack(20);
            Console.WriteLine($"Изначальное состояние расширяемого стека: {expandableStack.ToString()}");
            
            // Добавление элементов в расширяемый стек
            expandableStack.Push(4);
            expandableStack.Push(5);
            expandableStack.Push(6);
            Console.WriteLine($"Расширяемый стек, после добавления элементов: {expandableStack.ToString()}");
           
            // удаление элементов из расширяемого стека
            expandableStack.Pop(out bool ok);
            expandableStack.Pop(out ok);
            
            Console.WriteLine($"Расширяемый стек, после удаления элементов: {expandableStack.ToString()}");
            
            expandableStack.Shrink();
            Console.WriteLine($"Расширяемый стек, после изменения размера: {expandableStack.ToString()}");

            

        }
    }
}

