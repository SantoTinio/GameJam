using Godot;
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
	private double dashTime = 0;
	private bool dashed = false;
	private double dashTimer;
	private double DashCooldown;
	private double time = 10;
	private double maxTime = 1.0;

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
		
		//Slime dash

		if (!isDashReady())
		{
			if (dashed)	returnSpeed(delta);

			DashCooldown += delta;
			GD.Print("CoolTime:" + DashCooldown);

			if (DashCooldown > 5.0)
			{
				_playerStats.dashCount += 1;
				DashCooldown = 0;
			} 
		}	

		// Auto Run
		float speedMultiplier = Input.IsActionJustPressed("Run") ? 1.0f : _playerStats.SprintFactor;

		_movement = _inputDirection.LimitLength(1.0f);
		if (_movement != Vector2.Zero)
		{
			_player.Velocity = _player.Velocity.Lerp(_movement * _playerStats.speed * speedMultiplier, _playerStats.Accel);
		}
		else
		{
			_player.Velocity = _player.Velocity.Lerp(Vector2.Zero, _playerStats.Decel);
			
		}
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
			GD.Print("Health: " + _playerStats.health);
			GD.Print("Speed: " + _playerStats.speed);
			GD.Print("FireRate: " + _playerStats.fireRate);
			GD.Print("Dash: " + +_playerStats.dashCount);
		}
		//Space to Dash
		if (@event.IsActionPressed("Dash"))
		{
			GD.Print("dashing");
			if (isDashReady())
			{
				_playerStats.speed = 1600;
				_playerStats.dashCount -= 1;
				dashed = true;
			}
		}
    }
	//Bullet Spawning function
    private void ShootIt(double delta)
	{
		var bullet = (Bullet)Bullet.Instantiate();
		var direction = Vector2.Right.Rotated(_player.Position.AngleToPoint(GetGlobalMousePosition()));
		if (isBulletReady(delta))
		{
			_player.AddChild(bullet);

			bullet.direction = direction;
			bullet.LookAt(_player.GetGlobalMousePosition());
			bullet.spawnLocation = _marker.Position;
			bullet.targetLocation = GetGlobalMousePosition();
		}
		else return;
	}

	//Checks if player has dash!
	private bool isDashReady()
	{
		if (_playerStats.dashCount > 0)	return true;
		else return false;
	}
	//Returns player speed to original speed after the dash frame
	private void returnSpeed(double delta)
	{
		dashTimer += delta;
		GD.Print("returning Speed");
		if (dashTimer > 0.0167)
		{
			_playerStats.speed = 50.00f;
			dashTimer = 0.0;
			dashed = false;
		}
	}

	//Bullet Cooldown!
	private bool isBulletReady(double delta)
	{
		time += delta * _playerStats.fireRate;

		if (time < maxTime) return false;
		else {
			time = 0;
			return true;
		}
	}

}


 
