using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMoveScript : MonoBehaviour {

	/*public GameObject hitBox;
	public GameObject hurtBox;

	public Sprite idle;

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
		liveHurtBox = Instantiate (hurtBox, new Vector3 (), Quaternion.identity);
		this.GetComponent<SpriteRenderer> ().sprite = ;
		liveHurtBox.transform.parent = gameObject.transform;
	}

	void Active(){
		liveHitBox = Instantiate (hitBox, new Vector3 (), Quaternion.identity);
		this.GetComponent<SpriteRenderer> ().sprite = ;
		liveHitBox.transform.parent = gameObject.transform;
	}

	void Recovery(){
		Destroy (liveHitBox);
		this.GetComponent<SpriteRenderer> ().sprite = ;
	}

	void MoveDone(){
		Destroy (liveHurtBox);
		kickGoing = false;
		KenController.doingMove = false;
		counter = -1;
		this.GetComponent<SpriteRenderer> ().sprite = idle;
	}*/
}
