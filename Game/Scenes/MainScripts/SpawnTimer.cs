using System;
using Godot;

public partial class SpawnTimer : Timer
{
	[Export]
	private MainScript _main;
	[Export]
	private PathFollow2D _mobSpawner;
	public void SpawnTime()
	{
		_mobSpawner.Progress = _main.Random.Next();
		var warrior = (Warrior)_main.Warrior.Instantiate();
		_main.AddChild(warrior);
		GD.Print( _mobSpawner.Position);
		

		warrior.Position = _mobSpawner.Position;
	}
}
