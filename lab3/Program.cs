using System;

namespace lab3
{
    internal static class Program
    {
        private static void Main()
        {
            var arr = new DynamicArray<string>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Array: \n{arr}\n" +
                                  "[A] Add\n" +
                                  "[S] Set\n" +
                                  "[D] Delete at\n" +
                                  "[C] Clear\n" +
                                  "[Esc] Exit");

                try
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.A:
                        {
                            Console.Write("New item: ");
                            arr.Add(Console.ReadLine());
                            break;
                        }
                        case ConsoleKey.S:
                        {
                            Console.Write("Item at: ");
                            var index = Convert.ToUInt32(Console.ReadLine());
                            Console.Write($"Item at {index} = ");
                            arr[index] = Console.ReadLine();
                            break;
                        }
                        case ConsoleKey.R:
                        {
                            Console.Write("Delete item at: ");
                            var index = Convert.ToUInt32(Console.ReadLine());
                            arr.RemoveAt(index);
                            break;
                        }
                        case ConsoleKey.C:
                        {
                            Console.WriteLine("Press 'C' again to confirm");
                            if (Console.ReadKey(true).Key == ConsoleKey.C)
                            {
                                arr.Clear();
                            }
                            break;
                        }
                        case ConsoleKey.Escape:
                        {
                            return;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey(true);
                }
            }
        }
    }
}
