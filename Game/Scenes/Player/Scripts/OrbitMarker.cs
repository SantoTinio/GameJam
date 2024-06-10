using Godot;
using System;

public partial class OrbitMarker : Marker2D
{
	[Export] private Player _player;
	private float _direction;
	private float _motion;

	public override void _Process(double delta)
	{
		//Angles in Radians
		if (_motion > 360) _motion = 0;
		
		_motion += (float)delta * PlayerStats.OrbitSpeed;
		_direction = _motion * MathF.PI / 180;
		Position = new Vector2(50 * MathF.Cos(_direction), 50 * MathF.Sin(_direction) + 4);
	}
}
