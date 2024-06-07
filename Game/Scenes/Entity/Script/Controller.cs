using System;
using Godot;

public partial class Controller : Node2D
{
	[Export]
	private UnarmedWarrior _unarmedWarrior;
	[Export]
	private Stats _stats;
	[Export]
	private Hitbox _hitbox;

	[Export] private AnimationPlayer _animationPlayer;
	[Signal] 
	public delegate void HitEventHandler(Node2D node);
	private Vector2 _direction;
	private Vector2 _targetPosition;
	private CharacterBody2D _player;
	private Boolean _isMoving;
	public override void _Ready()
	{
		//_stats = _warrior.GetStats();
		_player =  GetNode<CharacterBody2D>("/root/Main/Goom");
	}

	public override void _PhysicsProcess(double delta)
	{
		//Vector math to move the character
		_targetPosition = _player.Position;
		_direction = (_targetPosition - _unarmedWarrior.Position).Normalized();
		_unarmedWarrior.Velocity = _direction * _stats.Speed;

		_unarmedWarrior.MoveAndSlide();
		//Update Animation stuff
		_animationPlayer._UpdateAnimation(_unarmedWarrior.Velocity != null, _player, _unarmedWarrior);
		
		// To be edited
		if (_stats.Health == 0)
		{
			_unarmedWarrior.QueueFree();
		}

	}

	public void onHit(Node2D node)
	{
		if (IsInGroup("Mob"))
			GD.Print("IN MOB");
		EmitSignal(SignalName.Hit, node);
	}
}
