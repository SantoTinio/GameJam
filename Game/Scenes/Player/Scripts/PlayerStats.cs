using Godot;
public partial class PlayerStats : Node
{
	public static float Health;
	public static float Speed; 
	public static readonly float SprintFactor = 1.5f;
	public static readonly float Accel = 0.35f;
	public static readonly float Decel = 0.5f;
	public static float FireRate; 
	public static float BulletSpeed;
	public static float BulletDamage;
	public static float OrbitSpeed;
	public static float DashCount; 
	public static float MaxDashCount; 
	private static int _playerType;

	public static void SetStats(float health, float speed, float fireRate, float bulletSpeed, float orbit, float damage,
		 float dash, float maxDash, int type)
	{
		Health = health;
		Speed = speed;
		FireRate = fireRate;
		BulletSpeed = bulletSpeed;
		BulletDamage = damage;
		OrbitSpeed = orbit;
		DashCount = dash;
		MaxDashCount = maxDash;
		_playerType = type;
	}

	/*public static PlayerStats GetStats()
	{
		return PlayerStats;
	}*/
	public override void _Ready()
	{
		GD.Print("Character Chosen: " + _playerType + " Ready");
	}
}