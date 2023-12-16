using System;

public class ArrayUltilits
{
    public ArrayUltilits() { }

    public static T[] RandomArrayOrder<T>(T[] array)
    {
        Random random = new();
        T[] tempArray = array;

        int n = array.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(0, 1 + i);

            T temp = tempArray[i];
            tempArray[i] = tempArray[j];
            tempArray[j] = temp;
        }
        return tempArray;
    }
}