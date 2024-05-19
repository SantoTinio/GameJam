using Godot;

public partial class Controller : Node2D
{
	[Export]
	private Warrior _warrior;
	[Export]
	private Stats _stats;
	[Export]
	private Hitbox _hitbox;
	[Signal] 
	public delegate void HitEventHandler(Node2D node);
	private Vector2 _direction = new Vector2();
	private Vector2 targetPosition = new Vector2();
	private CharacterBody2D _player;
	//private Area2D _playerBullet;
	public override void _Ready()
	{
		_stats = _warrior.GetStats();
		_player =  GetNode<CharacterBody2D>("/root/Main/Goom");
		//_playerBullet = GetNode<Area2D>("res://Game/Scenes/Bullet/bullet.tscn");
		GD.Print("Enemy Controller Ready!");
	}

	public override void _PhysicsProcess(double delta)
	{
		targetPosition = _player.Position;
		_direction = (targetPosition - _warrior.Position).Normalized();

		_warrior.Velocity = _direction * _stats.Speed;
		
		_warrior.MoveAndSlide();

		if (_stats.Health == 0)
		{
			_warrior.QueueFree();
		}

	}

	public void onHit(Node2D node)
	{
		EmitSignal(SignalName.Hit, node);
	}
}
