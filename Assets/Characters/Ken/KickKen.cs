using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickKen : MonoBehaviour {

	public GameObject hitBox;
	public GameObject hurtBox;

	public Sprite idle;
	public Sprite startRecov;
	public Sprite activeKick;

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
		startUp = 5;
		active = 7;
		recovery = 5;
		damage = 15;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("w") && KenController.doingMove == false) {
			kickGoing = true;
			KenController.doingMove = true;
		}
		if (kickGoing == true) {
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
		liveHurtBox = Instantiate (hurtBox, new Vector3 (transform.position.x + 1.0f, transform.position.y + 0.9f, 0), Quaternion.identity);
		this.GetComponent<SpriteRenderer> ().sprite = startRecov;
		liveHurtBox.transform.parent = gameObject.transform;
	}

	void Active(){
		liveHitBox = Instantiate (hitBox, new Vector3 (transform.position.x + 1.0f, transform.position.y + 0.9f, 0), Quaternion.identity);
		this.GetComponent<SpriteRenderer> ().sprite = activeKick;
		liveHitBox.transform.parent = gameObject.transform;
	}

	void Recovery(){
		Destroy (liveHitBox);
		this.GetComponent<SpriteRenderer> ().sprite = startRecov;
	}

	void MoveDone(){
		Destroy (liveHurtBox);
		kickGoing = false;
		KenController.doingMove = false;
		counter = -1;
		this.GetComponent<SpriteRenderer> ().sprite = idle;
	}
}
