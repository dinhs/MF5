using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public static float inputX, inputY;
	public float speed;


	private Rigidbody2D playerObject;

	// Use this for initialization
	void Start () {
		playerObject = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		inputX = Input.GetAxisRaw ("Horizontal");

		if (inputX != 0 || inputY != 0) {
			playerObject.velocity = transform.up * speed * inputY + transform.right * speed * inputX;
		} else {
			playerObject.velocity = new Vector2 (0, 0);
		}
	}
}
