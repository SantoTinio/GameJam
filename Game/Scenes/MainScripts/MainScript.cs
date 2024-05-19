using Godot;
using System;

public partial class MainScript : Node2D
{
	[Export]
	private Timer _Timer;
	[Signal]
	public delegate void TimeoutEventHandler();
	public PackedScene _Warrior;
	public Random _Random = new Random();

    public override void _Ready()
    {
        _Warrior = GD.Load<PackedScene>("res://Game/Scenes/Entity/Warrior.tscn");
	}
	public float RandRange(float min, float max)
	{
		return (float)_Random.NextDouble() * (max - min) + min;
	}

	public void SpawnTime()
	{
		EmitSignal(SignalName.Timeout);
	}
}
