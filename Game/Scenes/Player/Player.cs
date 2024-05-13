using Godot;
using System;
using System.Data;

public partial class Player : CharacterBody2D
{
	[Export]
	private PlayerStats _stats;
	[Export]
	private playerController _controller;
	
	public void SetPlayerStats(PlayerStats stats)
	{
		_stats = stats;
	}

	public PlayerStats GetPlayerStats()
	{
		return _stats;
	}
    public override void _Ready()
    {
        GD.Print("Game Ready");
    }
}
