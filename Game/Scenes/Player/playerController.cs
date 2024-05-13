using System;
using Godot;
public partial class playerController : Node2D
{
	[Export] 
	private Player _player;
	private Vector2 _inputDirection = new Vector2();
	private Vector2 _movement = new Vector2();
	private PlayerStats _playerStats;

	public override void _Ready()
	{
		_playerStats = _player.GetPlayerStats();
		GD.Print("Controller is Ready!");
	}

	public override void _PhysicsProcess(double delta) 
	{
		_playerDirection(GetViewport().GetMousePosition().LimitLength(1.0f), _player.GetPositionDelta());
		_inputDirection = new Vector2(
			Input.GetActionStrength("moveRight") - Input.GetActionStrength("moveLeft"),
			Input.GetActionStrength("moveDown") - Input.GetActionStrength("moveUp")
		);
		// Auto Run
		float speedMultiplier = Input.IsActionJustPressed("Run") ? 1.0f : _playerStats.SprintFactor;

		_movement = _inputDirection.LimitLength(1.0f);
		if (_movement != Vector2.Zero)
		{
			_player.Velocity = _player.Velocity.Lerp(_movement * _playerStats.speed * speedMultiplier, _playerStats.Accel);
		}
		
		{
			_player.Velocity = _player.Velocity.Lerp(Vector2.Zero, _playerStats.Decel);
			
		}

		_player.MoveAndSlide();
	}
	public void _updateAnimation(Vector2 state)
	{
		AnimatedSprite2D animate = (AnimatedSprite2D)GetNode("/root/Main/Goom/AnimatedSprite2D");
		animate.Play("Down");
	}
	public void _playerDirection(Vector2 Direction, Vector2 Player)
	{
		//var direction = GetViewport().GetMousePosition().Normalized;
		GD.Print("Mouse Position: " + Direction);
		GD.Print("Player Position: " + Player);
		//Mouse distance to Player
		Vector2 distance = Direction - Player;
		GD.Print("Mouse to Player distance: " + distance);
	}
	
}


 
