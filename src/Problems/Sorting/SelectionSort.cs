namespace Problems.Sorting
{
    public class SelectionSortingSolution
    {
        public static void Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = int.MaxValue;
                int minIndex = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        minIndex = j;
                    }
                }
                var temp = arr[i];
                arr[i] = min;
                arr[minIndex] = temp;
            }
        }
    }
}