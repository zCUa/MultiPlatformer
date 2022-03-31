using UnityEngine;
using Cinemachine;

public class PlayerLife : MonoBehaviour
{
	public Transform respawnPoint;
	public GameObject playerPrefab;
	public CinemachineVirtualCameraBase cam;
	public static PlayerLife instance;


	// Start is used for linking game objects. Awake is used to initalize game objects.
    private void Awake()
    {
        instance = this;
    }

	private void OnCollisionEnter2D(Collision2D collision) 
	{
		// Player death on enemy
		if (collision.gameObject.tag == ("Enemy")) {
			PlayerDie();
		}

		// Player is the Female character. Collision from Male will win level.
		if (collision.gameObject.tag == ("Player")) {
			LevelWon();
		}
	}

	// If both players collide Level is won
	private void LevelWon()
	{
		print("Level completd!!");
	}

	private void PlayerDie()
	{
		Respawn();
		Destroy(this.gameObject);
		
	}

	public void Respawn()
    {
        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
		cam.Follow = player.transform;
    }
}
