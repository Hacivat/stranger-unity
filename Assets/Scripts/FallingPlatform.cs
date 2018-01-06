using UnityEngine;

public class FallingPlatform : MonoBehaviour {

	public PlatformMover platformMover;
	GameObject player;
	Player playerScript;
	void Start(){
		player = GameObject.Find ("Character");
		playerScript = player.GetComponent<Player> ();
	}

	void Update () {
		if ((MobileController.onMove) || playerScript.rightAndUpCase) {
			this.transform.Translate (-platformMover.speed * Time.deltaTime, 0f, 0f);
		}
	}
}