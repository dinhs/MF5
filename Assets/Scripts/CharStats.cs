using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour {

	public int health;
	//private int meter;

	private bool dead;

	// Use this for initialization
	void Start () {
		dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		isDead ();
	}


	public void IsHit(int damageDone){
		health = health - damageDone;
	}

	void isDead(){
		if (health <= 0) {
			dead = true;
		}
	}
}
