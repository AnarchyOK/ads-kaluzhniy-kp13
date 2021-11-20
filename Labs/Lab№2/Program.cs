using System;
using static System.Console;
using System.Text;

namespace ASD_Lab2
{
    class Program
    {
        static int[,] GenMat(int N)
        {
            WriteLine("Напишить С-для контрольного прикладу або Р-для псевдорандомної матриці");
            string S = ReadLine();
            int a = 0;
            Random rnd = new Random();
            int[,] mat = new int[N, N];
            WriteLine("Матриця:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (S == "P")
                    {
                        mat[i, j] = rnd.Next(1, 100);
                    }
                    else if (S == "C")
                    {
                        mat[i, j] = a;
                        a++;
                    }
                    Write(mat[i, j] + "\t");
                }
                WriteLine();
            }
            return mat;
        }
        static int Function1(int[,] mat,int N)
        {
            int n = N;
            int n2 = N;
            int i, j, c, stop, min;
            min = int.MaxValue;
            c = 1;
            j = i = stop = 0;
            WriteLine("Послідовність обходу спіраллю над головною діагоналлю: ");
            while (stop < ((N * N) - N) / 2)
            {
                while (j < n - 1)
                {
                    j++;
                    Write(mat[i, j] + " | ");
                    if (mat[i, j] < min)
                        min = mat[i, j];
                    stop++;
                }
                while (i < n2 - 2)
                {
                    i++;
                    Write(mat[i, j] + " | ");
                    if (mat[i, j] < min)
                        min = mat[i, j];
                    stop++;
                }
                while (i > c)
                {
                    i--;
                    j--;
                    Write(mat[i, j] + " | ");
                    if (mat[i, j] < min)
                        min = mat[i, j];
                    stop++;
                }
                c++;
                n--;
                n2 -= 2;
            }
            return min;
        }
        static string Function2(int[,] mat, int N)
        {
            string S = "";
            int n = N;
            int i, j, c, c2, sum, stop;
            c = c2 = 1;
            j = i = stop = sum = 0;
            WriteLine("Послідовність обходу спіраллю головною діагоналлю та під нею: ");
            while (i < N) 
            {
                sum += mat[i, j];
                Write(mat[i, j] + " | ");
                i++;
                j++;
            }
            i--;
            j--;
            while (stop < ((N * N) - N) / 2)
            {
                while (j >= c)
                {
                    j--;
                    Write(mat[i, j] + " | ");
                    if (mat[i, j] > sum / 2.0)
                    {
                        S = S + mat[i, j] + $"[{i},{j}]; ";
                    }
                    stop++;
                }
                while (i > c2)
                {
                    i--;
                    Write(mat[i, j] + " | ");
                    if (mat[i, j] > sum / 2.0)
                    {
                        S = S + mat[i, j] + $"[{i},{j}]; ";
                    }
                    stop++;
                }
                while (i < n - 2) 
                {
                    i++;
                    j++;
                    Write(mat[i, j] + " | ");
                    if (mat[i, j] > sum / 2.0)
                    {
                        S = S + mat[i, j] + $"[{i},{j}]; ";
                    }
                    stop++;
                }
                c++;
                c2 +=2;
                n--;
            }
            return S;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Default;
            try
            {
                WriteLine("Введіть N:");
                int N = Convert.ToInt32(ReadLine());
                int[,] Mat = GenMat(N);
                int min = Function1(Mat, N);
                WriteLine($"\nМінімальний елемент над головною діагоналлю = {min}");
                string S = Function2(Mat, N);
                if (S == "")
                    WriteLine("\nЕлементів більших за півсуму головної діагоналі немає");
                else
                    WriteLine("\nЕлементи більші за півсуму головної діагоналі:" + S);
            }
            catch
            {
                WriteLine("Некоректно введені дані!!!");
            }
            ReadKey();
        }
    }
}

