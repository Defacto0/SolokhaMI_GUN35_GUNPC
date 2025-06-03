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
    public int Damage { get; } = 5;
    public float Armor { get; }
    public Unit() : this("Unknown Unit") { }
    public Unit(string name)
    {
        Name = name;
        Armor = 0.6f;
    }
    public float GetRealHealth()
    {
        return Health * (1f + Armor);
    }
    public bool SetDamage(float value)
    {
        _health -= value * Armor;
        if (_health <= 0f)
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}