using Godot;
public partial class Bullet : Area2D
{
	[Export]
	private bulletSprite _bulletStats;
	[Export]
	public Vector2 SpawnLocation;
	[Export]
	public Vector2 TargetLocation;
	[Export]
	public Vector2 Direction;
	private float _maxDistance = 600;
	private float _life = 1;

    public override void _PhysicsProcess(double delta)
    {
		var motion = Direction * _bulletStats.Speed * (float)delta;
	
		Position += motion;
		
		var distanceTravelled = Position.DistanceTo(SpawnLocation);

		if (distanceTravelled > _maxDistance)
		{
			QueueFree();
		}	
    }
	public void _on_hit(Area2D area)
	{
		_bulletStats.Visible = false;
	}
}
