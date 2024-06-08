namespace GameJam.Game.Scenes.Entity.Script;
using Godot;

public partial class MonsterStats : Node
{
    private float _health;
    private float _speed;
    private int _damage;

    public void SetStats(int health, float speed, int damage)
    {
        _health = health;
        _speed = speed;
        _damage = damage;
    }

    public void SetHealth(float health)
    {
        _health = health;
    }

    public float GetHealth()
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