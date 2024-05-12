using Cars;
using LAB_12;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace LAB_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu choise = new Menu();
            MyList<Car> list = new MyList<Car>();
            HTable<Car> htable = new HTable<Car>();
            while (true)
            {
                choise.MenuChoise();
                var str = Console.ReadLine();
                int l = int.Parse(str);
                Console.Clear();
                switch (l)
                {
                    case 1: //сформировать двунаправленный список и распечатать
                        Console.WriteLine("Введите размер списка: ");
                        int size = int.Parse(Console.ReadLine());
                        list = new MyList<Car>(size);
                        break;
                    case 2:
                        list.PrintList();
                        break;
                    case 3: // добавление в начало
                        Car midCar = new Car();
                        Console.WriteLine("Сколько добавить элементов: ");
                        int count = int.Parse(Console.ReadLine());
                        for (int i = 0; i < count; i++)
                        { 
                            midCar.RandomInit();
                            list.AddInMiddle(midCar);
                        }
                        Console.WriteLine("Элементы добавлены");
                        list.PrintList();
                        break;
                    case 4: // добавление в конец
                        list.RemoveItemAfterBrand("Toyota");
                        Console.WriteLine("Элементы удалены");
                        break;
                    case 5: // глубокое клонирование
                        MyList<Car> carsClone = list.DeepClone();
                        carsClone.PrintList();
                        break;
                    case 6: //удаление списка
                        list.Delete();
                        Console.WriteLine("Список удалён");
                        break;
                    case 7: // создание хэш-таблицы
                        Console.WriteLine("Введите размер хеш-таблицы: ");
                        int size1 = int.Parse(Console.ReadLine());
                        htable = new HTable<Car>(size1);
                        for (int i = 0; i < size1; i++)
                        {
                            Car car = new Car();
                            car.RandomInit();
                            htable.Add(car);
                        }
                        break;
                    case 8: // вывод
                        htable.Print();
                        break;
                    case 9: // поиск и удаление элемента 
                        htable.Print();
                        Console.WriteLine("Введите элемент для поиска: ");
                        Car searchCar = new Car();
                        searchCar.Init(); 
                        bool found = htable.FindPoint(searchCar);
                        Console.WriteLine($"Элемент найден: {found}");
                        bool removed = htable.DelPoint(searchCar);
                        Console.WriteLine($"Элемент удален: {removed}");
                        break;
                    case 10:
                        break;
                }
            }
        }
    }
}