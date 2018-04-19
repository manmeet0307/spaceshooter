using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{



	
	
	public float moveSpeed = 10;

	
	
	
	
	public GameStateManager manager;


	public Text healthText;
	public CameraUtils camUtils;
	public GameObject bullet;


	
	private void Awake(){
		initHealth = health;
		
	}


	private Coroutine shooter;
	private void Start (){
		int currHealth = (int)((health * 1.0f / initHealth )* 100);
		
		healthText.text = "Health : "+ currHealth+"%";
	
		shooter = StartCoroutine(shootBullet());
		myExplosion = Instantiate(manager.GetExplosionPrefab(), transform);
	}


	public void decreaseHealth(){
		health--;
	}


	private bool isHealthDecreased;

	// Update is called once per frame
	private void Update (){

		//check if no health left
		if (health == 0){
			

			//make sure this code runs only once
			--health;
			//stop bullets		
			StopCoroutine(shooter);

			//disable sprire renderer
			GetComponent<SpriteRenderer>().enabled=false;
			//disable collider
			GetComponent<BoxCollider2D>().enabled=false;
		
			//show death animation			
			myExplosion.GetComponent<ExplosionScript>().show(cleanupPlayer);

		}
		else if(health > 0){


			//check if health decreased
			if (isHealthDecreased){
				onHealthDecreased();

			}


			movePlayer();
		}

		
		isHealthDecreased = false;


	}

	private void cleanupPlayer(){
		
		manager.GameOver = true;
		Destroy(this.gameObject);
		
	}


	private void movePlayer(){
		
		
		Vector3 pos = transform.position;
		
		//player movement
		if (Input.GetKey(KeyCode.RightArrow)){

			pos.x += moveSpeed*Time.deltaTime;	

		}		
		if (Input.GetKey(KeyCode.LeftArrow)){
			
			pos.x -= moveSpeed*Time.deltaTime;

		}



		float xStuff = GetComponent<SpriteRenderer>().sprite.bounds.extents.x;		
		if (pos.x + xStuff > camUtils.getCamRightBound()){
			pos.x = camUtils.transform.position.x + camUtils.getCameraWidth()/2 - xStuff;
			
		} 

		if( pos.x-xStuff < camUtils.getCamLeftBound() ){
			
			pos.x = camUtils.transform.position.x - camUtils.getCameraWidth()/2 + xStuff;

		}
		transform.position = pos;


	}

	private void onHealthDecreased(){
	
		//update the gui		
		int currHealth = (int)(health * 1.0f / initHealth * 100);
		
		healthText.text = "Health : "+currHealth +"%";

	}


	IEnumerator shootBullet(){

		while (true){
			BulletScript.CreateBullet(bullet,gameObject,new Vector3(0,0.25f,0));
			yield return new WaitForSeconds(0.1f);
		}

	}
	
	private void OnTriggerEnter2D(Collider2D other){

		if (health > 0 && other.gameObject.CompareTag("Meteor")){
			decreaseHealth();
			//blinker should work only if health was more than zero
			if(health > 0)
				StartCoroutine(Blink());
			isHealthDecreased = true;
			
			
		}
	}

	private IEnumerator Blink(){

		
		var sp = GetComponent<SpriteRenderer>();
		var origColor = sp.color;

		//flash i times
		for (int i = 0; i < 10; i++){
			sp.color = Color.red;
			yield return new WaitForSeconds(0.1f);			
			sp.color = origColor;
			yield return new WaitForSeconds(0.1f);
	
		}
		
		
	
	}


	private GameObject myExplosion;
	//serialize field gives the same effect as making variable public(in inspector) but 
	//provides finer access control
	[SerializeField]
	private int health = 3;
	private int initHealth;

	

}
