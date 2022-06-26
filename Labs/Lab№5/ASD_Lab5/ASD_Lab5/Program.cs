using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_Lab5
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<double> list = new List<double>();
            int N, M;
            Console.WriteLine("Input N and M:");
            N = M = Convert.ToInt32(Console.ReadLine());
            double[,] mat = new double[N, M];
            int asd = 1;
            Console.WriteLine("Оберіть контрольний приклад(1) чи рандом(2)");
            int inter = Convert.ToInt32(Console.ReadLine());
            if(inter == 1)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        mat[i, j] = asd;
                        asd++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        mat[i, j] = rnd.Next(100);  
                    }
                }
            }
            Console.WriteLine("Початкова матриця:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(mat[i, j] + "\t");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
            int num = 2;
            int num2 = 1;
            int k = N;
            int k2 = 2;
            while (num2 < ((M - 1) / 2))
            {
                while (num < k)
                {
                    list.Add(mat[N - num, M - num2]);
                    num++;
                    
                }
                k -= 2; ;
                num-=2;
                num2++;
                while (num > k2)
                {
                    list.Add(mat[N - num, M - num2]);
                    num--;

                }
                k2 += 2;
                num += 2;
                num2++;
            }
            if(N % 2 != 0)
            {
                if(list[list.Count-1] != mat[N / 2, (M / 2) + 1])
                {
                    list.Add(mat[N / 2, (M / 2) + 1]);
                }
            }
            double[] sort_temp = new double[Convert.ToInt32(list.Max())+1];
            for (int i = 0; i < sort_temp.Length; i++)
            {
                sort_temp[i]=0;
            }
            for (int i = 0; i < list.Count; i++)
            {
                sort_temp[Convert.ToInt32(list[i])]++;
            }
           
            List<double> sorted = new List<double>();
            int amount = (N * M - 2 * N) / 4;
            if(N % 2 != 0)
            {
                amount++;
            }
            for (int i = 0; i < sort_temp.Length; i++)
            {
                for (int j = 0; j < sort_temp[i]; j++)
                {
                    sorted.Add(i);
                    
                }
            }
            int l = 0;
            num = 2;
            num2 = 1;
            k = N;
            k2 = 2;
            while (num2 < ((M - 1) / 2))
            {
                while (num < k)
                {
                    mat[N - num, M - num2] = sorted[l];
                    num++;
                    l++;
                }
                k -= 2; ;
                num -= 2;
                num2++;
                while (num > k2)
                {
                    mat[N - num, M - num2] = sorted[l];
                    num--;
                    l++;
                }
                k2 += 2;
                num += 2;
                num2++;
            }
            Console.WriteLine("Відсортована матриця:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(mat[i, j] + "\t");
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }
}
