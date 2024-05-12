using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class LightCar : Car, IInit //легковой
    {
        private int numSeats; // количество мест
        private int maxSpeed; //макс.скорость
        static Random random = new Random();
        public int NumSeats
        {
            get => numSeats;
            set
            {
                if (value >= 2 &&  value <= 8) numSeats = value;
                else numSeats = 5;
            }
        }
        public int MaxSpeed
        {
            get => maxSpeed;
            set
            {
                if (value >= 160 && value <= 500) maxSpeed = value;
                else maxSpeed = 200;
            }
        }
        public LightCar() : base() // конструктор без параметров
        { 
            numSeats = 5;
            maxSpeed = 200;
        } 
        public LightCar(int numSeats, int maxSpeed) // конструктор с параметрами
        {
            NumSeats = numSeats;
            MaxSpeed = maxSpeed;
        }
        public LightCar(LightCar lCar) // конструктор копирования
        {
            NumSeats = lCar.NumSeats;
            MaxSpeed = lCar.MaxSpeed;
        }
        public override void Show()
        {
            Console.WriteLine("\nЛегковой автомобиль:");
            base.Show();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Количество мест: {NumSeats} Макс.скорость: {MaxSpeed}\n");
            Console.ResetColor();
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество мест: ");
            NumSeats = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите макс.скорость: ");
            MaxSpeed = int.Parse(Console.ReadLine());
        }
        public override void RandomInit()
        {
            base.RandomInit();
            numSeats = random.Next(2, 8);
            maxSpeed = random.Next(160,500);
        }
        public int GetSpeed()
        {
            return MaxSpeed;
        }
    }
}
