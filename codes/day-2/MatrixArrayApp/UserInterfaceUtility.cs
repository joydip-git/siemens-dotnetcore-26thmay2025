namespace MatrixArrayApp
{
    static class UserInterfaceUtility
    {
        public static void PrintValues(int[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"value from result[{i}]: {result[i]}");
            }
        }

        public static int GetCount()
        {
            Console.Write("enter size of the matrix array: ");
            return int.Parse(Console.ReadLine() ?? "3");
        }

        public static void SaveValuesInArray(int[,] matrixArray)
        {
            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    Console.Write($"enter value at array[{i},{j}]: ");
                    matrixArray[i, j] = int.Parse(Console.ReadLine() ?? "0");
                }
            }
        }

        public static int[] CopyToSingleDimensionalArray(int[,] matrixArray)
        {
            int[] numbers = new int[matrixArray.Length];
            int index = 0;
            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    numbers[index] = matrixArray[i, j];
                    index++;
                }
            }
            return numbers;
        }

        public static int[] ArrangeElements(int[] array)
        {
            int[] final = new int[array.Length];
            Array.Sort(array);
            int midIndex = array.Length / 2;
            int leftIndex = midIndex - 1;
            int rightIndex = midIndex + 1;
            final[midIndex] = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (i % 2 != 0)
                {
                    final[leftIndex] = array[i];
                    leftIndex--;
                }
                else
                {
                    final[rightIndex] = array[i];
                    rightIndex++;
                }
            }
            return final;
        }
    }
}
