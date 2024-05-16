using System;
using Godot;
public partial class playerController : Node2D
{
	[Export] 
	private Player _player;
	[Export]
	private playerAnimation _anims;
	[Export]
	private Bullet _bullet;
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
		_anims._updateAnimation();

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

    /*public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("Shoot"))
		{
			_player.Marker().LookAt(_player.GetGlobalMousePosition());

			for (var i = 0; i < _playerStats.bulletCount; i++)
			{
				var bullet = _bullet;
				var direction = Vector2.Right.Rotated(GetGlobalMousePosition().AngleToPoint(_player.Position));

				Global.Main.AddChild(bullet);


			}
		}
    }*/


}


 
