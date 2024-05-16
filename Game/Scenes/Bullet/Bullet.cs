using Godot;
using System;

public partial class Bullet : RigidBody2D
{
	[Export]
	private bulletSprite _bulletStats;
	public float MaxDistance = 600;
	public float Impulse = 1200;
	public float life = 1;
	public Vector2 newImpulse = new Vector2();
	public Timer Timer;
	
	public void launchBullet()
	{
	
		this.ApplyCentralImpulse(this.Transform.X.Normalized()*Impulse);
		Timer.Start();
		
	}

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }
    public void DieOnTime()
	{
		this.QueueFree();
	}
}
