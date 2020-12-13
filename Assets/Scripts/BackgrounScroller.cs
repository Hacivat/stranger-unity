using UnityEngine;

public class BackgrounScroller : MonoBehaviour {

	private MeshRenderer _meshRenderer;
	private Player _player;
	public float scrollSpeed;
	public float scrollTimer;

	void Start () {
		scrollSpeed = 0.1f;
		_player = FindObjectOfType<Player>();
		_meshRenderer = GetComponent<MeshRenderer>();
	}

	void Update () {
		if ((MobileController.onMove) || _player.rightAndUpCase) {
			scrollTimer += Time.deltaTime * scrollSpeed;
			_meshRenderer.material.mainTextureOffset = new Vector2 (scrollTimer, 0f);
		}
	}
}
