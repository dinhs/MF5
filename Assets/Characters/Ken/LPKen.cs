using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPKen : MonoBehaviour {

	public GameObject hitBox;
	public GameObject hurtBox;

	public Sprite idle;
	public Sprite punch1;
	public Sprite punch2;
	public Sprite punch3;

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
		liveHurtBox = Instantiate (hurtBox, new Vector3 (transform.position.x + 1.0f, transform.position.y + 0.9f, 0), Quaternion.identity);
		this.GetComponent<SpriteRenderer> ().sprite = punch1;
		liveHurtBox.transform.parent = gameObject.transform;
	}

	void Active(){
		liveHitBox = Instantiate (hitBox, new Vector3 (transform.position.x + 1.0f, transform.position.y + 0.9f, 0), Quaternion.identity);
		this.GetComponent<SpriteRenderer> ().sprite = punch2;
		liveHitBox.transform.parent = gameObject.transform;
	}

	void Recovery(){
		Destroy (liveHitBox);
		this.GetComponent<SpriteRenderer> ().sprite = punch3;
	}

	void MoveDone(){
		Destroy (liveHurtBox);
		lpGoing = false;
		KenController.doingMove = false;
		counter = -1;
		this.GetComponent<SpriteRenderer> ().sprite = idle;
	}
}
