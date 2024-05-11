using Godot;
using System;

public partial class PlayerStats : Node2D
{
	[Export]
	public float health = 5.00f;
	[Export]
	public float speed = 50.00f;
	[Export]
	public float maxHealth = 10.00f;
	[Export]
	public float Accel = 0.30f;
	[Export]
	public float Decel = 0.50f;
}
