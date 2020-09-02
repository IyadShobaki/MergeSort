using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Not in-place algorithm (Its create temporary arrays)
            // O(nlogn) - base 2.
            // Stable algorithm
            int[] intArray = { 20, 35, -15, 7, 55, 1, -22 };

            //MergeSort(intArray, 0, intArray.Length);

            

            Console.WriteLine(string.Join(" ", intArray));
            Console.ReadLine();
        }

        // A recursion function
        // { 20, 35, -15, 7, 55, 1, -22 }
        public static void MergeSort(int[] input, int start, int end)
        {
            if (end - start < 2) // It means that one element left 
            {
                return;
            }

            // Partition phase 
            int mid = (start + end) / 2;
            //  the left side
            // { 20, 35, -15}
            // {20} {35, -15}
            // {20} {35} {-15}
            MergeSort(input, start, mid);
            // the right side
            // {7, 55, 1, -22 }
            // {7, 55} {1, -22}
            // {7} {55} {1} {-15}
            MergeSort(input, mid, end);
            Merge(input, start, mid, end);
        }


        // { 20, 35, -15, 7, 55, 1, -22 }
        public static void Merge(int[] input, int start, int mid, int end)
        {
            if (input[mid - 1] <= input[mid]) 
            {
                return;
            }

            int i = start;
            int j = mid;
            int tempIndex = 0;

            int[] temp = new int[end - start];
            while (i < mid && j < end)
            {
                temp[tempIndex++] = input[i] <= input[j] ? input[i++] : input[j++];
            }

            Array.Copy(input, i, input, start + tempIndex, mid - i);
            Array.Copy(temp, 0, input, start, tempIndex);

        }
    }
}
