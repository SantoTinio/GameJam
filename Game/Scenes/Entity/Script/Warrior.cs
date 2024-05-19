using Godot;

public partial class Warrior : CharacterBody2D
{
	[Export]
	private Stats _stats;
	
	public void SetStats(Stats stats)
	{
		_stats = stats;
	}
	public Stats GetStats()
	{
		return _stats;
	}
}
