using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPKen : MonoBehaviour {

	public GameObject hitBox;
	public GameObject hurtBox;

	private GameObject liveHitBox;
	private GameObject liveHurtBox;
	private int startUp;
	private int active;
	private int recovery;
	private int damage;

	private bool lpGoing;
	private int counter;

	// Use this for initialization
	void Start () {
		startUp = 3;
		active = 7;
		recovery = 4;
		damage = 5;
		lpGoing = false;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("q") && KenController.doingMove == false) {
			lpGoing = true;
			KenController.doingMove = true;
		}
		if (lpGoing == true) {
			if (counter == 0) {
				StartingUp ();
			}
			if(counter == startUp){
				Active();
			}
			if (counter == (startUp + active)) {
				Recovery ();
			}
			if (counter > (startUp + active + recovery)) {
				MoveDone ();
			}
			counter++;
				
		}
	}

	void StartingUp(){
		liveHurtBox = Instantiate (hurtBox, new Vector3 (transform.position.x + 1.0f, transform.position.y + 1.2f, 0), Quaternion.identity);
		Debug.Log ("StartUp");
	}

	void Active(){
		liveHitBox = Instantiate (hitBox, new Vector3 (transform.position.x + 1.0f, transform.position.y + 1.2f, 0), Quaternion.identity);
		Debug.Log ("Active");
	}

	void Recovery(){
		Destroy (liveHitBox);
		Debug.Log ("Recovery");
	}

	void MoveDone(){
		Destroy (liveHurtBox);
		lpGoing = false;
		KenController.doingMove = false;
		counter = -1;
		Debug.Log ("Move Done");
	}
}
