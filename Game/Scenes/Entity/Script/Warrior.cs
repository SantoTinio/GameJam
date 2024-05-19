using Godot;

public partial class Warrior : CharacterBody2D
{
	[Export]
	private Stats _stats;
	public Vector2 SpawnPosition;
	
	public void SetStats(Stats stats)
	{
		_stats = stats;
	}
	public Stats GetStats()
	{
		return _stats;
	}
	public override void _Ready()
	{
		Position = SpawnPosition;
	}
}
