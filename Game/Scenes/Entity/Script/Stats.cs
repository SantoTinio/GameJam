using Godot;

public partial class Stats : Node2D
{
	[Export]
	public int Health = 3;
	[Export]
	public float Speed = 300.00f;
	[Export]
	public float SprintFactor = 1.50f;
	[Export]
	public float Acceleration = 0.35f;
	[Export]
	public int Damage = 1;
}
