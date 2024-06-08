using Godot;
public partial class Bullet : Area2D
{

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
		var motion = Direction * PlayerStats.BulletSpeed * (float)delta;
	
		Position += motion;
		
		var distanceTravelled = Position.DistanceTo(SpawnLocation);

		if (distanceTravelled > _maxDistance)
		{
			QueueFree();
		}	
		if (_life < 1) QueueFree();
    }
	public void _on_hit(Area2D node)
	{
		_life -= 1;
	}
}
