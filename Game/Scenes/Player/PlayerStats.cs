using Godot;

public partial class PlayerStats : Node2D
{
	[Export]
	public float health = 5.00f;
	[Export]
	public float speed = 35.00f;
	[Export]
	public float maxHealth = 10.00f;
	[Export]
	public float SprintFactor = 1.5f;
	[Export]
	public float Accel = 0.35f;
	[Export]
	public float Decel = 0.5f;
	[Export]
	public float fireRate = 1;
	[Export]
	public int dashCount = 2;
	[Export]
	public int maxDashCount = 2;
}