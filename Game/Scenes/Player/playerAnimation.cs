using Godot;
using System;

public partial class playerAnimation : AnimatedSprite2D
{
	[Export] 
	private Player _player;
	private Vector2 mousePosition = new Vector2();
	private Vector2 playerPosition = new Vector2();
	private Vector2 _direction = new Vector2();

	public void _updateAnimation()
	{
		mousePosition = GetViewport().GetMousePosition();
		playerPosition = _player.Position;
		_direction = playerPosition.DirectionTo(mousePosition);	
		GD.Print("Direction: " + _direction);

		// Use C or something not pythagoras but, A + B = C
		//Up
		if (_direction.Y < 0.3)
		{
			if (_direction.X >0.94)
			{
				Play("Right");
			}
			else
			{
				Play("Up");
			}
			
		}
		//Down
		else if(_direction.Y > 0.3)
		{
			Play("Down");
		}


	}
}
