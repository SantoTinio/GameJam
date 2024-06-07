using Godot;

public partial class bulletSprite : Sprite2D
{
	[Export]
	public float Damage = 1.5f;
	[Export]
	public float Speed = 200.0f;
	
	[Signal]
	public delegate void HitEventHandler(Area2D node);

	public void OnHit(Area2D node)
	{
		EmitSignal(SignalName.Hit, node);
	}
}
