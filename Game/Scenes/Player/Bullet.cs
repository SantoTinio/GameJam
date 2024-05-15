using Godot;
using System;

public partial class Bullet : RigidBody2D
{
	public float MaxDistance = 600.0f;
	public float  Impulse = 1200.0f;
	public float life = 1;
	private Timer timer;

	public void spawnBullet()
	{
		//this.ApplyCentralImpulse(new Vector2(this.Transform.X.Normalized() * Impulse, this.Transform.Y.Normalized() * Impulse));

		timer = new Timer();
		this.AddChild(timer);
		timer.WaitTime = this.life;
		timer.OneShot = true;
		
		timer.Start();
	}

	public void despawn()
	{
		this.QueueFree();
	}
}
