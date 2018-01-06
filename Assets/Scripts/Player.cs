using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Text scoreText;
	Animator animator;
	Rigidbody2D myRigidbody;
	public float jump;
	public bool isJumped = false;
	public bool rightAndUpCase = false;
	bool ground = false;
	public int score = 0;

	void Start() {
		if (Time.timeScale == 0) {
			Time.timeScale = 1f;
		}
		animator = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
		scoreText.text = 0.ToString();
	}

	void FixedUpdate () {
		bool move = (MobileController.onMove);
		if (move && isJumped) {
			rightAndUpCase = true;
		}
		else if (ground) {
			rightAndUpCase = false;
		}


		animator.SetBool ("touch", move);
		if (MobileController.onJump) {
			isJumped = true;
			if (ground) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jump);	
			}
		}
		if (myRigidbody.velocity.y < -0.1 && isJumped) {
			animator.SetBool ("up", false);
		} else if (isJumped){
			animator.SetBool ("up", true);
		}
	}

	public void SetScore() {
		scoreText.text = score.ToString();
	}
		
	void OnTriggerEnter2D() {
		ground = true;
		isJumped = false;
		animator.SetBool ("ground", ground);
	}

	void OnTriggerExit2D() {
		ground = false;
		animator.SetBool ("ground", ground);
	}
}
