using System;
using static System.Console;

namespace ASD_lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = System.Text.Encoding.Default;
            WriteLine("Введіть перший елемент списку:");
            string X = ReadLine();
            DLNode list = new DLNode(X);
            list.Print();
            string func = "";
            string data = "";
            int pos;
            while (func != "0")
            {
                WriteLine("Введіть функцію(Додати в голову=1, Додати в кінець=2, Додати на позицію=3, Видалити голову=4,\n Видалити останній елемент=5, Видалити з позиції=6, Функція за умовою=7), для виходу=0:");
                func = ReadLine();
                if (func == "1")
                {
                    WriteLine("Введіть значення елементу який хочете додати:");
                    data = ReadLine();
                    list.AddFirst(data);
                }
                else if (func == "2")
                {
                    WriteLine("Введіть значення елементу який хочете додати:");
                    data = ReadLine();
                    list.AddLast(data);
                }
                else if (func == "3")
                {
                    WriteLine("Введіть значення елементу який хочете додати:");
                    data = ReadLine();
                    WriteLine("Введіть позицію на яку потрбіно додати елемент:");
                    pos = Convert.ToInt32(ReadLine());
                    list.AddToPosition(data, pos);
                }
                else if (func == "4")
                {
                    list.DeleteFirst();
                }
                else if (func == "5")
                {
                    list.DeleteLast();
                }
                else if (func == "6")
                {
                    WriteLine("Введіть позицію з якої потрбіно видалити елемент:");
                    pos = Convert.ToInt32(ReadLine());
                    list.DeleteFromPosition(pos);
                }
                else if (func == "7")
                {
                    WriteLine("Введіть значення елементу який хочете додати:");
                    data = ReadLine();
                    list.MyFunction(data);
                }
                else
                    WriteLine("Такої функції не існує, спробуйте іншу)");
                list.Print();
            }
            list.Print();
        }
    }
}
