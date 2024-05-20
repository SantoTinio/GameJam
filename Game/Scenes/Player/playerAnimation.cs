using Godot;

public partial class PlayerAnimation : AnimatedSprite2D
{
	[Export] 
	private Player _player;
	private double _angle;

	public void _updateAnimation()
	{
		_angle = GetGlobalMousePosition().AngleToPoint(_player.Position);
		switch (_angle)
		{
			case > -0.8 and < 0.6:
				Play("Left");
				break;
			case >= 0.6 and < 2.6:
				Play("Up");
				break;
			case >= 2.6 and <= 3.14:
			case <= -2.14 and >= -3.14:
				Play("Right");
				break;
			default:
				Play("Down");
				break;
		}
	}
}
