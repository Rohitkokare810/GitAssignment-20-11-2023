using System;
using System.Diagnostics;

class QuickSortExample
{
    static void Main()
    {
        // Test the QuickSort algorithm
        int[] arrayToSort = { 12, 4, 5, 6, 7, 3, 1, 15, 2, 8 };

        Console.WriteLine("Original array:");
        PrintArray(arrayToSort);

        // Sorting using QuickSort
        QuickSort(arrayToSort, 0, arrayToSort.Length - 1);

        Console.WriteLine("\nArray after QuickSort:");
        PrintArray(arrayToSort);

        // Check if the array is sorted correctly
        Console.WriteLine("\nArray is sorted correctly: " + IsSorted(arrayToSort));

        // Performance analysis
        Console.WriteLine("\nPerformance Analysis:");
        MeasurePerformance();

        // Compare QuickSort with MergeSort
        Console.WriteLine("\nComparison with MergeSort:");
        CompareSortingAlgorithms();

        Console.ReadLine();
    }

    // QuickSort algorithm
    static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(array, low, high);

            QuickSort(array, low, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);
        return i + 1;
    }

    static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    // Method to check if the array is sorted correctly
    static bool IsSorted(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1])
                return false;
        }
        return true;
    }

    // Print array elements
    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    // Performance analysis
    static void MeasurePerformance()
    {
        int[] sizes = { 20, 30, 50, 100, 200 };
        Stopwatch stopwatch = new Stopwatch();

        foreach (int size in sizes)
        {
            int[] randomArray = GenerateRandomArray(size);

            stopwatch.Restart();
            QuickSort(randomArray, 0, randomArray.Length - 1);
            stopwatch.Stop();

            Console.WriteLine($"Array size: {size}, Time taken: {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    // Generate an array with random integers
    static int[] GenerateRandomArray(int size)
    {
        int[] randomArray = new int[size];
        Random random = new Random();

        for (int i = 0; i < size; i++)
        {
            randomArray[i] = random.Next(1000); // Generating random integers between 0 and 999
        }

        return randomArray;
    }

    // Comparison with MergeSort
    static void CompareSortingAlgorithms()
    {
        int[] arrayToSort = GenerateRandomArray(1000);
        Stopwatch stopwatch = new Stopwatch();

        // Measure time for QuickSort
        stopwatch.Restart();
        QuickSort(arrayToSort, 0, arrayToSort.Length - 1);
        stopwatch.Stop();
        Console.WriteLine($"QuickSort Time: {stopwatch.ElapsedMilliseconds} ms");

        // Measure time for MergeSort
        stopwatch.Restart();
        MergeSort(arrayToSort, 0, arrayToSort.Length - 1);
        stopwatch.Stop();
        Console.WriteLine($"MergeSort Time: {stopwatch.ElapsedMilliseconds} ms");
    }

    // MergeSort algorithm for comparison
    static void MergeSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int mid = (low + high) / 2;
            MergeSort(array, low, mid);
            MergeSort(array, mid + 1, high);
            Merge(array, low, mid, high);
        }
    }

    static void Merge(int[] array, int low, int mid, int high)
    {
        int n1 = mid - low + 1;
        int n2 = high - mid;

        int[] left = new int[n1];
        int[] right = new int[n2];

        Array.Copy(array, low, left, 0, n1);
        Array.Copy(array, mid + 1, right, 0, n2);

        int i = 0, j = 0, k = low;

        while (i < n1 && j < n2)
        {
            if (left[i] <= right[j])
            {
                array[k] = left[i];
                i++;
            }
            else
            {
                array[k] = right[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            array[k] = left[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            array[k] = right[j];
            j++;
            k++;
        }
    }
}
