using System;
using Godot;

public partial class SpawnTimer : Timer
{
	[Export]
	private MainScript _Main;
	[Export]
	private PathFollow2D _MobSpawner;
	public void SpawnTime()
	{
		_MobSpawner.Progress = _Main._Random.Next();
		var warrior = (Warrior)_Main._Warrior.Instantiate();
		_Main.AddChild(warrior);
		GD.Print( _MobSpawner.Position);
		

		warrior.Position = _MobSpawner.Position;
	}
}
