using UnityEngine;

public class BackgrounScroller : MonoBehaviour {

	MeshRenderer rend;
	GameObject player;
	Player playerScript;
	public float scrollSpeed;
	public float scrollTimer;

	void Start () {
		player = GameObject.Find ("Character");
		playerScript = player.GetComponent<Player> ();
		scrollSpeed = 0.1f;
		rend = GetComponent<MeshRenderer>();
	}

	void Update () {
		if ((MobileController.onMove) || playerScript.rightAndUpCase) {
			scrollTimer += Time.deltaTime * scrollSpeed;
			rend.material.mainTextureOffset = new Vector2 (scrollTimer, 0f);
		}
	}
}
