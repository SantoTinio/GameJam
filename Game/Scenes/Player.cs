using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private Vector2 _movementVector = new Vector2();
	public const float Speed = 300.0f;
	
	public override void _PhysicsProcess(double delta)
	{
		_movementVector = new Vector2(
			Input.GetActionStrength("right") - Input.GetActionStrength("left"),
			Input.GetActionStrength("down") - Input.GetActionStrength("up")
		);

	}
}
