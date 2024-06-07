using Godot;
using System;

public partial class AnimationPlayer : AnimatedSprite2D
{
	[Export] 
	private Warrior _warrior;
	private double _angle;

	public void _UpdateAnimation(Boolean isMoving, CharacterBody2D player, CharacterBody2D entity)
	{
		_angle = player.Position.AngleToPoint(entity.Position);
		switch (_angle)
		{
			case > -0.8 and < 0.6:
				Play(isMoving ? "LeftWalk" : "LeftIdle");
				break;
			case >= 0.6 and < 2.6:
				Play(isMoving ? "UpWalk" : "UpIdle");
				break;
			case >= 2.6 and <= 3.14:
			case <= -2.14 and >= -3.14:
				Play(isMoving ? "RightWalk" : "RightIdle");
				break;
			default:
				Play(isMoving ? "DownWalk" : "DownIdle");
				break;
		}
	}
}
