using GameJam.Game.Scenes.Entity.Script;
using Godot;

public partial class UnarmedWarrior : CharacterBody2D
{
	[Export] private AnimationPlayer _anims;
	[Export] private MonsterController _controller;

	[Signal]
	public delegate void HitEventHandler(Node2D node);
	//private MonsterController _controller = new MonsterController();
	private CharacterBody2D _player;

	public override void _Ready()
	{
		_controller.SetStats(3,50.00f,1);
		_player =  GetNode<CharacterBody2D>("/root/Main/Goom");
	}

	public override void _PhysicsProcess(double delta)
	{
		_controller.Control(_player, this);
		_anims._UpdateAnimation(_controller.GetMoving(), _player, this);
	}

	private void OnHit(Node2D node)
	{
		EmitSignal(SignalName.Hit, node);
	}

	public void Damaged()
	{
		_controller.SetHealth( _controller.GetHealth() - _controller.GetDamage());
		
		GD.Print(_controller.GetHealth());
		
		if (_controller.GetHealth() < 1)
			QueueFree();
		
		_controller.SetHealth(_controller.GetHealth()-PlayerStats.BulletDamage);
	}
}
