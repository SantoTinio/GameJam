using Godot;
using System;

public partial class MainScript : Node2D
{
	[Export]
	private Timer _timer;
	[Signal]
	public delegate void TimeoutEventHandler();
	public PackedScene Warrior;
	public readonly Random Random = new();

    public override void _Ready()
    {
        Warrior = GD.Load<PackedScene>("res://Game/Scenes/Entity/Warrior.tscn");
	}
	public float RandRange(float min, float max)
	{
		return (float)Random.NextDouble() * (max - min) + min;
	}

	private void SpawnTime()
	{
		EmitSignal(SignalName.Timeout);
	}
}
