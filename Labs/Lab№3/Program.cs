using System;
using System.Collections.Generic;
using static System.Console;

namespace ASD_lab_3
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                int N = Int32.Parse(ReadLine());
                int M = Int32.Parse(ReadLine());
                int K = Int32.Parse(ReadLine());
                int L = Int32.Parse(ReadLine());
                int[,] mat = new int[N, M];
                int[] arr = new int[mat.Length];
                List<int> I = new List<int>();
                List<int> J = new List<int>();
                mat = GenMat(N, M);
                WriteLine("Matrix:");
                PrintMat(mat, K, L);
                I = Index_I(mat, K, L);
                J = Index_J(mat, K, L);
                mat = SortMat(mat, I, J);
                WriteLine("Sorted Matrix:");
                PrintMat(mat, K, L);
            }
            catch
            {
                WriteLine("Wrong input");
            }
            ReadKey();
        }
        static int[,] GenMat(int N, int M) //Генерація матриці
        {
            int[,] mat = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    mat[i, j] = rnd.Next(-100, 101);
                }
            }
            return mat;
        }
        static int[,] PrintMat(int[,] mat, int K, int L) //Вивід матриці
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(0); j++)
                {
                    if (Math.Abs(mat[i, j]) / K < L)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Write($"{mat[i, j]}\t");
                }
                WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            return mat;
        }
        static List<int> Index_I(int[,] mat, int K, int L) //Запис індексу елементу який підходить під умову
        {
            List<int> I = new List<int>();
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (Math.Abs(mat[i, j]) / K < L)
                    {
                        I.Add(i);
                    }
                }
            }
            return I;
        }
        static List<int> Index_J(int[,] mat, int K, int L) //Запис індексу елементу який підходить під умову
        {
            List<int> J = new List<int>();
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (Math.Abs(mat[i, j]) / K < L)
                    {
                        J.Add(j);
                    }
                }
            }
            return J;
        }
        static int[,] SortMat(int[,] mat, List<int> I, List<int> J) //Сортування матриці
        {
            int temp;
            int gap = I.Count;
            while (gap != 1)
            {
                gap = (int)(gap / 1.3);
                if (gap < 1)
                    gap = 1;
                for (int i = 0; i < I.Count - gap; i++) //Обхід матриці здійснюється наскрізно за рядками згори вниз зліва направо(зробити зправа наліво в мене не вийшло)
                {
                    if (mat[I[i], J[i]] < mat[I[i + gap], J[i + gap]])
                    {
                        temp = mat[I[i], J[i]];
                        mat[I[i], J[i]] = mat[I[i + gap], J[i + gap]];
                        mat[I[i + gap], J[i + gap]] = temp;
                    }
                }
            }
            return mat;
        }
    }
}
