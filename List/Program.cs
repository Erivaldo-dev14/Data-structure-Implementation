class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[6];
        arr[0] = 2;
        arr[1] = 3;
        arr[2] = 4;
        arr[3] = 6;
        arr[4] = 7;
        arr[5] = 9;

        int size = InsertAt(ref arr, 5, 0, 5);
       

        for (int i = 0; i< size; i++)
        {
            Console.WriteLine(arr[i]);
        }
        Console.WriteLine(size);
         
    }

    //ARRAY SECTION
    static int InsertAt(ref int[] array, int size, int index, int value)
    {
        if (index > size || index < 0)
        {
            throw new ArgumentException("Index out of the bounds of the array...");
            
        }
        if (array.Length == size)
        {
            int[] arr = new int[array.Length * 2];
            array.CopyTo(arr, 0);

            array = arr;
             
        }
 
            for (int i = size -1  ; i >=  index; i--)
            {
                array[i + 1] = array[i];
            }

            array[index] = value;
            size++;
            
            return size;

      
         

        
    }

    //LINKEDLISTSECTION
}