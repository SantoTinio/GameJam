using Godot;

public partial class SignalBus : Node2D
{
	[Signal]
	public delegate void HitEventHandler(Area2D node);

	private void OnHit(Area2D node)
	{
		EmitSignal(SignalName.Hit, node);
	}
}
