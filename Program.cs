namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment 1");
            int[] numbers = { 1, 2, 3, 4, 5 };
            ArrayUtils.ReverseArray(numbers);
            Console.WriteLine("Reversed Array: " + string.Join(", ", numbers)); 

            double[] decimals = { 9.5, 5.6, 8.12, 9.41, 2.2 };
            double maxDecimal = ArrayUtils.FindMax(decimals);
            Console.WriteLine("Max Element: " + maxDecimal);


            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Assignment 2");
            Cache<int, string> cache = new Cache<int, string>(3);

            cache.Add(1, "Item1");
            cache.Add(2, "Item2");
            cache.Add(3, "Item3");

            Console.WriteLine(cache.Retrieve(1));  

            cache.Add(4, "Item4"); 

            try
            {
                Console.WriteLine(cache.Retrieve(2)); 
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            cache.Add(5, "Item5");
            Console.WriteLine(cache.Retrieve(1));  
            Console.WriteLine(cache.Retrieve(4));  


        }
    }
}
