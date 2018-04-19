using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	
	


	private void OnTriggerEnter2D(Collider2D other){
		var gObj = other.gameObject;
		
		if (gObj.CompareTag("Bullet")){
//			GetComponent<Health>().initHealth-=gObj.GetComponent<Damage>().damage;
	
		}
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
