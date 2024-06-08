using System;
using Godot;
public partial class PlayerController : Node2D
{
	[Export] 
	private Player _player;
	[Export]
	private PlayerAnimation _anims;
	[Export]
	private Marker _marker;
	/*[Signal]
	public delegate void EnemyHitEventHandler(Node2D node);*/
	private PackedScene _bullet;
	private Vector2 _inputDirection;
	private Vector2 _movement;
	private double _dashTime;
	private bool _dashed;
	private double _dashTimer;
	private double _dashCooldown;
	private double _time = 10;
	private double _maxTime = 1.0;
	private float _initSpeed = 35.0f;

	public override void _Ready()
	{
		_bullet = GD.Load<PackedScene>("res://Game/Scenes/Bullet/bullet.tscn");
		GD.Print("Controller is Ready!");
	}

	public override void _PhysicsProcess(double delta) 
	{
		_anims._updateAnimation();

		_inputDirection = new Vector2(
			Input.GetActionStrength("moveRight") - Input.GetActionStrength("moveLeft"),
			Input.GetActionStrength("moveDown") - Input.GetActionStrength("moveUp")
		);
		
		//Slime dash
		if (!IsDashReady() || _dashed || PlayerStats.DashCount != PlayerStats.MaxDashCount)
		{
			//return to ogSpeed
			if (_dashed)	ReturnSpeed(delta);
			//Cooldown the dash
			_dashCooldown += delta;
			if (_dashCooldown > 5.0)
			{
				PlayerStats.DashCount += 1;
				_dashCooldown = 0;
				GD.Print("Dashes:" + PlayerStats.DashCount);
			} 
		}	
		// Auto Run
		var speedMultiplier = Input.IsActionJustPressed("Run") ? 1.0f : PlayerStats.SprintFactor;

		_movement = _inputDirection.LimitLength();
		_player.Velocity = _movement != Vector2.Zero
			? _player.Velocity.Lerp(_movement * PlayerStats.Speed * speedMultiplier, PlayerStats.Accel)
			: _player.Velocity.Lerp(Vector2.Zero, PlayerStats.Decel);

		//shoot
		ShootIt(delta);
		//MOVE THE PLAYER!
		_player.MoveAndSlide();
	}

    public override void _Input(InputEvent @event)
    {
		// debug Check! Left Click to see Player Stats
        if (@event.IsActionPressed("Shoot"))
		{
			GD.Print("Health: " + PlayerStats.Health);
			GD.Print("Speed: " + PlayerStats.Speed);
			GD.Print("FireRate: " + PlayerStats.FireRate);
			GD.Print("Dash: " + PlayerStats.DashCount);
		}
		//Space to Dash
		if (@event.IsActionPressed("Dash"))
		{
			GD.Print("dashing");
			if (IsDashReady())
			{
				PlayerStats.Speed = 1300;
				PlayerStats.DashCount -= 1;
				_dashed = true;
			}
		}
		if (@event.IsActionPressed("LevelUp"))
		{
			PlayerStats.Health += 1;
			PlayerStats.Speed = PlayerStats.Speed * 1.10f;
			PlayerStats.FireRate = PlayerStats.FireRate * 1.15f;
			PlayerStats.MaxDashCount += 1;
			_initSpeed = PlayerStats.Speed;
			GD.Print("Health: " + PlayerStats.Health);
			GD.Print("Speed: " + PlayerStats.Speed);
			GD.Print("FireRate: " + PlayerStats.FireRate);
			GD.Print("Max Dash: " + PlayerStats.MaxDashCount);
		}
    }
	//Bullet Spawning function
    private void ShootIt(double delta)
	{
		var bullet = (Bullet)_bullet.Instantiate();
		var direction = Vector2.Right.Rotated(_player.Position.AngleToPoint(GetGlobalMousePosition()));
		if (IsBulletReady(delta))
		{
			_player.AddChild(bullet);
			bullet.Direction = direction;
			bullet.LookAt(_player.GetGlobalMousePosition());
			bullet.SpawnLocation = _marker.Position;
			bullet.TargetLocation = GetGlobalMousePosition();
		}
	}
	//Checks if player has dash!
	private static bool IsDashReady()
	{
		return PlayerStats.DashCount > 0 && PlayerStats.DashCount <= PlayerStats.MaxDashCount;
	}
	//Returns player Speed to original Speed after the dash frame
	private void ReturnSpeed(double delta)
	{
		_dashTimer += delta;
		if (!(_dashTimer > 0.0167)) return;
		PlayerStats.Speed = _initSpeed;
		_dashTimer = 0.0;
		_dashed = false;
	}
	//Bullet Cooldown!
	private bool IsBulletReady(double delta)
	{
		_time += delta * PlayerStats.FireRate;
		if (_time < _maxTime) return false;
		else {
			_time = 0;
			return true;
		}
	}

	/*private void OnHit(Node2D node)
	{
		EmitSignal(SignalName.EnemyHit, node);
	}*/
}