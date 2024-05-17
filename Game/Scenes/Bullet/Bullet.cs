using Godot;
public partial class Bullet : Area2D
{
	[Export]
	private bulletSprite _bulletStats;
	[Export]
	public Vector2 spawnLocation;
	[Export]
	public Vector2 targetLocation;
	[Export]
	public Vector2 direction;
	private float MaxDistance = 600;
	private float life = 1;

    public override void _PhysicsProcess(double delta)
    {
		var motion = direction * _bulletStats.speed * (float)delta;
	
		Position += motion;
		
		var disatnceTravelled = Position.DistanceTo(spawnLocation);

		if (disatnceTravelled > MaxDistance)
		{
			QueueFree();
		}	
    }
}
