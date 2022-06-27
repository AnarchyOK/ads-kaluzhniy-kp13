using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace ASD_Lab6
{
    public class MyStack<T>
    {
        private T[] items; // масив з елементами стеку
        private int count;  // кількість елементів
        const int n = 100;   // кількість по замовчуванню
        public MyStack()
        {
            items = new T[n];
        }
        public MyStack(int length)
        {
            items = new T[length];
        }
        public bool IsEmpty
        {
            get { return count == 0; }
        }
        public int Count
        {
            get { return count; }
        }
        public void Push(T item)
        {
            if (count == items.Length)
                throw new InvalidOperationException("Переповнення стека");
            items[count++] = item;
        }
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пустий");
            T item = items[--count];
            items[count] = default(T);
            return item;
        }
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пустий");
            return items[count - 1];
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string temp = "";
            WriteLine("Введіть приклад:");
            temp = ReadLine();
            string notation = infixToPostfix(temp);
            MyStack<double> st2 = new MyStack<double>();
            for (int i = 0; i < notation.Length; i++)
            {
                if (notation[i] == '+')
                {
                    double t1 = st2.Pop();
                    checkStack(st2);
                    double t2 = st2.Pop();
                    checkStack(st2);
                    st2.Push(t2 + t1);
                    checkStack(st2);
                }
                else if (notation[i] == '-')
                {
                    double t1 = st2.Pop();
                    checkStack(st2);
                    double t2 = st2.Pop();
                    checkStack(st2);
                    st2.Push(t2 - t1);
                    checkStack(st2);
                }
                else if (notation[i] == '*')
                {
                    double t1 = st2.Pop();
                    checkStack(st2);
                    double t2 = st2.Pop();
                    checkStack(st2);
                    st2.Push(t2 * t1);
                    checkStack(st2);
                }
                else if (notation[i] == '/')
                {
                    double t1 = st2.Pop();
                    checkStack(st2);
                    double t2 = st2.Pop();
                    checkStack(st2);
                    st2.Push(t2 / t1);
                    checkStack(st2);
                }
                else
                {
                    st2.Push(Convert.ToDouble(notation[i].ToString()));
                    checkStack(st2);
                }
            }
            WriteLine("^^^^^^Результат на рядок вище^^^^^^");
            ReadKey();
        }
        static void checkStack(MyStack<double> stack)
        {
            MyStack<double> stack2 = new MyStack<double>();

            while (stack.Count > 0)
            {
                double temp = stack.Pop();
                stack2.Push(temp);
                Write(temp+"  ");
            }
            WriteLine();
            while (stack2.Count > 0)
            {
                double temp = stack2.Pop();
                stack.Push(temp);
            }
        }
        internal static int Prec(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
        }

        public static string infixToPostfix(string exp)
        {

            string result = "";


            MyStack<char> stack = new MyStack<char>();

            for (int i = 0; i < exp.Length; ++i)
            {
                char c = exp[i];


                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        result += stack.Pop();
                    }
                    if (stack.Count > 0 && stack.Peek() != '(')
                    {
                        return "Invalid Expression"; 
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else 
                {
                    while (stack.Count > 0 && Prec(c) <=
                                      Prec(stack.Peek()))
                    {
                        result += stack.Pop();
                    }
                    stack.Push(c);
                }

            }

            
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }


    }
}
