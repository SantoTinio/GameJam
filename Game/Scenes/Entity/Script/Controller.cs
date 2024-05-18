using Godot;

public partial class Controller : Node2D
{
	[Export]
	private human1 _human;
	[Export]
	private Stats _stats;
	private Vector2 _direction = new Vector2();
	private Vector2 targetPosition = new Vector2();
	private CharacterBody2D _player;
	public override void _Ready()
	{
		_stats = _human.GetStats();
		_player =  GetNode<CharacterBody2D>("/root/Main/Goom");
		GD.Print("Enemy Controller Ready!");
	}

	public override void _PhysicsProcess(double delta)
	{
		targetPosition = _player.Position;
		_direction = (targetPosition - _human.Position).Normalized();

		_human.Velocity = _direction * _stats.Speed;
		
		_human.MoveAndSlide();
	}
}
