using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour{




	public float shaker = 2;
	// Use this for initialization
	void Start (){


		GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-50,50);

	}
	
}
