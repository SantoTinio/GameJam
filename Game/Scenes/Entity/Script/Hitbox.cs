using Godot;
using System;
using GameJam.Game.Scenes.Entity.Script;

public partial class Hitbox : Area2D
{
	[Export] private UnarmedWarrior _monster;

	public void onHit(Node2D controller)
	{
		_monster.Damaged();
	}

	/*public void GotHit(Node2D Controller)
	{
		monster.SetHealth(monster.GetHealth() - monster.GetDamage());
	}*/
}
