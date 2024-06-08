using Godot;

public partial class MonsterStats : Node
{
    public float Health;
    public float Speed;
    public int Damage;

    public void SetStats(int health, float speed, int damage)
    {
        Health = health;
        Speed = speed;
        Damage = damage;
    }
    /*

    public void SetHealth(float health)
    {
        Health = health;
    }

    public float GetHealth()
    {
        return Health;
    }

    public int GetDamage()
    {
        return Damage;
    }

    public float GetSpeed()
    {
        return Speed;
    }*/
}