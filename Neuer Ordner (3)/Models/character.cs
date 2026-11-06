using System.Runtime.CompilerServices;

namespace Rpg;

public abstract class Character
{
    public string Name { get; private set; }
    public int Level { get; protected set; }
    public double Health { get; protected set; }
    public double MaxHealth { get; protected set; }
    public int Experience { get; protected set; }
    public double BaseDamage { get; protected set; }

    public Character(string name)
    {
        Name = name;
        Experience = 0;
        Level = GetExperienceToLevel();
        MaxHealth = GetMaxHealth();
        Health = GetHealth();
        BaseDamage = GetBaseDamage();
    }

    private double GetMaxHealth()
    {
        double maxHealth = 50 + (int)(Level * 0.25f);
        return maxHealth;
    }

    public double GetHealth()
    {
        double health;
        return health = MaxHealth;
    }

    public int GetExperienceToLevel()
    {
        // Gesamt-XP für ein Level: 100 * (Level - 1)^2
        return (int)Math.Sqrt(Experience / 100.0) + 1;
    }

    public void TakeDamage(double amount)
    {
        amount = Math.Max(0, amount);

        if (Health - amount <= 0)
        {
            Health = 0;
        }
        else
        {
            Health -= amount;
        }
    }

    public void Heal(double amount)
    {
        amount = Math.Max(0, amount);

        if (Health + amount > MaxHealth)
        {
            Health = MaxHealth;
        }
        else
        {
            Health += amount;
        }
    }

    public double GetBaseDamage()
    {
        double dmg = (2 + Level * 0.5);
        return dmg;
    }

    public void FullStatCheck()
    {
        Console.WriteLine($" \n Name: {Name} \n Level: {Level} \n Health: {Health} \n MaxHealth: {MaxHealth} \n Experience: {Experience} \n BaseDamage: {BaseDamage}");
    }
}