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
			GD.Print("Speed = " + _playerStats.speed);
		}
		
		{
			_player.Velocity = _player.Velocity.Lerp(Vector2.Zero, _playerStats.Decel);
		}

		_player.MoveAndSlide();
	}

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("moveUp"))
		{
			GD.Print("moved up");
		}
		 if (@event.IsActionPressed("moveDown"))
		{
			GD.Print("moved Down");
		}
		 if (@event.IsActionPressed("moveLeft"))
		{
			GD.Print("moved Left");
		}
		 if (@event.IsActionPressed("moveRight"))
		{
			GD.Print("moved Right");
		}
    }
}
