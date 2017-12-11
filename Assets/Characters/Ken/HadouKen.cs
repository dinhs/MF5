using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadouKen : MonoBehaviour {

	//public GameObject hitBox;
	public GameObject hurtBox;

	public Sprite idle;
	public Sprite start1;
	public Sprite start2;
	public Sprite active1;
	public Sprite active2;

	private GameObject liveHitBox;
	private GameObject liveHurtBox;
	private int startUp;
	private int active;
	private int recovery;
	private int damage;

	private bool kickGoing;
	private int counter;

	// Use this for initialization
	void Start () {
		startUp = 12;
		active = 10;
		recovery = 15;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("e") && KenController.doingMove == false) {
			kickGoing = true;
			KenController.doingMove = true;
		}
		if (kickGoing == true) {
			if (counter == 0) {
				StartingUp ();
			}
			if(counter == (startUp/2)){
				StartingUp2();
			}
			if (counter == startUp) {
				Active ();
			}
			if (counter == (startUp + active)/2) {
				Recovery ();
			}
			if (counter == (startUp + active)) {
				Recovery2 ();
			}
			if (counter > (startUp + active + recovery)) {
				MoveDone ();
			}
			counter++;

		}

	}

	void StartingUp(){
		liveHurtBox = Instantiate (hurtBox, new Vector3 (transform.position.x + 1.0f, transform.position.y + 0.5f, 0), Quaternion.identity);
		this.GetComponent<SpriteRenderer> ().sprite = start1;
		liveHurtBox.transform.parent = gameObject.transform;
	}
	void StartingUp2(){
		//liveHurtBox = Instantiate (hurtBox, new Vector3 (), Quaternion.identity);
		this.GetComponent<SpriteRenderer> ().sprite = start2;
		//liveHurtBox.transform.parent = gameObject.transform;
	}

	void Active(){
		//liveHitBox = Instantiate (hitBox, new Vector3 (), Quaternion.identity);
		this.GetComponent<SpriteRenderer> ().sprite = active1;
		//liveHitBox.transform.parent = gameObject.transform;
	}
	void Active2(){
		//liveHitBox = Instantiate (hitBox, new Vector3 (), Quaternion.identity);
		this.GetComponent<SpriteRenderer> ().sprite = active2;
		//liveHitBox.transform.parent = gameObject.transform;
	}

	void Recovery(){
		//Destroy (liveHitBox);
		this.GetComponent<SpriteRenderer> ().sprite = start2;
	}
	void Recovery2(){
		//Destroy (liveHitBox);
		this.GetComponent<SpriteRenderer> ().sprite = start1;
	}

	void MoveDone(){
		Destroy (liveHurtBox);
		kickGoing = false;
		KenController.doingMove = false;
		counter = -1;
		this.GetComponent<SpriteRenderer> ().sprite = idle;
	}
}
