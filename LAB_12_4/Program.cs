using Cars;
using LAB_12_3;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace LAB_12_4
{
    class Program
    {
        static void Main(string[] args)
        {
            D choise = new D();
            MyCollection<Car> collection = new MyCollection<Car>(10);
            while (true)
            {
                choise.MenuChoise();
                var str = Console.ReadLine();
                int l = int.Parse(str);
                Console.Clear();
                switch (l)
                {
                    case 1:
                        foreach (Car c in collection)
                        {
                            Console.WriteLine(c);
                        }
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        
                        break;
                }
            }
        }
    }
}