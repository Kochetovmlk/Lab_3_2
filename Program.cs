using System;
using System.Collections.Generic;

class Car : IEquatable<Car>
{
    public string Name { get; }
    public string Engine { get; }
    public int MaxSpeed { get; }

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

    public bool Equals(Car other)
    {
        if (other is null)
            return false;

        return Name == other.Name && Engine == other.Engine && MaxSpeed == other.MaxSpeed;
    }

    public override bool Equals(object obj)
    {
        if (obj is Car otherCar)
            return Equals(otherCar);

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Engine, MaxSpeed);
    }
}

class CarsCatalog
{
    private List<Car> cars = new List<Car>();

    public CarsCatalog()
    {
        // Добавьте машины в каталог
        cars.Add(new Car("Toyota Camry", "V6", 180));
        cars.Add(new Car("Honda Civic", "Inline-4", 160));
        cars.Add(new Car("Ford Mustang", "V8", 220));
    }

    public int Length => cars.Count;

    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < cars.Count)
            {
                Car car = cars[index];
                return $"{car.Name} ({car.Engine})";
            }
            else
            {
                return "Car not found";
            }
        }
    }
}

class Program
{
    static void Main()
    {
        CarsCatalog catalog = new CarsCatalog();

        Console.WriteLine("Cars in the catalog:");
        for (int i = 0; i < catalog.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {catalog[i]}");
        }

        // Пример сравнения объектов Car
        Car car1 = new Car("Toyota Camry", "V6", 180);
        Car car2 = new Car("Toyota Camry", "V6", 180);

        if (car1.Equals(car2))
        {
            Console.WriteLine("Cars are equal");
        }
        else
        {
            Console.WriteLine("Cars are not equal");
        }
    }
}