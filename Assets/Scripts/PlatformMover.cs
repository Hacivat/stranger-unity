using UnityEngine;

public class PlatformMover : MonoBehaviour {
	GameObject player;
	Player playerScript;
	SpriteRenderer spriteRenderer;
	public Vector2 mover;
	public GameObject fallingGameObject;
	public float speed;
	public float fallingTime;
	public float upDownSpeed;
	public float transparencySpeed;
	float aValue = 1;
	bool down = true;
	bool up = false;
	bool transDown = true;
	bool upAndDown = false;
	bool coll = false;
	[SerializeField]
	int _upAndDownRate = 0;
	int upAndDownRate = 0;
	[SerializeField]
	int _visibilityRate = 0;
	int visibilityRate = 0;

	void Start () {
		player = GameObject.Find ("Character");
		try {
			playerScript = player.GetComponent<Player> ();
		} catch (System.Exception ex) {
			if (ex != null) {
				Time.timeScale = 0f;
			}
		}
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		upAndDownRate = Random.Range (1, _upAndDownRate);
		visibilityRate = Random.Range (1, _visibilityRate);
	}

	void Update () {
		Move ();
		Visibility (visibilityRate);
		UpAndDown (upAndDownRate);
		if (coll && !upAndDown && !this.gameObject.CompareTag("MainPlatform")) {
			Falling (fallingTime);
		}
	}


	void OnTriggerEnter2D (Collider2D other) {
		ScoreCalc (other);
	}
		
	void OnCollisionEnter2D () {
		transDown = false;
		coll = true;
		this.spriteRenderer.color = new Color (255f, 255f, 255f, 255f);
	}
		
	void Move () {
		try {
			if ((MobileController.onMove) || playerScript.rightAndUpCase) {
				this.transform.Translate (-speed * Time.deltaTime, 0f, 0f);
			}
		} catch (System.Exception ex) {
			if (ex != null) {
				Time.timeScale = 0f;
			}
		}
	}

	void UpAndDown (int upAndDownRate) {
		if (this.gameObject.CompareTag("Platform")) {
			if (upAndDownRate == 1) {
				upAndDown = true;
				if (this.transform.position.y > -5f && down && !up) {		
					this.transform.Translate (0f, -upDownSpeed * Time.deltaTime, 0f);
				} else {
					down = false;
					up = true;
				}
				if (this.transform.position.y < 1.35f && up && !down) {	

					this.transform.Translate (0f, upDownSpeed * Time.deltaTime, 0f);
				} else {
					down = true;
					up = false;
				}
			}
		}
	}

	void Visibility (int visibilityRate){
		if (visibilityRate == 1) {
			if (!upAndDown && this.gameObject.CompareTag("Platform") && transDown) {
				if (!(this.spriteRenderer.color.a <= 0.1f)) {
					aValue -= transparencySpeed * Time.deltaTime;
					this.spriteRenderer.color = new Color (255f, 255f, 255f, aValue);
				}
				else {
					this.spriteRenderer.color = new Color (255f, 255f, 255f, 0f);
					transDown = false;
				}
			}
		}
	}
		
	bool isWritable = true;
	float _waitForSec = 0;
	void Falling (float waitForSec) {
		if (isWritable) {
			_waitForSec = waitForSec;
			isWritable = false;
		}
		_waitForSec -= Time.deltaTime;
		if (_waitForSec < 0f) {
			Instantiate (fallingGameObject, this.gameObject.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
		
	bool setScoreAvailable = true;
	void ScoreCalc(Collider2D other){
		if (other.name == "Character"&& setScoreAvailable && !gameObject.CompareTag("MainPlatform")) {
			playerScript.score++;
			setScoreAvailable = false;
			playerScript.SetScore ();
		}
	}
}
