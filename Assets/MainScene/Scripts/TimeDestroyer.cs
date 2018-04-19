using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyer : MonoBehaviour{

	public float timeToLive = 5;
	
	// Use this for initialization
	void Start () {
		Invoke("kill",timeToLive);	
	}

	void kill(){
		Destroy(this.gameObject);
	}
	
}
