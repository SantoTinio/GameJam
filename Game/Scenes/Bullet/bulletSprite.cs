using Godot;
using System;

public partial class bulletSprite : Sprite2D
{
	[Export]
	public float damage = 1.5f;
	[Export]
	public float speed = 200.0f;

	public void Spawn()
	{
		this.Visible = true;
	}
}
