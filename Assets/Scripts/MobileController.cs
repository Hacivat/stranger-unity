using UnityEngine;

public class MobileController : MonoBehaviour {

	public static bool onJump = false;
	public static bool onMove = false;

	public GameObject jump;
	public GameObject move;

	void Update () {
		if (Time.timeScale == 1) {
			jump.SetActive (true);
			move.SetActive (true);
		} else {
			onJump = false;
			onMove = false;
			jump.SetActive (false);
			move.SetActive (false);
		}
	}

	public void OnJumpButtonDown () {
		onJump = true;
	} 
	public void OnJumpButtonUp () {
		onJump = false;
	}
	public void OnMoveButtonDown () {
		onMove = true;
	} 
	public void OnMoveButtonUp () {
		onMove = false;
	}
}