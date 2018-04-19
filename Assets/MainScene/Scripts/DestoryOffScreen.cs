using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOffScreen : MonoBehaviour{



	public Player player;


	public CameraUtils cam;

	public float offDelay = 0.0f;

	
	private void Awake(){
		myCollider = GetComponent<BoxCollider2D>();
		
	}

	
	// Update is called once per frame
	void Update () {
		myCollider.size = new Vector2(cam.getCameraWidth(),myCollider.size.y);
		
		
		
	}


	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Meteor")){			
			Destroy(other.gameObject);
		}
	}


	private BoxCollider2D myCollider;
}
