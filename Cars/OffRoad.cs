using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class OffRoad : Car, IInit //внедорожник
    {
        private bool fourWheel; // полный привод
        private string offRoadType; // тип бездорожья
        static Random random = new Random();
        private static readonly string[] offRoadTypes = {"Гравий", "Песчаник", "Лес", "Болото", "Горы"};
        public string OffRoadType
        {
            get => offRoadType;
            set => offRoadType = (value != null) ? value : "Гравий";
        }
        public OffRoad() : base() 
        {
            fourWheel = true;
            offRoadType = "Гравий";
        }
        public OffRoad(bool fourWheel, string offRoadType) // конструктор с параметрами
        {
            fourWheel = fourWheel;
            OffRoadType = offRoadType;
        }
        public OffRoad(OffRoad offRoad) // конструктор копирования
        {
            fourWheel = offRoad.fourWheel;
            offRoadType = offRoad.offRoadType;
        }
        override public void Show()
        {
            Console.WriteLine("Внедорожник:");
            base.Show();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Полный привод: {fourWheel} Тип бездорожья: {OffRoadType}\n");
            Console.ResetColor();
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Есть полный привод?: ");
            fourWheel = bool.Parse(Console.ReadLine());
            Console.WriteLine("Введите тип бездорожья: ");
            OffRoadType = Console.ReadLine();
        }
        public override void RandomInit()
        {
            base.RandomInit();
            fourWheel = random.Next(2) == 1; 
            OffRoadType = offRoadTypes[random.Next(0, offRoadTypes.Length)];
        }
    }
}
