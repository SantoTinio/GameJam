using Godot;
public partial class Player : CharacterBody2D
{

	[Export]
	private Marker2D _marker;

	private int _type;
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
        //Sets Stats of the player
        SetCharacter(3);
    }
	
    //Call once Player chooses a type
    public void SetType(int type)
    {
	    _type = type;
    }
	
    //Different Player Stats
    private void SetCharacter(int type)
    {
	    switch (type)
	    {
		    //Standard Slime
		    case 1:
			    PlayerStats.SetStats(5, 25, 1, 200, 1, 2, 2, type);
			    break;
		    //Fast Slime
		    case 2:
			    PlayerStats.SetStats(4, 50, 1, 250, 1, 2, 2, type);
			    break;
		    //Glass Cannon Slime
		    case 3:
			    PlayerStats.SetStats(1, 55, 1, 300, 3, 3, 3, type);
			    break;
	    }
    }
}
