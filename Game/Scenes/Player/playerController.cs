using System;
using Godot;
using GodotPlugins.Game;
public partial class playerController : Node2D
{
	[Export] 
	private Player _player;
	[Export]
	private playerAnimation _anims;
	[Export]
	private Marker _marker;
	private PackedScene Bullet;
	private Vector2 _inputDirection = new Vector2();
	private Vector2 _movement = new Vector2();
	private PlayerStats _playerStats;

	public override void _Ready()
	{
		Bullet = GD.Load<PackedScene>("res://Game/Scenes/Bullet/bullet.tscn");
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

		//shoot
		ShootIt();
		_player.MoveAndSlide();
	}

    /*public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("Shoot"))
		{
			for (var i = 0; i < _playerStats.bulletCount; i++)
			{
				var bullet = (Bullet)Bullet.Instantiate();
				var direction = Vector2.Right.Rotated(_player.Position.AngleToPoint(GetGlobalMousePosition()));

				_player.AddChild(bullet);

				bullet.direction = direction;
				bullet.LookAt(_player.GetGlobalMousePosition());
				bullet.spawnLocation = _marker.Position;
				bullet.targetLocation = GetGlobalMousePosition();
			}
		}
    }*/

	public void ShootIt()
	{
		var bullet = (Bullet)Bullet.Instantiate();
		var direction = Vector2.Right.Rotated(_player.Position.AngleToPoint(GetGlobalMousePosition()));
		if (!bullet.isReady)
		{
			_player.AddChild(bullet);

			bullet.direction = direction;
			bullet.LookAt(_player.GetGlobalMousePosition());
			bullet.spawnLocation = _marker.Position;
			bullet.targetLocation = GetGlobalMousePosition();
		}
		
}

}


 
