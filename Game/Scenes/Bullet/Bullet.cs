using Godot;
using System;

public partial class Bullet : Area2D
{
	[Export]
	private bulletSprite _bulletStats;
	[Export]
	private Cooldown _timer;
	private float MaxDistance = 600;
	private float life = 1;
	[Export]
	public Vector2 spawnLocation;
	[Export]
	public Vector2 targetLocation;
	[Export]
	public Vector2 direction;
	public bool isReady;

    public override void _PhysicsProcess(double delta)
    {
		isReady = false;
		_timer.Start();
		var motion = direction * _bulletStats.speed * (float)delta;

		Position += motion;
		
        var disatnceTravelled = Position.DistanceTo(spawnLocation);

		if (disatnceTravelled > MaxDistance)
		{
			QueueFree();
		}
    }
    public void _on_cooldown_timeout()
	{
		isReady = true;
	}
}
