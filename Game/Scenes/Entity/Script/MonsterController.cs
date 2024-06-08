namespace GameJam.Game.Scenes.Entity.Script;
using System;
using Godot;

public partial class MonsterController : Node
{
    private MonsterStats _stats = new MonsterStats();
    private Vector2 _targetPos;
    private Vector2 _direction;
    private bool _isMoving;
    
    public void SetStats(int health, float speed, int damage)
    {
        _stats.SetStats(health, speed, damage);
    }

    public void Control(CharacterBody2D player, CharacterBody2D entity)
    {
        //Get Range when in Dungeon Crawler Mode
        _targetPos = player.Position;
        _direction = (_targetPos - entity.Position).Normalized();
        entity.Velocity = _direction * _stats.GetSpeed();
        _isMoving = true;

        entity.MoveAndSlide();
    }

    public void SetHealth(float health)
    {
        _stats.SetHealth(health);
    }

    public bool GetMoving()
    {
        return _isMoving;
    }

    public int GetDamage()
    {
        return _stats.GetDamage();
    }

    public float GetHealth()
    {
        return _stats.GetHealth();
    }
    
}