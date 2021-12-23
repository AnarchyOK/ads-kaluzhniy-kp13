using System;
using static System.Console;

namespace ASD_lab4
{
    class DLNode
    {
        public Node head;
        public class Node
        {
            public string data;
            public Node next;
            public Node previous;
            public Node(string data)
            {
                this.data = data;
            }
            public Node(string data, Node next, Node previous)
            {
                this.data = data;
                this.next = next;
                this.previous = previous;
            }
        }
        public DLNode(string data)
        {
            head = new Node(data);
        }
        public void AddFirst(string data)
        {
            Node current = head;
            current.previous = new Node(data)
            {
                next = head
            };
            head = current.previous;
        }
        public void AddToPosition(string data, int position)
        {
            Node current = head;
            for (int i = 0; i < position - 2; i++)
            {
                try
                {
                    current = current.next;
                }
                catch
                {
                    break;
                }
            }
            if (current == null || current.next == null || position < 2)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Insert error (wrong position)");
                ResetColor();
            }
            else
            {
                Node temp = new Node(data)
                {
                    previous = current,
                    next = current.next
                };
                current.next.previous = temp;
                current.next = temp;
            }
        }
        public void AddLast(string data)
        {
            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = new Node(data)
            {
                previous = current
            };
        }
        public void DeleteFirst()
        {
            if (head.next == null)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Deleting error!");
                ResetColor();
            }
            else
            {
                head = head.next;
                head.previous = null;
            }
        }
        public void DeleteFromPosition(int position)
        {
            Node current = head;
            for (int i = 0; i < position - 1; i++)
            {
                current = current.next;
            }
            if (current == null || position < 1)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Delete error (wrong position)");
                ResetColor();
            }
            else if (current.next == null)
                current.previous.next = null;
            else if (current.previous == null)
            {
                head = current.next;
                head.previous = null;
            }
            else
            {
                current.previous.next = current.next;
                current.next.previous = current.previous;
            }

        }
        public void DeleteLast()
        {
            if (head.next == null)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Deleting error!");
                ResetColor();
            }
            else
            {
                Node current = head;
                while (current.next.next != null)
                {
                    current = current.next;
                }
                current.next = null;
            }
        }
        public void Print()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("<= Список =>");
            Node current = head;
            while (current != null)
            {
                WriteLine(current.data);
                current = current.next;
            }
            WriteLine("<= Кінець =>");
            ResetColor();
        }
        public void MyFunction(string data)
        {
            int d = Convert.ToInt32(data);
            if (d % 2 == 0)
            {
                AddFirst(data);
            }
            else
            {
                AddLast(data);
            }
        }
    }
}
