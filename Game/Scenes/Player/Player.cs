using Godot;
public partial class Player : CharacterBody2D
{

	[Export]
	private Marker2D _marker;
	private Marker2D Marker ()
	{
		return _marker;
	}

	private Vector2 BulletSpawnPoint()
	{
		return Position;
	}
    public override void _Ready()
    {
        GD.Print("Game Ready");
    }
}
