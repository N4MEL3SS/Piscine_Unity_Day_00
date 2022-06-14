using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour {

	// Debug.Log, Random.Range, Input.GetKey, Transform.Translate

	// Use this for initialization
	public Player playerLeft, playerRight;
	private float speed;

	private Vector3 direction;

	void ResetBallDirection () {
		speed = 3;
		transform.position = new Vector3 (0f, 0f, 0f);
		int x = Random.Range (-2, 2);
		if (x == 0)
			x = 1;
		int y = Random.Range (-2, 2);
		if (y == 0)
			y = 1;
		direction = new Vector3 (x, y, 0f);
	}
	void Start () {
		ResetBallDirection ();
	}

	void CheckColidedWall () {
		if (transform.position.y >= 4.9 || transform.position.y <= -4.9) {
			direction = new Vector3 (direction.x, -direction.y, 0f);
		}
	}

	void CheckOutWall () {
		if (transform.position.x >= 9) {
			playerLeft.SetScore (1);
			Debug.Log ("Player 1 : " + playerLeft.GetScore () + " | Player 2 : " + playerRight.GetScore ());
			ResetBallDirection ();
		} else if (transform.position.x <= -9) {
			playerRight.SetScore (1);
			Debug.Log ("Player 1 : " + playerLeft.GetScore () + " | Player 2 : " + playerRight.GetScore ());
			ResetBallDirection ();
		}
	}

	bool CheckRightPlayerCol () {
		Debug.Log("R_BallX:" + transform.position.x);
		if (transform.position.x >= 4.0f && transform.position.x <= 4.5f)
		{
			var playerLeftTop = playerLeft.transform.position.y + 1.8f;
			var playerLeftBottom = playerLeft.transform.position.y - 1.8f;
			if (playerLeftTop >= transform.position.y &&
			    playerLeftBottom <= transform.position.y)
				if (direction.x > 0)
					return (true);
		}
		return (false);
	}

	bool CheckLeftPlayerCol () {
		Debug.Log("L_BallX:" + transform.position.x);
		if (transform.position.x >= -4.5f && transform.position.x <= -4.0f)
		{
			var playerRightTop = playerRight.transform.position.y + 1.8f;
			var playerRightBottom = playerRight.transform.position.y - 1.8f;
			if (playerRightTop >= transform.position.y &&
			     playerRightBottom <= transform.position.y)
				if (direction.x < 0)
					return (true);
		}
		return (false);
	}
	void CheckColidedPlayer () {
		if (CheckRightPlayerCol () || CheckLeftPlayerCol ()) {
			speed += 0.5f;
			direction = new Vector3 (-direction.x, direction.y, 0f);
		}
	}
	// Update is called once per frame
	void Update () {
		transform.Translate (direction * speed * Time.deltaTime);
		CheckColidedPlayer ();
		CheckColidedWall ();
		CheckOutWall ();
	}
}
