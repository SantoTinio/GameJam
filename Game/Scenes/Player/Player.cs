using Godot;
public partial class Player : CharacterBody2D
{
	[Export]
	private PlayerStats _stats;
	[Export]
	private playerController _controller;
	[Export]
	private Marker2D _marker;
	
	public void SetPlayerStats(PlayerStats stats)
	{
		_stats = stats;
	}

	public PlayerStats GetPlayerStats()
	{
		return _stats;
	}
	public Marker2D Marker ()
	{
		_marker = GetNode<Marker2D>("/root/Main/Goon/Marker");
		return _marker;
	}
	public Vector2 BulletSpawnPoint()
	{
		return Position;
	}
    public override void _Ready()
    {
        GD.Print("Game Ready");
    }
}
