using System;
using System.Collections.Generic;

namespace lab3_2
{

    public class Car : IEquatable<Car>
    {
        public string Name { get; set; }
        public string Engine { get; set; }
        public int MaxSpeed { get; set; }

        public Car(string name, string engine, int maxSpeed)
        {
            Name = name;
            Engine = engine;
            MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            return Name;
        }

        //реализация интерфейса
        public bool Equals(Car other)
        {
            if (other is null) return false;
            return Name == other.Name && Engine == other.Engine && MaxSpeed == other.MaxSpeed;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Car);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Engine, MaxSpeed);
        }
    }

    public class CarsCatalog
    {
        private List<Car> cars = new List<Car>();

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        //индексатор для доступа к названию машины и типу двигателя
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= cars.Count)
                    throw new IndexOutOfRangeException("Index is out of range.");
                Car car = cars[index];
                return $"{car.Name} - {car.Engine}";
            }
        }

        //получение общего количества машин в каталоге
        public int Count => cars.Count;
    }

    public class Program
    {
        public static void Main()
        {
            CarsCatalog catalog = new CarsCatalog();

            catalog.AddCar(new Car("Tesla", "Electric", 250));
            catalog.AddCar(new Car("Ferrari", "Gasoline", 310));
            catalog.AddCar(new Car("Mercedes", "Gasoline", 290));
            catalog.AddCar(new Car("Mercedes", "Gasoline", 290));


            for (int i = 0; i < catalog.Count; i++)
            {
                Console.WriteLine(catalog[i]);
            }

            Console.WriteLine(catalog[2].Equals(catalog[3])); // true
            Console.WriteLine(catalog[0].Equals(catalog[1])); // false

        }
    }

}
