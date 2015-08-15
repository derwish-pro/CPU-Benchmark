using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleSelectionSort
{
    internal class Program
    {
        private static int[] mass = new int[10000];

        private static void Main(string[] args)
        {
            RandomizeArray(mass);

            DateTime dateTimeStart = DateTime.Now;
            //Array.Sort(mass);
            //SelectionSort(mass);
            selectsort(mass);
            DateTime dateTimeFinish = DateTime.Now;

            //PrintArray(mass);
            Console.WriteLine(new string('-',50));
            Console.WriteLine((dateTimeFinish - dateTimeStart).Seconds);
            Console.WriteLine((dateTimeFinish - dateTimeStart).Milliseconds);
            Console.ReadLine();
        }

        private static void RandomizeArray(int[] array)
        {
            int lengt = array.Length;
            Random random = new Random();
            for (int i = 0; i < lengt; i++)
            {
                array[i] = random.Next(0, 100);
            }
        }

        static void PrintArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }

        }

        static int FindMinIndex(int[] array, int start)
        {
            int min = array[start];
            int index = start;
            for (int i = start; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    index = i;
                }
            }
            return index;
        }

        static void SwapPosition(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int inexMin = FindMinIndex(array, i);
                SwapPosition(array, i, inexMin);
            }

        }
        static void selectsort(int[] dataset)
        {
            int n = dataset.Length;
            int i, j;
            for (i = 0; i < n; i++)
            {
                int min = i;
                for (j = i + 1; j < n; j++)
                    if (dataset[j] < dataset[min]) min = j; //find min value
                //then swap it with the beginning item of the unsorted list
                int temp = dataset[i];
                dataset[i] = dataset[min];
                dataset[min] = temp;
            }

        }




    }

}
