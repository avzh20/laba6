using System;
using System.IO;

class Program
{
    static void Main()
    {
        using (StreamReader sr = new StreamReader("Inlet.in"))
        {
            string line = sr.ReadLine();
            string[] values = line.Split(' ');

            int N = int.Parse(values[0]);
            int M = int.Parse(values[1]);
            int CЗ = int.Parse(values[2]);
            int CВ = int.Parse(values[3]);
            int ЮЗ = int.Parse(values[4]);
            int ЮВ = int.Parse(values[5]);

            int[,] A = new int[N, M];
            A[0, 0] = CЗ;
            A[0, M - 1] = CВ;
            A[N - 1, 0] = ЮЗ;
            A[N - 1, M - 1] = ЮВ;

            for (int i = 1; i < (((M - 1) - ((M - 1) % 2)) / 2) + 1; i++)
            {
                A[0, i] = A[0, 0];
            }

            for (int i = (((M - 1) - ((M - 1) % 2)) / 2) + 1; i < M - 1; i++)
            {
                A[0, i] = A[0, M - 1];
            }

            for (int j = 1; j < (((N - 1) - ((N - 1) % 2)) / 2) + 1; j++)
            {
                for (int i = 0; i < (((M - 1) - ((M - 1) % 2)) / 2) + 1; i++)
                {
                    A[j, i] = A[0, 0];
                }
            }

            for (int j = 1; j < (((N - 1) - ((N - 1) % 2)) / 2) + 1; j++)
            {
                for (int i = (((M - 1) - ((M - 1) % 2)) / 2) + 1; i < M; i++)
                {
                    A[j, i] = A[0, M - 1];
                }
            }

            for (int i = 1; i < (((M - 1) - ((M - 1) % 2)) / 2) + 1; i++)
            {
                A[N - 1, i] = A[N - 1, 0];
            }

            for (int i = (((M - 1) - ((M - 1) % 2)) / 2) + 1; i < M - 1; i++)
            {
                A[N - 1, i] = A[N - 1, M - 1];
            }

            for (int j = (((N - 1) - ((N - 1) % 2)) / 2) + 1; j < N - 1; j++)
            {
                for (int i = 0; i < (((M - 1) - ((M - 1) % 2)) / 2) + 1; i++)
                {
                    A[j, i] = A[N - 1, 0];
                }
            }

            for (int j = (((N - 1) - ((N - 1) % 2)) / 2) + 1; j < N - 1; j++)
            {
                for (int i = (((M - 1) - ((M - 1) % 2)) / 2) + 1; i < M; i++)
                {
                    A[j, i] = A[N - 1, M - 1];
                }
            }

            if (((N - 1) / 2) * 2 == N - 1)
            {
                for (int i = 0; i < (((M - 1) - ((M - 1) % 2)) / 2) + 1; i++)
                {
                    A[N / 2, i] = A[0, 0] + A[N - 1, 0];
                }
                for (int i = (((M - 1) - ((M - 1) % 2)) / 2) + 1; i < M; i++)
                {
                    A[N / 2, i] = A[0, M - 1] + A[N - 1, M - 1];
                }
            }

            if (((M - 1) / 2) * 2 == M - 1)
            {
                for (int i = 0; i < (((N - 1) - ((N - 1) % 2)) / 2) + 1; i++)
                {
                    A[i, M / 2] = A[0, 0] + A[0, M - 1];
                }
                for (int i = (((N - 1) - ((N - 1) % 2)) / 2) + 1; i < N; i++)
                {
                    A[i, M / 2] = A[N - 1, 0] + A[N - 1, M - 1];
                }
            }

            if (((M - 1) / 2) * 2 == M - 1 && ((N - 1) / 2) * 2 == N - 1)
            {
                A[N / 2, M / 2] = A[0, 0] + A[0, M - 1] + A[N - 1, 0] + A[N - 1, M - 1];
            }

                using (StreamWriter sw = new StreamWriter("Outlet.out"))
                {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        sw.Write(A[i, j] + " ");
                    }
                    sw.WriteLine();
                }
                Console.WriteLine("Результаты были записаны в файл Outlet.out.");
            }
        }
    }
}
