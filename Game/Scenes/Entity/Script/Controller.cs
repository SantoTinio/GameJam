using System;
using Godot;

public partial class Controller : Node2D
{
	[Export]
	private Warrior _warrior;
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
		_stats = _warrior.GetStats();
		_player =  GetNode<CharacterBody2D>("/root/Main/Goom");
	}

	public override void _PhysicsProcess(double delta)
	{
		//Vector math to move the character
		_targetPosition = _player.Position;
		_direction = (_targetPosition - _warrior.Position).Normalized();
		_warrior.Velocity = _direction * _stats.Speed;

		_warrior.MoveAndSlide();
		//Update Animation stuff
		_animationPlayer._UpdateAnimation(_warrior.Velocity != null, _player, _warrior);
		
		// To be edited
		if (_stats.Health == 0)
		{
			_warrior.QueueFree();
		}

	}

	public void onHit(Node2D node)
	{
		EmitSignal(SignalName.Hit, node);
	}
}
