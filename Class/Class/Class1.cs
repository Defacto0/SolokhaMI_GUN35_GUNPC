using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Unit
{
    public string Name { get; }
    private float _health;
    public float Health => _health;
    public Interval Damage { get; }
    public float Armor { get; }
    public Unit() : this("Unknown Unit") { }
    public Unit(string name) : this(name, 0, 5) { }
    public Unit(string name, int minDamage, int maxDamage)
    {
        Name = name;
        Damage = new Interval(minDamage, maxDamage);
        Armor = 0.6f;
    }

    public float GetRealHealth()
    {
        return Health * (1f + Armor);
    }

    public bool SetDamage(float value)
    {
        _health -= value * Armor;
        return _health <= 0f;
    }
}

public class Weapon
{
    public string Name { get; }
    public int MinDamage { get; private set; }
    public int MaxDamage { get; private set; }
    public float Durability { get; } = 1f;

    public Weapon(string name)
    {
        Name = name;
        SetDamageParams(1, 10);
    }

    public Weapon(string name, int minDamage, int maxDamage) : this(name)
    {
        SetDamageParams(minDamage, maxDamage);
    }

    public void SetDamageParams(int minDamage, int maxDamage)
    {
        if (minDamage > maxDamage)
        {
            (minDamage, maxDamage) = (maxDamage, minDamage);
            Console.WriteLine($"[{Name}] minDamage > maxDamage. Значения поменяны местами.");
        }

        if (minDamage < 1)
        {
            minDamage = 1;
            Console.WriteLine($"[{Name}] minDamage < 1. Установлено 1.");
        }

        if (maxDamage <= 1)
        {
            maxDamage = 10;
            Console.WriteLine($"[{Name}] maxDamage <= 1. Установлено 10.");
        }

        MinDamage = minDamage;
        MaxDamage = maxDamage;
    }

    public int GetDamage() => (int)Math.Round((MinDamage + MaxDamage) / 2f);
}
public struct Interval
{
    private readonly Random _random;
    public float Min { get; }
    public float Max { get; }

    public Interval(int minValue, int maxValue)
    {
        _random = new Random();

        if (minValue < 0)
        {
            minValue = 0;
            Console.WriteLine("Некорректные входные данные: minValue < 0. Установлено 0.");
        }
        if (maxValue < 0)
        {
            maxValue = 0;
            Console.WriteLine("Некорректные входные данные: maxValue < 0. Установлено 0.");
        }

        if (minValue > maxValue)
        {
            (minValue, maxValue) = (maxValue, minValue);
            Console.WriteLine("Некорректные входные данные: minValue > maxValue. Значения поменяны местами.");
        }

        if (minValue == maxValue)
        {
            maxValue += 10;
            Console.WriteLine("Некорректные входные данные: minValue == maxValue. Max увеличен на 10.");
        }

        Min = minValue;
        Max = maxValue;
    }

    public float Get()
    {
        return (float)(Min + _random.NextDouble() * (Max - Min));
    }
}

public struct Room
{
    public Unit Unit { get; }
    public Weapon Weapon { get; }

    public Room(Unit unit, Weapon weapon)
    {
        Unit = unit;
        Weapon = weapon;
    }
}

    public class Dungeon
{
    private readonly Room[] _rooms;

    public Dungeon()
    {
        _rooms = new Room[]
        {
            new Room(
                new Unit("Воин", 5, 15),
                new Weapon("Меч", 10, 20)
            ),
            new Room(
                new Unit("Лучник", 3, 12),
                new Weapon("Лук", 8, 18)
            ),
            new Room(
                new Unit("Маг", 1, 10),
                new Weapon("Посох", 5, 25)
            )
        };
    }

    public void ShowRooms()
    {
        for (int i = 0; i < _rooms.Length; i++)
        {
            var room = _rooms[i];
            Console.WriteLine($"Комната {i + 1}:");
            Console.WriteLine($"Юнит: {room.Unit.Name}, Здоровье: {room.Unit.Health}");
            Console.WriteLine($"Оружие: {room.Weapon.Name}, Урон: {room.Weapon.MinDamage}-{room.Weapon.MaxDamage}");
            Console.WriteLine("---");
        }
    }
}