using Godot;

public partial class DebugNode : Node2D
{
	[Export] private Marker _marker;
	[Export] private OrbitMarker _orbit;

	public override void _Draw()
	{
		DrawCircle(_marker.Position, 1,Colors.Crimson);
		DrawCircle(_orbit.Position, 4, Colors.Black);
	}
	public override void _Process(double delta)
	{
		QueueRedraw();
	}
}
