using Godot;

public partial class Controller : Node2D
{
	[Export]
	private human1 _human;
	[Export]
	private Stats _stats;
	private PackedScene player;
	public override void _Ready()
	{
		player = GD.Load<PackedScene>("res://GameJam/Game/Scenes/Player/Player.tscn");
		_stats = _human.GetStats();
		GD.Print("Enemy Controller Ready!");
	}

	public override void _Process(double delta)
	{
	}
}
