using Godot;
public partial class Bullet : Area2D
{
	public Vector2 SpawnLocation;
	public Vector2 TargetLocation;
	public Vector2 Direction;
	private static int _maxRange = 200;
	private int _life = 1;

    public override void _PhysicsProcess(double delta)
    {
		var motion = Direction * PlayerStats.BulletSpeed * (float)delta;
		Position += motion;
		var distanceTravelled = Position.DistanceTo(SpawnLocation);
		if (distanceTravelled > _maxRange) QueueFree();
		if (_life < 1) QueueFree();
    }
	private void _on_hit(Area2D node)
	{
		_life -= 1;
	}
}
