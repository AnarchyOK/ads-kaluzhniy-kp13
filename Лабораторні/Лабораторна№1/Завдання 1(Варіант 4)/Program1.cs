﻿using System;
using static System.Console;
using static System.Math;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            //блок оголошення змінних
            double x, y, z;
            double a, b;
            double zn_a, ch_a, ch_b;
            //Блок ведення даних
            Write("Input x=");
            x = Convert.ToDouble(ReadLine());
            Write("Input y=");
            y = Convert.ToDouble(ReadLine());
            Write("Input z=");
            z = Convert.ToDouble(ReadLine());
            //блок математичних обрахувань
            ch_a = Sign(Abs(y) + Pow(z, 3)) * Pow(Abs(Abs(y) + Pow(z, 3)), 1.0 / 3.0);
            zn_a = Pow(x, 3) + x;
            a = x + ch_a / zn_a;
            ch_b = Sqrt(x - y);
            b = ch_b / z + 1.0 / Pow(a, 2);
            //блок обробки виключень
            if (a == 0 || z == 0 || x - y < 0)
            {
                WriteLine($"Output a={a}\nCannot calculate b");
            }
            else if (x == 0)
            {
                WriteLine("Cannot calculate a and b");
            }
            else
            {
                WriteLine($"Output a={a}\nOutput b={b}");
            }
        }
        catch
        {
            WriteLine("Input error");
        }
        ReadKey();
    }
}