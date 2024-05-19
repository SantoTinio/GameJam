using Godot;

public partial class SpawnTimer : Timer
{
	[Export]
	private MainScript _Main;
	[Export]
	private PathFollow2D _MobSpawner;
	public void SpawnTime()
	{
		_MobSpawner.VOffset = _Main._Random.Next();
		_MobSpawner.HOffset = _Main._Random.Next();
		var warrior = (Warrior)_Main._Warrior.Instantiate();
		_Main.AddChild(warrior);
		
		warrior.SpawnPosition = _MobSpawner.Position;
	}
}
