//static import
using static MatrixArrayApp.UserInterfaceUtility;
//using ls = MatrixArrayApp;
namespace MatrixArrayApp
{
    internal class Program
    {
        static void Main()
        {
            int count = GetCount();
            int[,] matrixArray = new int[count, count];
            SaveValuesInArray(matrixArray);
            int[] numbers = CopyToSingleDimensionalArray(matrixArray);
            int[] result = ArrangeElements(numbers); 
            PrintValues(result);
        }       
    }
}
