using Godot;

public partial class Stats : Node2D
{
	[Export]
	public int Health = 100;
	[Export]
	public float Speed = 250f;
	[Export]
	public float SprintFactor = 1.5f;
	[Export]
	public float Accel = 0.35f;
	[Export]
	public int Damage = 1;
}
