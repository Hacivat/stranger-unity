using UnityEngine;

public class Destroyer : MonoBehaviour {
	
	public GameObject gameOver;
	GameManager gameManager;
	Player playerScript;

	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		playerScript = GameObject.Find ("Character").GetComponent<Player> ();
	}

	void OnTriggerExit2D (Collider2D other) {
		OnPlayerExitBoundry (other);
	}

	void OnPlayerExitBoundry(Collider2D other) {
		if (other.name == "Character") {
			Time.timeScale = 0f;
			gameManager.ScoreCounter (playerScript.score);
			gameOver.SetActive (true);
		}
		Destroy (other.gameObject);
	}
}
	