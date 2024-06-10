using System;
using Godot;

public partial class Marker : Marker2D
{
    [Export] private Player _player;
    private float _direction;
    public override void _Process(double delta)
    {
        // in Radians
        _direction = _player.Position.AngleToPoint(GetGlobalMousePosition());
        Position = new Vector2(10 * MathF.Cos(_direction), 10 * MathF.Sin(_direction) + 4);
    }
}
