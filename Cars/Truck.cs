using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Truck: Car, IInit //грузовой
    {
        private int carrying; // грузоподъемность
        static Random random = new Random();
        public int Carrying
        {
            get => carrying;
            set => carrying = (value >= 1 && value <=20) ? value : 5;
        }
        public Truck() : base()
        {
            carrying = 5;
        }
        public Truck(int carrying) // конструктор с параметрами
        {
            Carrying = carrying;
        }
        public Truck(Truck truck) // конструктор копирования
        {
            carrying = truck.carrying;
        }
        override public void Show() //использован не вирутальный метод, поэтому работать не будет, будут выводится объекты класса Car!!!
        {
            Console.WriteLine("Грузовой автомобиль:");
            base.Show();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Грузоподъёмность: {carrying}\n");
            Console.ResetColor();
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите грузоподъемность: ");
            Carrying = int.Parse(Console.ReadLine());
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Carrying = random.Next(1,20);
        }
    }
}
