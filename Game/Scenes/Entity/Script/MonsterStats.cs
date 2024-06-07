namespace GameJam.Game.Scenes.Entity.Script;
using Godot;

public partial class MonsterStats : Node
{
    private int _health;
    private float _speed;
    private int _damage;

    public void SetStats(int health, float speed, int damage)
    {
        _health = health;
        _speed = speed;
        _damage = damage;
    }

    public void SetHealth(int health)
    {
        _health = health;
    }

    public int GetHealth()
    {
        return _health;
    }

    public int GetDamage()
    {
        return _damage;
    }

    public float GetSpeed()
    {
        return _speed;
    }
}