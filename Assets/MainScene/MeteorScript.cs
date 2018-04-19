using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour{



	public float speed = 5;
	public int health = 1;


	private GameObject controller;
	private GameObject myExplosion;

	void Start (){
		
		controller = GameObject.FindGameObjectWithTag("GameController");
		myExplosion = Instantiate(controller.GetComponent<GameStateManager>().GetExplosionPrefab(),transform);
		
	}


	private void OnTriggerEnter2D(Collider2D other){

		//good idea to keep only very fast code in OnTrigger/CollisionMethods
		
		//collided with bullet fired from player
		if (health >0 && other.gameObject.CompareTag("Bullet") ){
			var firer = other.gameObject.GetComponent<BulletScript>().getFirer();
			if (firer!=null && firer.CompareTag("Player")){
				--health;
			}
		}
		
		
	}


	void killMe(){	
		Destroy(this.gameObject);
	}
	private void Update(){
		if (health == 0){



			--health;
			
			GetComponent<SpriteRenderer>().enabled = GetComponent<CircleCollider2D>().enabled = false;
			controller.GetComponent<GameStateManager>().updateScore(1);			
			myExplosion.GetComponent<ExplosionScript>().show(killMe);	
			
		}
		else if(health >0){
			transform.position-=new Vector3(0,speed*Time.deltaTime,0);
		}
		
	}
}
