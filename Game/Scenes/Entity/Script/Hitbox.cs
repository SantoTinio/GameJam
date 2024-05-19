using Godot;
using System;

public partial class Hitbox : Area2D
{
	[Export]
	private Stats _stats;

	public void onHit(Node2D controller)
	{
		_stats.Health -= PlayerStats.BulletDamage;
	}
}
