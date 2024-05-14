using Godot;
using System;

public partial class playerAnimation : AnimatedSprite2D
{
	[Export] 
	private Player _player;
	private Vector2 playerPosition = new Vector2();
	private double _angle;

	public void _updateAnimation()
	{
		playerPosition = _player.Position;
		_angle = GetGlobalMousePosition().AngleToPoint(playerPosition);
		if (_angle > -0.8 && _angle < 0.6)
		{
			Play("Left");
		}
		else if (_angle >= 0.6 && _angle < 2.6)
		{
			Play("Up");
		}
		else if (_angle >= 2.6 && _angle <= 3.14 || _angle >= -2.14 && _angle < -3.14)
		{
			Play("Right");
		}
		else 
		{
			Play("Down");
		}
		

	}
}
