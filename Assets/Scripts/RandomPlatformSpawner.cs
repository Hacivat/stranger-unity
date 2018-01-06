using UnityEngine;

public class RandomPlatformSpawner : MonoBehaviour {

	public float top;
	public float bot;
	[SerializeField]
	Vector2 spawnedPosition;
	GameObject player;
	Player playerScript;
	public GameObject spawnedPlatform;
	private float timer;
	public float platformDistance;

	void Start() {
		player = GameObject.Find ("Character");
		playerScript = player.GetComponent<Player> ();
	}
	void Update (){
		if ((MobileController.onMove) || playerScript.rightAndUpCase) {
			timer -= Time.deltaTime;

			if (timer < 0) {
				spawnedPosition = new Vector2 (9.30f, Random.Range (bot, top));
				Instantiate (spawnedPlatform, spawnedPosition, Quaternion.identity);
				timer = platformDistance;
			}
		}
	}
}
