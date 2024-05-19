using Godot;
public partial class PlayerController : Node2D
{
	[Export] 
	private Player _player;
	[Export]
	private PlayerAnimation _anims;
	[Export]
	private Marker _marker;
	//[Export]
	//private Bullet _bullet;
	//[Signal]
	//public delegate void HitEventHandler(Node2D node);
	private PackedScene Bullet;
	private Vector2 _inputDirection = new Vector2();
	private Vector2 _movement = new Vector2();
	private double dashTime = 0;
	private bool dashed = false;
	private double dashTimer;
	private double DashCooldown;
	private double time = 10;
	private double maxTime = 1.0;
	private float _initSpeed = 35.0f;

	public override void _Ready()
	{

		Bullet = GD.Load<PackedScene>("res://Game/Scenes/Bullet/bullet.tscn");
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
		if (!isDashReady() || dashed || PlayerStats.DashCount != PlayerStats.MaxDashCount)
		{
			//return to ogSpeed
			if (dashed)	returnSpeed(delta);
			//Cooldown the dash
			DashCooldown += delta;
			if (DashCooldown > 5.0)
			{
				PlayerStats.DashCount += 1;
				DashCooldown = 0;
				GD.Print("Dashes:" + PlayerStats.DashCount);
			} 
		}	
		// Auto Run
		float SpeedMultiplier = Input.IsActionJustPressed("Run") ? 1.0f : PlayerStats.SprintFactor;

		_movement = _inputDirection.LimitLength(1.0f);
		if (_movement != Vector2.Zero)
		{
			_player.Velocity = _player.Velocity.Lerp(_movement * PlayerStats.Speed * SpeedMultiplier, PlayerStats.Accel);
		}
		else
		{
			_player.Velocity = _player.Velocity.Lerp(Vector2.Zero, PlayerStats.Decel);
			
		}

		//shoot
		shootIt(delta);
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
			if (isDashReady())
			{
				PlayerStats.Speed = 1300;
				PlayerStats.DashCount -= 1;
				dashed = true;
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
    private void shootIt(double delta)
	{
		var _bullet = (Bullet)Bullet.Instantiate();
		var direction = Vector2.Right.Rotated(_player.Position.AngleToPoint(GetGlobalMousePosition()));
		if (isBulletReady(delta))
		{
			_player.AddChild(_bullet);
			_bullet.direction = direction;
			_bullet.LookAt(_player.GetGlobalMousePosition());
			_bullet.spawnLocation = _marker.Position;
			_bullet.targetLocation = GetGlobalMousePosition();
		}
		else return;
	}
	//Checks if player has dash!
	private bool isDashReady()
	{
		if (PlayerStats.DashCount > 0 && PlayerStats.DashCount <= PlayerStats.MaxDashCount)	return true;
		else return false;
	}
	//Returns player Speed to original Speed after the dash frame
	private void returnSpeed(double delta)
	{
		dashTimer += delta;
		if (dashTimer > 0.0167)
		{
			PlayerStats.Speed = _initSpeed;
			dashTimer = 0.0;
			dashed = false;
		}
	}
	//Bullet Cooldown!
	private bool isBulletReady(double delta)
	{
		time += delta * PlayerStats.FireRate;
		if (time < maxTime) return false;
		else {
			time = 0;
			return true;
		}
	}
	/*private void onHit(Node2D node)
	{
		EmitSignal(SignalName.Hit, node);
	}*/
}