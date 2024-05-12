namespace Cars
{
    public class IdNumber :ICloneable
    {
        public int number { get; set; }

        public IdNumber() // Конструктор по умолчанию
        {
            Number = 0;
        }
        public object Clone()
        {
            return new IdNumber(Number);
        }

        public IdNumber(int number) // Конструктор с параметром
        {
            Number = number;
        }
        public int Number 
        {
            get { return number; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("number", "Не может быть отрицательным");
                number = value;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            IdNumber other = (IdNumber)obj;
            return Number == other.Number;
        }
        public override string ToString()
        {
            return Number.ToString();
        }
    }
    public class Car : IInit, IComparable<Car>, ICloneable
    {
        protected string brand; // бренд
        private int year_Issue; //год выпуска
        private string color; // цвет
        private double price; // цена
        private int groundClearance; // дорожный просвет
        int count = 0;

        static Random random = new Random();
        private static readonly string[] brands = { "BMW", "Mercedes", "Mazda", "Hyundai", "Audi", "Ford", "Chevrolet", "Toyota", "Nissan", "Aston Martin", "Acura", "Lexus", "Porsche" };
        private static readonly string[] colors = { "Красный", "Белый", "Синий", "Серебристый", "Черный", "Фиолетовый" };
        public IdNumber Id { get; set; }
        public string Brand
        {
            get => brand;
            set
            {
                if (value != null)
                    brand = value;
                else brand = "No name";
            }
        }
        public int Year_Issue
        {
            get => year_Issue;
            set
            {
                if (value >= 1980 && value <= 2024)
                    year_Issue = value;
                else year_Issue = 2020;
            }
        }
        public string Color
        {
            get => color;
            set
            {
                if (value != null) color = value;
                else color = "Белый";
            }
        }
        public double Price
        {
            get => price;
            set
            {
                if (value > 50000) price = value;
                else price = 1000000;
            }
        }

        public int GroundClearance
        {
            get => groundClearance;
            set
            {
                if (groundClearance >= 120 && groundClearance <= 180) groundClearance = value;
                else groundClearance = 140;
            }
        }
        public Car() : this(new IdNumber(0), "BMW", 2013, "Белый", 1500000, 140) { } // конструктор без параметров
        public Car(IdNumber id, string brand, int year_Issue, string color, double price, int groundClearance) // конструктор с параметрами
        {
            Id = id;
            Brand = brand;
            Year_Issue = year_Issue;
            Color = color;
            Price = price;
            GroundClearance = groundClearance;
        }
        public Car(Car car) // конструктор копирования
        {
            Id = car.Id;
            Brand = car.Brand;
            Year_Issue = car.Year_Issue;
            Color = car.Color;
            Price = car.Price;
            GroundClearance = car.GroundClearance;
        }
        virtual public void Show()
        {
            Console.WriteLine($"Id: {Id} Бренд: {Brand} Год выпуска: {Year_Issue} Цвет: {Color} Цена: {Price} Дорожный просвет: {GroundClearance}");
        }
        public override string ToString()
        {
            return $"Id: {Id} Бренд: {Brand} Год выпуска: {Year_Issue} Цвет: {Color} Цена: {Price} Дорожный просвет: {GroundClearance}";
        }
        public object Clone()
        {
            // Создаем новый объект Car с клонированным IdNumber
            return new Car((IdNumber)Id.Clone(), Brand, Year_Issue, Color, Price, GroundClearance);
        }
        public Car ShallowCopy()
        {
            return (Car)this.MemberwiseClone();
        }
        public virtual int GetCount => count;
        public virtual void Init() //ввод с клавиатуры
        {
            try
            {
                Console.WriteLine("Введите бренд: ");
                Brand = Console.ReadLine();
                Console.WriteLine("Введите год выпуска: ");
                Year_Issue = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите цвет авто: ");
                Color = Console.ReadLine();

                Console.WriteLine("Введите цену: ");
                Price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Введите дорожный просвет: ");
                GroundClearance = int.Parse(Console.ReadLine());
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }
        public virtual void RandomInit()
        {
            Id = new IdNumber(random.Next(1, 100));
            Brand = brands[random.Next(0, brands.Length)];
            Year_Issue = random.Next(1980, 2024);
            Color = colors[random.Next(0, colors.Length)];
            Price = random.Next(50000, 1000000);
            GroundClearance = random.Next(120, 180);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Car other = (Car)obj;
            return Brand == other.Brand && Year_Issue == other.Year_Issue && Color == other.Color && Price == other.Price && GroundClearance == other.GroundClearance;
        }
        public int CompareTo(Car other)
        {
            return Year_Issue.CompareTo(other.Year_Issue);
        }
    }
}