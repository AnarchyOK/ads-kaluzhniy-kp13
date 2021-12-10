﻿using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace TaskASD
{
    class Program
    {
        static void PrintMatrix(int[,] Matrix, List<List<int>> Indexes)
        {
            int M = Matrix.GetLength(0);
            int N = Matrix.GetLength(1);

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                    if (Indexes[i].Contains(j))
                    {
                        ForegroundColor = ConsoleColor.DarkGreen;
                        Write("{0,3}", Matrix[i, j]);
                        ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Write("{0,3}", Matrix[i, j]);
                WriteLine();
            }
        }

        static int[,] GenerateMatrix(int M, int N)
        {
            Random rnd = new Random();
            int[,] Matrix = new int[M, N];

            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    Matrix[i, j] = rnd.Next(20);

            return Matrix;
        }


        static List<List<int>> CheckElems(int[,] Matrix, int K, int L)
        {
            int M = Matrix.GetLength(0);
            int N = Matrix.GetLength(1);
            List<List<int>> Indexes = new List<List<int>>();

            for (int i = 0; i < M; i++)
            {
                Indexes.Add(new List<int>());
                for (int j = 0; j < N; j++)
                    if (Matrix[i, j] / K < L)
                        Indexes[i].Add(j);
            }
            DivElemOfMatrix(Matrix, K);

            return Indexes;
        }


        static void DivElemOfMatrix(int[,] Matrix, int K)
        {
            int M = Matrix.GetLength(0);
            int N = Matrix.GetLength(1);
            List<List<int>> Indexes = new List<List<int>>();
            WriteLine("------------ Diviation Elems Of Matrix by Number K ----------");
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                    Write("{0,3}", Matrix[i, j] / K);
                WriteLine();
            }
        }

        static void PrintCheckIndexes(List<List<int>> Indexes)
        {
            int M = Indexes.Count;
            WriteLine("-.-.-.-.-.-.-.- Indexes of soting elems -.-.-.-.-.-.-.-.-.-");
            for (int i = 0; i < M; i++)
            {
                int N = Indexes[i].Count;
                for (int j = 0; j < N; j++)
                    Write(Indexes[i][j] + " ");
                WriteLine();
            }

        }

        static int[,] SortingCheckElems(int[,] Matrix, List<List<int>> Indexes)
        {
            for (int t = 0; t < Indexes.Capacity; t++)
                for (int i = 0; i < Indexes.Count; i++)
                {
                    for (int j = Indexes[i].Count - 1; j >= 0; j--) 
                    {
                        int Index = Indexes[i][j];
                        if (j - 1 < 0) 
                        {
                            if (i + 1 > Indexes.Count - 1)
                                break;
                            i = i + 1;
                            j = Indexes[i].Count - 1;
                        }
                        int IndexPrev = Indexes[i][j - 1];
                        if (Matrix[i, Index] < Matrix[i, IndexPrev])
                        {
                            int temp = Matrix[i, Index];
                            Matrix[i, Index] = Matrix[i, IndexPrev];
                            Matrix[i, IndexPrev] = temp;
                        }
                    }
                }

            return Matrix;
        }



        static void Main(string[] args)
        {
            Random rnd = new Random();
            int M, N;
            int K, L;
            int[,] Matrix;
            List<List<int>> Indexes;
            /*
            Write("M = "); M = Convert.ToInt32(ReadLine());
            Write("N = "); N = Convert.ToInt32(ReadLine());
            Write("K = "); K = Convert.ToInt32(ReadLine());
            Write("L = "); L = Convert.ToInt32(ReadLine());*/

            for (int test = 1; test < 10; test++)
            {
                WriteLine("########################## TEST # " + test + " #############################");
                M = rnd.Next(5, 30); N = rnd.Next(5, 30);
                K = rnd.Next(2, 5); L = rnd.Next(2, 5);

                Write("M = " + M); Write("N = " + N); Write("K = " + K); WriteLine("L = " + L);

                Matrix = GenerateMatrix(M, N);
                Indexes = CheckElems(Matrix, K, L);
                PrintCheckIndexes(Indexes);
                WriteLine("***************** Matrix: *****************");
                PrintMatrix(Matrix, Indexes); WriteLine();
                WriteLine("***************** Sorted Elems in Matrix: *****************");
                Matrix = SortingCheckElems(Matrix, Indexes);
                PrintMatrix(Matrix, Indexes); WriteLine();
                Thread.Sleep(1000);
            }
        }
    }
}