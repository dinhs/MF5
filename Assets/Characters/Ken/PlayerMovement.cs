using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public static float inputX;
	public static bool inputY;
	public float speed;


	private Rigidbody2D playerObject;

	// Use this for initialization
	void Start () {
		playerObject = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		inputX = Input.GetAxisRaw ("Horizontal");
		inputY = Input.GetKeyDown ("up");

		if ((inputX != 0 && !inputY) && KenController.doingMove == false) {
			playerObject.velocity = transform.right * speed * inputX;

			//Vector3 dir = Quaternion.AngleAxis(45, Vector3.forward) * Vector3.right;
			//rigidbody2D.AddForce(dir*force);
			//playerObject.AddForce (dir * 25000);
			//Debug.Log ("Adding Force");
		} else {
			playerObject.velocity = new Vector2 (0, 0);
		}

		Vector3 pos = transform.position;

		pos.x = Mathf.Clamp (pos.x, -8.0f, 8f);
		pos.y = Mathf.Clamp (pos.y, -1.4f, 5f);
		transform.position = pos;
	}
}
