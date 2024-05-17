using Godot;

public partial class bulletSprite : Sprite2D
{
	[Export]
	public float damage = 1.5f;
	[Export]
	public float speed = 200.0f;
	[Export]
	public float acceleration = 0.35f;
}
