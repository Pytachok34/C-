using System;
using System.IO;



class Program
{
    public static void FillArray(int[] array, int N)
    {
        Random random = new Random();

        // Создаем временный массив, заполняем его значениями от 0 до N
        int[] tempArray = new int[N + 1];
        for (int i = 0; i <= N; i++)
        {
            tempArray[i] = i;
        }

        // Заполняем основной массив случайными числами из временного массива без повторений
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = random.Next(0, N + 1 - i);
            array[i] = tempArray[randomIndex];
            tempArray[randomIndex] = tempArray[N - i];
        }
        int random_index1 = random.Next(0, N);
        int random_index2 = random.Next(0, N);
        while(random_index1==random_index2)
        {
            random_index2=random.Next(0, N);
        }
        array[random_index1] = array[random_index2];
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите размерность массива :");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];
        FillArray(arr, n);
        for(int i=0; i < arr.Length; ++i)
            Console.Write(arr[i]+" ");
        Console.WriteLine();
        HashSet<int> set = new HashSet<int>();
        int repeated = 0;
        int missing = -1;
        for(int i=0;i<arr.Length; ++i)
        {
            if(set.Contains(arr[i]))
                repeated=arr[i];
            set.Add(arr[i]);
        }
        int index = 0;
        while(missing==-1)
        {
            if(!set.Contains(index))
                missing=index;
            index++;
        }
        Console.WriteLine($"Пропавшее число = {missing}, Повторяющееся число = {repeated}");
    }
}
