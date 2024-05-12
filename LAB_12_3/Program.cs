using Cars;
using LAB_12_3;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace LAB_12_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu choise = new Menu();
            MyTree<Car> tree = new MyTree<Car>(10);
            //tree.ShowTree();
            while (true)
            {
                choise.MenuChoise();
                var str = Console.ReadLine();
                int l = int.Parse(str);
                Console.Clear();
                switch (l)
                {
                    case 1:
                        Console.WriteLine("Исходное дерево: ");
                        tree.ShowTree();
                        break;
                    case 2:
                        Car max = tree.FindMax();
                        Console.WriteLine(max);
                        break;
                    case 3:
                        Console.WriteLine("Исходное ИСД:");
                        tree.ShowTree();
                        Console.WriteLine("Преобразованное дерево поиска:");
                        tree.TransformToFindTree();
                        tree.ShowTree();
                        break;
                    case 4:
                        Console.WriteLine("Исходное дерево:");
                        tree.ShowTree();
                        Car car = new Car();
                        car.Brand = "Acura";
                        bool r = tree.Remove(car);
                        if (r) { Console.WriteLine("Элементы удалены"); }
                        else { Console.WriteLine("Элементы не найдены"); }
                        Console.WriteLine("Новое дерево:");
                        tree.ShowTree();
                        break;
                    case 5:
                        tree.Delete();
                        Console.WriteLine("Дерево удалено!)");
                        break;
                    case 6:
                        MyTree<Car> exp = new MyTree<Car>(25);
                        exp.ShowTree();
                        Console.WriteLine("---------------------------------------");
                        exp.TransformToFindTree();
                        Car car3 = new Car();
                        Car car1 = new Car();
                        Car car2 = new Car();
                        car3.Brand = "Acura";
                        car1.Brand = "Mercedes";
                        car2.Brand = "Nissan";
                        exp.ShowTree();
                        Console.WriteLine("---------------------------------------");
                        // Act
                        bool res = exp.Remove(car3);
                        bool res1 = exp.Remove(car1);
                        bool res2 = exp.Remove(car2);
                        exp.ShowTree();
                        break;
                }
            }
        }
    }
}
