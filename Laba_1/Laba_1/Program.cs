using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedListNode<T>
{
    public T Value { get; set; }
    public LinkedListNode<T> Next { get; set; }

    public LinkedListNode(T value)
    {
        Value = value;
        Next = null;
    }
}

public class MyLinkedList<T>
{
    private LinkedListNode<T> head;
    private LinkedListNode<T> tail;

    public void AddToHead(T value)
    {
        var newNode = new LinkedListNode<T>(value);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
        }
    }

    public T DelFromHead()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Список пуст");
        }

        var value = head.Value;
        head = head.Next;
        if (head == null)
        {
            tail = null;
        }
        return value;
    }

    public T Get_head_Value()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Список пуст");
        }
        return head.Value;
    }

    public MyLinkedList<T> GetTail()
    {
        var newList = new MyLinkedList<T>();
        if (head != null)
        {
            newList.head = head.Next;
            newList.tail = tail;
        }
        return newList;
    }
    public LinkedListNode<T> get_head()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Список пуст");
        }
        return head;
    }
}

class Program
{
    static void Main()
    { 
        var intList = new MyLinkedList<int>();
        intList.AddToHead(1);
        intList.AddToHead(2);
        intList.AddToHead(3);
        LinkedListNode<int> int_ptr = intList.get_head();
        while(int_ptr!= null)
        {
            Console.WriteLine(int_ptr.Value);
            int_ptr= int_ptr.Next;
        }
        var stringList = new MyLinkedList<string>();
        stringList.AddToHead("This is first string");
        stringList.AddToHead("This is second string");
        stringList.AddToHead("This is third string, but it could be first");
        LinkedListNode<string> string_ptr = stringList.get_head();
        while (string_ptr != null)
        {
            Console.WriteLine(string_ptr.Value);
            string_ptr = string_ptr.Next;
        }
        var figureList = new MyLinkedList<Figure>();
        figureList.AddToHead(new Circle(10));
        figureList.AddToHead(new Triangle(2, 4, 5));
        figureList.AddToHead(new Square(3));
        figureList.AddToHead(new Rectangle(7, 6));
        LinkedListNode<Figure> figure_ptr = figureList.get_head();
        while(figure_ptr != null)
        {
            Console.WriteLine($"Площадь: { figure_ptr.Value.Area()}, Периметр: { figure_ptr.Value.Perimeter()}");
            figure_ptr = figure_ptr.Next;
        }
    }
}