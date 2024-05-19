using Godot;

public partial class PlayerAnimation : AnimatedSprite2D
{
	[Export] 
	private Player _player;
	private double angle;

	public void _updateAnimation()
	{
		angle = GetGlobalMousePosition().AngleToPoint(_player.Position);
		if (angle > -0.8 && angle < 0.6)
		{
			Play("Left");
		}
		else if (angle >= 0.6 && angle < 2.6)
		{
			Play("Up");
		}
		else if ((angle >= 2.6 && angle <= 3.14) || (angle <= -2.14 && angle >= -3.14))
		{
			Play("Right");
		}
		else 
		{
			Play("Down");
		}
		

	}
}
